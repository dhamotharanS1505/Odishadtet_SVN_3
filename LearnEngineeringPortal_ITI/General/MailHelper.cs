using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Configuration;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using Odishadtet.General;
using System.Net;

namespace LearnEngineeringPortalService_ITI
{
    public class MailHelper
    {
      //  Authconfig Auth=new Authconfig ();
        public static void SendMail(string To, string Subject, string Body,string fromMail=null)
        {
            string FromUser = "support@learnengg.com";
            string CC = "";
            if (fromMail != null)
            {
                CC = fromMail;
            }

            string SMTP_Username = "";
            string SMTP_Pass = "";

            string smtpUser = "";
            smtpUser = ConfigurationManager.AppSettings["SMTP_Username"].ToString();
            if (string.IsNullOrEmpty(smtpUser))
            {
                SMTP_Username = "AKIAVQ6ZNGH4DVJHGF65";
            }
            else
            {
                SMTP_Username = smtpUser;
            }


            string smtpPass = "";
            smtpPass = ConfigurationManager.AppSettings["SMTP_Password"].ToString();
            if (string.IsNullOrEmpty(smtpPass))
            {
                SMTP_Pass = "BItQTYqWyHwD9rMIYy4NqgEXT+qkx9m/f9Pdjszb+KgD";
            }
            else
            {
                SMTP_Pass = smtpPass;
            }


            string MailOption = ConfigurationManager.AppSettings["MailConfig"].ToString();
            if (MailOption == "P")
            {
                try
                {
                    SmtpClient smtpClient = new SmtpClient();
                    MailMessage message = new MailMessage();
               
                    string smtpHost = "";
                    smtpHost = ConfigurationManager.AppSettings["SendMail_SMTPSERVER"].ToString();
                    if (string.IsNullOrEmpty(smtpHost))
                    {
                        smtpHost = "email-smtp.us-east-1.amazonaws.com";
                    }
                    smtpClient.Host = smtpHost;
                    string mailUsername = "";
                    mailUsername = ConfigurationManager.AppSettings["Mail_Username"].ToString();
                    if (string.IsNullOrEmpty(mailUsername))
                    {
                        mailUsername = FromUser;
                    }
                    MailAddress fromAddress = new MailAddress(mailUsername);
                    string mailPassword;
                    mailPassword = ConfigurationManager.AppSettings["Mail_Password"].ToString();
                    if (string.IsNullOrEmpty(mailPassword))
                    {
                        mailPassword = "infoplus3dm";
                    }
                    int smtpPortNo = -1;
                    smtpPortNo = Convert.ToInt16(ConfigurationManager.AppSettings["Mail_Port"]);

                    if (int.Equals(-1, smtpPortNo))
                    {
                        smtpPortNo = 25;
                    }
                    smtpClient.Port = smtpPortNo;
                    ////string BCCMailId = ConfigurationManager.AppSettings["BCC"].ToString();
                    System.Net.NetworkCredential myCredential = new System.Net.NetworkCredential(SMTP_Username, SMTP_Pass);
                    smtpClient.Credentials = myCredential;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.EnableSsl = true;
                    message.From = fromAddress;
                    message.To.Add(To.Trim());
                    message.Bcc.Add("rajiniprabu.p@infoplus.co.in");
                    //message.To.Add("rajiniprabu.p@infoplus.co.in");
                    //message.Bcc.Add(BCCMailId);
                    ////if (CC != "")
                    ////{
                    ////    message.Bcc.Add(CC);
                    ////}
                    ////else
                    ////{
                    ////    message.Bcc.Add(BCCMailId);
                    ////}
                    ////
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                    message.Subject = Subject;
                    message.IsBodyHtml = true;
                    message.Body = Body;
                    smtpClient.Send(message);

                }
                catch (SmtpFailedRecipientsException smtpEx)
                {
                    Log.WriteLogMessage("MailHelper", "NewUserRegistration", "GetVerificationCode", smtpEx.Message, "error");
                    throw smtpEx;
                }
                catch (Exception ex)
                {
                    Log.WriteLogMessage("MailHelper", "NewUserRegistration", "GetVerificationCode", ex.InnerException.Message, "error");
                    throw ex;
                }
            }

        }


        #region Encption Process
        

        /// <summary>
        /// Encrypt the String And PWD
        /// </summary>
        /// <param name="pwd"></param>
        /// <param name="hasing"></param>
        /// <returns></returns>
        public string encrptpwd(string pwd, bool hasing)
        {
            byte[] keyarray;
            byte[] encryptarray = UTF8Encoding.UTF8.GetBytes(pwd);
            AppSettingsReader settingsReader = new AppSettingsReader();

            string key = (string)settingsReader.GetValue("SecurityKey", typeof(String));

            if (hasing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyarray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
            {
                keyarray = UTF8Encoding.UTF8.GetBytes(key);
            }
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyarray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform ctransform = tdes.CreateEncryptor();
            byte[] resultarray = ctransform.TransformFinalBlock(encryptarray, 0, encryptarray.Length);
            tdes.Clear();
            string dd = Convert.ToBase64String(resultarray, 0, resultarray.Length);
            return Convert.ToBase64String(resultarray, 0, resultarray.Length);
        }
        /// <summary>
        /// Decrypt the String And PWD
        /// </summary>
        /// <param name="pwd"></param>
        /// <param name="hasing"></param>
        /// <returns></returns>
        public string Decrypt(string enstring, bool hasing)
        {
            byte[] keyarray;
            byte[] encryptarray = Convert.FromBase64String(enstring);
            System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
            string key = (string)settingsReader.GetValue("SecurityKey", typeof(String));
            if (hasing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyarray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
            {
                keyarray = UTF8Encoding.UTF8.GetBytes(key);
            }

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyarray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform ctransform = tdes.CreateDecryptor();
            byte[] resultarray = ctransform.TransformFinalBlock(encryptarray, 0, encryptarray.Length);
            tdes.Clear();
            return UTF8Encoding.UTF8.GetString(resultarray);
        }

        #endregion

        public static string EmailBody_OTP(string MailTitle, string Mobile, string OTP, string UserName)
        {
            string body = string.Empty;
            using (System.IO.StreamReader reader = new System.IO.StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplate/otp.html")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{MailTitle}", MailTitle);
            body = body.Replace("{mobile}", Mobile);
            body = body.Replace("{otp}", OTP);
            body = body.Replace("{UserName}", UserName);
          

            return body;
        }

        public static string EmailBody_ActivationCode(string MailTitle, string Mobile, string ActivationCode, string UserName,string OrderID)
        {
            string body = string.Empty;
            using (System.IO.StreamReader reader = new System.IO.StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplate/ActivationCode.html")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{MailTitle}", MailTitle);
            body = body.Replace("{mobile}", Mobile);
            body = body.Replace("{code}", ActivationCode);
            body = body.Replace("{UserName}", UserName);
            body = body.Replace("{orderid}", OrderID);

            return body;
        }

        public static string EmailBody_Orderplaced(string OrderID)
        {
            string body = string.Empty;
            using (System.IO.StreamReader reader = new System.IO.StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplate/ordersucess.html")))
            {
                body = reader.ReadToEnd();
            }
           // body = body.Replace("{MailTitle}", MailTitle);
            
           // body = body.Replace("{UserName}", UserName);
            body = body.Replace("{orderid}", OrderID);

            return body;
        }

        public static string EmailBody_Ordercancelled(string OrderID)
        {
            string body = string.Empty;
            using (System.IO.StreamReader reader = new System.IO.StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplate/orderCancelled.html")))
            {
                body = reader.ReadToEnd();
            }
            // body = body.Replace("{MailTitle}", MailTitle);

            // body = body.Replace("{UserName}", UserName);
            body = body.Replace("{orderid}", OrderID);

            return body;
        }



        public static string EmailBody_OrderShipped(string OrderID,string TrackingID)
        {
            string body = string.Empty;
            using (System.IO.StreamReader reader = new System.IO.StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplate/ordershipped.html")))
            {
                body = reader.ReadToEnd();
            }
            // body = body.Replace("{MailTitle}", MailTitle);

            body = body.Replace("{trackingid}", TrackingID);
            body = body.Replace("{orderid}", OrderID);

            return body;
        }

        public static string EmailBody_ActivationExtension(string days)
        {
            string body = string.Empty;
            using (System.IO.StreamReader reader = new System.IO.StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplate/Extended_daysActivation.html")))
            {
                body = reader.ReadToEnd();
            }
            // body = body.Replace("{MailTitle}", MailTitle);

            body = body.Replace("{days}", days);

            return body;
        }

        public static string EmailBody_PasswordChange(string name, string emailId)
        {
            string body = string.Empty;
            using (System.IO.StreamReader reader = new System.IO.StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplate/PasswordChange.html")))
            {
                body = reader.ReadToEnd();
            }
            // body = body.Replace("{MailTitle}", MailTitle);

            body = body.Replace("{name}", name);
            body = body.Replace("{emailId}", emailId);

            return body;
        }
    }
}