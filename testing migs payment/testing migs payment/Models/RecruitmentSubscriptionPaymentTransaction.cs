using MIGS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testing_migs_payment.Models
{
    public class RecruitmentSubscriptionPaymentTransaction : VPCResponse
    {
        private int? _paymentTypeId;
        private string _offlineMethod;
        public string TxnServiceDescription { get; set; }
        public string ServiceId { get; set; }
        public int EmployerId { get; set; }
        public int PaymentTypeId { get { return _paymentTypeId.HasValue ? _paymentTypeId.Value : 1; } set { _paymentTypeId = value; } }
        public string OfflineMethod { get { return _offlineMethod?.FirstCharToUpper(); } set { _offlineMethod = value; } }
        public int SubscriptionId { get; set; }
        public int UserId { get; set; }
        public string UserEmail { get; set; }
        public string UserIP { get; set; }
        public string TxnId { get; set; }
        public bool IsPaid { get; set; }
        public DateTime TxnDate { get; set; }
    }

    public static class StringExtentsion
    {
        public static string FirstCharToUpper(this string str)
        {
            // Check for empty string.  
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }
            // Return char and concat substring.  
            return char.ToUpper(str[0]) + str.Substring(1);
        }

    }
}