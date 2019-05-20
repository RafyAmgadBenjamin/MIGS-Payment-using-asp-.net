using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testing_migs_payment.Models
{
    public class TransactionDetails
    {
            public double TxnAmount { get; set; }
            public int EmployerId { get; set; }
            public string TxnCurrencyCode { get; set; }
            public string TxnEmail { get; set; }
            public string TxnIP { get; set; }
            public string TxnServiceDescription { get; set; }
            public string TxnServiceId { get; set; }
    }
}