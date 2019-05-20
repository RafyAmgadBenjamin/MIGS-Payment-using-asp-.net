using MIGS.Comparrers;
using MIGS.Extensions;
using MIGS.Helpers;
using MIGS.Models;
using System;
using System.Collections.Specialized;

namespace MIGS.Services
{
    public static class VPC3PartyService
    {
        public static string Build3PartyRequestUrl(VPCRequest request, string secureHashCode)
        {
            if (request == null || secureHashCode == null) return null;
            var sortedDictionary = request.ToVPCSortedDictionary();
            var queryString = sortedDictionary.ToUrlQueryString();
            var secureHash = HashHelper.CreateHMACSHA256Signature(secureHashCode, queryString);

            return $"{request.SUBMIT_PAYMENT_URL}?{queryString}&vpc_SecureHash={secureHash}&vpc_SecureHashType=SHA256";
        }

        public static VPCResponse Process3PartyResponse(NameValueCollection response, string secureHashCode)
        {
            var sortedDictionary = response.ToSortedDictionary(new VPCStringComparer());
            var queryString = sortedDictionary.ToUrlQueryString();
            var secureHash = HashHelper.CreateHMACSHA256Signature(secureHashCode, queryString);

            // Validate "SecureHashCode".
            if (string.IsNullOrEmpty(response["vpc_SecureHash"]))
            {
                throw new Exception("No Secure Hash included in response");
            }
            if (!secureHash.Equals(response["vpc_SecureHash"]))
            {
                throw new Exception("Secure Hash does not match");
            }

            // Build response as model.
            var vpcReponse = new VPCResponse()
            {
                Amount = (double.Parse(response["vpc_Amount"]) / 100),
                BatchNumber = response["vpc_BatchNo"],
                Command = response["vpc_Command"],
                Currency = response["vpc_Currency"],
                CurrencyCode = response["user_CurrencyCode"],
                Local = response["vpc_Local"],
                Card = response["vpc_Card"],
                MerchantId = response["vpc_Merchant"],
                AuthorizeId = response["vpc_AuthorizeId"],
                MerchantTxnRef = response["vpc_MerchTxnRef"],
                Message = response["vpc_Message"],
                OrderInfo = response["vpc_OrderInfo"],
                ReceiptNumber = response["vpc_ReceiptNo"],
                AcqResponseCode = response["vpc_AcqResponseCode"],
                TxnNumber = response["vpc_TransactionNo"],
                TxnQuery = response.ToUrlQueryString(),
                TxnResponseCode = response["vpc_TxnResponseCode"],
            };
            return vpcReponse;
        }
    }
}
