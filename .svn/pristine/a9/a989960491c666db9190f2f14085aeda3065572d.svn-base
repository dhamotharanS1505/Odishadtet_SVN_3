using System;
using System.Web;
using DotNetIntegrationKit;
using System.Configuration;

namespace Odishadtet.Models
{
    public class PaymentTransactionModels
    {
        //string L__merchantcode = "T6672";
        //string L__IsKey = "9943129768BHIENU";
        //string L__IsIv = "3445166828GFOPAV";

        //string L__merchantcode = "L69442";
        //string L__IsKey = "2915945233XYYXUY"; 
        //string L__IsIv = "3002664172CCYQDQ";

        string L__merchantcode = ConfigurationManager.AppSettings["merchant"];
        string L__IsKey = ConfigurationManager.AppSettings["sKey"];
        string L__IsIv = ConfigurationManager.AppSettings["sIv"];

        string L__Shoppingcartdetails = "NA";



        //string L__Shoppingcartdetails = "Info";

        // string L__PropertyPath = "C:\\PropertyFile\\Merchant.property";
        public string PaymentCall(string clientRefID, string paymentRefno, string paymentAmount,string userEmail)
        {
            string L__requesttype = "T";
            string L__MerchantTxnRefNo = paymentRefno;  // HttpContext.Current.Session["clientRefID"].ToString();
            string L__ITC = "email:"+userEmail; // "email:tharmachandran.a@infoplus.co.in";
            string L__Amount = paymentAmount;
            L__Shoppingcartdetails = ConfigurationManager.AppSettings["karttype"] + paymentAmount + "_0.0";
            string L__Currencycode = "INR";
            string L__uniqueCustomerID = "NA";
            string L__returnURL = ConfigurationManager.AppSettings["ReturnUrl"] + clientRefID;
            string L__StoSreturnURL = "NA";            //// 
            string L__TPSLTXNID = clientRefID;  // HttpContext.Current.Session["clientRefID"].ToString();
            string L__TxnDate = DateTime.Now.ToString("dd-MM-yyyy");
            string L__Email = userEmail; // "tharmachandran.a@infoplus.co.in";
            string L__mobileNo = "NA";
            string L__Bankcode = "";
            string L__customerName = "NA";
            string L__CardID = "NA";
            string LBL_Response = "";
            string lblError = "";

            RequestURL objRequestURL = new RequestURL();



            String response = objRequestURL.SendRequest
            (
                      L__requesttype, L__merchantcode, L__MerchantTxnRefNo, L__ITC, L__Amount
                     , L__Currencycode, L__uniqueCustomerID, L__returnURL, L__StoSreturnURL
                     , L__TPSLTXNID, L__Shoppingcartdetails, L__TxnDate, L__Email
                     , L__mobileNo, L__Bankcode, L__customerName
                     , L__CardID, L__IsKey, L__IsIv
             //,L__PropertyPath

             );

            String strResponse = response.ToUpper();
            LBL_Response = response;


            if (strResponse.StartsWith("ERROR"))
            {
                lblError = response;
            }
            else
            {
                if (L__requesttype.ToUpper() == "T")
                {
                    // none

                }

            }

            return LBL_Response;
        }

        public string PaymentVerifyCall(string clientRefID, string paymentRefno, string paymentDate, string paymentTxnId)
        {

            string L__requesttype = "S";
            string L__MerchantTxnRefNo = paymentRefno;
            string L__ITC = "email:tharmachandran.a@infoplus.co.in";
            string L__Amount = "NA";
            string L__Currencycode = "NA";
            string L__uniqueCustomerID = "NA";
            string L__returnURL = "NA"; // ConfigurationManager.AppSettings["ReturnUrlReVerify"] + clientRefID; ;
            string L__StoSreturnURL = "NA";
            string L__TPSLTXNID = "NA";
            string L__TxnDate = paymentDate;
            //string L__TxnDate = DateTime.Now.ToString("dd-MM-yyyy");
            string L__Email = "NA";
            string L__mobileNo = "NA";
            string L__Bankcode = "470";
            string L__customerName = "NA";
            string L__CardID = "NA";
            string LBL_Response = "";
            string lblError = "";
            L__Shoppingcartdetails = "NA";

            RequestURL objRequestURL = new RequestURL();

            String response = objRequestURL.SendRequest
            (
                       L__requesttype, L__merchantcode, L__MerchantTxnRefNo, L__ITC, L__Amount
                     , L__Currencycode, L__uniqueCustomerID, L__returnURL, L__StoSreturnURL
                     , L__TPSLTXNID, L__Shoppingcartdetails, L__TxnDate, L__Email
                     , L__mobileNo, L__Bankcode, L__customerName
                     , L__CardID, L__IsKey, L__IsIv
             // ,L__PropertyPath

             );

            String strResponse = response.ToUpper();
            LBL_Response = response;


            if (strResponse.StartsWith("ERROR"))
            {
                lblError = response;
            }
            else
            {
                if (L__requesttype.ToUpper() == "S")
                {
                    // none

                }

            }

            return LBL_Response;
        }

        public string PaymentOfflineVerificationCall(string clientRefID, string paymentRefno, string paymentDate, string paymentTxnId)
        {

            string L__requesttype = "O";
            string L__MerchantTxnRefNo = paymentRefno;
            string L__ITC = "email:tharmachandran.a@infoplus.co.in";
            string L__Amount = "NA";
            string L__Currencycode = "NA";
            string L__uniqueCustomerID = "NA";
            string L__returnURL = "NA";
            string L__StoSreturnURL = "NA";
            string L__TPSLTXNID = paymentTxnId;
            string L__TxnDate = paymentDate;
            //string L__TxnDate = DateTime.Now.ToString("dd-MM-yyyy");
            string L__Email = "NA";
            string L__mobileNo = "NA";
            string L__Bankcode = "470";
            string L__customerName = "NA";
            string L__CardID = "NA";
            // string L__PropertyPath = "C:\\PropertyFile\\Merchant.property";
            string LBL_Response = "";
            string lblError = "";

            RequestURL objRequestURL = new RequestURL();

            String response = objRequestURL.SendRequest
            (
                       L__requesttype, L__merchantcode, L__MerchantTxnRefNo, L__ITC, L__Amount
                     , L__Currencycode, L__uniqueCustomerID, L__returnURL, L__StoSreturnURL
                     , L__TPSLTXNID, L__Shoppingcartdetails, L__TxnDate, L__Email
                     , L__mobileNo, L__Bankcode, L__customerName
                     , L__CardID, L__IsKey, L__IsIv
             // ,L__PropertyPath

             );

            String strResponse = response.ToUpper();
            LBL_Response = response;


            if (strResponse.StartsWith("ERROR"))
            {
                lblError = response;
            }
            else
            {
                if (L__requesttype.ToUpper() == "")
                {
                    // none

                }

            }

            return LBL_Response;
        }

        public string PaymentRefundCall(string clientRefID, string paymentRefno, string paymentDate, string paymentAmount, string paymentTxnId)
        {
            string L__requesttype = "R";
            string L__MerchantTxnRefNo = "NA";
            string L__ITC = "email:tharmachandran.a@infoplus.co.in";
            string L__Amount = paymentAmount;
            string L__Currencycode = "NA";
            string L__uniqueCustomerID = "NA";
            string L__returnURL = "NA";
            string L__StoSreturnURL = "NA";
            string L__TPSLTXNID = paymentTxnId;
            string L__TxnDate = paymentDate;
            string L__Email = "NA";
            string L__mobileNo = "NA";
            string L__Bankcode = "NA";
            string L__customerName = "NA";
            string L__CardID = "NA";
            string LBL_Response = "";
            string lblError = "";

            RequestURL objRequestURL = new RequestURL();
            String response = objRequestURL.SendRequest
            (
                      L__requesttype, L__merchantcode, L__MerchantTxnRefNo, L__ITC, L__Amount
                     , L__Currencycode, L__uniqueCustomerID, L__returnURL, L__StoSreturnURL
                     , L__TPSLTXNID, L__Shoppingcartdetails, L__TxnDate, L__Email
                     , L__mobileNo, L__Bankcode, L__customerName
                     , L__CardID, L__IsKey, L__IsIv
             //,L__PropertyPath

             );

            String strResponse = response.ToUpper();
            LBL_Response = response;


            if (strResponse.StartsWith("ERROR"))
            {
                lblError = response;
            }
            else
            {
                if (L__requesttype.ToUpper() == "R")
                {
                    // none

                }

            }


            return LBL_Response;
        }


    }
    public class PaymentTransaction
    {
        public string clientRefID { get; set; }
        public string transType { get; set; }
        public decimal TotAmt { get; set; }
        public string userSubscribeMasterID { get; set; }
        public string payment_refid { get; set; }
        public string payment_date { get; set; }
        public decimal payment_amount { get; set; }
        public string payment_txnId { get; set; }
        public string payment_userEmailId { get; set; }
        public string payment_loginId { get; set; }
        public string payment_EmailId { get; set; }
        public string payment_mobile { get; set; }
        

    }
    public class PaymentModelProperty
    {
        public string LBL_DisplayResult { get; set; }
        public string lblResponseDecrypted { get; set; }
        public string lblValidate { get; set; }
        public string LBL_TxnStatus { get; set; }
        public string LBL_ClintTxnRefNo { get; set; }
        public string LBL_TPSLTxnBankCode { get; set; }
        public string LBL_TPSLTxnID { get; set; }
        public string LBL_TxnAmount { get; set; }
        public DateTime LBL_TxnDateTime { get; set; }
        public DateTime LBL_TxnDate { get; set; }
        public string LBL_TxnTime { get; set; }
        public string LBL_TxnMsg { get; set; }
        public string LBL_TxnErrMsg { get; set; }
        public string LBL_RqstToken { get; set; }
        public string ClntRqstMeta { get; set; }
        public string LBL_TpslRfndId { get; set; }
        public string LBL_BalAmt { get; set; }
        public int UsrSubcrpMasterId { get; set; }

    }

}
