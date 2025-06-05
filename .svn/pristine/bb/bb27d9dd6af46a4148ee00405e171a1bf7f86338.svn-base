using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Odishadtet.Models
{
    public class PaymentModels
    {
    }

    public class UserSubscribePayment
    {

        public long user_id { get; set; }
        public int? DeliveryModeID { get; set; }
        public long mobile { get; set; }
        public int packageId { get; set; }
        public decimal ActualPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal deliveryPrice { get; set; }
        public int packageValidityDays { get; set; }
        public int Promo_Code { get; set; }
        public DateTime created_on { get; set; }
        public string Email_ID { get; set; }
        public int DeliveryType { get; set; }

    }
    public class UserDetailss
    {
        public long userid { get; set; }
        public string studentName { get; set; }
    }

    public class PromoCode
    {
        public long PromoId { get; set; }
        public string Promo_Code { get; set; }
        public string PromoName { get; set; }
        public string PromoDesc { get; set; }
        public DateTime PromoExpiryOn { get; set; }
        public int PromoExtendDays { get; set; }
        public long PromoDiscountPrice { get; set; }
        public int active_status { get; set; }
    }
    public class Payment
    {
        public long UserId { get; set; }
        public long UsrSubcrpMasterId { get; set; }
        public string txn_msg { get; set; }
        public string txn_err_msg { get; set; }
        public string ClintTxnRefNo { get; set; }
        public string tpsl_txn_id { get; set; }
        public string tpsl_bank_code { get; set; }
        public int txn_amt { get; set; }
        public DateTime TxnDate { get; set; }
        public string Txn_Date { get; set; }
        public DateTime TxnDateTime { get; set; }
        public TimeSpan Txn_time { get; set; }
        public string txn_status { get; set; }
        public string TransactionType { get; set; }
        public decimal? TpslCharges { get; set; }
        public string rqst_token { get; set; }
        public decimal? ServiceFee { get; set; }
        public decimal? BaseFee { get; set; }
        public string tpsl_rfnd_id { get; set; }
        public int bal_amt { get; set; }
        public string clnt_rqst_meta { get; set; }
        public string ResponseDecrypted { get; set; }
        public string Validate { get; set; }
        public string paytmtransID { get; set; }
        public string transID { get; set; }
        public int PaymentGatewayId { get; set; }
        public int refund_amt { get; set; }
        public DateTime refund_Date { get; set; }
        public string refund_txn_id { get; set; }

    }

    public class SubjectPackage
    {
        public List<UserSubscribeDetails> SubscribeDetailsList { get; set; }
    }


    public class UserSubscribeDetails
    {

        public long usrSubscrbDetailsId { get; set; }

        public long usrSubscrbMasterId { get; set; }

        public int packageId { get; set; }

        public decimal ActualPrice { get; set; }

        public decimal SellingPrice { get; set; }

        public int packageValidityDays { get; set; }

        public DateTime packageExpiryOn { get; set; }

    }

    public class UserSubscribeMaster
    {

        public long usrSubscrbMasterId { get; set; }

        public long UserId { get; set; }

        public string paymentType { get; set; }

        public string paymentRefNo { get; set; }

        public decimal paymentTotAmt { get; set; }

        public DateTime paymentOn { get; set; }

        public DateTime createdOn { get; set; }

        public int Count { get; set; }

        public int promocodeId { get; set; }

        public int PaymentStatus { get; set; }

        public int packageId { get; set; }

        //
        //public string ClintTxnRefNo { get; set; }
        //
        //public decimal TxnAmount { get; set; }
        //
        //public DateTime TxnDate { get; set; }
        //
        //public DateTime TxnDateTime { get; set; }
        //
        //public string TxnStatus { get; set; }
        //
        //public string TransactionType { get; set; }

    }

    public class packagedetails
    {

        public int packageId { get; set; }

        public decimal? actualprice { get; set; }

        public decimal? sellingprice { get; set; }

        public int pckgvalidity { get; set; }

        public string pckgExpon { get; set; }

        public string TpslTxnId { get; set; }

        public DateTime PaymentOn { get; set; }

        public string TxnDateTime { get; set; }

        public string TxnStatus { get; set; }

        public long paymentMasterId { get; set; }

        public string SubjectCode { get; set; }

        public string SubjectName { get; set; }

        public string PaymentType { get; set; }

        public string TxnMsg { get; set; }

    }

    public class OrderSummary
    {
        public long usersubscribeid { get; set; }
        public string ClientRefNo { get; set; }
        public string PackageName { get; set; }
        public string operatingsystem { get; set; }
        public int bundle { get; set; }
        public string bundlesubjects { get; set; }
        public string paymentmode { get; set; }
        public string DeliveryMode { get; set; }
        public int SellingPrice { get; set; }
        public int ShippingPrice { get; set; }
        public int pckgSubTotal { get; set; }
        public int pckgTotal { get; set; }
        public string UserBillingName { get; set; }
        public string UserBillingaddress { get; set; }
        public long? UserBillingpincode { get; set; }
        public string UserBillingCity { get; set; }
        public string UserBillingState { get; set; }
        public string UserBillingCountry { get; set; }
        public long? UserBilingMobileno { get; set; }
        public string UserDeliveryName { get; set; }
        public string UserDeliveryaddress { get; set; }
        public long? UserDeliverypincode { get; set; }
        public string UserDeliveryCity { get; set; }
        public string UserDeliveryState { get; set; }
        public string UserDeliveryCountry { get; set; }
        public long? UserDeliveryMobileno { get; set; }
        public string pckgetransdate { get; set; }
        public int pckgecount { get; set; }
        public int Amount { get; set; }
        public int OrderStatus { get; set; }
        public string ProductStatus { get; set; }
        public int packageid { get; set; }
        public string paymentStatus { get; set; }
        public string packageExpiryon { get; set; }
        public string packagecpverpath { get; set; }
        public string Discountcode { get; set; }
        public long UserId { get; set; }
        public long MobileNumber { get; set; }
        public string Emailid { get; set; }
        public int discountprice { get; set; }
        public string PckgpurchasedOn { get; set; }
        public string packagename { get; set; }
        public string discountcode { get; set; }
        public int? discountamt { get; set; }
        public int sellingprice { get; set; }
        public int Actuallprice { get; set; }
        public string universityname { get; set; }
        public int DeliveryshippingCharges { get; set; }
        public decimal TotalPrice { get; set; }
        public string DeliveryMediaType { get; set; }
        public string paymenttype { get; set; }
        public string subjectunitpath_sms { get; set; }
        public string subjectunitpath_mail { get; set; }


    }

    public class AddressDetails
    {
        public string Address { get; set; }
        public long AddressID { get; set; }
        public string address_type { get; set; }
        public string FullName { get; set; }
        public string Pincode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string MobileNumber { get; set; }
        public string Landmark { get; set; }
    }

    public class DeliveryOptionMode
    {
        public int DeliveryOptionID { get; set; }
        public string DeliveryMode { get; set; }
        public int DeliveryOptionPrice { get; set; }
        public int DeliveryProductPrice { get; set; }
        public int DeliveryShippingPrice { get; set; }
        public string Description { get; set; }
        public string DeliveryDesc { get; set; }

    }

    public class userBillingaddress
    {
        public long user_id { get; set; }

        public int address_type { get; set; }

        public string address { get; set; }

        public string full_name { get; set; }

        public long mobile_number { get; set; }

        public string landmark { get; set; }

        public string city { get; set; }

        public long pincode { get; set; }

        public int country { get; set; }

        public string state { get; set; }

        public int isbilling_delivery { get; set; }


    }

    public class country
    {
        public int countryid { get; set; }
        public string countryname { get; set; }
    }

    public class OpenOrdersDetails
    {
        public long UsersubscribemasterID { get; set; }
        public long Identyvalue { get; set; }
        public string OrderRefNo { get; set; }
        public string OrderPlacedOn { get; set; }
        public DateTime createdOn { get; set; }
        public DateTime OrderPlacedOndatetime { get; set; }
        public Int64 OrderPlacedOnInt { get; set; }
        public Int64 PreparedDateInt { get; set; }
        // public Int64 OrderPlacedOndatetime { get; set; }
        public Int32 TotalItems { get; set; }
        public string OrderStatus { get; set; }
        public string DepartmentName { get; set; }
        public int Year { get; set; }
        public int Semester { get; set; }
        public string DeliveryMode { get; set; }
        public string UserName { get; set; }
        public string Mobile { get; set; }
        public int PaymentGatewayId { get; set; }
        public string PreparationStatus { get; set; }
        public string PreparedDate { get; set; }
        public string Preparedby { get; set; }
        public string PackageName { get; set; }
        public int PackageId { get; set; }
        public string QC_Status { get; set; }
        public string Delivery_Status { get; set; }
        public string PaymentStatus { get; set; }
        public string DeliveryDate { get; set; }
        public string PaymentDate { get; set; }
        public int CancelOrderStatus { get; set; }
        public int? Refundamt { get; set; }
        public string PaymentReceivedamt { get;set;}
        public string paymentReveicedOn { get; set; }
        public string paymentrefundstatus { get; set; }
        public string Lastordestatuscompleted { get; set; }
        public string Activation { get; set; }
        public string OnlinePaymentStatus { get; set; }
        public string universityname { get; set; }
        public int TotalItems1 { get; set; }
        public int TransactionAmount { get; set; }
        public int BalanceAmount { get; set; }
        public int RefundAmount { get; set; }
    }

    public class email
    {
        public string mobileno { get; set; }
        public string Emailid { get; set; }
        public string OrderID { get; set; }
        public string EmailContent { get; set; }
        public string SubjectInstallation { get; set; }
        public string SubjectName { get; set; }
    }

    public class OrderDetails
    {
      
        public string UserName { get; set; }
        public long Mobile { get; set; }
        public string Email { get; set; }
        public string OrderDate { get; set; }
        public string DeliveryMode { get; set; }
        public string OrderRefNo { get; set; }
        public string University { get; set; }
        public string CollegeName { get; set; }
        public string DepartmentName { get; set; }
        public int Year { get; set; }
        public int Semester { get; set; }
        public string UserRole { get; set; }
        public string SubjectName { get; set; }
        public int AmountSubtotal { get; set; }
        public int SellingAmount { get; set; }
        public int ShippingAmount { get; set; }
        public int? DiscountAmount { get; set; }
        public int TotalAmount { get; set; }
        public string DeliveryUser { get; set; }
        public string DeliveryAddress { get; set; }
        public string AddressType { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string DeliveryContact { get; set; }
        public string Landmark { get; set; }
        public string Pincode { get; set; }
        public string TraxnType { get; set; }
        public string OSType { get; set; }
        public string PrimaryMacWindows { get; set; }
        public string PrimaryMacAndroid { get; set; }
    }

    public class AdminDashboard
    {
        public string OrderRefNo { get; set; }
        public string Createdon { get; set; }
        public int TotalItmes { get; set; }
        public int TotalAmount { get; set; }
        public long TotalOrders { get; set; }
        public int SubjectCount { get; set; }
        public int OpenOrders { get; set; }
        public int CancelledOrders { get; set; }
        public int DeliveredOrderds { get; set; }
        public int OrdersInQue { get; set; }
        public int OrderInPreparation { get; set; }
        public int OrdersInQalityCheck { get; set; }
        public int OrdersInDelivery { get; set; }
        public long OrderCount { get; set; }
        public int ShippingAndMedia { get; set; }
        public int ProductPrice { get; set; }
        public int DiscountAmount { get; set; }
    }
    public class ordercancel
    {
        public int? orderstatusMaster { get; set; }
        public int orderstatustrak { get; set; }
        public int? orderstatusdetails { get; set; }
        public int? Activationusagestatus { get; set; }
        public DateTime orderpurchasedOn { get; set;}
        public string orderid { get; set; }
    }

    public class CancelCategory
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}