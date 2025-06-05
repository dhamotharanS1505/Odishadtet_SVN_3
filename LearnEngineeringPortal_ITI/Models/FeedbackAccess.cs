using System;
using System.Collections.Generic;
using System.Linq;
using LearnEngineeringPortalService_ITI.BusinessLogic;
using Odishadtet.DAL;
using Odishadtet.Models;
using Odishadtet.General;

namespace LearnEngineeringPortalService_ITI.DataAccess
{
    public class FeedbackAccess
    {
        string PageName = "FeedbackAccess"; 

        public int SaveFeedback(FeedbackViewModel fvm)
        {
            int result = 0;
            try
            {
                using (var DB = new learnengg_payment_portal_entities())
                {
                    feedback _feedbackEntity = new feedback()
                    {
                        college_name = fvm.collegeName,
                        createdon = DateTime.Now,
                        email = fvm.email,
                        isread = false,
                        message = fvm.message,
                        mobile_number = fvm.mobileNumber,
                        name = fvm.name,
                        subject_name = fvm.subjectName,
                        status = false
                    };
                    DB.feedbacks.Add(_feedbackEntity);
                    DB.SaveChanges();
                    result = 1;
                }
            }
            catch (Exception Ex)
            {
                Log.WriteLogMessage(PageName, "SaveFeedback", "SaveFeedback", Ex.Message, "Error");
            }
            return result;
        }

        public List<feedback> GetAllFeedbacks()
        {
            using (var DB = new learnengg_payment_portal_entities())
            {
                return DB.feedbacks.ToList();
            }
        }

        public int UpdateReadStatus(int fId,int readBy)
        {
            int result = 0;
            try
            {
                using (var DB = new learnengg_payment_portal_entities())
                {
                    var feedback = DB.feedbacks.FirstOrDefault(t => t.fb_id == fId);
                    feedback.isread = true;
                    feedback.readon = DateTime.Now;
                    if (!feedback.isread)
                        feedback.read_by = readBy;
                    DB.SaveChanges();
                    result = 1;
                }
            }
            catch (Exception Ex)
            {
                Log.WriteLogMessage(PageName, "UpdateReadStatus", "UpdateReadStatus", Ex.Message, "Error");
            }
            return result;
        }

        
    }
}