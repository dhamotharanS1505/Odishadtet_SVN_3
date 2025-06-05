using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;
using Odishadtet.Models;

namespace Odishadtet.DAL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPaymentService" in both code and config file together.

    public interface IPaymentService
    {
        string SaveUserOrderDetails(int userId, int billingAddressID, int DeliveryAddressID, int discount_id, string pOrderItems, int TransactionType, int PaymentgatewayId);

        string GetTransactionNumber();  

        List<PaymentTransaction> GetTransactionNumberAgainstMasterId(int usersubscribemasterid);

        /// <summary>
        /// Gets the transaction number against payment reference.
        /// </summary>
        /// <param name="paymentRef">The payment reference.</param>
        /// <returns></returns>
        List<PaymentTransaction> GetTransactionNumberAgainstPaymentRef(string paymentRef);

        string UpdatePayment(Payment pm, int PaymentType);

        //string UpdatepaytmPayment(Payment pm, int PaymentType);

        string CancelOrder(int? usersubscribemasterid, long buyer_mobileNo, string ToEmailID, string OrderID, int userid, string verificationcode);

        List<OrderSummary> GetOrderSummary(int? usersubscribemasterid);

        List<OrderSummary> GetOrderDetails(int userid, int OrderStatus);

        List<OrderSummary> GetPopupOrderDetails(int userid, int OrderStatus, string paymentrefno);

        int CancelOrderConfirmation(int usersubscribemasterid);

        int CanelOrderHistory(string orderId, int action_user_id, string canelcategory);

        int VerifyCancelOrderOTP(string orderId, string otpcode, int action_userId, string cancel_category);

        string UserAddress(int pUserId, int pAddressType, string pFullName, long pMobileNumber, string pAddress, int pPincode, string pCity, string pState, int pCountry, string pLandmark, int pIsbilling_delivery,int EditAddressID);

        List<AddressDetails> GetAddressDetails(int pUserId);

        List<AddressDetails> GetEditAddressDetails(int pUserId, int AddressID);

        List<country> GetCountry();

        string OtpVerificationOrderConfirmation(int userid, string verificationcode);

        string DiscountCalc(string DiscountCode);

        string GetUserCartDetails(string userId);

        string sendEmailOrderInvoice(string mobileno, string Emailid, string OrderID, string EmailContent,string SubjectName);

        string CancelOrderOTP(long actn_user_mobile, string orderId);

        List<CancelCategory> LoadCancelOrderCategory();

        string CheckIsExistTxn(long pUserId);

        string UpdatePackageOnlinePayment(long userSubscribeMasterId);

        int UpdateRefundPayment(Payment pm, int PaymentType);

        int VerifyCancelOrderAmount(int? usersubscribemasterid, long buyer_mobileNo, string ToEmailID, string OrderID, int userid, string verificationcode, int AmtToRefund);


    }
}






