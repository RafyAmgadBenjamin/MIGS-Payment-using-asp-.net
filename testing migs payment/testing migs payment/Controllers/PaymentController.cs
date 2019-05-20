using MIGS.Models;
using MIGS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testing_migs_payment.Models;

namespace testing_migs_payment.Controllers
{
    public class PaymentController : Controller
    {
        private readonly string _txnServiceId = "4270-01-04-2";
        private readonly string _txnServiceDescription = "Employer Subscription";

        // GET: Payment
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult HandleMigsRequest()
        {
            TransactionDetails txn = new TransactionDetails
            {
                TxnIP = Request.UserHostAddress,
                TxnCurrencyCode = "100",
                TxnAmount = 100,
                EmployerId = 1,
                TxnServiceId = _txnServiceId,
                TxnServiceDescription = _txnServiceDescription,
                TxnEmail = "rbenjamin@arkdev.net",
            };
            var txnRef = "123_dasf_ff";
            var request = new VPCRequest()
            {
                Amount = (txn.TxnAmount * 100).ToString(),
                Currency = "USD",
                CurrencyCode = "100",
                MerchantAccessCode = "F05FC469",
                MerchantId = "TEST512345USD",
                MerchantTxnRef = txnRef,
                OrderInfo = "rbenjamin@arkdev.net",
                ReturnUrl = $"{Request.Url.Scheme}://{Request.Url.Host}:{Request.Url.Port}{"/Payment/HandleMigsResponse"}",
            };

            var url = VPC3PartyService.Build3PartyRequestUrl(request, "E49780B4C8FDB4E38222ADE7F3B97CCA");

            return Redirect(url);
        }


        public ActionResult HandleMigsResponse()
        {
            // Process 3Party response.
            var response = VPC3PartyService.Process3PartyResponse(Request.QueryString, "E49780B4C8FDB4E38222ADE7F3B97CCA");
            // Build payment model.
            var transaction = new RecruitmentSubscriptionPaymentTransaction()
            {
                AcqResponseCode = response.AcqResponseCode,
                Amount = response.Amount,
                AuthorizeId = response.AuthorizeId,
                BatchNumber = response.BatchNumber,
                Card = response.Card,
                Currency = response.Currency,
                CurrencyCode = response.CurrencyCode,
                MerchantId = response.MerchantId,
                MerchantTxnRef = response.MerchantTxnRef,
                Message = response.Message,
                PaymentTypeId = 1,
                ReceiptNumber = response.ReceiptNumber,
                ServiceId = _txnServiceId,
                TxnDate = DateTime.Now,
                TxnNumber = response.TxnNumber,
                TxnQuery = response.TxnQuery,
                TxnResponseCode = response.TxnResponseCode,
                TxnServiceDescription = _txnServiceDescription,
                UserEmail = response.OrderInfo,
                UserIP = Request.UserHostAddress
            };

            return View(transaction);


        }
    }
}