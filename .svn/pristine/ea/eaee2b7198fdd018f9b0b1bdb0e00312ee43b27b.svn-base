using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNetIntegrationKit;
using Odishadtet.DAL;
using Odishadtet.Models;
using System.Transactions;

namespace Odishadtet.Controllers
{
    [CustomAuthorization]
    public class UserViewCartDetailsController : Controller
    {
        IPaymentService _Paymentrepository;
        string paymentRefno = "", paymentDate = "", paymentTxnId = "", paymentAmount = "", userEmail = "", paymentsubscribeId="";
        Payment PaymentModelProp = new Payment();

        // GET: UserViewCartDetails
        public UserViewCartDetailsController(IPaymentService Paymentrepository)
        {
            _Paymentrepository = Paymentrepository;
        }
        public ActionResult UserViewCartDetails()
        {
            return View();
        }

        public void redirectToPaymentGateway()
        {

            string clientRefID = Request.QueryString["clientRefID"];
            HttpContext.Session["clientRefID"] = clientRefID;

            SetTransactionDetails(clientRefID);
            PaymentTransactionModels ptm = new PaymentTransactionModels();
            string returl = ptm.PaymentCall(clientRefID, paymentRefno, paymentAmount, userEmail);
            pgresponse(returl);
        }

        [HttpGet]
        public int GetCancelOrder(int usersubscribemasterid,int AmtToRefund)
        {

           int result = 0;
           
            try
            {

                result = redirectToRefundPaymentGateway(usersubscribemasterid.ToString(), AmtToRefund);
               // transactionScope.Complete();

                }
                catch (Exception ex) {
                    throw ex;
                }
            return result;
        }

        public void SetTransactionDetails(string clientRefID)
        {

            List<PaymentTransaction> TransactionNumber = _Paymentrepository.GetTransactionNumberAgainstMasterId(int.Parse(clientRefID));
            foreach (var item in TransactionNumber)
            {
                paymentRefno = item.payment_refid;
                paymentDate = item.payment_date;
                paymentAmount = item.payment_amount.ToString();
                paymentTxnId = item.payment_txnId;
                userEmail = item.payment_userEmailId;
            }
        }

        public void SetTransactionDetailsByPaymentRef(string clientRefID)
        {

            List<PaymentTransaction> TransactionNumber = _Paymentrepository.GetTransactionNumberAgainstPaymentRef(clientRefID);
            foreach (var item in TransactionNumber)
            {
                paymentRefno = item.payment_refid;
                paymentDate = item.payment_date;
                paymentAmount = item.payment_amount.ToString();
                paymentTxnId = item.payment_txnId;
                userEmail = item.payment_userEmailId;
            }
        }

        public int GetDualOrderVerification(string clientRefID)
        {
            int data = 0;
            //   string clientRef = Request.QueryString["usersubscribemasterID"];
            try
            {
                SetTransactionDetailsByPaymentRef(clientRefID);
                PaymentTransactionModels ptm = new PaymentTransactionModels();
                string returl = ptm.PaymentVerifyCall(clientRefID, paymentRefno, paymentDate, paymentTxnId);
               // pgresponse(returl);

                if (returl.StartsWith("ERROR"))
                {
                    data = 0;

                }
                else
                {
                    data = 1;
                    string[] strSplitDecryptedResponse = returl.Split('|');
                    GetPGResponseData(strSplitDecryptedResponse);

                    if (PaymentModelProp.txn_msg.Trim().ToLower() == "success")
                    {
                        _Paymentrepository.UpdatePayment(PaymentModelProp, 3);
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
            return data;
        }

        public int GetManualOrderVerification(string clientRefID)
        {
            int data = 0;
            try
            {
                string clientRef = Request.QueryString["usersubscribemasterID"];

                SetTransactionDetails(clientRef);
                //   HttpContext.Session["clientRefundRefID"] = clientRefID;
                PaymentTransactionModels ptm = new PaymentTransactionModels();
                string returl = ptm.PaymentOfflineVerificationCall(clientRef, paymentRefno, paymentDate, paymentTxnId);
             //   pgresponse(returl);

                if (returl.StartsWith("ERROR"))
                {
                    data = 0;
                    // data = "Order Not Cancelled:There is no Item To Cancel ";
                }
                else
                {
                    data = 1;
                    string[] strSplitDecryptedResponse = returl.Split('|');
                    GetPGResponseData(strSplitDecryptedResponse);

                }
            }
            catch (Exception)
            {

                throw;
            }
            return data;
        }

        public int redirectToRefundPaymentGateway(string clientRefID,int AmtToRefund)
        {
            int data = 0;

            using (TransactionScope transactionScope = new TransactionScope())
            {
                SetTransactionDetails(clientRefID);
                PaymentTransactionModels ptm = new PaymentTransactionModels();
                string returl = ptm.PaymentRefundCall(clientRefID, paymentRefno, paymentDate, AmtToRefund.ToString(), paymentTxnId);

                try
                {
                    if (returl.StartsWith("ERROR"))
                    {
                        //data = 0;
                        // data = "Order Not Cancelled:There is no Item To Cancel ";
                    }
                    else
                    {
                        string[] strSplitDecryptedResponse = returl.Split('|');
                        GetPGResponseData(strSplitDecryptedResponse);

                        if (PaymentModelProp.txn_status.Trim().Equals("0400") || PaymentModelProp.txn_msg.Trim().Equals("TXN_SUCCESS"))
                        {
                            PaymentModelProp.txn_amt = AmtToRefund;
                            data = _Paymentrepository.UpdateRefundPayment(PaymentModelProp, 3);                           
                            transactionScope.Complete();
                        }

                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            return data;
        }

        public void pgresponse(string responsestring)
        {
            Response.Write("<form name='s1_2' id='s1_2' action='" + responsestring + "' method='post'> ");
            Response.Write("<script type='text/javascript' language='javascript' >document.getElementById('s1_2').submit();");
            Response.Write("</script>");
            Response.Write("<script language='javascript' >");
            Response.Write("</script>");
            Response.Write("</form> ");
            Response.End();
        }
        // GET: UserViewCartDetails
        /// <summary>
        /// To load view cart page
        /// </summary>
        /// <returns></returns>
        public ActionResult ViewMyCart()
        {

            return View();
        }

        public ActionResult ShoppingCart()
        {

            return View();
        }

        public ActionResult PaymentStatus()
        {

            return View();
        }

        public void GetPGResponseData(string[] parameters)
        {


            string strPG_TxnStatus = string.Empty,
            strPG_ClintTxnRefNo = string.Empty,
            strPG_TPSLTxnBankCode = string.Empty,
            strPG_TPSLTxnID = string.Empty,
            strPG_TxnAmount = string.Empty,
            strPG_TxnDateTime = string.Empty,
            strPG_TxnDate = string.Empty,
            strPG_TxnTime = string.Empty;
            string strPG_TxnMsg = string.Empty;
            string strPG_TxnErrMsg = string.Empty;
            string strPG_RqstToken = string.Empty;
            string strPG_ClntRqstMeta = string.Empty;
            string strPG_TpslRfndId = string.Empty;
            string strPG_BalAmt = "0";
            string custID = string.Empty;
            string strPGResponse = string.Empty;
            string strPG_MerchantCode = string.Empty;
         //   string[] strSplitDecryptedResponse;
            string[] strArrPG_TxnDateTime;
            string[] strGetMerchantParamForCompare;

            for (int i = 0; i < parameters.Length; i++)
            {
                strGetMerchantParamForCompare = parameters[i].ToString().Split('=');
                if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "TXN_STATUS")
                {
                    strPG_TxnStatus = Convert.ToString(strGetMerchantParamForCompare[1]);
                    PaymentModelProp.txn_status = strPG_TxnStatus;
                }
                else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "CLNT_TXN_REF")
                {
                    strPG_ClintTxnRefNo = Convert.ToString(strGetMerchantParamForCompare[1]);
                    PaymentModelProp.ClintTxnRefNo = strPG_ClintTxnRefNo;
                }
                else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "TPSL_BANK_CD")
                {
                    strPG_TPSLTxnBankCode = Convert.ToString(strGetMerchantParamForCompare[1]);
                    PaymentModelProp.tpsl_bank_code = strPG_TPSLTxnBankCode;
                }
                else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "TPSL_TXN_ID")
                {
                    strPG_TPSLTxnID = Convert.ToString(strGetMerchantParamForCompare[1]);
                    PaymentModelProp.tpsl_txn_id = strPG_TPSLTxnID;
                }
                else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "TXN_AMT")
                {
                   // strPG_TxnAmount = Convert.ToString(strGetMerchantParamForCompare[1]);
                   // PaymentModelProp.txn_amt = Convert.ToInt32(double.Parse(strPG_TxnAmount));
                }
                else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "TPSL_TXN_TIME")
                {
                    strPG_TxnDateTime = Convert.ToString(strGetMerchantParamForCompare[1]);
                    strArrPG_TxnDateTime = strPG_TxnDateTime.Split(' ');
                    strPG_TxnDate = Convert.ToString(strArrPG_TxnDateTime[0]);
                    strPG_TxnTime = Convert.ToString(strArrPG_TxnDateTime[1]);

                    PaymentModelProp.TxnDateTime = DateTime.ParseExact(strPG_TxnDateTime, "dd-MM-yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                    PaymentModelProp.TxnDate = DateTime.ParseExact(strPG_TxnDateTime, "dd-MM-yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                    PaymentModelProp.Txn_time = Convert.ToDateTime(strPG_TxnTime).TimeOfDay;
                }
                else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "TXN_MSG")
                {
                    strPG_TxnMsg = Convert.ToString(strGetMerchantParamForCompare[1]);
                    PaymentModelProp.txn_msg = strPG_TxnMsg;
                }
                else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "TXN_ERR_MSG")
                {
                    strPG_TxnErrMsg = Convert.ToString(strGetMerchantParamForCompare[1]);
                    PaymentModelProp.txn_err_msg = strPG_TxnErrMsg;
                }
                else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "RQST_TOKEN")
                {
                    strPG_RqstToken = Convert.ToString(strGetMerchantParamForCompare[1]);
                    PaymentModelProp.rqst_token = strPG_RqstToken;
                }
                else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "CLNT_RQST_META")
                {
                    strPG_ClntRqstMeta = Convert.ToString(strGetMerchantParamForCompare[1]);
                    custID = (strPG_ClntRqstMeta.Split(':')[3]).Split('}')[0].ToString();
                    Session["custID"] = custID;
                    PaymentModelProp.clnt_rqst_meta = strPG_ClntRqstMeta;
                }
                else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "TPSL_RFND_ID")
                {
                    strPG_TpslRfndId = Convert.ToString(strGetMerchantParamForCompare[1]);
                    PaymentModelProp.tpsl_rfnd_id = strPG_TpslRfndId;
                }
                else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "BAL_AMT")
                {
                    if (strGetMerchantParamForCompare[1] != null)
                    {
                        strPG_BalAmt = strGetMerchantParamForCompare[1];
                    }
                    
                    PaymentModelProp.bal_amt = Convert.ToInt32(double.Parse(strPG_BalAmt));
                   // PaymentModelProp.bal_amt = 0;
                }
            }
        }



    }
}
