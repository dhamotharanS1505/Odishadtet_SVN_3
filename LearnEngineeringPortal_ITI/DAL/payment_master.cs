//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Odishadtet.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class payment_master
    {
        public long payment_master_id { get; set; }
        public long user_subscribe_master_id { get; set; }
        public string Txn_msg { get; set; }
        public string Txn_err_msg { get; set; }
        public string ClintTxnRefNo { get; set; }
        public string TPSLTxnBankCode { get; set; }
        public string TPSLTxnID { get; set; }
        public decimal TxnAmount { get; set; }
        public System.DateTime TxnDate { get; set; }
        public System.DateTime TxnDateTime { get; set; }
        public string TxnStatus { get; set; }
        public Nullable<System.TimeSpan> TxnTime { get; set; }
        public string TransactionType { get; set; }
        public Nullable<decimal> Tpsl_charges { get; set; }
        public string rpst_token { get; set; }
        public Nullable<decimal> service_fee { get; set; }
        public Nullable<decimal> base_fee { get; set; }
        public string TPSLRefundID { get; set; }
        public Nullable<decimal> bal_amt { get; set; }
        public string request_token { get; set; }
        public Nullable<int> sms_status { get; set; }
        public int payment_gatway_id { get; set; }
        public Nullable<decimal> refund_amt { get; set; }
        public Nullable<System.DateTime> refund_date { get; set; }
    }
}
