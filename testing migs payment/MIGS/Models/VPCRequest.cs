using MIGS.Attributes;
using MIGS.Comparrers;
using System.Collections.Generic;

namespace MIGS.Models
{
    public class VPCRequest
    {
        // Default values:
        private const string LOCAL = "en";
        private const string COMMAND = "pay";
        private const string VERSION = "1";
        private const string CURRENCY = "USD";

        // Local variables:
        private string _local;
        private string _command;
        private string _version;
        private string _currency;

        public string SUBMIT_PAYMENT_URL => "https://migs.mastercard.com.au/vpcpay";

        [VPCParameter("user_CurrencyCode")]
        public string CurrencyCode { get; set; }

        [VPCParameter("vpc_AccessCode")]
        public string MerchantAccessCode { get; set; }

        [VPCParameter("vpc_Merchant")]
        public string MerchantId { get; set; }

        [VPCParameter("vpc_MerchTxnRef")]
        public string MerchantTxnRef { get; set; }

        [VPCParameter("vpc_ReturnURL")]
        public string ReturnUrl { get; set; }

        [VPCParameter("vpc_Command")]
        public string Command { get { return string.IsNullOrWhiteSpace(_command) ? COMMAND : _command; } set { _command = value; } }

        [VPCParameter("vpc_Version")]
        public string Version { get { return string.IsNullOrWhiteSpace(_version) ? VERSION : _version; } set { _version = value; } }

        [VPCParameter("vpc_OrderInfo")]
        public string OrderInfo { get; set; }

        [VPCParameter("vpc_Amount")]
        public string Amount { get; set; }

        [VPCParameter("vpc_Currency")]
        public string Currency { get { return string.IsNullOrWhiteSpace(_currency) ? CURRENCY : _currency; } set { _currency = value; } }

        [VPCParameter("vpc_Locale")]
        public string Local { get { return string.IsNullOrWhiteSpace(_local) ? LOCAL : _local; } set { _local = value; } }

        /// <summary>
        /// Create a sorted dictionary of the current VPCReponse properties with VPC parameters as its keys.
        /// </summary>
        /// <returns>Current VPCResponse object as <typeparam name="SortedDictionary<string, string>"> with VPC parameters as its keys.</returns>
        public SortedDictionary<string, string> ToVPCSortedDictionary()
        {
            var dic = new SortedDictionary<string, string>(new VPCStringComparer())
            {
                { "vpc_Version", this.Version },
                { "vpc_Command", this.Command },
                { "vpc_AccessCode", this.MerchantAccessCode },
                { "vpc_Merchant", this.MerchantId },
                { "vpc_ReturnURL", this.ReturnUrl },
                { "vpc_MerchTxnRef", this.MerchantTxnRef },
                { "vpc_OrderInfo", this.OrderInfo },
                { "vpc_Amount", this.Amount },
                { "vpc_Currency", this.Currency },
                { "vpc_Locale", this.Local },
                { "user_CurrencyCode", this.CurrencyCode},
            };
            return dic;
        }
    }
}
