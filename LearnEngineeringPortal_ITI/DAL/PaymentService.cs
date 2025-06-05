using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.ServiceModel;
using System.Web.Script.Serialization;
using Odishadtet.Models;
using System.Data.Entity;
using System.Collections;
using LearnEngineeringPortalService_ITI;
using System.Configuration;
using System.Data.Entity.Migrations;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Odishadtet.DAL;
using Odishadtet.General;

namespace Odishadtet.DAL
{
    /// <summary>
    ///Get Payment Details 
    /// </summary>
    public class PaymentService : IPaymentService
    {

        //learnengg_payment_portal_entities sdce = new learnengg_payment_portal_entities();
        string PageName = "PaymentService.cs";

        #region MyOrder Page Methods

        public string UserAddress(int pUserId, int pAddressType, string pFullName, long pMobileNumber, string pAddress, int pPincode, string pCity, string pState, int pCountry, string pLandmark, int pIsbilling_delivery, int EditAddressID)
        {
            string message = "";
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                List<Dashboard> studentdashboard = new List<Dashboard>();
                try
                {
                    if (EditAddressID > 0)
                    {
                        var ude = (from uad in contextsdce.user_address_details where uad.delivery_address_id == EditAddressID select uad).FirstOrDefault();
                        ude.user_id = pUserId;
                        ude.address_type = pAddressType;
                        ude.full_name = pFullName;
                        ude.mobile_number = pMobileNumber;
                        ude.address = pAddress;
                        ude.pincode = pPincode;
                        ude.city = pCity;
                        ude.state = pState;
                        ude.country = pCountry;
                        ude.landmark = pLandmark;
                        ude.isbilling_delivery = pIsbilling_delivery;
                        message = "2";
                    }

                    else
                    {
                        user_address_details ude = new user_address_details();
                        ude.user_id = pUserId;
                        ude.address_type = pAddressType;
                        ude.full_name = pFullName;
                        ude.mobile_number = pMobileNumber;
                        ude.address = pAddress;
                        ude.pincode = pPincode;
                        ude.city = pCity;
                        ude.state = pState;
                        ude.country = pCountry;
                        ude.landmark = pLandmark;
                        ude.isbilling_delivery = pIsbilling_delivery;
                        ude.created_on = DateTime.Now;
                        contextsdce.user_address_details.Add(ude);
                        message = "1";
                    }
                    contextsdce.SaveChanges();

                }
                catch (Exception ex)
                {
                    message = "0";
                    throw ex.InnerException;
                }
                return message;
            }
        }

        public List<AddressDetails> GetAddressDetails(int pUserId)
        {
            List<AddressDetails> AddressDetails = new List<AddressDetails>();
            try
            {
                using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
                {
                    AddressDetails = (from ude in contextsdce.user_address_details
                                      join cm in contextsdce.country_master on ude.country equals cm.country_id
                                      where ude.user_id == pUserId
                                      select new AddressDetails
                                      {
                                          AddressID = ude.delivery_address_id,
                                          address_type = ude.address_type.ToString(),
                                          FullName = ude.full_name.ToString().ToUpper(),
                                          Address = ude.address,
                                          City = ude.city,
                                          State = ude.state,
                                          Country = cm.country_name,
                                          Pincode = ude.pincode.ToString(),
                                          MobileNumber = ude.mobile_number.ToString(),
                                          Landmark = ude.landmark
                                      }).ToList();

                }
                return AddressDetails;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
            catch (Exception)
            {
                return AddressDetails;
            }
        }


        public List<AddressDetails> GetEditAddressDetails(int pUserId, int AddressID)
        {
            List<AddressDetails> AddressDetails = new List<AddressDetails>();
            try
            {
                using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
                {
                 
                    AddressDetails = (from ude in contextsdce.user_address_details         
                                          //join cm in contextsdce.country_master on ude.country equals cm.country_id
                                      where ude.user_id == pUserId && ude.delivery_address_id == AddressID
                                      select new AddressDetails
                                      {
                                          AddressID = ude.delivery_address_id,
                                          address_type = ude.address_type.ToString(),
                                          FullName = ude.full_name.ToString().ToUpper(),
                                          Address = ude.address,
                                          City = ude.city,
                                          State = ude.state,
                                          Country = ude.country.ToString(),
                                          Pincode = ude.pincode.ToString(),
                                          MobileNumber = ude.mobile_number.ToString(),
                                          Landmark = ude.landmark
                                      }).ToList();

                }
                return AddressDetails;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
            catch (Exception)
            {
                return AddressDetails;
            }
        }

        public string DiscountCalc(string DiscountCode)
        {
            try
            {
                using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
                {
                    var DiscountAmt = (from pdm in contextsdce.promo_discount_master
                                       where pdm.discount_code == DiscountCode && pdm.active_status == 1
                                       select new
                                       {
                                           discount = pdm.discount_id + "-" + pdm.discount_price
                                       }
                    ).FirstOrDefault();
                    if (DiscountAmt != null)
                    {
                        return DiscountAmt.discount.ToString();
                    }
                    else
                    {
                        return "";
                    }
                }

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
            catch (Exception ex)
            {
                throw ex;
                return "";
            }
        }

        public string OtpVerificationOrderConfirmation(int userid, string verificationcode)
        {
            try
            {
                using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
                {
                    var codeVerification = (from randomcode in contextsdce.user_random_pass
                                            where randomcode.user_id == userid && randomcode.verification_code == verificationcode
                                            select randomcode).FirstOrDefault();


                    if (codeVerification != null)
                    {
                        return "1";
                    }
                    else
                    {
                        return "0";
                    }
                }
            }
            catch (Exception ex)
            {
                Log.WriteLogMessage(PageName, "NewUserRegistration", "RandomCodeVerification", ex.Message, "error");

                return "Enter the Correct Verification code";
            }

        }

        public string GetUserCartDetails(string userId)
        {

            string result = "0";
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                contextsdce.Database.Connection.Open();

                string[] viewCartDetails = (from packg in contextsdce.package_master
                                            join user_cart in contextsdce.user_cart_details on packg.package_id equals user_cart.package_id
                                            join um in contextsdce.user_master on user_cart.user_id equals um.user_id
                                            where user_cart.user_id.ToString() == userId && packg.activestatus == 1
                                            select packg.package_id.ToString()
                                       ).ToArray();
                if (viewCartDetails.Length > 0)
                {
                    result = viewCartDetails.Aggregate((a, b) => a + "_" + b);
                }
                return result;
            }
        }

        public List<PaymentTransaction> GetTransactionNumberAgainstMasterId(int usersubscribemasterid)
        {
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                List<PaymentTransaction> TransactionNumber = new List<PaymentTransaction>();
                try
                {
                    //   contextsdce.Database.Connection.Open();
                    var TransactionDetails = (from sm in contextsdce.user_subscribe_master
                                              join um in contextsdce.user_master on sm.user_id equals um.user_id
                                              join pm in contextsdce.payment_master on sm.user_subscribe_master_id equals pm.user_subscribe_master_id
                                              where sm.user_subscribe_master_id == usersubscribemasterid
                                              select new
                                              {
                                                  payment_refid = sm.payment_ref_no,
                                                  payment_date = pm.TxnDate,
                                                  payment_amount = pm.TxnAmount,
                                                  payment_txnId = pm.TPSLTxnID,
                                                  payment_userEmail = um.email_id
                                              }
                                                ).ToList();

                    TransactionNumber = (from flist in TransactionDetails
                                         select new PaymentTransaction
                                         {
                                             payment_refid = flist.payment_refid,
                                             payment_date = flist.payment_date.ToString("dd-MM-yyyy"),
                                             payment_amount = flist.payment_amount,
                                             payment_txnId = flist.payment_txnId,
                                             payment_userEmailId = flist.payment_userEmail,
                                             clientRefID = flist.payment_refid

                                         }).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return TransactionNumber;
            }

        }

        public List<PaymentTransaction> GetTransactionNumberAgainstPaymentRef(string paymentRef)
        {
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                List<PaymentTransaction> TransactionNumber = new List<PaymentTransaction>();
                try
                {
                    contextsdce.Database.Connection.Open();
                    var TransactionDetails = (from sm in contextsdce.user_subscribe_master
                                              join um in contextsdce.user_master on sm.user_id equals um.user_id
                                              join pm in contextsdce.payment_master on sm.user_subscribe_master_id equals pm.user_subscribe_master_id
                                              where pm.ClintTxnRefNo == paymentRef
                                              select new
                                              {
                                                  payment_refid = sm.payment_ref_no,
                                                  payment_date = pm.TxnDate,
                                                  payment_amount = pm.TxnAmount,
                                                  payment_txnId = pm.TPSLTxnID,
                                                  payment_userEmail = um.email_id,
                                                  user_subscribeID = sm.user_subscribe_master_id,
                                                  purLoginId = um.user_id,
                                                  purmobile = um.mobile,
                                                  puremail = um.email_id
                                              }
                                                ).ToList();

                    TransactionNumber = (from flist in TransactionDetails
                                         select new PaymentTransaction
                                         {
                                             payment_refid = flist.payment_refid,
                                             payment_date = flist.payment_date.ToString("dd-MM-yyyy"),
                                             payment_amount = flist.payment_amount,
                                             payment_txnId = flist.payment_txnId,
                                             payment_userEmailId = flist.payment_userEmail,
                                             userSubscribeMasterID = flist.user_subscribeID.ToString(),
                                             payment_loginId = flist.purLoginId.ToString(),
                                             payment_EmailId = flist.puremail,
                                             payment_mobile = flist.purmobile.ToString()

                                         }).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return TransactionNumber;
            }

        }

        public string SaveUserOrderDetails(int userId, int billingAddressID, int DeliveryAddressID, int discount_id, string pOrderItems, int TransactionType, int PaymentgatewayId)
        {
            PaymentTransaction ptm = new PaymentTransaction();
            int result = 0;
            string CurrentOrderItems = "";
            int itemcnt = pOrderItems.IndexOf('_');
            int totalorders;
            List<string> CurrentOrderItemsList = new List<string>();

            if (itemcnt > 0)
            {
                string[] CurrentOrderItems_ = pOrderItems.Split('_');
                totalorders = CurrentOrderItems_.Length;
                CurrentOrderItemsList = CurrentOrderItems_.ToList();
            }
            else
            {
                string[] CurrentOrderItems_ = new string[] { pOrderItems };
                totalorders = CurrentOrderItems_.Length;
                CurrentOrderItemsList = CurrentOrderItems_.ToList();
            }

         

            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                //contextsdce.Database.Connection.Open();
                decimal DiscountAmt = (from pdm in contextsdce.promo_discount_master where pdm.discount_id == discount_id select pdm.discount_price).FirstOrDefault();
                if (billingAddressID == 0)
                {
                    var Address = (from uad in contextsdce.user_address_details where uad.user_id == userId select uad.delivery_address_id).FirstOrDefault();

                    billingAddressID = (int)Address;
                    DeliveryAddressID = (int)Address;
                }

                var viewCartDetails = (from packg in contextsdce.package_master
                                       join user_cart in contextsdce.user_cart_details on packg.package_id equals user_cart.package_id
                                       join um in contextsdce.user_master on user_cart.user_id equals um.user_id
                                       join usdm in contextsdce.user_subscribe_delivery_mode on user_cart.delivery_modeid equals usdm.user_subscribe_delivery_mode_id
                                       where user_cart.user_id == userId && packg.activestatus == 1 && CurrentOrderItemsList.Contains(packg.package_id.ToString())
                                       select new UserSubscribePayment
                                       {
                                           packageId = packg.package_id,
                                           ActualPrice = packg.actual_price,
                                           SellingPrice = packg.selling_price,
                                           deliveryPrice = usdm.price,
                                           user_id = user_cart.user_id,
                                           mobile = um.mobile,
                                           created_on = user_cart.created_on,
                                           packageValidityDays = packg.package_duration_days,
                                           DeliveryModeID = user_cart.delivery_modeid,
                                           Email_ID = um.email_id,
                                           DeliveryType = usdm.delivery_type ?? 0

                                       }).ToList();
                if (viewCartDetails.Count() == totalorders)
                {


                    using (var transaction = contextsdce.Database.BeginTransaction())
                    {
                        try
                        {
                            string Track_number = PaymentgatewayId == 1 ? "T" + GetTransactionNumber() : "P" + GetTransactionNumber();  // need to call the dynamic value
                            string buyer_mobile = viewCartDetails.FirstOrDefault().mobile + "";
                            string buyer_Email = viewCartDetails.FirstOrDefault().Email_ID + "";
                            user_subscribe_master usm = new user_subscribe_master();
                            usm.user_id = viewCartDetails.FirstOrDefault().user_id;
                            usm.TransactionType = TransactionType; //1 - COD 2 - Credit Card 3 - Debit Card 4 - Net Banking
                            usm.payment_ref_no = Track_number;
                            usm.discount_amt = 0;
                            usm.payment_on = DateTime.Now;
                            usm.created_on = DateTime.Now;
                            usm.count = viewCartDetails.Select(x => x.packageId).Count();
                            usm.discount_id = discount_id;
                            usm.discount_amt = Convert.ToInt32(DiscountAmt);
                            if (((viewCartDetails.Sum(v => v.SellingPrice) + viewCartDetails.FirstOrDefault().deliveryPrice) - DiscountAmt) == 0)
                            {
                                usm.payment_status = 4;
                                usm.order_status = 5;
                            }
                            else
                            {
                                usm.payment_status = 1;
                                usm.order_status = 1;
                            }
                            usm.user_subscribe_delivery_mode_id = viewCartDetails.FirstOrDefault().DeliveryModeID;
                            usm.billing_address_id = billingAddressID == 0 ? (long?)null : billingAddressID;
                            usm.deliver_address_id = DeliveryAddressID == 0 ? (long?)null : DeliveryAddressID;
                            contextsdce.user_subscribe_master.Add(usm);
                            contextsdce.SaveChanges();
                            var lastinsertedId = usm.user_subscribe_master_id;

                            payment_master pm = new payment_master();
                            pm.user_subscribe_master_id = lastinsertedId;
                            pm.ClintTxnRefNo = usm.payment_ref_no;
                            pm.TxnAmount = (viewCartDetails.Sum(v => v.SellingPrice) + viewCartDetails.FirstOrDefault().deliveryPrice) - DiscountAmt;
                            pm.TxnDate = DateTime.Now;
                            pm.TxnDateTime = DateTime.Now;
                            if (((viewCartDetails.Sum(v => v.SellingPrice) + viewCartDetails.FirstOrDefault().deliveryPrice) - DiscountAmt) == 0)
                            {
                                pm.TxnStatus = "4";
                                pm.TransactionType = TransactionType.ToString(); // "COD";
                            }
                            else
                            {
                                pm.TxnStatus = "1";
                                pm.TransactionType = TransactionType.ToString(); // "COD";
                            }
                            pm.sms_status = 0;
                            pm.payment_gatway_id = PaymentgatewayId;
                            contextsdce.payment_master.Add(pm);
                            contextsdce.SaveChanges();


                            foreach (var cartdetails in viewCartDetails)
                            {
                                user_subscribe_details usd = new user_subscribe_details();
                                usd.user_subscribe_master_id = lastinsertedId;
                                usd.package_id = cartdetails.packageId;
                                usd.actual_price = Convert.ToInt32(cartdetails.ActualPrice);
                                usd.selling_price = Convert.ToInt32(cartdetails.SellingPrice);
                                usd.promo_discount_amt = (int)DiscountAmt;
                                usd.package_validity_days = cartdetails.packageValidityDays;
                                usd.package_expiryon = DateTime.Now.AddDays(cartdetails.packageValidityDays);
                                usd.deliver_status = 1;
                                contextsdce.user_subscribe_details.Add(usd);
                                contextsdce.SaveChanges();

                                user_subscribe_order_track usot = new user_subscribe_order_track();
                                usot.user_subscribe_master_id = lastinsertedId;
                                usot.package_id = cartdetails.packageId;
                                usot.orderby = usm.user_id;
                                usot.orderrefno = pm.ClintTxnRefNo;
                                usot.ordermobile = viewCartDetails.FirstOrDefault().mobile.ToString();
                                if (((viewCartDetails.Sum(v => v.SellingPrice) + viewCartDetails.FirstOrDefault().deliveryPrice) - DiscountAmt) == 0)
                                {
                                    usot.orderstatus = 5;
                                    usot.paystatus = 4;
                                }
                                else
                                {
                                    usot.orderstatus = 1;
                                    usot.paystatus = 1;
                                }
                                usot.orderon = DateTime.Now;
                                usot.preparedstatus = 1;
                                usot.qualitycheckstatus = 1;
                                usot.deliverstatus = 1;
                                usot.activationstatus = 1;
                                contextsdce.user_subscribe_order_track.Add(usot);
                                contextsdce.SaveChanges();
                            }

                            //var ucd = (from usrcart in contextsdce.user_cart_details where usrcart.user_id == userId select usrcart).DefaultIfEmpty();
                            //if (ucd != null)
                            //{
                            //    contextsdce.user_cart_details.RemoveRange(ucd);
                            //}
                            if (TransactionType == 1)
                            {
                                contextsdce.user_cart_details.RemoveRange(contextsdce.user_cart_details.Where(c => c.user_id == userId));
                                contextsdce.SaveChanges();
                            }
                            result = 1;
                            transaction.Commit();
                            if (result > 0)
                            {
                                ptm.clientRefID = pm.ClintTxnRefNo;
                                ptm.TotAmt = pm.TxnAmount;
                                ptm.userSubscribeMasterID = lastinsertedId.ToString();
                                //StudentService ob = new StudentService();
                                //ob.OrderConformed(buyer_mobile, buyer_Email, Track_number);
                                ////OrderConformed
                                if (pm.TxnAmount == 0)
                                {
                                    UpdatePackageOnlinePayment(lastinsertedId);
                                    contextsdce.user_cart_details.RemoveRange(contextsdce.user_cart_details.Where(c => c.user_id == userId));
                                    contextsdce.SaveChanges();
                                }
                                return lastinsertedId.ToString(); // Success
                            }
                            else
                            {
                                return ""; // Failure
                            }


                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            transaction.Dispose();
                            contextsdce.Dispose();
                            Log.WriteLogMessage(PageName, "Payment", "SaveUserOrderDetails", ex.Message, "error");
                            return ""; // Failure
                        }
                        finally
                        {
                            transaction.Dispose();
                            contextsdce.Dispose();
                        }
                    }
                }
                else
                {
                    return "0"; // Failure
                }
            }
        }

        public string GetTransactionNumber()
        {
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                try
                {
                    int insert = 0;
                    int update = 0;
                    char[] arrMonth = { ' ', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V' };
                    char[] arrDate1 = { 'Z', 'Y', 'X', 'W' };
                    char[] arrDate2 = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };

                    string trans_number = string.Empty;
                    var transaction = (from td in contextsdce.Transaction_Details where td.trans_date == DateTime.Today select td).FirstOrDefault();
                    string month1 = arrMonth[Convert.ToInt32(DateTime.Now.Date.ToString("MM"))].ToString();
                    string Date1 = arrDate1[Convert.ToInt32(DateTime.Now.Date.ToString("dd").Remove(1, 1))].ToString();
                    string Date2 = arrDate2[Convert.ToInt32(DateTime.Now.Date.ToString("dd").Remove(0, 1))].ToString();
                    string year1 = DateTime.Now.Date.ToString("yyyy").Remove(0, 1);

                    if (transaction == null)
                    {
                        Transaction_Details inserttrans = new Transaction_Details();
                        inserttrans.trans_date = DateTime.Now.Date;
                        inserttrans.trans_number = 10001;
                        contextsdce.Transaction_Details.Add(inserttrans);
                        insert = contextsdce.SaveChanges();
                        //trans_number = inserttrans.trans_number.ToString();
                        trans_number = Date1 + Date2 + month1 + year1 + transaction.trans_number.ToString();
                    }
                    else if (transaction != null)
                    {
                        transaction.trans_number = transaction.trans_number + 1;
                        update = contextsdce.SaveChanges();
                        trans_number = transaction.trans_number.ToString();
                        trans_number = Date1 + Date2 + month1 + year1 + transaction.trans_number.ToString();
                    }

                    return "T" + trans_number;
                }

                catch (Exception ex)
                {
                    Log.WriteLogMessage(PageName, "Transcation", "SaveTransactiondetails", ex.Message, "error");
                    throw;
                }
                finally
                {
                    if (contextsdce != null)
                    {
                        contextsdce.Dispose();
                    }
                }
            }
        }


        //public user_cart_details GetUserCartPackageDetails(int UserID)
        //{
        //    using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
        //    {
        //        contextsdce.Database.Connection.Open(); var viewCartDetails = (from packg in contextsdce.package_master
        //                                                                       join user_cart in contextsdce.user_cart_details on packg.package_id equals user_cart.package_id
        //                                                                       where user_cart.user_id == UserID && packg.activestatus == 1
        //                                                                       select new UserSubscribePayment
        //                                                                       {
        //                                                                           packageId = packg.package_id,
        //                                                                           ActualPrice = packg.actual_price,
        //                                                                           SellingPrice = packg.selling_price,
        //                                                                           user_id = user_cart.user_id,
        //                                                                           created_on = user_cart.created_on,
        //                                                                           packageValidityDays = packg.package_duration_days
        //                                                                       }).ToList();
        //    }
        //}

       

        public string UpdatePayment(Payment pm, int PaymentType)
        {
            int result = 0;
            string resultxtring = "0";
            try
            {
                using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
                {
                    // Log.WriteLogMessage("PaymentService", "UpdatePayment", "before query ClintTxnRefNo", "" + pm.ClintTxnRefNo, "error");

                    var updatePayment = (from pay in contextsdce.payment_master
                                         join usm in contextsdce.user_subscribe_master on pay.user_subscribe_master_id equals usm.user_subscribe_master_id
                                         join usot in contextsdce.user_subscribe_order_track on usm.user_subscribe_master_id equals usot.user_subscribe_master_id
                                         join dom in contextsdce.user_subscribe_delivery_mode on usm.user_subscribe_delivery_mode_id equals dom.user_subscribe_delivery_mode_id
                                         where pay.ClintTxnRefNo == pm.ClintTxnRefNo
                                         select new { pay, usm, dom, usot }).FirstOrDefault();

                    // Log.WriteLogMessage("PaymentService", "UpdatePayment", "after query", "" + pm.ClintTxnRefNo, "error");
                    if (updatePayment != null)
                    {

                        // Log.WriteLogMessage("PaymentService", "UpdatePayment", "if updatePayment notnull", "" + pm.ClintTxnRefNo, "error");

                        updatePayment.usm.payment_ref_no = pm.ClintTxnRefNo;

                        Log.WriteLogMessage("PaymentService", "UpdatePayment", "PaymentType  ", "" + PaymentType, "error");
                        if (PaymentType == 3)
                        {
                            // Log.WriteLogMessage("PaymentService", "UpdatePayment", "before if txn_msg ", "" + PaymentType, "error");
                            if (pm.txn_msg.Trim().Equals("success") || pm.txn_msg.Trim().Equals("SUCCESS"))
                            {
                                //  Log.WriteLogMessage("PaymentService", "UpdatePayment", "after if PaymentType", "" + PaymentType, "error");
                                updatePayment.usm.payment_status = 2;
                                updatePayment.pay.TxnStatus = "2";
                                //  UpdatePackageOnlinePayment(updatePayment.usm.user_subscribe_master_id);

                                // if online download then consider as delivered
                                if (updatePayment.dom.delivery_type == 2)
                                {
                                    updatePayment.usm.order_status = 5;
                                    updatePayment.usot.orderstatus = 5;

                                }
                                else
                                {
                                    updatePayment.usm.order_status = 1;
                                    updatePayment.usot.orderstatus = 1;
                                }
                            }
                            else
                            {
                                updatePayment.usm.payment_status = 3;
                                updatePayment.pay.TxnStatus = "3";
                                updatePayment.pay.TxnDateTime = DateTime.Now;
                            }

                        }

                        if (PaymentType == 2)
                        {
                            // Log.WriteLogMessage("PaymentService", "UpdatePayment", "PaymentType 2 ", "" + PaymentType, "error");
                            if (pm.txn_msg.Trim().Equals("success") || pm.txn_msg.Trim().Equals("SUCCESS"))
                            {
                                updatePayment.usm.payment_status = 2;
                                updatePayment.pay.TxnStatus = "2";
                                //  UpdatePackageOnlinePayment(updatePayment.usm.user_subscribe_master_id);

                                // if online download then consider as delivered
                                if (updatePayment.dom.delivery_type == 2)
                                {
                                    updatePayment.usm.order_status = 5;
                                    updatePayment.usot.orderstatus = 5;
                                }
                                else
                                {
                                    updatePayment.usm.order_status = 1;
                                    updatePayment.usot.orderstatus = 1;
                                }
                            }
                            else
                            {
                                updatePayment.usm.payment_status = 3;
                                updatePayment.pay.TxnStatus = "3";
                            }

                        }

                        //else if (pm.txn_msg.Trim().ToLower() == "failure")
                        //{
                        //    updatePayment.usm.payment_status = 3;
                        //    updatePayment.pay.TxnStatus = "3";
                        //}

                        //Log.WriteLogMessage("PaymentService", "UpdatePayment", "before update bal_amt", "" + pm.bal_amt, "error");
                        //Log.WriteLogMessage("PaymentService", "UpdatePayment", "before update BaseFee", "" + pm.BaseFee, "error");
                        //Log.WriteLogMessage("PaymentService", "UpdatePayment", "before update ClintTxnRefNo", "" + pm.ClintTxnRefNo, "error");
                        //Log.WriteLogMessage("PaymentService", "UpdatePayment", "before update rqst_token", "" + pm.rqst_token, "error");
                        //Log.WriteLogMessage("PaymentService", "UpdatePayment", "before update ServiceFee", "" + pm.ServiceFee, "error");
                        //Log.WriteLogMessage("PaymentService", "UpdatePayment", "before update tpsl_rfnd_id", "" + pm.tpsl_rfnd_id, "error");
                        //Log.WriteLogMessage("PaymentService", "UpdatePayment", "before update tpsl_bank_code", "" + pm.tpsl_bank_code, "error");
                        //Log.WriteLogMessage("PaymentService", "UpdatePayment", "before update tpsl_txn_id", "" + pm.tpsl_txn_id, "error");
                        //Log.WriteLogMessage("PaymentService", "UpdatePayment", "before update txn_amt", "" + pm.txn_amt, "error");
                        //Log.WriteLogMessage("PaymentService", "UpdatePayment", "before update TxnDate", "" + pm.TxnDate, "error");
                        //Log.WriteLogMessage("PaymentService", "UpdatePayment", "before update TxnDateTime", "" + pm.TxnDateTime, "error");
                        //Log.WriteLogMessage("PaymentService", "UpdatePayment", "before update txn_err_msg", "" + pm.txn_err_msg, "error");
                        //Log.WriteLogMessage("PaymentService", "UpdatePayment", "before update Txn_time", "" + pm.Txn_time, "error");
                        //Log.WriteLogMessage("PaymentService", "UpdatePayment", "before update PaymentGatewayId", "" + pm.PaymentGatewayId, "error");

                        updatePayment.pay.bal_amt = pm.bal_amt;
                        updatePayment.pay.base_fee = pm.BaseFee;
                        updatePayment.pay.ClintTxnRefNo = pm.ClintTxnRefNo;
                        updatePayment.pay.request_token = pm.rqst_token;
                        updatePayment.pay.service_fee = pm.ServiceFee;
                        //updatePayment.pay.TPSLRefundID = pm.tpsl_rfnd_id;
                        updatePayment.pay.TPSLTxnBankCode = pm.tpsl_bank_code;
                        updatePayment.pay.TPSLTxnID = pm.tpsl_txn_id;
                        updatePayment.pay.TxnAmount = pm.txn_amt;
                        //     updatePayment.pay.TxnDate = pm.TxnDate;
                        //    updatePayment.pay.TxnDateTime = pm.TxnDateTime;
                        updatePayment.pay.TxnDateTime = DateTime.Now;
                        updatePayment.pay.Txn_err_msg = pm.txn_err_msg;
                        //    updatePayment.pay.TxnTime = pm.Txn_time;
                        updatePayment.pay.payment_gatway_id = pm.PaymentGatewayId;
                        contextsdce.SaveChanges();

                        // result = 1;

                        // Int64 usersubscribemasterid = updatePayment.usm.user_subscribe_master_id;
                        if (PaymentType == 2 || PaymentType == 3)
                        {
                            // Log.WriteLogMessage("PaymentService", "UpdatePayment", "before if UpdatePackageOnlinePayment", "" + pm.ClintTxnRefNo, "error");
                            if (pm.txn_msg.Trim().Equals("success") || pm.txn_msg.Trim().Equals("SUCCESS"))
                            {
                                // Log.WriteLogMessage("PaymentService", "UpdatePayment", "after if UpdatePackageOnlinePayment", "" + pm.ClintTxnRefNo, "error");
                                resultxtring = UpdatePackageOnlinePayment(updatePayment.usm.user_subscribe_master_id);
                                contextsdce.user_cart_details.RemoveRange(contextsdce.user_cart_details.Where(c => c.user_id == updatePayment.usm.user_id));
                                contextsdce.SaveChanges();

                            }
                        }

                    }
                    else
                    {
                        resultxtring = "0";
                    }
                }
                return resultxtring;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                Log.WriteLogMessage(PageName, "UpdatePayment", "UpdatePayment", raise.Message, "error");
                Log.WriteLogMessage(PageName, "UpdatePayment", "UpdatePayment", raise.InnerException.Message, "error");
                throw raise;
            }
            catch (Exception ex)
            {
                Log.WriteLogMessage(PageName, "UpdatePayment", "UpdatePayment", ex.Message, "error");
                Log.WriteLogMessage(PageName, "UpdatePayment", "UpdatePayment", ex.InnerException.Message, "error");
                return "0";
            }


        }


        //public string UpdatepaytmPayment(Payment pm, int PaymentType)
        //{
        //    int result = 0;
        //    try
        //    {
        //        using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
        //        {

        //            Log.WriteLogMessage("PaymentService", "UpdatePayment", "before query ClintTxnRefNo", "" + pm.ClintTxnRefNo, "error");

        //            var updatePayment = (from pay in contextsdce.payment_master
        //                                 join usm in contextsdce.user_subscribe_master on pay.user_subscribe_master_id equals usm.user_subscribe_master_id
        //                                 join usot in contextsdce.user_subscribe_order_track on usm.user_subscribe_master_id equals usot.user_subscribe_master_id
        //                                 join dom in contextsdce.user_subscribe_delivery_mode on usm.user_subscribe_delivery_mode_id equals dom.user_subscribe_delivery_mode_id
        //                                 where pay.ClintTxnRefNo == pm.ClintTxnRefNo
        //                                 select new { pay, usm, dom, usot }).FirstOrDefault();
        //            if (updatePayment != null)
        //            {
        //                updatePayment.usm.payment_ref_no = pm.ClintTxnRefNo;
        //                if (PaymentType == 3)
        //                {
        //                    if (pm.txn_msg.Trim() == "success" || pm.txn_msg.Trim() == "SUCCESS")
        //                    {

        //                        updatePayment.usm.payment_status = 2;
        //                        updatePayment.pay.TxnStatus = "2";
        //                        //  UpdatePackageOnlinePayment(updatePayment.usm.user_subscribe_master_id);

        //                        // if online download then consider as delivered
        //                        if (updatePayment.dom.delivery_type == 2)
        //                        {
        //                            updatePayment.usm.order_status = 5;
        //                            updatePayment.usot.orderstatus = 5;

        //                        }
        //                        else
        //                        {
        //                            updatePayment.usm.order_status = 1;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        updatePayment.usm.payment_status = 3;
        //                        updatePayment.pay.TxnStatus = "3";
        //                    }

        //                }

        //                if (PaymentType == 2)
        //                {
        //                    if (pm.txn_msg.Trim() == "success" || pm.txn_msg.Trim() == "SUCCESS")
        //                    {
        //                        updatePayment.usm.payment_status = 2;
        //                        updatePayment.pay.TxnStatus = "2";
        //                        //  UpdatePackageOnlinePayment(updatePayment.usm.user_subscribe_master_id);

        //                        // if online download then consider as delivered
        //                        if (updatePayment.dom.delivery_type == 2)
        //                        {
        //                            updatePayment.usm.order_status = 5;
        //                            updatePayment.usot.orderstatus = 5;
        //                        }
        //                        else
        //                        {
        //                            updatePayment.usm.order_status = 1;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        updatePayment.usm.payment_status = 3;
        //                        updatePayment.pay.TxnStatus = "3";
        //                    }

        //                }

        //                //else if (pm.txn_msg.Trim().ToLower() == "failure")
        //                //{
        //                //    updatePayment.usm.payment_status = 3;
        //                //    updatePayment.pay.TxnStatus = "3";
        //                //}
        //                updatePayment.pay.bal_amt = pm.bal_amt;
        //                updatePayment.pay.base_fee = pm.BaseFee;
        //                updatePayment.pay.ClintTxnRefNo = pm.ClintTxnRefNo;
        //                updatePayment.pay.request_token = pm.rqst_token;
        //                updatePayment.pay.service_fee = pm.ServiceFee;
        //                updatePayment.pay.TPSLRefundID = pm.tpsl_rfnd_id;
        //                updatePayment.pay.TPSLTxnBankCode = pm.tpsl_bank_code;
        //                updatePayment.pay.TPSLTxnID = pm.tpsl_txn_id;
        //                updatePayment.pay.TxnAmount = pm.txn_amt;
        //                updatePayment.pay.TxnDate = pm.TxnDate;
        //                updatePayment.pay.TxnDateTime = pm.TxnDateTime;
        //                updatePayment.pay.Txn_err_msg = pm.txn_err_msg;
        //                updatePayment.pay.TxnTime = pm.Txn_time;
        //                updatePayment.pay.payment_gatway_id = pm.PaymentGatewayId;
        //                contextsdce.SaveChanges();

        //                result = 1;

        //                // Int64 usersubscribemasterid = updatePayment.usm.user_subscribe_master_id;
        //                if (PaymentType == 2 || PaymentType == 3)
        //                {
        //                    Log.WriteLogMessage("PaymentService", "UpdatePayment", "before if UpdatePackageOnlinePayment", "" + pm.ClintTxnRefNo, "error");
        //                    if (pm.txn_msg.Trim() == "success" || pm.txn_msg.Trim() == "SUCCESS")
        //                    {
        //                        Log.WriteLogMessage("PaymentService", "UpdatePayment", "after if UpdatePackageOnlinePayment", "" + pm.ClintTxnRefNo, "error");

        //                        UpdatePackageOnlinePayment(updatePayment.usm.user_subscribe_master_id);
        //                        contextsdce.user_cart_details.RemoveRange(contextsdce.user_cart_details.Where(c => c.user_id == updatePayment.usm.user_id));
        //                        contextsdce.SaveChanges();
        //                    }
        //                }

        //            }
        //            else
        //            {
        //                result = 0;
        //            }
        //        }
        //        if (result == 1)
        //        {
        //            return "1";
        //        }
        //        else
        //        {
        //            return "0";
        //        }
        //    }
        //    catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
        //    {
        //        Exception raise = dbEx;
        //        foreach (var validationErrors in dbEx.EntityValidationErrors)
        //        {
        //            foreach (var validationError in validationErrors.ValidationErrors)
        //            {
        //                string message = string.Format("{0}:{1}",
        //                    validationErrors.Entry.Entity.ToString(),
        //                    validationError.ErrorMessage);
        //                // raise a new exception nesting  
        //                // the current instance as InnerException  
        //                raise = new InvalidOperationException(message, raise);
        //            }
        //        }
        //        Log.WriteLogMessage(PageName, "UpdatePayment", "UpdatePayment", raise.Message, "error");
        //        Log.WriteLogMessage(PageName, "UpdatePayment", "UpdatePayment", raise.InnerException.Message, "error");
        //        throw raise;
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.WriteLogMessage(PageName, "UpdatePayment", "UpdatePayment", ex.Message, "error");
        //        Log.WriteLogMessage(PageName, "UpdatePayment", "UpdatePayment", ex.InnerException.Message, "error");
        //        return "0";
        //    }


        //}

        public string UpdatePackageOnlinePayment(long userSubscribeMasterId)
        {

            // Log.WriteLogMessage("PaymentService", "UpdatePackageOnlinePayment", "after if UpdatePackageOnlinePayment", "" + userSubscribeMasterId, "error");

            List<purchase_activationmaster> ActivationKeys = new List<purchase_activationmaster>();
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                List<int> PaymentStatus = new List<int>() { 2, 4 };
                using (var transaction = contextsdce.Database.BeginTransaction())
                {
                    try
                    {

                        // map subjects once it activated

                        List<saveSubjeDetails> saveSubjct = new List<saveSubjeDetails>();
                        List<saveSubjeDetails> saveSubjct1 = new List<saveSubjeDetails>();
                        List<saveSubjeDetails> saveSubjct2 = new List<saveSubjeDetails>();
                        List<saveSubjeDetails> saveSubjct3 = new List<saveSubjeDetails>();
                        List<saveSubjeDetails> saveSubjct4 = new List<saveSubjeDetails>();
                        saveSubjct1 = (from usm in contextsdce.user_subscribe_master
                                       join usd in contextsdce.user_subscribe_details on usm.user_subscribe_master_id equals usd.user_subscribe_master_id
                                       join pm in contextsdce.package_master on usd.package_id equals pm.package_id
                                       join dm in contextsdce.department_master on pm.department_id equals dm.department_id
                                       join sm in contextsdce.subject_master on pm.subject_id equals sm.subject_id
                                       join sbum in contextsdce.subject_unit_master on sm.subject_id equals sbum.subject_id
                                       where usm.user_subscribe_master_id == userSubscribeMasterId
                                             && sm.active_status == 1 && sbum.active_status == 1 && pm.is_bundle == 0
                                             && PaymentStatus.Contains(usm.payment_status) && usm.TransactionType == 2 && pm.subject_unit_type == sbum.subject_unit_type && pm.subject_unit_type != 3
                                       select new saveSubjeDetails
                                       {
                                           subj_ID = sm.subject_id,
                                           sub_Code = sm.subject_code,
                                           subj_Name = sm.subject_name,
                                           subj_CoverParth = sm.subject_cover_path,
                                           subj_Version = sm.subject_version,
                                           subjUnit_ID = sbum.unit_id,
                                           subjUnit_code = sbum.unit_code,
                                           subjUnit_Name = sbum.unit_name,
                                           subjUnit_Path = sbum.subject_unit_path,
                                           subjUnit_version = sbum.subject_unit_version,
                                           subjUnit_usrVersion = sbum.subject_unit_version,
                                           deprtId = dm.department_id,
                                           deprtCode = dm.department_code,
                                           deprtName = dm.department_name,
                                           isDemo = sbum.is_demo,
                                           unit_orIdx = sbum.is_unit_or_index,
                                           activesubjdays = pm.package_duration_days,
                                           activDurDate = DateTime.Now,
                                           released_On = sm.released_on,
                                           user_ID = (int)usm.user_id,
                                           is_updated_to_client = 1,
                                           LastmodifiedOn = DateTime.Now,
                                           LastClientUpdatedOn = DateTime.Now,
                                           LastSubunitModifiedOn = DateTime.Now,
                                           IsUpdatedSubunitToClient = 1,
                                           LastSubunitClientUpdatedOn = DateTime.Now,
                                           YearSem = pm.semester
                                       }).Distinct().ToList();

                        string[] subjectunittype = { "1", "2" };
                        saveSubjct2 = (from usm in contextsdce.user_subscribe_master
                                       join usd in contextsdce.user_subscribe_details on usm.user_subscribe_master_id equals usd.user_subscribe_master_id
                                       join pm in contextsdce.package_master on usd.package_id equals pm.package_id
                                       join dm in contextsdce.department_master on pm.department_id equals dm.department_id
                                       join sm in contextsdce.subject_master on pm.subject_id equals sm.subject_id
                                       join sbum in contextsdce.subject_unit_master on sm.subject_id equals sbum.subject_id
                                       where usm.user_subscribe_master_id == userSubscribeMasterId
                                             && sm.active_status == 1 && sbum.active_status == 1 && pm.is_bundle == 0
                                              && PaymentStatus.Contains(usm.payment_status) && usm.TransactionType == 2 && pm.subject_unit_type == 3 && subjectunittype.Contains(sbum.subject_unit_type.ToString())
                                       select new saveSubjeDetails
                                       {
                                           subj_ID = sm.subject_id,
                                           sub_Code = sm.subject_code,
                                           subj_Name = sm.subject_name,
                                           subj_CoverParth = sm.subject_cover_path,
                                           subj_Version = sm.subject_version,
                                           subjUnit_ID = sbum.unit_id,
                                           subjUnit_code = sbum.unit_code,
                                           subjUnit_Name = sbum.unit_name,
                                           subjUnit_Path = sbum.subject_unit_path,
                                           subjUnit_version = sbum.subject_unit_version,
                                           subjUnit_usrVersion = sbum.subject_unit_version,
                                           deprtId = dm.department_id,
                                           deprtCode = dm.department_code,
                                           deprtName = dm.department_name,
                                           isDemo = sbum.is_demo,
                                           unit_orIdx = sbum.is_unit_or_index,
                                           activesubjdays = pm.package_duration_days,
                                           activDurDate = DateTime.Now,
                                           released_On = sm.released_on,
                                           user_ID = (int)usm.user_id,
                                           is_updated_to_client = 1,
                                           LastmodifiedOn = DateTime.Now,
                                           LastClientUpdatedOn = DateTime.Now,
                                           LastSubunitModifiedOn = DateTime.Now,
                                           IsUpdatedSubunitToClient = 1,
                                           LastSubunitClientUpdatedOn = DateTime.Now,
                                           YearSem = pm.semester
                                       }).Distinct().ToList();

                        saveSubjct3 = (from usm in contextsdce.user_subscribe_master
                                       join usd in contextsdce.user_subscribe_details on usm.user_subscribe_master_id equals usd.user_subscribe_master_id
                                       join pm in contextsdce.package_master on usd.package_id equals pm.package_id
                                       join pd in contextsdce.package_details on pm.package_id equals pd.package_id
                                       join dm in contextsdce.department_master on pm.department_id equals dm.department_id
                                       join sm in contextsdce.subject_master on pd.subject_id equals sm.subject_id
                                       join sbum in contextsdce.subject_unit_master on sm.subject_id equals sbum.subject_id
                                       where usm.user_subscribe_master_id == userSubscribeMasterId
                                             && sm.active_status == 1 && sbum.active_status == 1 && pm.is_bundle == 1 && PaymentStatus.Contains(usm.payment_status)
                                             && usm.TransactionType == 2 && pm.subject_unit_type == sbum.subject_unit_type && pm.subject_unit_type != 3
                                       select new saveSubjeDetails
                                       {
                                           subj_ID = sm.subject_id,
                                           sub_Code = sm.subject_code,
                                           subj_Name = sm.subject_name,
                                           subj_CoverParth = sm.subject_cover_path,
                                           subj_Version = sm.subject_version,
                                           subjUnit_ID = sbum.unit_id,
                                           subjUnit_code = sbum.unit_code,
                                           subjUnit_Name = sbum.unit_name,
                                           subjUnit_Path = sbum.subject_unit_path,
                                           subjUnit_version = sbum.subject_unit_version,
                                           subjUnit_usrVersion = sbum.subject_unit_version,
                                           deprtId = dm.department_id,
                                           deprtCode = dm.department_code,
                                           deprtName = dm.department_name,
                                           isDemo = sbum.is_demo,
                                           unit_orIdx = sbum.is_unit_or_index,
                                           activDurDate = DateTime.Now,
                                           activesubjdays = pm.package_duration_days,
                                           released_On = sm.released_on,
                                           user_ID = (int)usm.user_id,
                                           is_updated_to_client = 1,
                                           LastmodifiedOn = DateTime.Now,
                                           LastClientUpdatedOn = DateTime.Now,
                                           LastSubunitModifiedOn = DateTime.Now,
                                           IsUpdatedSubunitToClient = 1,
                                           LastSubunitClientUpdatedOn = DateTime.Now,
                                           YearSem = pm.semester
                                       }).Distinct().ToList();


                        saveSubjct4 = (from usm in contextsdce.user_subscribe_master
                                       join usd in contextsdce.user_subscribe_details on usm.user_subscribe_master_id equals usd.user_subscribe_master_id
                                       join pm in contextsdce.package_master on usd.package_id equals pm.package_id
                                       join pd in contextsdce.package_details on pm.package_id equals pd.package_id
                                       join dm in contextsdce.department_master on pm.department_id equals dm.department_id
                                       join sm in contextsdce.subject_master on pd.subject_id equals sm.subject_id
                                       join sbum in contextsdce.subject_unit_master on sm.subject_id equals sbum.subject_id
                                       where usm.user_subscribe_master_id == userSubscribeMasterId
                                             && sm.active_status == 1 && sbum.active_status == 1 && pm.is_bundle == 1 && PaymentStatus.Contains(usm.payment_status)
                                             && usm.TransactionType == 2 && subjectunittype.Contains(sbum.subject_unit_type.ToString()) && pm.subject_unit_type == 3
                                       select new saveSubjeDetails
                                       {
                                           subj_ID = sm.subject_id,
                                           sub_Code = sm.subject_code,
                                           subj_Name = sm.subject_name,
                                           subj_CoverParth = sm.subject_cover_path,
                                           subj_Version = sm.subject_version,
                                           subjUnit_ID = sbum.unit_id,
                                           subjUnit_code = sbum.unit_code,
                                           subjUnit_Name = sbum.unit_name,
                                           subjUnit_Path = sbum.subject_unit_path,
                                           subjUnit_version = sbum.subject_unit_version,
                                           subjUnit_usrVersion = sbum.subject_unit_version,
                                           deprtId = dm.department_id,
                                           deprtCode = dm.department_code,
                                           deprtName = dm.department_name,
                                           isDemo = sbum.is_demo,
                                           unit_orIdx = sbum.is_unit_or_index,
                                           activDurDate = DateTime.Now,
                                           activesubjdays = pm.package_duration_days,
                                           released_On = sm.released_on,
                                           user_ID = (int)usm.user_id,
                                           is_updated_to_client = 1,
                                           LastmodifiedOn = DateTime.Now,
                                           LastClientUpdatedOn = DateTime.Now,
                                           LastSubunitModifiedOn = DateTime.Now,
                                           IsUpdatedSubunitToClient = 1,
                                           LastSubunitClientUpdatedOn = DateTime.Now,
                                           YearSem = pm.semester
                                       }).Distinct().ToList();

                        saveSubjct = saveSubjct.Union(saveSubjct1).Distinct().ToList();
                        saveSubjct = saveSubjct.Union(saveSubjct2).Distinct().ToList();
                        saveSubjct = saveSubjct.Union(saveSubjct3).Distinct().ToList();
                        saveSubjct = saveSubjct.Union(saveSubjct4).Distinct().ToList();
                        foreach (var k in saveSubjct)
                        {
                            user_subject_mapping usbm = new user_subject_mapping();
                            usbm.subject_id = (int)k.subj_ID;
                            usbm.subject_code = k.sub_Code;
                            usbm.subject_name = k.subj_Name;
                            usbm.subject_cover_path = k.subj_CoverParth;
                            usbm.subject_version = k.subj_Version;
                            usbm.subject_unit_version = k.subjUnit_usrVersion;
                            usbm.subject_unit_user_version = k.subjUnit_usrVersion;
                            usbm.subject_unit_id = (int)k.subjUnit_ID;
                            usbm.subject_unit_code = k.subjUnit_code;
                            usbm.subject_unit_name = k.subjUnit_Name;
                            usbm.subject_unit_path = k.subjUnit_Path;
                            usbm.is_demo = k.isDemo;
                            usbm.department_code = k.deprtCode;
                            usbm.department_name = k.deprtName;
                            usbm.department_id = k.deprtId;
                            usbm.is_unit_or_index = k.unit_orIdx;
                            usbm.subject_purchasedon = DateTime.Now;
                            usbm.downloaded_on = DateTime.Now;
                            usbm.download_status = 1;
                            usbm.user_id = k.user_ID;
                            usbm.is_updated_to_client = 1;
                            usbm.last_modified_on = k.LastmodifiedOn;
                            usbm.last_client_updated_on = k.LastClientUpdatedOn;
                            usbm.is_updated_subunit_to_client = k.IsUpdatedSubunitToClient;
                            usbm.last_subunit_modified_on = k.LastSubunitModifiedOn;
                            usbm.last_subunit_client_updated_on = k.LastSubunitClientUpdatedOn;
                            DateTime actDuration = DateTime.Now.AddDays(k.activesubjdays);
                            DateTime actSubjdays = DateTime.Now.AddDays(k.activesubjdays);
                            usbm.subject_unit_expiryon = actSubjdays;
                            usbm.package_expirydate = actSubjdays;
                            usbm.is_purchased = 1;
                            usbm.yearsem = k.YearSem;
                            //  contextsdce.user_subject_mapping.Add(usbm);
                            contextsdce.user_subject_mapping.AddOrUpdate(u => new { u.user_id, u.subject_unit_id }, usbm);
                        }

                        int result = contextsdce.SaveChanges();
                        transaction.Commit();
                        //
                        if (result > 0)
                        {
                            return "1";
                        }
                        else
                        {
                            return "0";
                        }

                    }
                    catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                    {
                        Exception raise = dbEx;
                        foreach (var validationErrors in dbEx.EntityValidationErrors)
                        {
                            foreach (var validationError in validationErrors.ValidationErrors)
                            {
                                string message1 = string.Format("{0}:{1}",
                                    validationErrors.Entry.Entity.ToString(),
                                    validationError.ErrorMessage);
                                // raise a new exception nesting  
                                // the current instance as InnerException  
                                raise = new InvalidOperationException(message1, raise);
                                Log.WriteLogMessage(PageName, "Student", "UpdateActivationCodeForPurchase", message1, "error");
                            }
                        }
                        Log.WriteLogMessage(PageName, "Student", "UpdateActivationCodeForPurchase", raise.Message.ToString(), "error");
                        // throw raise;
                        return "";
                    }

                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        transaction.Dispose();
                        contextsdce.Dispose();
                        Log.WriteLogMessage(PageName, "Student", "UpdateActivationCodeForPurchase", ex.Message, "error");
                        return ""; // Failure
                    }

                    finally
                    {
                        transaction.Dispose();
                        contextsdce.Dispose();
                    }
                }
            }
        }


        #endregion



        public int GetOrderActivationStatus(int? usersubscribemasterid)
        {
            int resultreturn = 0;
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                try
                {

                    List<int> unitypes = new List<int>() { 1, 2, 4 };
                    List<int> unitypes2 = new List<int>() { 1, 2 };
                    List<int> PaymentStatus = new List<int>() { 2, 4 };

                    resultreturn += (from pm in contextsdce.payment_master
                                     join usm in contextsdce.user_subscribe_master on pm.ClintTxnRefNo equals usm.payment_ref_no
                                     join usd in contextsdce.user_subscribe_details on usm.user_subscribe_master_id equals usd.user_subscribe_master_id
                                     join p in contextsdce.package_master on usd.package_id equals p.package_id
                                     join sm in contextsdce.subject_master on p.subject_id equals sm.subject_id
                                     //join dm in contextsdce.department_master on p.department_id equals dm.department_id
                                     join sunit in contextsdce.subject_unit_master on sm.subject_id equals sunit.subject_id
                                     join usmm in contextsdce.user_subject_mapping on usm.user_id equals usmm.user_id
                                     where PaymentStatus.Contains(usm.payment_status) && pm.TxnStatus.Equals("2") && p.is_bundle == 0 && p.subject_id == usmm.subject_id && sunit.unit_id == usmm.subject_unit_id
                                     && p.subject_unit_type == sunit.subject_unit_type && unitypes.Contains((int)sunit.subject_unit_type) && p.subject_unit_type != 3
                                     && usm.user_subscribe_master_id == usersubscribemasterid

                                     select new { pm }).Count();


                    resultreturn += (from pm in contextsdce.payment_master
                                     join usm in contextsdce.user_subscribe_master on pm.ClintTxnRefNo equals usm.payment_ref_no
                                     join usd in contextsdce.user_subscribe_details on usm.user_subscribe_master_id equals usd.user_subscribe_master_id
                                     join p in contextsdce.package_master on usd.package_id equals p.package_id
                                     join sm in contextsdce.subject_master on p.subject_id equals sm.subject_id
                                     join dm in contextsdce.department_master on p.department_id equals dm.department_id
                                     join sunit in contextsdce.subject_unit_master on sm.subject_id equals sunit.subject_id
                                     join usmm in contextsdce.user_subject_mapping on usm.user_id equals usmm.user_id
                                     where PaymentStatus.Contains(usm.payment_status) && pm.TxnStatus.Equals("2") && p.is_bundle == 0 && p.subject_id == usmm.subject_id && sunit.unit_id == usmm.subject_unit_id
                                    && p.subject_unit_type == 3 && unitypes2.Contains((int)sunit.subject_unit_type)
                                    && usm.user_subscribe_master_id == usersubscribemasterid

                                     select new { pm }).Count();

                    resultreturn += (from pm in contextsdce.payment_master
                                     join usm in contextsdce.user_subscribe_master on pm.ClintTxnRefNo equals usm.payment_ref_no
                                     join usd in contextsdce.user_subscribe_details on usm.user_subscribe_master_id equals usd.user_subscribe_master_id
                                     join p in contextsdce.package_master on usd.package_id equals p.package_id
                                     join pd in contextsdce.package_details on p.package_id equals pd.package_id
                                     join sm in contextsdce.subject_master on pd.subject_id equals sm.subject_id
                                     join dm in contextsdce.department_master on p.department_id equals dm.department_id
                                     join sunit in contextsdce.subject_unit_master on sm.subject_id equals sunit.subject_id
                                     join usmm in contextsdce.user_subject_mapping on usm.user_id equals usmm.user_id
                                     where PaymentStatus.Contains(usm.payment_status) && pm.TxnStatus.Equals("2") && p.is_bundle == 1 && pd.subject_id == usmm.subject_id && sunit.unit_id == usmm.subject_unit_id
                                    && p.subject_unit_type == sunit.subject_unit_type && unitypes.Contains((int)sunit.subject_unit_type)
                                    && usm.user_subscribe_master_id == usersubscribemasterid

                                     select new { pm }).Count();




                }
                catch (Exception ex)
                {
                    contextsdce.Dispose();
                    Log.WriteLogMessage(PageName, "PaymentService", "GetOrderActivationStatus", ex.Message, "error");
                    Log.WriteLogMessage(PageName, "PaymentService", "GetOrderActivationStatus", ex.InnerException.Message, "error");
                    throw;
                }
                finally
                {
                    contextsdce.Dispose();
                }
            }
            return resultreturn;
        }



        public List<OrderSummary> GetOrderSummary(int? usersubscribemasterid)
        {
            List<OrderSummary> orderDetails = new List<OrderSummary>();

            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                try
                {
                    // Order Activation (Order succes but subject activation may not happen).. calling the activation method
                    if (GetOrderActivationStatus(usersubscribemasterid) == 0)
                    {
                        UpdatePackageOnlinePayment((long)usersubscribemasterid);
                    }

                    // Get Order Details

                    var viewOrdersummary = (from usm in contextsdce.user_subscribe_master
                                            join pdm in contextsdce.promo_discount_master on usm.discount_id equals pdm.discount_id into lftpdm
                                            from pdm in lftpdm.DefaultIfEmpty()
                                            join usd in contextsdce.user_subscribe_details on usm.user_subscribe_master_id equals usd.user_subscribe_master_id
                                            join pm in contextsdce.package_master on usd.package_id equals pm.package_id

                                            join pd in contextsdce.package_details on pm.package_id equals pd.package_id into lftpd
                                            from pd in lftpd.DefaultIfEmpty()

                                            join sm in contextsdce.subject_master on pd.subject_id equals sm.subject_id into leftsm
                                            from sm in leftsm.DefaultIfEmpty()
                                            join sum in contextsdce.subject_unit_master on pm.subject_id equals sum.subject_id
                                            join um in contextsdce.user_master on usm.user_id equals um.user_id
                                            join umm in contextsdce.university_master on um.univ_id equals umm.univ_id
                                            join uadb in contextsdce.user_address_details on usm.billing_address_id equals uadb.delivery_address_id
                                            into uaddb
                                            from uadb in uaddb.DefaultIfEmpty()
                                            join uadd in contextsdce.user_address_details on usm.deliver_address_id equals uadd.delivery_address_id
                                            into uaddr
                                            from uadd in uaddr.DefaultIfEmpty()
                                            join cm in contextsdce.country_master on uadd.country equals cm.country_id
                                            into ccm
                                            from cm in ccm.DefaultIfEmpty()
                                            join usdm in contextsdce.user_subscribe_delivery_mode on usm.user_subscribe_delivery_mode_id equals usdm.user_subscribe_delivery_mode_id
                                            join pay in contextsdce.payment_master on usm.user_subscribe_master_id equals pay.user_subscribe_master_id

                                            where usm.user_subscribe_master_id == usersubscribemasterid
                                            group new { usm, usd, pdm, um, umm, uadb, uadd, cm, pm, sm, usdm, pay, sum } by new { pm.package_id } into packgrp


                                            select new
                                            {
                                                packageID = packgrp.Key.package_id,

                                                subject = packgrp.OrderBy(x => x.sm.subject_name)
                                            });
                    int sumsubtotal = 0;
                    int packitems = 0;
                    int FinalTotal = 0;
                    int discountamt = 0;
                    int shippingcharge = 0;
                    foreach (var output in viewOrdersummary)
                    {
                        OrderSummary ord = new OrderSummary();
                        ord.packageid = output.packageID;
                        int itemcnt = 0;
                        string bundlesubj = "";

                        foreach (var res in output.subject)
                        {
                            if (res.sm != null && bundlesubj != res.sm.subject_name)
                            {
                                ord.bundlesubjects += (res.sm == null) ? "" : res.sm.univ_subject_code + "-" + res.sm.subject_name + ",";
                                bundlesubj = res.sm.subject_name;
                            }
                            ord.UserId = res.usm.user_id;
                            ord.usersubscribeid = res.usm.user_subscribe_master_id;
                            ord.ClientRefNo = res.usm.payment_ref_no;
                            ord.PckgpurchasedOn = res.usm.payment_on.ToString("dd-MM-yyyy");
                            ord.packagename = res.pm.package_name;
                            ord.operatingsystem = res.pm.os_type == 1 ? "Windows" : "Android";
                            ord.DeliveryMode = res.usdm.subscribe_delivery_mode;
                            ord.discountcode = res.pdm == null ? "NA" : res.pdm.discount_code;
                            ord.discountamt = res.usd == null ? 0 : res.usd.promo_discount_amt;
                            //  ord.pckgTotal = viewOrdersummary.Select(x => x.sellingprice).Sum() + s.ShippingPrice - Convert.ToInt32(s.discountamt),
                            ord.discountprice = (res.usd.actual_price - res.usd.selling_price);

                            ord.paymentmode = res.usm.TransactionType == 1 ? "Cash On Delivery" : "Online Payment";
                            ord.sellingprice = res.usd.selling_price;
                            ord.Actuallprice = res.usd.actual_price;
                            ord.ShippingPrice = res.usdm.price;
                            ord.UserBillingName = res.uadb == null ? "" : res.uadb.full_name;
                            ord.UserBillingaddress = res.uadb == null ? "" : res.uadb.address;
                            ord.UserBillingpincode = res.uadb == null ? (long?)null : res.uadb.pincode;
                            ord.UserBillingCity = res.uadb == null ? "" : res.uadb.city;
                            ord.UserBillingState = res.uadb == null ? "" : res.uadb.state;
                            ord.UserBillingCountry = res.cm == null ? "" : res.cm.country_name;
                            ord.UserBilingMobileno = res.uadb == null ? (long?)null : res.uadb.mobile_number;
                            ord.UserDeliveryName = res.uadd == null ? "" : res.uadd.full_name;
                            ord.UserDeliveryaddress = res.uadd == null ? "" : res.uadd.address;
                            ord.UserDeliverypincode = res.uadd == null ? (long?)null : res.uadd.pincode;
                            ord.UserDeliveryCity = res.uadd == null ? "" : res.uadd.city;
                            ord.UserDeliveryState = res.uadd == null ? "" : res.uadd.state;
                            ord.UserDeliveryCountry = res.cm == null ? "" : res.cm.country_name;
                            ord.UserDeliveryMobileno = res.uadd == null ? (long?)null : res.uadd.mobile_number;
                            ord.MobileNumber = res.um.mobile;
                            ord.Emailid = res.um.email_id;
                            ord.bundle = res.pm.is_bundle;
                            ord.universityname = res.umm.university_name;
                            ord.paymenttype = res.pay.TxnStatus;
                            if (res.pm.subject_unit_type == 4 && res.sum.subject_unit_type == 4)
                            {
                                ord.subjectunitpath_sms = res.pm.os_type == 2 ? res.sum.subject_unit_path : "NoFilePath";
                                ord.subjectunitpath_mail = res.pm.os_type == 2 ? ConfigurationManager.AppSettings["SubjectUnitPath"].ToString() + res.sum.subject_unit_path : "NoFilePath";
                            }
                            else if (res.pm.subject_unit_type != 4)
                            {
                                ord.subjectunitpath_sms = "NoFilePath";
                                ord.subjectunitpath_mail = "NoFilePath";
                            }
                            if (itemcnt == 0)
                            {
                                sumsubtotal = sumsubtotal + res.usd.selling_price;
                                discountamt = res.usd.promo_discount_amt == null ? 0 : (Int32)res.usd.promo_discount_amt;
                                shippingcharge = res.usdm.price;
                            }

                            itemcnt++;


                        }
                        if (ord.bundlesubjects != null && ord.bundlesubjects.Length > 0)
                        {
                            ord.bundlesubjects = ord.bundlesubjects.Substring(0, ord.bundlesubjects.Length - 1);
                        }
                        packitems++;
                        orderDetails.Add(ord);
                    }

                    FinalTotal = sumsubtotal - discountamt + shippingcharge;
                    orderDetails.ToList().ForEach(c => c.pckgSubTotal = sumsubtotal);
                    orderDetails.ToList().ForEach(c => c.pckgTotal = FinalTotal);


                    return orderDetails;
                }
                catch (Exception ex)
                {
                    contextsdce.Dispose();
                    Log.WriteLogMessage(PageName, "PaymentService", "GetViewCartDetails", ex.Message, "error");
                    Log.WriteLogMessage(PageName, "PaymentService", "GetViewCartDetails", ex.InnerException.Message, "error");
                    throw;
                }
                finally
                {
                    contextsdce.Dispose();
                }
            }

        }

        /// <summary>
        /// CancelOrderConfirmation with OTP submission
        /// </summary>
        /// <param name="usersubscribemasterid"></param>
        /// <returns></returns>
        public int CancelOrderConfirmation(int usersubscribemasterid)
        {
            int data = 0;
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                try
                {
                   

                    var UpdateStatuscancelorders = (from usm in contextsdce.user_subscribe_master
                                                    join usd in contextsdce.user_subscribe_details on usm.user_subscribe_master_id equals usd.user_subscribe_master_id
                                                    join uot in contextsdce.user_subscribe_order_track on usm.user_subscribe_master_id equals uot.user_subscribe_master_id
                                                    where usm.user_subscribe_master_id == usersubscribemasterid
                                                    select new { usm, uot, usd }).Distinct().ToList();

                    if (UpdateStatuscancelorders != null)
                    {
                        UpdateStatuscancelorders.ForEach(x => x.usm.order_status = 2);
                        UpdateStatuscancelorders.ForEach(x => x.uot.orderstatus = 2);
                        UpdateStatuscancelorders.ForEach(x => x.usd.deliver_status = 2);
                        data = contextsdce.SaveChanges();
                    }
                   
                }
                catch (Exception ex)
                {

                    contextsdce.Dispose();
                    Log.WriteLogMessage(PageName, "PaymentService", "CancelOrderConfirmation", ex.Message, "error");
                   
                }
                finally
                {
                    contextsdce.Dispose();
                }
            }
            return data;
        }

        public int VerifyCancelOrderOTP(string orderId, string otpcode, int action_userId, string cancel_category)
        {
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                try
                {
                    var otpverify = (from ocrp in contextsdce.order_cancel_random_pass
                                     where ocrp.verification_code == otpcode && ocrp.order_ref_no == orderId
                                     select ocrp).FirstOrDefault();

                    if (otpverify != null)
                    {
                        var subscribedetails = (from usm in contextsdce.user_subscribe_master where usm.payment_ref_no == otpverify.order_ref_no select usm).FirstOrDefault();

                        int subscribedId = Convert.ToInt32(subscribedetails.user_subscribe_master_id);

                        string order_Id = subscribedetails.payment_ref_no;

                        int orderReulst = CancelOrderConfirmation(subscribedId);

                        if (orderReulst == 1)
                        {
                            CanelOrderHistory(order_Id, action_userId, cancel_category);
                        }
                        return orderReulst;
                    }
                    else
                    {
                        return -2;
                    }
                }
                catch (Exception ex)
                {
                    contextsdce.Dispose();
                    Log.WriteLogMessage(PageName, "PaymentService", "VerifyCancelOrderOTP", ex.Message, "error");
                    throw;
                }
                finally
                {
                    contextsdce.Dispose();
                }
            }
        }

        public int CanelOrderHistory(string orderId, int action_user_id, string canelcategory)
        {
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                int result = 0;
                try
                {
                    order_cancel_history och = new order_cancel_history();
                    och.cancelled_by = action_user_id;
                    och.cancelled_on = DateTime.Now;
                    och.order_ref_no = orderId;
                    och.category = canelcategory;
                    och.reason = "";
                    contextsdce.order_cancel_history.Add(och);
                    result = contextsdce.SaveChanges();
                    if (result > 0)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }

                }
                catch (Exception ex)
                {
                    contextsdce.Dispose();
                    Log.WriteLogMessage(PageName, "PaymentService", "CanelOrderHistory", ex.Message, "error");
                    throw;
                }
                finally
                {
                    contextsdce.Dispose();
                }

            }
        }


        public List<country> GetCountry()
        {
            List<country> country = new List<country>();
            try
            {
                using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
                {
                    country = (from cm in contextsdce.country_master
                               select new country
                               {
                                   countryid = cm.country_id,
                                   countryname = cm.country_name
                               }).ToList();

                }

                return country;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
                return country;
            }

        }
        /// <summary>
        /// GetOrderDetails for overall order details
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="OrderStatus"></param>
        /// <returns></returns>
        public List<OrderSummary> GetOrderDetails(int userid, int OrderStatus)
        {
            List<OrderSummary> orderDetails = new List<OrderSummary>();
            try
            {
                using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
                {
                    var order = (from usm in contextsdce.user_subscribe_master
                                 join usd in contextsdce.user_subscribe_details on usm.user_subscribe_master_id equals usd.user_subscribe_master_id
                                 join pay in contextsdce.payment_master on usm.user_subscribe_master_id equals pay.user_subscribe_master_id
                                 join pm in contextsdce.package_master on usd.package_id equals pm.package_id
                                 join usdm in contextsdce.user_subscribe_delivery_mode on usm.user_subscribe_delivery_mode_id equals usdm.user_subscribe_delivery_mode_id
                                 where usm.user_id == userid
                                 select new
                                 {
                                     usersubscribeid = usm.user_subscribe_master_id,
                                     orderstsus = usd.deliver_status,
                                     ClientRefNo = usm.payment_ref_no,
                                     pckgetransdate = pay.TxnDate,
                                     paymentstatus = usm.payment_status,
                                     packageid = pm.package_id,
                                     Amount = usd.selling_price,
                                     deliveryshippingCharges = usdm.price,
                                     totalPrice = pay.TxnAmount,
                                     txnstauts = pay.TxnStatus,
                                     ProductStatus = usm.payment_status
                                 }).ToList();

                    if (OrderStatus == 1)
                    {
                        var datanew = order.ToList();
                        order.Clear();
                        order.AddRange(datanew.Where(x => x.orderstsus == OrderStatus));
                    }

                    if (OrderStatus == 2)
                    {
                        var datanew = order.ToList();
                        order.Clear();
                        order.AddRange(datanew.Where(x => x.orderstsus == OrderStatus));

                    }
                    else if (OrderStatus == 3)
                    {
                        var datanew = order.ToList();
                        order.Clear();
                        order.AddRange(datanew.Where(x => x.orderstsus != 2));
                    }

                    orderDetails = (from t in order
                                    group t by t.ClientRefNo into s
                                    select new OrderSummary
                                    {
                                        usersubscribeid = s.FirstOrDefault().usersubscribeid,
                                        packageid = s.FirstOrDefault().packageid,
                                        ClientRefNo = s.FirstOrDefault().ClientRefNo,
                                        pckgetransdate = s.FirstOrDefault().pckgetransdate.ToString("dd-MM-yyyy"),
                                        pckgecount = s.Select(x => x.packageid).Count(),
                                        Amount = s.Select(x => x.Amount).Sum(),
                                        ProductStatus = s.FirstOrDefault().ProductStatus == 1 ? "Process Initiated" : s.FirstOrDefault().ProductStatus == 2 ? "Success" : Convert.ToInt16(s.FirstOrDefault().txnstauts) == 3 ? "Failure" : "Delivered",
                                        OrderStatus = OrderStatus,
                                        paymentStatus = s.FirstOrDefault().paymentstatus == 2 ? "Details" : s.FirstOrDefault().paymentstatus == 1 ? "ReVerify" : "-",
                                        DeliveryshippingCharges = s.FirstOrDefault().deliveryshippingCharges,
                                        TotalPrice = s.FirstOrDefault().totalPrice

                                    }).Distinct().ToList();
                }

                return orderDetails;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
            catch (Exception ex)
            {
                return orderDetails;
                throw ex;
            }
        }

        public List<OrderSummary> GetPopupOrderDetails(int userid, int OrderStatus, string OrderId)
        {
            List<OrderSummary> orderDetails = new List<OrderSummary>();
            try
            {
                using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
                {
                    var order = (from usm in contextsdce.user_subscribe_master
                                 join pdm in contextsdce.promo_discount_master on usm.discount_id equals pdm.discount_id into lftpdm
                                 from pdm in lftpdm.DefaultIfEmpty()
                                 join usd in contextsdce.user_subscribe_details on usm.user_subscribe_master_id equals usd.user_subscribe_master_id
                                 join pm in contextsdce.package_master on usd.package_id equals pm.package_id
                                 join um in contextsdce.user_master on usm.user_id equals um.user_id
                                 join uadb in contextsdce.user_address_details on usm.billing_address_id equals uadb.delivery_address_id
                                 into uaddb
                                 from uadb in uaddb.DefaultIfEmpty()
                                 join uadd in contextsdce.user_address_details on usm.deliver_address_id equals uadd.delivery_address_id
                                 into uaddr
                                 from uadd in uaddr.DefaultIfEmpty()
                                 join cm in contextsdce.country_master on uadd.country equals cm.country_id
                                 into ccm
                                 from cm in ccm.DefaultIfEmpty()
                                 join usdm in contextsdce.user_subscribe_delivery_mode on usm.user_subscribe_delivery_mode_id equals usdm.user_subscribe_delivery_mode_id
                                 //   join payment_master pay on usm.user_subscribe_master_id = pay.user_subscribe_master_id
                                 where usm.user_id == userid && usm.payment_ref_no == OrderId
                                 //by usm.payment_ref_no into g
                                 select new
                                 {
                                     userid = usm.user_id,
                                     orderstsus = usd.deliver_status,
                                     ClientRefNo = usm.payment_ref_no,
                                     paymentstatus = usm.payment_status,
                                     packageexpiryon = usd.package_expiryon,
                                     PckgpurchasedOn = usm.payment_on,
                                     packagename = pm.package_name,
                                     pckgeCoverpath = pm.cover_path,
                                     Amount = usd.selling_price,
                                     discountcode = pdm.discount_code,
                                     discountamt = usm.discount_amt,
                                     //  ProductStatus = Convert.ToInt32(pay.TxnStatus) == 1 ? "PaymentInProgress" : Convert.ToInt32(pay.TxnStatus) == 2 ? "Cancel" : Convert.ToInt32(pay.TxnStatus) == 3 ? "Failure" : "Delivered",
                                     DeliveryMode = usdm.subscribe_delivery_mode,
                                     paymentmode = usm.TransactionType == 1 ? "Cash On Delivery" : "Online Payment",
                                     sellingprice = pm.selling_price,
                                     ShippingPrice = usdm.price,
                                     UserBillingName = uadb == null ? "" : uadb.full_name,
                                     UserBillingaddress = uadb == null ? "" : uadb.address,
                                     UserBillingCity = uadb == null ? "" : uadb.city,
                                     UserBillingState = uadb == null ? "" : uadb.state,
                                     UserBillingCountry = cm == null ? "" : cm.country_name,
                                     UserBilingMobileno = uadb == null ? (long?)null : uadb.mobile_number,
                                     UserDeliveryName = uadd == null ? "" : uadd.full_name,
                                     UserDeliveryaddress = uadd == null ? "" : uadd.address,
                                     UserDeliverypincode = uadd == null ? (long?)null : uadd.pincode,
                                     UserDeliveryCity = uadd == null ? "" : uadd.city,
                                     UserDeliveryState = uadd == null ? "" : uadd.state,
                                     UserDeliveryCountry = uadd == null ? "" : cm.country_name,
                                     UserDeliveryMobileno = uadd == null ? (long?)null : uadd.mobile_number,
                                     Operatingsystemtype = pm.os_type == 1 ? "Windows" : "Android"
                                 }).ToList();

                    if (OrderStatus == 1)
                    {
                        var datanew = order.ToList();
                        order.Clear();
                        order.AddRange(datanew.Where(x => x.orderstsus == OrderStatus));

                    }

                    if (OrderStatus == 2)
                    {
                        var datanew = order.ToList();
                        order.Clear();
                        order.AddRange(datanew.Where(x => x.orderstsus == OrderStatus));

                    }
                    else if (OrderStatus == 3)
                    {
                        var datanew = order.ToList();
                        order.Clear();
                        order.AddRange(datanew.Where(x => x.orderstsus != 2));
                    }

                    orderDetails = (from s in order
                                    select new OrderSummary
                                    {
                                        UserId = s.userid,
                                        ClientRefNo = s.ClientRefNo,
                                        PackageName = s.packagename,
                                        operatingsystem = s.Operatingsystemtype,
                                        pckgetransdate = s.PckgpurchasedOn.ToString("dd-MM-yyyy"),
                                        packageExpiryon = s.packageexpiryon.ToString("dd-MM-yyyy"),
                                        packagecpverpath = s.pckgeCoverpath,
                                        //pckgecount = s.Select(x => x.packageid).Count(),
                                        SellingPrice = s.Amount,
                                        Discountcode = s.discountcode,
                                        discountamt = s.discountamt,
                                        //ProductStatus = s.ProductStatus,
                                        DeliveryMode = s.DeliveryMode,
                                        paymentmode = s.paymentmode,
                                        ShippingPrice = s.ShippingPrice,
                                        pckgSubTotal = order.Select(x => x.sellingprice).Sum(),
                                        pckgTotal = order.Select(x => x.sellingprice).Sum() + s.ShippingPrice - Convert.ToInt32(s.discountamt),
                                        UserBillingName = s.UserBillingName,
                                        UserBillingaddress = s.UserBillingaddress,
                                        UserBillingCity = s.UserBillingCity,
                                        UserBillingState = s.UserBillingState,
                                        UserBillingCountry = s.UserBillingCountry,
                                        UserBilingMobileno = s.UserBilingMobileno,
                                        UserDeliveryName = s.UserDeliveryName,
                                        UserDeliveryaddress = s.UserDeliveryaddress,
                                        UserDeliverypincode = s.UserDeliverypincode,
                                        UserDeliveryCity = s.UserDeliveryCity,
                                        UserDeliveryState = s.UserDeliveryState,
                                        UserDeliveryCountry = s.UserDeliveryCountry,
                                        UserDeliveryMobileno = s.UserDeliveryMobileno
                                    }).Distinct().ToList();
                }

                return orderDetails;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
            catch (Exception ex)
            {
                return orderDetails;
            }
        }


        // send SMS and Email to get OTP for Cancellation process

        //public string COD_Cancellation(long buyer_mobileNo, string ToEmailID, string OrderID)
        //{
        //    string message = "";
        //    CallSendSMS ob = new CallSendSMS();
        //    //generate OTP and Email
        //    //send SMS to the User With Activation Code
        //    string OTP = GenerateVerificationCode(buyer_mobileNo, ToEmailID);
        //    ob.SendSMS(buyer_mobileNo + "", ob.SMS_orderCancellation_otp(OrderID, OTP), "");

        //    //Send Mail to User About his Activaiton Code
        //    string mailcontent = MailHelper.EmailBody_OTP("order Cancellation", buyer_mobileNo + "", OTP, "");
        //    MailHelper.SendMail(ToEmailID, "Learnengg - Order Cancellation one time password", mailcontent);
        //    message = OTP;
        //    return message;
        //}

        //// 7) send SMS and Email to get OTP for Cancellation process

        //public string COD_Cancellation_approved(long buyer_mobileNo, string ToEmailID, string OrderID)
        //{
        //    string message = "";
        //    CallSendSMS ob = new CallSendSMS();

        //    //  ob.SendSMS(buyer_mobileNo + "", ob.SMS_orderCancellationApprove(OrderID), "");

        //    //Send Mail to User About his Activaiton Code
        //    string mailcontent = MailHelper.EmailBody_Ordercancelled(OrderID);
        //    MailHelper.SendMail(ToEmailID, "Learnengg - Order Cancellation Approved", mailcontent);
        //    return message;
        //}

        //public string GenerateVerificationCode(long MobNo, string emailID)
        //{
        //    using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
        //    {
        //        try
        //        {

        //            var userdetails = (from userm in contextsdce.user_master where userm.mobile == MobNo && userm.email_id == emailID select userm).FirstOrDefault();

        //            if (userdetails != null)
        //            {

        //                CallSendSMS obj1 = new CallSendSMS();

        //                string sOTP = obj1.CreateRandomPassword(6);

        //                //Delete User Id if Already Exsist
        //                user_random_pass delurp = (from del in contextsdce.user_random_pass where del.user_id == userdetails.user_id && del.action_type == 1 select del).FirstOrDefault();
        //                if (delurp != null)
        //                {
        //                    //contextsdce.user_random_pass.DeleteObject(delurp);
        //                    contextsdce.user_random_pass.Remove(delurp);
        //                    contextsdce.SaveChanges();
        //                }


        //                //Inserting Random password to user_random_pass Generated in verificationcode
        //                user_random_pass urp = new user_random_pass();
        //                urp.verification_code = sOTP;
        //                urp.generated_time = DateTime.Now;
        //                urp.action_type = 1;
        //                urp.user_id = Convert.ToInt32(userdetails.user_id);
        //                //contextsdce.AddTouser_random_pass(urp);
        //                contextsdce.user_random_pass.Add(urp);
        //                contextsdce.SaveChanges();


        //                ////OTP send to Mobile Number
        //                //strPostResponse = obj1.SendSMS(MobNo.ToString().Trim(), "Please enter the OTP :  " + sOTP + "  to complete your Installation process, Infoplus learnengg.com Support", emailID);


        //                ////OTP send to EMail

        //                //MailHelper.SendMail(emailID, "One Time PassWord", "Your ONE TIME PASSWORD is:    " + "<b>" + sOTP + "</b>" + "<br/>" + "  Please enter the OTP To complete Your Installation Process Infoplus learnengg.com support");

        //                //MailHelper.SendMail("infoplus.otp@gmail.com", userdetails.collegename.ToString().Trim() + " - One Time PassWord For Registration", "One Time Password For:    " + userdetails.email_id.ToString() + " and his/her mobile number is : " + userdetails.mobile.ToString().Trim() + " and OTP is : " + "<b>" + sOTP + " " + "</b>" + " </br></br></br></br> By </br><b> LearnEngg Team</b>");

        //                //XDocument xdoc = new XDocument(new XElement("OneTimePassword", new XElement("OTP",
        //                //                                  new XAttribute("OneTimePasswrod", sOTP))));


        //                return sOTP;
        //            }
        //            else
        //            {
        //                return "";
        //            }


        //        }
        //        catch (Exception ex)
        //        {
        //            Log.WriteLogMessage(PageName, "NewUserRegistration", "GetVerificationCode", ex.Message, "error");


        //            return "";

        //        }
        //        finally
        //        {
        //            if (contextsdce != null)
        //            {
        //                contextsdce.Dispose();
        //            }
        //        }
        //    }
        //}


        //4) Send SMS and Email once Order Conformed(Purchase Bill for Courier Coppy)

        public string OrderConformed(string buyer_mobileNo, string ToEmailID, string orderID, string emailContent, string SubjectName)
        {
            string message = "";
            CallSendSMS ob = new CallSendSMS();
            //generate OTP and Email
            //send SMS to the User With Activation Code

            ob.SendSMS(buyer_mobileNo + "", ob.SMS_ordersucessfully(orderID, SubjectName), "");

            //Send Mail to User About his Activaiton Code //changes available

            string mailcontent = MailHelper.EmailBody_Orderplaced(emailContent);
            MailHelper.SendMail(ToEmailID, "Learnengg - Order placed Sucessfully", mailcontent, ConfigurationManager.AppSettings["OrderBCC"].ToString());
            return message;
        }






        public string sendEmailOrderInvoice(string mobileno, string Emailid, string OrderID, string EmailContent, string SubjectName)
        {
            //email emailcontent = new email();
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {

                try
                {
                    OrderConformed(mobileno, Emailid, OrderID, EmailContent, SubjectName);
                    return "1";

                }
                catch (Exception ex)
                {
                    contextsdce.Dispose();
                    Log.WriteLogMessage(PageName, "PaymentService", "sendEmailOrderInvoice", ex.Message, "error");
                    throw;
                }
                finally
                {
                    contextsdce.Dispose();
                }
            }


        }
        /// <summary>
        /// OTP code for order cancellation using orderid
        /// </summary>
        /// <param name="actn_user_mobile"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public string CancelOrderOTP(long actn_user_mobile, string orderId)
        {
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                try
                {
                    var actionuser = (from um in contextsdce.user_master where um.mobile == actn_user_mobile select um).FirstOrDefault();

                    var cancelotp = (from usm in contextsdce.user_subscribe_master
                                     join um in contextsdce.user_master on usm.user_id equals um.user_id
                                     join usd in contextsdce.user_subscribe_details on usm.user_subscribe_master_id equals usd.user_subscribe_master_id
                                     where usm.payment_ref_no == orderId
                                     select new
                                     {
                                         orderAmnt = usd.selling_price,
                                         userid = um.user_id,
                                         usermobile = um.mobile
                                     }).FirstOrDefault();

                    if (cancelotp != null)
                    {
                        CallSendSMS obj1 = new CallSendSMS();
                        string strPostResponse;
                        string sOTP = obj1.CreateRandomPassword(5);

                        //delete userid and password if already exsist
                        order_cancel_random_pass delteotp = (from del in contextsdce.order_cancel_random_pass where del.buyer_user_id == cancelotp.userid && del.action_type == 1 select del).FirstOrDefault();
                        if (delteotp != null)
                        {
                            contextsdce.order_cancel_random_pass.Remove(delteotp);
                            contextsdce.SaveChanges();
                        }

                        //Inserting Random password to order_cancel_random_pass Generated in verificationcode
                        order_cancel_random_pass urp = new order_cancel_random_pass();
                        urp.verification_code = sOTP;
                        urp.generated_time = DateTime.Now;
                        urp.action_type = 1;
                        urp.order_ref_no = orderId;
                        urp.buyer_mobile = cancelotp.usermobile;
                        urp.buyer_user_id = Convert.ToInt32(cancelotp.userid);
                        urp.action_user_id = Convert.ToInt32(actionuser.user_id);
                        contextsdce.order_cancel_random_pass.Add(urp);
                        contextsdce.SaveChanges();


                        //OTP send to Mobile Number
                        strPostResponse = obj1.SendSMS(actn_user_mobile.ToString().Trim(), "Order Cancel OTP Code (" + sOTP + ") For OrderId : " + orderId + " , Mobile :" + cancelotp.usermobile + ", Amount :" + cancelotp.orderAmnt + " , Infoplus learnengg.com Support", "");

                        return "1";
                    }
                    else
                    {
                        return "0";
                    }


                }
                catch (Exception ex)
                {
                    contextsdce.Dispose();
                    Log.WriteLogMessage(PageName, "PaymentService", "CancelOrderOTP", ex.Message, "error");
                    throw ex;
                }
                finally
                {
                    contextsdce.Dispose();
                }
            }
        }


        /// <summary>
        /// Loading Cancel orders Category
        /// </summary>
        /// <returns></returns>
        public List<CancelCategory> LoadCancelOrderCategory()
        {
            List<CancelCategory> category = new List<CancelCategory>();
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                try
                {
                    category = (from ocm in contextsdce.cancel_category_master
                                where ocm.active_status == 1
                                select new CancelCategory
                                {
                                    CategoryId = ocm.category_id,
                                    CategoryName = ocm.category_name
                                }).ToList();

                    return category;
                }
                catch (Exception ex)
                {
                    contextsdce.Dispose();
                    Log.WriteLogMessage(PageName, "PaymentService", "LoadCancelOrderCategory", ex.Message, "error");
                    throw;
                }
                finally
                {
                    contextsdce.Dispose();
                }
            }
        }

        public string CheckIsExistTxn(long pUserId)
        {
            string result = string.Empty;
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                try
                {
                    List<int> PaymentStatus = new List<int>() { 1, 3 };

                    var LastTxn = (from usm in contextsdce.user_subscribe_master
                                   where usm.user_id == pUserId && PaymentStatus.Contains(usm.payment_status)
                                   group usm by usm.user_subscribe_master_id into g
                                   select new
                                   {
                                       created = g.Max(x => x.created_on),
                                       createdid = g.Key
                                   }).OrderByDescending(x => x.createdid).FirstOrDefault();
                    if (LastTxn != null)
                    {
                        TimeSpan ts = new TimeSpan(DateTime.Now.Ticks - LastTxn.created.Ticks);
                        if (ts.TotalMinutes <= 10)
                        {
                            result = "Your Order was Initiated/Failed before " + Math.Ceiling(ts.TotalMinutes) + " Minute(s). Do you want to proceed?";
                        }
                    }
                    return result.ToString();
                }
                catch (Exception ex)
                {
                    contextsdce.Dispose();
                    Log.WriteLogMessage(PageName, "PaymentService", "CheckIsExistTxn", ex.Message, "error");
                    throw;
                }
                finally
                {
                    contextsdce.Dispose();
                }
            }
        }

        public string CheckIsExistPurchasedPackage(long pUserId)
        {
            string result = string.Empty;
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                try
                {
                    List<int> PaymentStatus = new List<int>() { 2, 4 };

                    var LastTxn = (from ucd in contextsdce.user_cart_details
                                   join usm in contextsdce.user_subscribe_master on ucd.user_id equals usm.user_id
                                   join usd in contextsdce.user_subscribe_details on usm.user_subscribe_master_id equals usd.user_subscribe_master_id
                                   where usm.user_id == pUserId && PaymentStatus.Contains(usm.payment_status)
                                   group usm by usm.user_subscribe_master_id into g
                                   select new
                                   {
                                       created = g.Max(x => x.created_on),
                                       createdid = g.Key
                                   }).OrderByDescending(x => x.createdid).FirstOrDefault();
                    if (LastTxn != null)
                    {
                        TimeSpan ts = new TimeSpan(DateTime.Now.Ticks - LastTxn.created.Ticks);
                        if (ts.TotalDays <= 10)
                        {
                            result = "Your Order was Initiated/Failed before " + ts.TotalDays + " Days.Do you want to purchase again?";
                        }
                    }
                    return result.ToString();
                }
                catch (Exception ex)
                {
                    contextsdce.Dispose();
                    Log.WriteLogMessage(PageName, "PaymentService", "CheckIsExistTxn", ex.Message, "error");
                    throw;
                }
                finally
                {
                    contextsdce.Dispose();
                }
            }
        }

        /// <summary>
        /// Updates the refund payment.
        /// </summary>
        /// <param name="pm">The pm.</param>
        /// <param name="PaymentType">Type of the payment.</param>
        /// <returns></returns>
        public int UpdateRefundPayment(Payment pm, int PaymentType)
        {
            int result = 0;
            try
            {
                using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
                {
                    var updatePayment = (from pay in contextsdce.payment_master
                                         join usm in contextsdce.user_subscribe_master on pay.user_subscribe_master_id equals usm.user_subscribe_master_id
                                         join usot in contextsdce.user_subscribe_order_track on usm.user_subscribe_master_id equals usot.user_subscribe_master_id
                                         join dom in contextsdce.user_subscribe_delivery_mode on usm.user_subscribe_delivery_mode_id equals dom.user_subscribe_delivery_mode_id
                                         where pay.ClintTxnRefNo == pm.ClintTxnRefNo
                                         select new { pay, usm, dom, usot }).FirstOrDefault();

                    if (updatePayment != null)
                    {
                        Log.WriteLogMessage("PaytmTransaction", "paytRefundStatus", "RefundTransaction", "AFTER UPDATE PAYMENT NOT NULL", "error");
                        if (PaymentType == 3 || PaymentType == 2)
                        {
                            // Log.WriteLogMessage("PaymentService", "UpdatePayment", "before if txn_msg ", "" + PaymentType, "error");
                            if (pm.txn_status.Trim().Equals("0400") || pm.txn_msg.Trim().Equals("TXN_SUCCESS"))
                            {
                                Log.WriteLogMessage("PaytmTransaction", "paytRefundStatus", "RefundTransaction", "TXN_SUCCESS", "error");
                                //   updatePayment.usm.payment_status = 3;
                                //   updatePayment.pay.TxnStatus = "3";


                                // purchased amount 
                                Decimal total_trans_amount = updatePayment.pay.TxnAmount;

                                // purchased amount -  balance total  + current refund
                                Decimal total_bal_amount = updatePayment.pay.bal_amt??0;

                                // Check balance amount is existing balance amount + current refund amount
                                Decimal chk_bal_amount = pm.txn_amt + total_bal_amount;

                                // 

                                long user_subscribe_id = updatePayment.usm.user_subscribe_master_id;


                                // total transaction amount must be greater than check balance amount
                                if (total_trans_amount >= chk_bal_amount)
                                {
                                    updatePayment.pay.bal_amt = pm.bal_amt;
                                    updatePayment.pay.refund_amt = pm.txn_amt + total_bal_amount;
                                    updatePayment.pay.refund_date = pm.TxnDate;
                                    updatePayment.pay.TPSLRefundID = pm.tpsl_rfnd_id;

                                    updatePayment.usm.order_status = 2;
                                    updatePayment.usot.orderstatus = 2;

                                    var refundata = new payment_refund_master
                                    {
                                        refund_amt = pm.txn_amt,
                                        refund_date = pm.TxnDate,
                                        refund_by = 1,
                                        Txn_msg = pm.txn_msg,
                                        ClintTxnRefNo = pm.ClintTxnRefNo,
                                        user_subscribe_master_id = user_subscribe_id,
                                        TPSLRefundID = pm.tpsl_rfnd_id
                                    };

                                    contextsdce.payment_refund_master.Add(refundata);
                                    result = contextsdce.SaveChanges();
                                }
                                
                            }
                        }

                    }

                }
                return result;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                Log.WriteLogMessage("PaytmTransaction", "paytRefundStatus", "RefundTransaction", "catch BLOCK", "error");
                Log.WriteLogMessage("PaytmTransaction", "paytRefundStatus", "RefundTransaction", raise.Message, "error");
                throw raise;
            }
            catch (Exception ex)
            {
                Log.WriteLogMessage(PageName, "Refund payment", "Refund payment", ex.Message, "error");
                Log.WriteLogMessage("PaytmTransaction", "paytRefundStatus", "RefundTransaction", "OUTER CATECH BLOCK", "error");
                return 0;
            }


        }

        /// <summary>
        /// Verifies the cancel order amount.
        /// </summary>
        /// <param name="usersubscribemasterid">The usersubscribemasterid.</param>
        /// <param name="buyer_mobileNo">The buyer mobile no.</param>
        /// <param name="ToEmailID">To email identifier.</param>
        /// <param name="OrderID">The order identifier.</param>
        /// <param name="userid">The userid.</param>
        /// <param name="verificationcode">The verificationcode.</param>
        /// <param name="AmtToRefund">The amt to refund.</param>
        /// <returns></returns>
        public int VerifyCancelOrderAmount(int? usersubscribemasterid, long buyer_mobileNo, string ToEmailID, string OrderID, int userid, string verificationcode, int AmtToRefund)
        {
            int data = 0;
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                try
                {
                    var test = OtpVerificationOrderConfirmation(userid, verificationcode);
                    int existrefundedamount = 0;
                    if (test != "0")
                    {
                        var UpdateStatuscancelorders = (from usm in contextsdce.user_subscribe_master
                                                        join pay in contextsdce.payment_master on usm.user_subscribe_master_id equals pay.user_subscribe_master_id
                                                        where usm.user_subscribe_master_id == usersubscribemasterid
                                                        select new { refundamount = pay.refund_amt,transactionamount = pay.TxnAmount }).FirstOrDefault();


                        if (UpdateStatuscancelorders != null) {
                            existrefundedamount = UpdateStatuscancelorders.refundamount==null?0: (int)UpdateStatuscancelorders.refundamount;
                        }

                        if(UpdateStatuscancelorders.transactionamount>=(AmtToRefund+ existrefundedamount))
                        {
                            data = 1;
                        }
                    }
                }
                catch (Exception ex)
                {
                    contextsdce.Dispose();
                    Log.WriteLogMessage(PageName, "PaymentService", "CancelOrder", ex.Message, "error");
                    throw;
                }
                finally
                {
                    contextsdce.Dispose();
                }               
            }
            return data;
        }

        public string CancelOrder(int? usersubscribemasterid, long buyer_mobileNo, string ToEmailID, string OrderID, int userid, string verificationcode)
        {
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                try
                {
                    string data = "";

                    var UpdateStatuscancelorders = (from usm in contextsdce.user_subscribe_master
                                                    join usd in contextsdce.user_subscribe_details on usm.user_subscribe_master_id equals usd.user_subscribe_master_id
                                                    join uot in contextsdce.user_subscribe_order_track on usm.user_subscribe_master_id equals uot.user_subscribe_master_id
                                                    join pam in contextsdce.purchase_activationmaster on usm.user_subscribe_master_id equals pam.user_subscribed_masterid
                                                    where usm.user_subscribe_master_id == usersubscribemasterid
                                                    select new { usm, usd, uot, pam }).ToList();


                    if (UpdateStatuscancelorders != null)
                    {
                        StudentService obj = new StudentService();
                        PaymentService pay = new PaymentService();
                        var test = pay.OtpVerificationOrderConfirmation(userid, verificationcode);
                        if (test != "0")
                        {
                            obj.COD_Cancellation_approved(buyer_mobileNo, ToEmailID, OrderID);
                            UpdateStatuscancelorders.ForEach(x => x.uot.orderstatus = 2);
                            UpdateStatuscancelorders.ForEach(x => x.usm.order_status = 2);
                            UpdateStatuscancelorders.ForEach(x => x.usd.deliver_status = 2);

                            int result = contextsdce.SaveChanges();
                            if (result > 0)
                            {
                                data = "1";
                                data = "Order Cancel successfully";
                            }
                            else
                            {
                                data = "0";
                                data = "Order Not Cancelled:There is no Item To Cancel";
                            }
                        }
                        else
                        {
                            data = "-1";
                            data = "InValid OTP";
                        }
                        return data;
                    }
                    else
                    {
                        return "No Orders To Be Cancel :Already Order Cancelled";
                    }

                }
                catch (Exception ex)
                {
                    contextsdce.Dispose();
                    Log.WriteLogMessage(PageName, "PaymentService", "CancelOrder", ex.Message, "error");
                    throw;
                }
                finally
                {
                    contextsdce.Dispose();
                }
            }


        }
    }
}