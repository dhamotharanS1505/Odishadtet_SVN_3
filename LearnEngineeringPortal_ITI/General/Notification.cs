using LearnEngineeringPortalService_ITI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace LearnEngineeringPortalService_ITI.BusinessLogic
{
    public class Notification
    {
        /// <summary>
        /// Method for send a change password mail
        /// </summary>
        /// <param name="name">string</param>
        /// <param name="emailId">string</param>
        public void PasswordChange(string name,string emailId)
        {
            MailHelper mail = new MailHelper();
           // var subjectLine = MailSubject.ResetPassword;
           // var mailBody = MailBody.ResetPassword;
           // mailBody = mailBody.Replace("#name#", name);
          //  mail.SendMail(emailId, subjectLine, mailBody);
        }
    }
}