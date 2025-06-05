using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Odishadtet.Models;
using static Odishadtet.Models.AdminAnalyzeModel;

namespace Odishadtet.DAL
{
    public interface IAdminAnalyzeService
    {
        List<AdminAnalyzeByPurchaseModel> OrderStatusBySubjectPurchase(int UnivId, DateTime StartDate, DateTime EndDate);
        List<AdminAnalyzeByPurchaseModel> GetTrailBySubjectWithMultipleCondition(int UnivId, string PurStartDate, string PurEndDate, string TraStartDate, string TraEndDate, string UsgStartDate, string UsgEndDate, string UserRole); 
        List<AdminAnalyzeByTrailUserMultipleModel> GetTrailByUserWithMultipleCondition(int UnivId, string RegStartDate, string RegEndDate, string PurStartDate, string PurEndDate, string TraStartDate, string TraEndDate, string UsgStartDate, string UsgEndDate, string UserRole);
        List<AdminAnalyzeByTrailUserMultipleModel> GetAnalyseDataByUuniversity();
        List<AdminAnalyzeByTrailSubjectModel> GetAnalyseSubjectDataByUuniversity();
        List<Datewise_Sales_Report> DateWise_Sales_Report();
        List<SemBatchReport> SemesterBatchReport();
        List<SemBatchReport> ExportSMSdataReport(int univId, int year, int batchyearId, int rpt_type);
    }
}
