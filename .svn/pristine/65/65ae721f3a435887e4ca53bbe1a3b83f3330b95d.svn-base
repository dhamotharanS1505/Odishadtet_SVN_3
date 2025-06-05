using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Odishadtet.DAL;
using Odishadtet.Models;
using LearnEngineeringPortalService_ITI;
using TNDET.DataAccess;

namespace Odishadtet.Models
{
    public class FeedbackViewModel
    {
        public int fb_id { get; set; }
        public string name { get; set; }
        public string collegeName { get; set; }
        public string subjectName { get; set; }
        public string email { get; set; }
        public string mobileNumber { get; set; }
        //public DateTime createdOn { get; set; }
        public bool isRead { get; set; }
        // public DateTime readOn { get; set; }
        public bool status { get; set; }
        public string message { get; set; }

        public string createdDate { get; set; }

        public string readDate { get; set; }

        public DateTime createdOn { get; set; }
    }

    public class FeedbackArchieveViewModel
    {
        public List<FeedbackViewModel> feedbacks { get; set; }
        public int allCount { get; set; }
        public int countByDate { get; set; }
        public int countByCollege { get; set; }
        public List<CollegeViewModel> colleges { get; set; }
        public List<DateViewModel> createdDate { get; set; }
    }

    public class CollegeViewModel
    {
        public string collgeName { get; set; }
        public int count { get; set; }
    }

    public class DateViewModel
    {
        public string createdDate { get; set; }
        public int count { get; set; }
    }

    public class FeedbackModel
    {
        public int SaveFeedBack(FeedbackViewModel fvm)
        {
            return new FeedbackAccess().SaveFeedback(fvm);
        }
        public List<FeedbackViewModel> GetAllFeedBacks(out int allCount, out int countByDate, out int countByCollege)
        {
            List<FeedbackViewModel> feedbacks = new List<FeedbackViewModel>();
            feedbacks = new FeedbackAccess().GetAllFeedbacks().Select(t => new FeedbackViewModel()
            {
                collegeName = t.college_name,
                createdOn = t.createdon,
                createdDate = t.createdon.ToString("dd-MMM-yyyy hh:mm:ss tt"),
                email = t.email,
                fb_id = t.fb_id,
                isRead = t.isread,
                message = t.message,
                mobileNumber = t.mobile_number,
                name = t.name,
                readDate = t.isread ? t.readon.Value.ToString("dd-MMM-yyyy hh:mm:ss tt") : "",
                //readOn = t.readon.HasValue ? t.readon.Value : DateTime.MinValue,
                status = t.status,
                subjectName = t.subject_name
            }).ToList();

            allCount = feedbacks.Count();
            countByDate = feedbacks.GroupBy(t => t.createdOn.ToString("dd-MM-yyyy")).Count();
            countByCollege = feedbacks.GroupBy(t => t.collegeName.ToLower()).Count();
            return feedbacks;
        }

        public List<FeedbackViewModel> GetAllFeedBacks(string createdDate)
        {

            List<FeedbackViewModel> feedbacks = new List<FeedbackViewModel>();
            //feedbacks = new FeedbackAccess().GetAllFeedbacks().ToList().Where(x => x.createdon.ToString("dd-MM-yyyy").Equals(createdDate))
            //    .Select(t => new FeedbackViewModel()
            //{
            //    collegeName = t.college_name,
            //    //createdOn = t.createdon,
            //    createdDate = t.createdon.ToString("dd-MMM-yyyy hh:mm:ss tt"),
            //    email = t.email,
            //    fb_id = t.fb_id,
            //    isRead = t.isread,
            //    message = t.message,
            //    mobileNumber = t.mobile_number,
            //    name = t.name,
            //    readDate = t.isread ? t.readon.Value.ToString("dd-MMM-yyyy hh:mm:ss tt") : "",
            //    //readOn = t.readon.HasValue ? t.readon.Value : DateTime.MinValue,
            //    status = t.status,
            //    subjectName = t.subject_name
            //}).ToList();
            feedbacks = new FeedbackAccess().GetAllFeedbacks().AsEnumerable().Where(x => x.createdon.ToString("dd-MM-yyyy") == createdDate)
                .Select(t => new FeedbackViewModel()
                {
                    collegeName = t.college_name,
                    createdOn = t.createdon,
                    createdDate = t.createdon.ToString("dd-MMM-yyyy hh:mm:ss tt"),
                    email = t.email,
                    fb_id = t.fb_id,
                    isRead = t.isread,
                    message = t.message,
                    mobileNumber = t.mobile_number,
                    name = t.name,
                    readDate = t.isread ? t.readon.Value.ToString("dd-MMM-yyyy hh:mm:ss tt") : "",
                    //readOn = t.readon.HasValue ? t.readon.Value : DateTime.MinValue,
                    status = t.status,
                    subjectName = t.subject_name
                }).ToList();
            return feedbacks;
        }

        public int UpdateReadStatus(int fId, int readBy)
        {
            return new FeedbackAccess().UpdateReadStatus(fId, readBy);
        }

        public FeedbackArchieveViewModel GetFeedBacks()
        {
            FeedbackArchieveViewModel feedback = new FeedbackArchieveViewModel();
            try
            {

                feedback.feedbacks = new List<FeedbackViewModel>();
                feedback.feedbacks = new FeedbackAccess().GetAllFeedbacks().Select(t => new FeedbackViewModel()
                {
                    collegeName = t.college_name,
                    createdOn = t.createdon,
                    createdDate = t.createdon.ToString("dd-MM-yyyy hh:mm:ss tt"),
                    email = t.email,
                    fb_id = t.fb_id,
                    isRead = t.isread,
                    message = t.message,
                    mobileNumber = t.mobile_number,
                    name = t.name,
                    readDate = t.isread ? t.readon.Value.ToString("dd-MM-yyyy hh:mm:ss tt") : "",
                    //readOn = t.readon.HasValue ? t.readon.Value : DateTime.MinValue,
                    status = t.status,
                    subjectName = t.subject_name
                }).OrderByDescending(t => t.createdOn).ToList();
                feedback.allCount = feedback.feedbacks.Count();
                //feedback.countByDate = feedback.feedbacks.GroupBy(t => t.createdOn.ToString("dd-MM-yyyy")).Count();
                //feedback.countByCollege = feedback.feedbacks.GroupBy(t => t.collegeName.ToLower()).Count();

                feedback.colleges = new List<CollegeViewModel>();
                feedback.colleges = feedback.feedbacks.Where(x => x.collegeName != null).GroupBy(x => x.collegeName).Select(t => new CollegeViewModel()
                {
                    collgeName = t.Key.ToString(),
                    count = t.Count()
                }).ToList();

                feedback.createdDate = new List<DateViewModel>();
                feedback.createdDate = feedback.feedbacks.GroupBy(t => t.createdOn.ToString("dd-MM-yyyy")).Select(t => new DateViewModel()
                {
                    createdDate = t.Key.ToString(),
                    count = t.Count()
                }).ToList();


                return feedback;
            }
            catch (Exception ex)
            {
                ExceptionStorage.saveExceptionFromService(ex, "", "");
                throw;
            }
        }

    }
}