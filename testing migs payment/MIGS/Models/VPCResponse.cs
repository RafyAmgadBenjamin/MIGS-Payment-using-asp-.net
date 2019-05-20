using MIGS.Attributes;

namespace MIGS.Models
{
    public class VPCResponse
    {
        [VPCParameter("vpc_AuthorizeId")]
        public string AuthorizeId { get; set; }

        [VPCParameter("vpc_Merchant")]
        public string MerchantId { get; set; }

        [VPCParameter("vpc_MerchTxnRef")]
        public string MerchantTxnRef { get; set; }

        [VPCParameter("vpc_ReceiptNo")]
        public string ReceiptNumber { get; set; }

        [VPCParameter("vpc_SecureHash")]
        public string SecureHashCode { get; set; }

        [VPCParameter("vpc_Command")]
        public string Command { get; set; }

        [VPCParameter("vpc_Version")]
        public string Version { get; set; }

        [VPCParameter("vpc_OrderInfo")]
        public string OrderInfo { get; set; }

        [VPCParameter("vpc_Amount")]
        public double Amount { get; set; }

        [VPCParameter("vpc_Card")]
        public string Card { get; set; }

        [VPCParameter("vpc_Locale")]
        public string Local { get; set; }

        [VPCParameter("vpc_Message")]
        public string Message { get; set; }

        [VPCParameter("vpc_TransactionNo")]
        public string TxnNumber { get; set; }

        [VPCParameter("vpc_AcqResponseCode")]
        public string AcqResponseCode { get; set; }

        [VPCParameter("vpc_TxnResponseCode")]
        public string TxnResponseCode { get; set; }

        [VPCParameter("vpc_BatchNo")]
        public string BatchNumber { get; set; }

        [VPCParameter("vpc_Currency")]
        public string Currency { get; set; }

        [VPCParameter("user_CurrencyCode")]
        public string CurrencyCode { get; set; }

        public string TxnQuery { get; set; }

        public bool TxnSuccessful
        {
            get
            {
                return !string.IsNullOrWhiteSpace(TxnResponseCode)
                    && TxnResponseCode.Equals("0")
                    && !string.IsNullOrEmpty(Message);
            }
        }
    }
}
