using Odishadtet.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static Odishadtet.Models.AdminAnalyzeModel;
using Odishadtet.Models;

namespace Odishadtet.APIServiceControllers
{
    public class APIAdminAnalyzeActivityController : ApiController
    {

        static IAdminAnalyzeService _AdminRepository;

        public APIAdminAnalyzeActivityController(IAdminAnalyzeService Productrepository)
        {
            if (Productrepository == null)
            {
                throw new ArgumentNullException("Productrepository");
            }

            _AdminRepository = Productrepository;
        }
        /// <summary>
        /// Gets the admin analyze by product sales.
        /// </summary>
        /// <returns></returns>
        public List<AdminAnalyzeByPurchaseModel> GetAdminAnalyzeByProductSales(int UnivId, DateTime StartDate, DateTime EndDate)
        {
            List<AdminAnalyzeByPurchaseModel> apm = new List<AdminAnalyzeByPurchaseModel>();
            apm = _AdminRepository.OrderStatusBySubjectPurchase(UnivId, StartDate, EndDate);
            return apm;

        }
        /// <summary>
        /// Gets the admin analyze by product sales.
        /// </summary>
        /// <returns></returns>
        public List<AdminAnalyzeByPurchaseModel> GetAdminAnalyzeBySubjectsMultipleSelection(int UnivId, string PurStartDate, string PurEndDate, string TraStartDate, string TraEndDate, string UsgStartDate, string UsgEndDate, string UserRole)
        {
            List<AdminAnalyzeByPurchaseModel> TrailSubject = new List<AdminAnalyzeByPurchaseModel>();
            TrailSubject = _AdminRepository.GetTrailBySubjectWithMultipleCondition(UnivId, PurStartDate, PurEndDate, TraStartDate, TraEndDate, UsgStartDate, UsgEndDate, UserRole);
            return TrailSubject;

        }

        public List<AdminAnalyzeByTrailUserMultipleModel> GetAdminAnalyzeForUserMultipleSelection(int UnivId, string RegStartDate, string RegEndDate, string PurStartDate, string PurEndDate, string TraStartDate, string TraEndDate, string UsgStartDate, string UsgEndDate, string UserRole)
        {
            List<AdminAnalyzeByTrailUserMultipleModel> TrailSubject = new List<AdminAnalyzeByTrailUserMultipleModel>();
            TrailSubject = _AdminRepository.GetTrailByUserWithMultipleCondition(UnivId, RegStartDate, RegEndDate, PurStartDate, PurEndDate, TraStartDate, TraEndDate, UsgStartDate, UsgEndDate, UserRole);
            return TrailSubject;


        }
        [HttpGet]
        public List<AdminAnalyzeByTrailUserMultipleModel> GetAdminAnalyzeDataByUuniversityall()
        {

            List<AdminAnalyzeByTrailUserMultipleModel> TrailSubject = new List<AdminAnalyzeByTrailUserMultipleModel>();
            TrailSubject = _AdminRepository.GetAnalyseDataByUuniversity();
            return TrailSubject;
        }
        [HttpGet]
        public List<AdminAnalyzeByTrailSubjectModel> GetAdminAnalyzeSubjectDataByUuniversityall()
        {
            List<AdminAnalyzeByTrailSubjectModel> AnalyseSubjectData = new List<AdminAnalyzeByTrailSubjectModel>();
            AnalyseSubjectData = _AdminRepository.GetAnalyseSubjectDataByUuniversity();
            return AnalyseSubjectData;
        }
        [HttpGet]
        public List<Datewise_Sales_Report> DatewiseSalesReport()
        {
            List<Datewise_Sales_Report> DatewiseSalesData = new List<Datewise_Sales_Report>();
            DatewiseSalesData = _AdminRepository.DateWise_Sales_Report();
            return DatewiseSalesData;
        }

        [HttpGet]
        public List<SemBatchReport> SemesterBatchReport()
        {
            List<SemBatchReport> report = _AdminRepository.SemesterBatchReport();
            return report;
        }


        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}