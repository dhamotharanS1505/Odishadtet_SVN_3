using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using Odishadtet.DAL;
using System.Configuration;
using System.Text;

namespace LearnEngineeringPortalService_ITI
{
    public class CallSendSMS
    {
        private WebProxy objProxy1 = null;

        //public string SendSMS(string Mobile_Number, string Message, string EmailId)
        //{
        //    string stringpost = null;

        //    //stringpost = "User=infoplustech " + "&passwd=47605484 " + "&mobilenumber=" + Mobile_Number + "&message=" + Message;
        //    EmailId = "LearnEngg";
        //    //stringpost = "MobileNo=" + Mobile_Number + "&EmailId=" + EmailId + "&smsMsg=" + Message + "&PId=605" + "&Uname=smsinfoplus" + "&Pwd=infoplus2015sms";
        //    //stringpost = "user=alam74" + "&password=9941226274" + "&mobile=" + Mobile_Number + "&message=" + Message + "&sender=LRNENG" + "&type=3";

        //    stringpost = "user=learnengg&password=Netty@24&senderid=LEENGG&channel=Trans&DCS=0&flashsms=0&number=" + Mobile_Number + "&text=" + Message + "&route=4";

        //    HttpWebRequest objWebRequest = null;
        //    HttpWebResponse objWebResponse = null;
        //    StreamWriter objStreamWriter = null;
        //    StreamReader objStreamReader = null;

        //    try
        //    {

        //        string stringResult = null;
        //        System.Net.ServicePointManager.Expect100Continue = false;
        //        //objWebRequest = (HttpWebRequest)WebRequest.Create("http://www.smscountry.com/SMSCwebservice_bulk.aspx?");
        //        // objWebRequest = (HttpWebRequest)WebRequest.Create("http://boancomm.net//boanOtp/SmsEmail.aspx?");
        //        //objWebRequest = (HttpWebRequest)WebRequest.Create("http://login.bulksmsgateway.in/sendmessage.php?");
        //        objWebRequest = (HttpWebRequest)WebRequest.Create("http://retailsms.nettyfish.com/api/mt/SendSMS?");
        //        objWebRequest.Method = "POST";

        //        if ((objProxy1 != null))
        //        {
        //            objWebRequest.Proxy = objProxy1;
        //        }


        //        // Use below code if you want to SETUP PROXY.
        //        //Parameters to pass: 1. ProxyAddress 2. Port
        //        //You can find both the parameters in Connection settings of your internet explorer.

        //        //WebProxy myProxy = new WebProxy("YOUR PROXY", PROXPORT);
        //        //myProxy.BypassProxyOnLocal = true;
        //        //wrGETURL.Proxy = myProxy;

        //        objWebRequest.ContentType = "application/x-www-form-urlencoded";

        //        objStreamWriter = new StreamWriter(objWebRequest.GetRequestStream());
        //        objStreamWriter.Write(stringpost);
        //        objStreamWriter.Flush();
        //        objStreamWriter.Close();

        //        objWebResponse = (HttpWebResponse)objWebRequest.GetResponse();
        //        objStreamReader = new StreamReader(objWebResponse.GetResponseStream());
        //        stringResult = objStreamReader.ReadToEnd();

        //        objStreamReader.Close();
        //        return stringResult;
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }
        //    finally
        //    {

        //        if ((objStreamWriter != null))
        //        {
        //            objStreamWriter.Close();
        //        }
        //        if ((objStreamReader != null))
        //        {
        //            objStreamReader.Close();
        //        }
        //        objWebRequest = null;
        //        objWebResponse = null;
        //        objProxy1 = null;
        //    }

        //}



        public string SendSMS(string Mobile_Number, string Message, string EmailId)
        {
            //string stringpost = null;

            ////stringpost = "User=infoplustech " + "&passwd=47605484 " + "&mobilenumber=" + Mobile_Number + "&message=" + Message;
            //EmailId = "LearnEngg";
            ////stringpost = "MobileNo=" + Mobile_Number + "&EmailId=" + EmailId + "&smsMsg=" + Message + "&PId=605" + "&Uname=smsinfoplus" + "&Pwd=infoplus2015sms";
            ////stringpost = "user=alam74" + "&password=9941226274" + "&mobile=" + Mobile_Number + "&message=" + Message + "&sender=LRNENG" + "&type=3";

            //stringpost = "user=learnengg&password=Netty@24&senderid=LEENGG&channel=Trans&DCS=0&flashsms=0&number=" + Mobile_Number + "&text=" + Message + "&route=4";

            //HttpWebRequest objWebRequest = null;
            //HttpWebResponse objWebResponse = null;
            //StreamWriter objStreamWriter = null;
            //StreamReader objStreamReader = null;

            try
            {

                //string stringResult = null;
                //System.Net.ServicePointManager.Expect100Continue = false;
                ////objWebRequest = (HttpWebRequest)WebRequest.Create("http://www.smscountry.com/SMSCwebservice_bulk.aspx?");
                //// objWebRequest = (HttpWebRequest)WebRequest.Create("http://boancomm.net//boanOtp/SmsEmail.aspx?");
                ////objWebRequest = (HttpWebRequest)WebRequest.Create("http://login.bulksmsgateway.in/sendmessage.php?");
                //objWebRequest = (HttpWebRequest)WebRequest.Create("http://retailsms.nettyfish.com/api/mt/SendSMS?");
                //objWebRequest.Method = "POST";

                //if ((objProxy1 != null))
                //{
                //    objWebRequest.Proxy = objProxy1;
                //}


                // Use below code if you want to SETUP PROXY.
                //Parameters to pass: 1. ProxyAddress 2. Port
                //You can find both the parameters in Connection settings of your internet explorer.

                //WebProxy myProxy = new WebProxy("YOUR PROXY", PROXPORT);
                //myProxy.BypassProxyOnLocal = true;
                //wrGETURL.Proxy = myProxy;

                ////objWebRequest.ContentType = "application/x-www-form-urlencoded";

                ////objStreamWriter = new StreamWriter(objWebRequest.GetRequestStream());
                ////objStreamWriter.Write(stringpost);
                ////objStreamWriter.Flush();
                ////objStreamWriter.Close();

                ////objWebResponse = (HttpWebResponse)objWebRequest.GetResponse();
                ////objStreamReader = new StreamReader(objWebResponse.GetResponseStream());
                ////stringResult = objStreamReader.ReadToEnd();

                ////objStreamReader.Close();


                //string sURL = "http://retailsms.nettyfish.com/api/mt/SendSMS?user=learnengg&password=Netty@24&senderid=LEENGG&channel=Trans&DCS=0&flashsms=0&number=" + Mobile_Number + "&text=" + Message + "&route=4";

                string sURL = "http://retailsms.nettyfish.com/api/mt/SendSMS?APIKEY=A1eiTj192kGDJPHw5dAuYQ&senderid=LEENGG&channel=trans&DCS=0&flashsms=0&number=" + Mobile_Number + "&text=" + Message + "&route=4";
                string sResponse = GetResponse(sURL);
                //Response.Write(sResponse);


                return sResponse;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {

                //if ((objStreamWriter != null))
                //{
                //    objStreamWriter.Close();
                //}
                //if ((objStreamReader != null))
                //{
                //    objStreamReader.Close();
                //}
                //objWebRequest = null;
                //objWebResponse = null;
                objProxy1 = null;
            }

        }


        public static string GetResponse(string sURL)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sURL);
                request.MaximumAutomaticRedirections = 4;
                request.Credentials = CredentialCache.DefaultCredentials;
                try
                {
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    Stream receiveStream = response.GetResponseStream(
                    );
                    StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                    string sResponse = readStream.ReadToEnd();
                    response.Close();
                    readStream.Close();
                    return sResponse;
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }

            private void StreamReader(Stream stream)
        {
            throw new NotImplementedException();
        }

        public string CreateRandomPassword(int passwordLength)
        {
            string allowedChars = "123456789";
            char[] chars = new char[passwordLength];
            Random rd = new Random();

            for (int i = 0; i < passwordLength; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }

            return new string(chars);
        }

        public string CreateActivationKey(int passwordLength)
        {
            string allowedChars = "123456789ABCDEFGHIJKLMNPQRSTUVWXYZ";
            char[] chars = new char[passwordLength];
            Random rd = new Random();

            for (int i = 0; i < passwordLength; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }

            string activationKey = new string(chars);

            bool activationKeyAlreadyExists = StudentService.GetActivationKeys().Any(key => key.activationcode == activationKey);

            if (activationKeyAlreadyExists)
            {
                activationKey = CreateActivationKey(passwordLength);
            }

            return activationKey;
        }

        public string SMS_RegistrationConformation(string OTP)
        {
            return "Please enter the OTP :  " + OTP + " to complete your Registration process, Infoplus learnengg.com Support";
        }

        public string SMS_orderConformation(string OTP)
        {
            return "Please enter the OTP :  " + OTP + " to complete your purchase Order process, Infoplus learnengg.com Support";
        }

        public string SMS_ordersucessfully(string OrderID, string SubjectName)
        {
            string[] subjectUnitPath = SubjectName.ToString().Split(',');
            string ordersucess = "Order confirmation: " + OrderID + ". Your order placed Sucessfully,For order status visit LearnEngg.com. To Download Subject(s)";

            for (int i = 0; i < subjectUnitPath.Count(); i++)
            {
                if (subjectUnitPath[i].ToString() != "NoFilePath")
                {
                    ordersucess = ordersucess + "   " + ConfigurationManager.AppSettings["SubjectUnitPath"].ToString() + subjectUnitPath[i] + "       ";
                }
            } 
            return ordersucess;

        }

        public string SMS_OrderDelivery(string OrderID, string TrackingID)
        {
            return "Your Learnengg.com Order (" + OrderID + ") is now shipped. professional courier Tracking ID:" + TrackingID;
        }

        public string SMS_Payment_ActivationCode(string MobileNumber, string ActivationCode)
        {
            return "Learnengg.com Payment received Sucessfully. Register Mobile No:" + MobileNumber + " ,Your Activation Code:" + ActivationCode + ", Dont share with anyone for security Purpose";
        }

        public string SMS_orderCancellationApprove(string OrderID)
        {
            return "Your order cancellation for :" + OrderID + " is approved, Visit Learnengg.com for more subjects";
        }

        public string SMS_orderCancellation_otp(string OrderID, string OTP)
        {
            return "Your OTP is " + OTP + " for the order cancellation of:" + OrderID;
        }

        public string SMS_ExtendedDaysActivation(string UserName, int days)
        {
            return "Dear  " + UserName + " your subject License period is extended to " + days + " days, Please use the 'Check Update'  Option on LearnEngg Client Application for License extension,Visit Learnengg.com for more subjects";
        }



    }
}