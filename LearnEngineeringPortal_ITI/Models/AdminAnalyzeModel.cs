using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Odishadtet.Models
{
    public class AdminAnalyzeModel
    {
        public class AdminAnalyzeByPurchaseModel
        {           
            public int univ_id { get; set; }
            public string univ_name { get; set; }
            public long subject_id { get; set; }
            public string subject_code { get; set; }
            public string subject_name { get; set; }
            public int year { get; set; }
            public int semester{ get; set; }
            public string subject_unit_type_content { get; set; }
            public string subject_unit_type_qa { get; set; }
            public string os_type_windows { get; set; }
            public string os_type_android { get; set; }
            public int total_purchased_content { get; set; }
            public int total_purchased_qa_android { get; set; }
            public int total_purchased_qa_desktop { get; set; }
            public int trail_count { get; set; }
            public int usagehrs { get; set; }
        }

        public class AdminAnalyzeByTrailSubjectModel
        {
            public int univ_id { get; set; }
            public string univ_name { get; set; }
            public long subject_id { get; set; }
            public string subject_code { get; set; }
            public string subject_name { get; set; }
            public int trail_count { get; set; }
            public int actual_subject_count { get; set; }
            public int purchased_count { get; set; }
            public int Usage_Count { get; set; }

        }

        public class AdminAnalyzeByTrailUserMultipleModel
        {
            public int univ_id { get; set; }
            public string univ_name { get; set; }
            public long user_id { get; set; }
            public string user_name { get; set; }
            public string user_role { get; set; }
            public string college_name { get; set; }
            public long mobileno { get; set; }
            public string registered_on { get; set; }
            public DateTime registered_date { get; set; }
            public int registered_count { get; set; }
            public int purchased_count { get; set; }
            public int purchased_content_count { get; set; }
            public int purchased_qa_desktop_count { get; set; }
            public int purchased_qa_android_count { get; set; }
            public int purchased_combo_count { get; set; }
            public int trail_count { get; set; }
            public int Usage_hours { get; set; }
            public int? year { get; set; }
            public int? semester { get; set; }
            public int purchasedyear { get; set; }
            public int purchasedsemester { get; set; }
            public string departmentName { get; set; }
            public string Total_Usage_hours { get; set; }

        }
    }
}