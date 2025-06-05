using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Odishadtet.DAL;
using Odishadtet.Models;

namespace Odishadtet.APIServiceControllers
{
    public class APIPaymentCartController : ApiController
    {

        string paymentRefno = "", paymentDate = "", paymentTxnId = "", paymentAmount = "", userEmail = "";

        static IPaymentService _Paymentrepository;

        public APIPaymentCartController(IPaymentService Paymentrepository)
        {
            if (Paymentrepository == null)
            {
                throw new ArgumentNullException("Paymentrepository");
            }

            _Paymentrepository = Paymentrepository;
        }


        [HttpGet]
        public string UpdatePayment(Payment pm)
        {
            string result = _Paymentrepository.UpdatePayment(pm, 1);
            return result;
        }
        public List<OrderSummary> GetOrderSummary(int? usersubscribemasterid)
        {
            List<OrderSummary> ordersummary = _Paymentrepository.GetOrderSummary(usersubscribemasterid);

            return ordersummary;
        }

        public int GetVerifyCancelOrderOTP(string orderId, string otpcode, int action_userId, string cancel_category)
        {
            int cancelorderotp = _Paymentrepository.VerifyCancelOrderOTP(orderId, otpcode, action_userId, cancel_category);

            return cancelorderotp;
        }

        public List<OrderSummary> GetAllOrderDetails(int userid, int OrderStatus)
        {
            List<OrderSummary> AllOrderDetails = _Paymentrepository.GetOrderDetails(userid, OrderStatus);
            return AllOrderDetails;
        }

        public List<OrderSummary> GetPopupOrderDetails(int userid, int OrderStatus, string OrderId)
        {
            List<OrderSummary> PopupOrderDetails = _Paymentrepository.GetPopupOrderDetails(userid, OrderStatus, OrderId);
            return PopupOrderDetails;
        }


        public string GetUserAddress(int user_id, int address_type, string full_name, long mobile_number, string address, int pincode, string city, string state, int country, string landmark, int isbilling_delivery, int EditAddressID)
        {
            //user_id = Convert.ToInt32(HttpContext.Current.Session["LoginUserID"]);
            string saveBillingAddress = _Paymentrepository.UserAddress(user_id, address_type, full_name, mobile_number, address, pincode, city, state, country, landmark, isbilling_delivery, EditAddressID);
            return saveBillingAddress;
        }


        public List<AddressDetails> GetAddressDetails(int UserID)
        {
            List<AddressDetails> address = _Paymentrepository.GetAddressDetails(UserID);
            return address;
        }


        public List<AddressDetails> GetEditAddressDetails(int UserID, int AddressID)
        {
            List<AddressDetails> address = _Paymentrepository.GetEditAddressDetails(UserID, AddressID);
            return address;
        }

        public List<country> GetCountry()
        {
            List<country> country = _Paymentrepository.GetCountry();
            return country;
        }


        public string GetIsExistTxn(int pUserId)
        {
            string status= _Paymentrepository.CheckIsExistTxn(pUserId);
            return status;
        }

        public string GetSaveUserOrderDetails(int pUserId, int pBillingAddressID, int pDeliveryAddressID, int pDiscountID, string pOrderItems, int pTransactionType , int PaymentgatewayId)
        {
            string UserSubscribeMasterID = _Paymentrepository.SaveUserOrderDetails(pUserId, pBillingAddressID, pDeliveryAddressID, pDiscountID, pOrderItems, pTransactionType, PaymentgatewayId);
            return UserSubscribeMasterID;
        }

        public string GetSaveUserOrderDetails_fromViewCart(int pUserId)
        {
           string pOrderItems = _Paymentrepository.GetUserCartDetails(pUserId.ToString());

            string UserSubscribeMasterID = _Paymentrepository.SaveUserOrderDetails(pUserId, 0, 0, 0, pOrderItems, 2,0);
            return UserSubscribeMasterID;
        }

        public string GetOtpVerificationOrderConfirmation(int userid, string verificationcode)
        {
            string CheckotpVerification = _Paymentrepository.OtpVerificationOrderConfirmation(userid, verificationcode);

            return CheckotpVerification;
        }

        public string GetDiscountCalc(string DiscountCode)
        {
            string result = _Paymentrepository.DiscountCalc(DiscountCode);
            return result;
        }

        [HttpGet]
        public List<CancelCategory> CancelOrderCategory()
        {
            List<CancelCategory> category = _Paymentrepository.LoadCancelOrderCategory();

            return category;
        }
        //public string GetUsageActviatonCancelOrder(int? usersubscribemasterid, long buyer_mobileNo, string ToEmailID, string OrderID)
        //{
        //    string UsageActviatonCancelOrders = _Paymentrepository.UsageActviatonCancelOrder(usersubscribemasterid, buyer_mobileNo, ToEmailID, OrderID);

        //    return UsageActviatonCancelOrders;
        //}

        public int GetVerifyCancelOrderOTP_Amount(int? usersubscribemasterid, long buyer_mobileNo, string ToEmailID, string OrderID, int userid, string verificationcode, int AmtToRefund)
        {
            int ordercancelOTP = _Paymentrepository.VerifyCancelOrderAmount( usersubscribemasterid,  buyer_mobileNo,  ToEmailID,  OrderID,  userid,  verificationcode,  AmtToRefund);

            return ordercancelOTP;
        }


        

        public string GetCancelOrderOTP(long actn_user_mobile, string orderId)
        {
            string ordercancelOTP = _Paymentrepository.CancelOrderOTP(actn_user_mobile, orderId);

            return ordercancelOTP;
        }

        //   public string SendEmail(email obj)
        public string SendEmail(email obj)
        {
            // var response = new HttpResponseMessage();
            string emailcontent = _Paymentrepository.sendEmailOrderInvoice(obj.mobileno, obj.Emailid, obj.OrderID, obj.EmailContent,obj.SubjectName);
            //response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            return emailcontent;
        }

        //public string  PostSendEmail(string mobileno, string Emailid, string OrderID, string EmailContent)
        //{
        //    string emailcontent = _Paymentrepository.sendEmailOrderInvoice(mobileno,Emailid,OrderID, EmailContent);
        //    return emailcontent;
        //}

        // GET: api/APIPaymentCart
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/APIPaymentCart/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/APIPaymentCart
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/APIPaymentCart/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/APIPaymentCart/5
        public void Delete(int id)
        {
        }
    }
}
