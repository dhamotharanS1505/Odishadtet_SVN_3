using System;
using System.Collections.Generic;
using System.Linq;
using Odishadtet.Models;
using static Odishadtet.Models.AdminAnalyzeModel;
using System.Globalization;
using Odishadtet.General;
using Odishadtet.DAL;

namespace Odishadtet.DAL
{
    public class AdminAnalyzeService : IAdminAnalyzeService
    {

        string PageName = "AdminAnalyzeService.cs";

        public List<AdminAnalyzeModel.AdminAnalyzeByPurchaseModel> OrderStatusBySubjectPurchase(int UnivId, DateTime StartDate, DateTime EndDate)
        {
            List<AdminAnalyzeByPurchaseModel> adminActivity = new List<AdminAnalyzeByPurchaseModel>();
            List<AdminAnalyzeByPurchaseModel> adminActivityFinal = new List<AdminAnalyzeByPurchaseModel>();
            List<AdminAnalyzeByPurchaseModel> adminActivityFinals = new List<AdminAnalyzeByPurchaseModel>();
            try
            {

                using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
                {
                    var adminactivities = (from usm in contextsdce.user_subscribe_master
                                           join usd in contextsdce.user_subscribe_details on usm.user_subscribe_master_id equals usd.user_subscribe_master_id
                                           join pm in contextsdce.package_master on usd.package_id equals pm.package_id
                                           join univ in contextsdce.university_master on pm.univ_id equals univ.univ_id
                                           join sub in contextsdce.subject_master on pm.subject_id equals sub.subject_id
                                           where pm.is_bundle == 0 && usm.payment_status == 2 && pm.univ_id == UnivId && usm.created_on >= StartDate.Date && usm.created_on <= EndDate.Date
                                           group new { pm, sub, usd, univ } by new { pm.subject_id } into subjectpurchasegrp

                                           select new
                                           {
                                               subject_id = subjectpurchasegrp.Key.subject_id,
                                               subjectgroup = subjectpurchasegrp

                                           }).ToList();

                    foreach (var grp in adminactivities)
                    {
                        AdminAnalyzeByPurchaseModel aap = new AdminAnalyzeByPurchaseModel();
                        aap.subject_id = grp.subject_id;
                        aap.total_purchased_content = grp.subjectgroup.Where(x => x.pm.subject_unit_type == 1 && x.pm.os_type == 1 || x.pm.subject_unit_type == 3 && x.pm.os_type == 1).Count();
                        aap.total_purchased_qa_android = grp.subjectgroup.Where(x => x.pm.subject_unit_type == 4 && x.pm.os_type == 2).Count();
                        aap.total_purchased_qa_desktop = grp.subjectgroup.Where(x => x.pm.subject_unit_type == 2 && x.pm.os_type == 1 || x.pm.subject_unit_type == 3 && x.pm.os_type == 1).Count();
                        aap.subject_name = grp.subjectgroup.FirstOrDefault().sub.subject_name;
                        aap.subject_code = grp.subjectgroup.FirstOrDefault().sub.subject_code;
                        aap.univ_name = grp.subjectgroup.FirstOrDefault().univ.university_name;
                        aap.univ_id = grp.subjectgroup.FirstOrDefault().univ.univ_id;
                        adminActivity.Add(aap);
                    }


                    var adminActivitiesBundle = (from usm in contextsdce.user_subscribe_master
                                                 join usd in contextsdce.user_subscribe_details on usm.user_subscribe_master_id equals usd.user_subscribe_master_id
                                                 join pm in contextsdce.package_master on usd.package_id equals pm.package_id
                                                 join pd in contextsdce.package_details on pm.package_id equals pd.package_id
                                                 join univ in contextsdce.university_master on pm.univ_id equals univ.univ_id
                                                 join sub in contextsdce.subject_master on pd.subject_id equals sub.subject_id
                                                 where pm.is_bundle == 1 && usm.payment_status == 2 && pm.univ_id == UnivId && usm.created_on >= StartDate.Date && usm.created_on <= EndDate.Date
                                                 group new { pm, sub, usd, univ } by new { sub.subject_id } into subjectpurchasegrp
                                                 select new
                                                 {
                                                     subject_id = subjectpurchasegrp.Key.subject_id,
                                                     subjectgroup = subjectpurchasegrp

                                                 }).ToList();

                    foreach (var grp in adminActivitiesBundle)
                    {
                        AdminAnalyzeByPurchaseModel aap = new AdminAnalyzeByPurchaseModel();
                        aap.subject_id = grp.subject_id;
                        aap.total_purchased_content = grp.subjectgroup.Where(x => x.pm.subject_unit_type == 1 && x.pm.os_type == 1 || x.pm.subject_unit_type == 3 && x.pm.os_type == 1).Count();
                        aap.total_purchased_qa_android = grp.subjectgroup.Where(x => x.pm.subject_unit_type == 4 && x.pm.os_type == 2).Count();
                        aap.total_purchased_qa_desktop = grp.subjectgroup.Where(x => x.pm.subject_unit_type == 2 && x.pm.os_type == 1 || x.pm.subject_unit_type == 3 && x.pm.os_type == 1).Count();
                        aap.subject_name = grp.subjectgroup.FirstOrDefault().sub.subject_name;
                        aap.subject_code = grp.subjectgroup.FirstOrDefault().sub.subject_code;
                        aap.univ_name = grp.subjectgroup.FirstOrDefault().univ.university_name;
                        aap.univ_id = grp.subjectgroup.FirstOrDefault().univ.univ_id;
                        adminActivity.Add(aap);
                    }

                }

                var res = (from aap in adminActivity
                           orderby aap.total_purchased_qa_android descending, aap.total_purchased_qa_desktop descending, aap.total_purchased_content descending
                           group aap by aap.subject_id into resultrep
                           select new
                           {
                               subject_id = resultrep.Key,
                               subjectgroup = resultrep

                           }).ToList();

                foreach (var grp in res)
                {
                    AdminAnalyzeByPurchaseModel aaps = new AdminAnalyzeByPurchaseModel();
                    aaps.subject_id = grp.subject_id;
                    aaps.total_purchased_content = grp.subjectgroup.Select(x => x.total_purchased_content).Sum();
                    aaps.total_purchased_qa_android = grp.subjectgroup.Select(x => x.total_purchased_qa_android).Sum();
                    aaps.total_purchased_qa_desktop = grp.subjectgroup.Select(x => x.total_purchased_qa_desktop).Sum();
                    aaps.subject_name = grp.subjectgroup.FirstOrDefault().subject_name;
                    aaps.subject_code = grp.subjectgroup.FirstOrDefault().subject_code;
                    aaps.univ_name = grp.subjectgroup.FirstOrDefault().univ_name;
                    aaps.univ_id = grp.subjectgroup.FirstOrDefault().univ_id;
                    adminActivityFinal.Add(aaps);
                }


            }
            catch (Exception)
            {

                throw;
            }

            return adminActivityFinal;
        }

        public List<AdminAnalyzeByPurchaseModel> GetTrailBySubjectWithMultipleCondition(int UnivId, string PurStartDate, string PurEndDate, string TraStartDate, string TraEndDate, string UsgStartDate, string UsgEndDate, string UserRole)
        {
            List<AdminAnalyzeByPurchaseModel> adminActivity = new List<AdminAnalyzeByPurchaseModel>();
            List<AdminAnalyzeByPurchaseModel> adminActivityFinal = new List<AdminAnalyzeByPurchaseModel>();
            List<AdminAnalyzeByPurchaseModel> adminActivityFinals = new List<AdminAnalyzeByPurchaseModel>();

            UserRole = UserRole.Replace('_', ',');

            List<int> RoleArray = new List<int>();
            if (UserRole.Contains("1"))
            {
                RoleArray.Add(1);
            }

            if (UserRole.Contains("2"))
            {
                RoleArray.Add(2);
            }

            try
            {
                using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
                {

                    if (PurStartDate != "0" && PurEndDate != "0")
                    {
                        DateTime pur_start_date = DateTime.ParseExact(PurStartDate + " " + "00:00:00 AM", "dd-MM-yyyy hh:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);
                        DateTime tpur_end_date = DateTime.ParseExact(PurEndDate + " " + "11:59:59 PM", "dd-MM-yyyy hh:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);

                        var adminactivities = (from um in contextsdce.user_master
                                               join usm in contextsdce.user_subscribe_master on um.user_id equals usm.user_id
                                               join usd in contextsdce.user_subscribe_details on usm.user_subscribe_master_id equals usd.user_subscribe_master_id
                                               join pm in contextsdce.package_master on usd.package_id equals pm.package_id
                                               join univ in contextsdce.university_master on pm.univ_id equals univ.univ_id
                                               join sub in contextsdce.subject_master on pm.subject_id equals sub.subject_id
                                               //join dsm in contextsdce.department_subject_mapping on sub.subject_id equals dsm.subject_id 
                                               where pm.is_bundle == 0 && usm.payment_status == 2 && univ.univ_id == UnivId
                                               //&& dsm.rule_id==sub.rule_id && dsm.university_id==sub.UniversityID && dsm.department_id==pm.department_id
                                               && usm.created_on >= pur_start_date && RoleArray.Contains(um.role_id)
                                               && usm.created_on <= tpur_end_date
                                               group new { pm, sub, usd, univ } by new { pm.subject_id } into subjectpurchasegrp

                                               select new
                                               {
                                                   subject_id = subjectpurchasegrp.Key.subject_id,
                                                   subjectgroup = subjectpurchasegrp

                                               }).ToList();

                        foreach (var grp in adminactivities)
                        {
                            AdminAnalyzeByPurchaseModel aap = new AdminAnalyzeByPurchaseModel();
                            aap.subject_id = grp.subject_id;
                            aap.total_purchased_content = grp.subjectgroup.Where(x => x.pm.subject_unit_type == 1 && x.pm.os_type == 1 || x.pm.subject_unit_type == 3 && x.pm.os_type == 1).Count();
                            aap.total_purchased_qa_android = grp.subjectgroup.Where(x => x.pm.subject_unit_type == 4 && x.pm.os_type == 2).Count();
                            aap.total_purchased_qa_desktop = grp.subjectgroup.Where(x => x.pm.subject_unit_type == 2 && x.pm.os_type == 1 || x.pm.subject_unit_type == 3 && x.pm.os_type == 1).Count();
                            aap.subject_name = grp.subjectgroup.FirstOrDefault().sub.subject_name;
                            aap.year = grp.subjectgroup.FirstOrDefault().pm.year;
                            aap.semester = grp.subjectgroup.FirstOrDefault().pm.semester;
                            aap.subject_code = grp.subjectgroup.FirstOrDefault().sub.subject_code;
                            aap.univ_name = grp.subjectgroup.FirstOrDefault().univ.university_name;
                            aap.univ_id = grp.subjectgroup.FirstOrDefault().univ.univ_id;
                            adminActivity.Add(aap);
                        }


                        var adminActivitiesBundle = (from um in contextsdce.user_master
                                                     join usm in contextsdce.user_subscribe_master on um.user_id equals usm.user_id
                                                     join usd in contextsdce.user_subscribe_details on usm.user_subscribe_master_id equals usd.user_subscribe_master_id
                                                     join pm in contextsdce.package_master on usd.package_id equals pm.package_id
                                                     join pd in contextsdce.package_details on pm.package_id equals pd.package_id
                                                     join univ in contextsdce.university_master on pm.univ_id equals univ.univ_id
                                                     join sub in contextsdce.subject_master on pd.subject_id equals sub.subject_id
                                                     //join dsm in contextsdce.department_subject_mapping on sub.subject_id equals dsm.subject_id
                                                     where pm.is_bundle == 1 && usm.payment_status == 2 && pm.univ_id == UnivId
                                                     //&& dsm.rule_id==sub.rule_id && dsm.university_id==sub.UniversityID && dsm.department_id == pm.department_id
                                                     && usm.created_on >= pur_start_date && RoleArray.Contains(um.role_id)
                                                     && usm.created_on <= tpur_end_date
                                                     group new { pm, sub, usd, univ } by new { sub.subject_id } into subjectpurchasegrp
                                                     select new
                                                     {
                                                         subject_id = subjectpurchasegrp.Key.subject_id,
                                                         subjectgroup = subjectpurchasegrp

                                                     }).ToList();

                        foreach (var grp in adminActivitiesBundle)
                        {
                            AdminAnalyzeByPurchaseModel aap = new AdminAnalyzeByPurchaseModel();
                            aap.subject_id = grp.subject_id;
                            aap.total_purchased_content = grp.subjectgroup.Where(x => x.pm.subject_unit_type == 1 && x.pm.os_type == 1 || x.pm.subject_unit_type == 3 && x.pm.os_type == 1).Count();
                            aap.total_purchased_qa_android = grp.subjectgroup.Where(x => x.pm.subject_unit_type == 4 && x.pm.os_type == 2).Count();
                            aap.total_purchased_qa_desktop = grp.subjectgroup.Where(x => x.pm.subject_unit_type == 2 && x.pm.os_type == 1 || x.pm.subject_unit_type == 3 && x.pm.os_type == 1).Count();
                            aap.subject_name = grp.subjectgroup.FirstOrDefault().sub.subject_name;
                            aap.subject_code = grp.subjectgroup.FirstOrDefault().sub.subject_code;
                            aap.year = grp.subjectgroup.FirstOrDefault().pm.year;
                            aap.semester = grp.subjectgroup.FirstOrDefault().pm.semester;
                            aap.univ_name = grp.subjectgroup.FirstOrDefault().univ.university_name;
                            aap.univ_id = grp.subjectgroup.FirstOrDefault().univ.univ_id;
                            adminActivity.Add(aap);
                        }



                        var res = (from aap in adminActivity
                                   orderby aap.total_purchased_qa_android descending, aap.total_purchased_qa_desktop descending, aap.total_purchased_content descending
                                   group aap by aap.subject_id into resultrep
                                   select new
                                   {
                                       subject_id = resultrep.Key,
                                       subjectgroup = resultrep

                                   }).ToList();

                        foreach (var grp in res)
                        {
                            AdminAnalyzeByPurchaseModel aaps = new AdminAnalyzeByPurchaseModel();
                            aaps.subject_id = grp.subject_id;
                            aaps.total_purchased_content = grp.subjectgroup.Select(x => x.total_purchased_content).Sum();
                            aaps.total_purchased_qa_android = grp.subjectgroup.Select(x => x.total_purchased_qa_android).Sum();
                            aaps.total_purchased_qa_desktop = grp.subjectgroup.Select(x => x.total_purchased_qa_desktop).Sum();
                            aaps.subject_name = grp.subjectgroup.FirstOrDefault().subject_name;
                            aaps.subject_code = grp.subjectgroup.FirstOrDefault().subject_code;
                            aaps.year = grp.subjectgroup.FirstOrDefault().year;
                            aaps.semester = grp.subjectgroup.FirstOrDefault().semester;
                            aaps.univ_name = grp.subjectgroup.FirstOrDefault().univ_name;
                            aaps.univ_id = grp.subjectgroup.FirstOrDefault().univ_id;
                            adminActivityFinal.Add(aaps);
                        }
                    }


                    if (TraStartDate != "0" && TraEndDate != "0")
                    {
                        DateTime tra_start_date = DateTime.ParseExact(TraStartDate + " " + "00:00:00 AM", "dd-MM-yyyy hh:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);
                        DateTime tra_end_date = DateTime.ParseExact(TraEndDate + " " + "11:59:59 PM", "dd-MM-yyyy hh:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);

                        var adminActivitiesBundle = (from um in contextsdce.user_master
                                                     join uts in contextsdce.user_trial_subject on um.user_id equals uts.user_id
                                                     join sub in contextsdce.subject_master on uts.subject_id equals sub.subject_id
                                                     join univ in contextsdce.university_master on sub.UniversityID equals univ.univ_id
                                                     join pm in contextsdce.package_master on sub.subject_id equals pm.subject_id
                                                     //join dsm in contextsdce.department_subject_mapping on sub.subject_id equals dsm.subject_id
                                                     where uts.created_on >= tra_start_date && uts.created_on <= tra_end_date
                                                     && univ.univ_id == UnivId && RoleArray.Contains(um.role_id)
                                                     //&& dsm.rule_id==sub.rule_id && dsm.university_id==sub.UniversityID
                                                     group new { uts, sub, univ, pm } by new { sub.subject_id } into subjectpurchasegrp
                                                     select new
                                                     {
                                                         subject_id = subjectpurchasegrp.Key.subject_id,
                                                         subjectgroup = subjectpurchasegrp

                                                     }).ToList();

                        foreach (var grp in adminActivitiesBundle)
                        {
                            AdminAnalyzeByPurchaseModel aap = new AdminAnalyzeByPurchaseModel();
                            aap.subject_id = grp.subject_id;
                            aap.trail_count = grp.subjectgroup.Select(x => x.uts.user_trial_subject_id).Distinct().Count();
                            aap.subject_name = grp.subjectgroup.FirstOrDefault().sub.subject_name;
                            aap.subject_code = grp.subjectgroup.FirstOrDefault().sub.subject_code;
                            aap.year = grp.subjectgroup.FirstOrDefault().pm.year;
                            aap.semester = grp.subjectgroup.FirstOrDefault().pm.semester;
                            aap.univ_name = grp.subjectgroup.FirstOrDefault().univ.university_name;
                            aap.univ_id = grp.subjectgroup.FirstOrDefault().univ.univ_id;
                            adminActivityFinal.Add(aap);
                        }
                    }

                    if (UsgStartDate != "0" && UsgEndDate != "0")
                    {
                        DateTime usg_start_date = DateTime.ParseExact(UsgStartDate + " " + "00:00:00 AM", "dd-MM-yyyy hh:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);
                        DateTime usg_end_date = DateTime.ParseExact(UsgEndDate + " " + "11:59:59 PM", "dd-MM-yyyy hh:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);

                        var adminanalyseUSRHSubjectActivities = (from univ in contextsdce.university_master
                                                                 join um in contextsdce.user_master on univ.univ_id equals um.univ_id
                                                                 join sub in contextsdce.subject_master on univ.univ_id equals sub.subject_id
                                                                 join usrh in contextsdce.user_subject_read_history on sub.subject_id equals usrh.subject_id // into leftuts
                                                                 join pm in contextsdce.package_master on sub.subject_id equals pm.subject_id
                                                                 //join dsm in contextsdce.department_subject_mapping on sub.subject_id equals dsm.subject_id
                                                                 // from usrh in leftuts.DefaultIfEmpty()
                                                                 where usrh.last_read_on >= usg_start_date && usrh.last_read_on <= usg_end_date // && testarray.Contains(um.mobile)
                                                                 && univ.univ_id == UnivId && um.user_id == usrh.user_id && RoleArray.Contains(um.role_id)
                                                                 //&& dsm.rule_id==sub.rule_id && dsm.university_id==sub.UniversityID
                                                                 group new { usrh, sub, univ, pm } by new { sub.subject_id } into subjectpurchasegrp
                                                                 select new
                                                                 {
                                                                     subject_id = subjectpurchasegrp.Key.subject_id,
                                                                     subjectgroup = subjectpurchasegrp

                                                                 }).ToList();

                        foreach (var grp in adminanalyseUSRHSubjectActivities)
                        {
                            AdminAnalyzeByPurchaseModel aap = new AdminAnalyzeByPurchaseModel();
                            aap.subject_id = grp.subject_id;
                            aap.usagehrs = grp.subjectgroup.Select(x => x.usrh.total_hours).Sum();
                            aap.subject_name = grp.subjectgroup.FirstOrDefault().sub.subject_name;
                            aap.subject_code = grp.subjectgroup.FirstOrDefault().sub.subject_code;
                            aap.year = grp.subjectgroup.FirstOrDefault().pm.year;
                            aap.semester = grp.subjectgroup.FirstOrDefault().pm.semester;
                            aap.univ_name = grp.subjectgroup.FirstOrDefault().univ.university_name;
                            aap.univ_id = grp.subjectgroup.FirstOrDefault().univ.univ_id;
                            adminActivityFinal.Add(aap);
                        }
                    }

                }
                adminActivityFinals = (from ud in adminActivityFinal
                                       orderby ud.subject_name
                                       group ud by ud.subject_id into grpusers
                                       select new AdminAnalyzeByPurchaseModel
                                       {
                                           subject_id = grpusers.Key,
                                           subject_name = grpusers.FirstOrDefault().subject_name,
                                           year = grpusers.FirstOrDefault().year,
                                           semester = grpusers.FirstOrDefault().semester,
                                           //total_purchased_content = grpusers.FirstOrDefault().total_purchased_content,
                                           //total_purchased_qa_android = grpusers.FirstOrDefault().total_purchased_qa_android,
                                           //total_purchased_qa_desktop = grpusers.FirstOrDefault().total_purchased_qa_desktop,
                                           total_purchased_content = grpusers.Select(x => x.total_purchased_content).Sum(),
                                           total_purchased_qa_android = grpusers.Select(x => x.total_purchased_qa_android).Sum(),
                                           total_purchased_qa_desktop = grpusers.Select(x => x.total_purchased_qa_desktop).Sum(),
                                           trail_count = grpusers.FirstOrDefault().trail_count,
                                           usagehrs = grpusers.FirstOrDefault().usagehrs,
                                           univ_name = grpusers.FirstOrDefault().univ_name,
                                           univ_id = grpusers.FirstOrDefault().univ_id
                                       }).ToList();

            }
            catch (Exception Ex)
            {
                Log.WriteLogMessage("AdminAnalysservice", "AdminAnalysservice", "UpdatePreparationOrderStatus", Ex.Message, "error");

                throw Ex;
            }
            return adminActivityFinals;
        }

        public List<AdminAnalyzeByTrailUserMultipleModel> GetTrailByUserWithMultipleCondition(int UnivId, string RegStartDate, string RegEndDate, string PurStartDate, string PurEndDate, string TraStartDate, string TraEndDate, string UsgStartDate, string UsgEndDate, string UserRole)
        {
            List<AdminAnalyzeByTrailUserMultipleModel> userData = new List<AdminAnalyzeByTrailUserMultipleModel>();
            List<AdminAnalyzeByTrailUserMultipleModel> userpurchaseData = new List<AdminAnalyzeByTrailUserMultipleModel>();
            List<AdminAnalyzeByTrailUserMultipleModel> userFinalData = new List<AdminAnalyzeByTrailUserMultipleModel>();

            List<int> rolelist = new List<int>();
            if (UserRole.Contains("1"))
            {
                rolelist.Add(1);
            }
            if (UserRole.Contains("2"))
            {
                rolelist.Add(2);
            }



            try
            {
                using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
                {

                    if (RegStartDate != "0" && RegEndDate != "0")
                    {
                        DateTime reg_start_date = DateTime.ParseExact(RegStartDate + " " + "00:00:00 AM", "dd-MM-yyyy hh:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);
                        DateTime reg_end_date = DateTime.ParseExact(RegEndDate + " " + "11:59:59 PM", "dd-MM-yyyy hh:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);


                        var adminanalyseUserActivities = (from univ in contextsdce.university_master
                                                          join um in contextsdce.user_master on univ.univ_id equals um.univ_id
                                                          join cm in contextsdce.college_master on um.collegeid equals cm.college_id
                                                          join dm in contextsdce.department_master on um.DepartmentID equals dm.department_id
                                                          //join usm in contextsdce.user_subscribe_master on um.user_id equals usm.user_id into leftusm
                                                          //from usm in leftusm.Where(x => x.order_status != 2).DefaultIfEmpty()
                                                          where um.active_status == 1 && um.created_on >= reg_start_date && um.created_on <= reg_end_date // && testarray.Contains(um.mobile)
                                                          && univ.univ_id == UnivId && univ.univ_id == cm.university_id && rolelist.Contains(um.role_id)
                                                          group new { um, cm, univ, dm } by new { um.user_id, um.mobile } into usergrp
                                                          select new
                                                          {
                                                              userid = usergrp.Key.user_id,
                                                              username = usergrp.FirstOrDefault().um.user_name,
                                                              userrole = usergrp.FirstOrDefault().um.role_id == 1 ? "Student" : "Staff",
                                                              usermobile = usergrp.Key.mobile,
                                                              usergroup = usergrp,
                                                              userdept = usergrp.FirstOrDefault().dm.department_name,
                                                              useryear = usergrp.FirstOrDefault().um.currentyear,
                                                              userSemester = usergrp.FirstOrDefault().um.currentsemester,
                                                              registeron = usergrp.FirstOrDefault().um.created_on
                                                          }).ToList();

                        foreach (var Tgrp in adminanalyseUserActivities)
                        {
                            AdminAnalyzeByTrailUserMultipleModel Trailaaps = new AdminAnalyzeByTrailUserMultipleModel();
                            Trailaaps.user_id = Tgrp.userid;
                            Trailaaps.user_name = Tgrp.username;
                            Trailaaps.user_role = Tgrp.userrole;
                            //Trailaaps.purchased_count = Tgrp.usergroup.Select(x => x.usm == null ? 0 : x.usm.count).Sum();
                            Trailaaps.univ_name = Tgrp.usergroup.FirstOrDefault().univ.university_name;
                            Trailaaps.univ_id = Tgrp.usergroup.FirstOrDefault().univ.univ_id;
                            Trailaaps.mobileno = Tgrp.usermobile;
                            Trailaaps.year = Tgrp.useryear;
                            Trailaaps.semester = Tgrp.userSemester;
                            Trailaaps.registered_on = Tgrp.registeron.Date.ToString("dd-MM-yyyy");
                            Trailaaps.departmentName = Tgrp.userdept;

                            userData.Add(Trailaaps);
                        }


                    }

                    if (PurStartDate != "0" && PurEndDate != "0")
                    {
                        DateTime pur_start_date = DateTime.ParseExact(PurStartDate + " " + "00:00:00 AM", "dd-MM-yyyy hh:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);
                        DateTime pur_end_date = DateTime.ParseExact(PurEndDate + " " + "11:59:59 PM", "dd-MM-yyyy hh:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);



                        var adminanalyseUsmUserActivities = (from univ in contextsdce.university_master
                                                             join um in contextsdce.user_master on univ.univ_id equals um.univ_id
                                                             join cm in contextsdce.college_master on um.collegeid equals cm.college_id
                                                             join dm in contextsdce.department_master on um.DepartmentID equals dm.department_id
                                                             join usm in contextsdce.user_subscribe_master on um.user_id equals usm.user_id // into leftusm
                                                             join usd in contextsdce.user_subscribe_details on usm.user_subscribe_master_id equals usd.user_subscribe_master_id
                                                             join pm in contextsdce.package_master on usd.package_id equals pm.package_id
                                                             // from usm in leftusm.Where(x => x.order_status != 2).DefaultIfEmpty()                                              
                                                             where usm.payment_status == 2 && usm.created_on >= pur_start_date && usm.created_on <= pur_end_date // && testarray.Contains(um.mobile)
                                                             && univ.univ_id == UnivId && pm.is_bundle == 0 && rolelist.Contains(um.role_id)  // && usm.user_id== 60918
                                                             group new { um, usm, cm, univ, dm, pm } by new { um.user_id, um.mobile, pm.year, pm.semester } into usergrp
                                                             select new
                                                             {
                                                                 userid = usergrp.Key.user_id,
                                                                 username = usergrp.FirstOrDefault().um.user_name,
                                                                 userrole = usergrp.FirstOrDefault().um.role_id == 1 ? "Student" : "Staff",
                                                                 usermobile = usergrp.Key.mobile,
                                                                 usergroup = usergrp,
                                                                 userdept = usergrp.FirstOrDefault().dm.department_name,
                                                                 useryear = usergrp.FirstOrDefault().um.currentyear,
                                                                 userSemester = usergrp.FirstOrDefault().um.currentsemester,
                                                                 registeron = usergrp.FirstOrDefault().um.created_on,
                                                                 purchasedYear = usergrp.FirstOrDefault().pm.year,
                                                                 purchasedSemester = usergrp.FirstOrDefault().pm.semester
                                                                 //   subjectunittype = usergrp.Key.subject_unit_type

                                                             }).ToList();

                        foreach (var Tgrp in adminanalyseUsmUserActivities)
                        {
                            AdminAnalyzeByTrailUserMultipleModel Trailaaps = new AdminAnalyzeByTrailUserMultipleModel();
                            Trailaaps.user_id = Tgrp.userid;
                            Trailaaps.user_name = Tgrp.username;
                            Trailaaps.user_role = Tgrp.userrole;
                            //Trailaaps.purchased_count = Tgrp.usergroup.Select(x => x.usm == null ? 0 : x.usm.count).Sum(); 

                            Trailaaps.univ_name = Tgrp.usergroup.FirstOrDefault().univ.university_name;
                            Trailaaps.univ_id = Tgrp.usergroup.FirstOrDefault().univ.univ_id;
                            Trailaaps.mobileno = Tgrp.usermobile;
                            Trailaaps.year = Tgrp.useryear;
                            Trailaaps.semester = Tgrp.userSemester;
                            Trailaaps.registered_on = Tgrp.registeron.Date.ToString("dd-MM-yyyy");
                            Trailaaps.departmentName = Tgrp.userdept;
                            Trailaaps.purchasedyear = Tgrp.purchasedYear;
                            Trailaaps.purchasedsemester = Tgrp.purchasedSemester;
                            Trailaaps.purchased_content_count = Tgrp.usergroup.Where(x => x.pm.subject_unit_type == 1 && x.pm.os_type == 1).Count();
                            Trailaaps.purchased_qa_android_count = Tgrp.usergroup.Where(x => x.pm.subject_unit_type == 4 && x.pm.os_type == 2).Count();
                            Trailaaps.purchased_qa_desktop_count = Tgrp.usergroup.Where(x => x.pm.subject_unit_type == 2 && x.pm.os_type == 1).Count();
                            Trailaaps.purchased_combo_count = Tgrp.usergroup.Where(x => x.pm.subject_unit_type == 3 && x.pm.os_type == 1).Count();
                            Trailaaps.purchased_count = Tgrp.usergroup.Where(x => x.pm.os_type == 2 || x.pm.os_type == 1).Count();
                            userpurchaseData.Add(Trailaaps);
                        }


                        var adminanalyseUsmUserActivitiesbundle = (from univ in contextsdce.university_master
                                                                   join um in contextsdce.user_master on univ.univ_id equals um.univ_id
                                                                   join cm in contextsdce.college_master on um.collegeid equals cm.college_id
                                                                   join dm in contextsdce.department_master on um.DepartmentID equals dm.department_id
                                                                   join usm in contextsdce.user_subscribe_master on um.user_id equals usm.user_id // into leftusm
                                                                   join usd in contextsdce.user_subscribe_details on usm.user_subscribe_master_id equals usd.user_subscribe_master_id
                                                                   join pm in contextsdce.package_master on usd.package_id equals pm.package_id
                                                                   join pd in contextsdce.package_details on pm.package_id equals pd.package_id
                                                                   // from usm in leftusm.Where(x => x.order_status != 2).DefaultIfEmpty()                                              
                                                                   where usm.payment_status == 2 && usm.created_on >= pur_start_date && usm.created_on <= pur_end_date // && testarray.Contains(um.mobile)
                                                             && univ.univ_id == UnivId && pm.is_bundle == 1 && rolelist.Contains(um.role_id) // && usm.user_id == 60918
                                                                   group new { um, usm, cm, univ, dm, pm } by new { um.user_id, um.mobile, pm.year, pm.semester } into usergrp
                                                                   select new
                                                                   {
                                                                       userid = usergrp.Key.user_id,
                                                                       username = usergrp.FirstOrDefault().um.user_name,
                                                                       userrole = usergrp.FirstOrDefault().um.role_id == 1 ? "Student" : "Staff",
                                                                       usermobile = usergrp.Key.mobile,
                                                                       usergroup = usergrp,
                                                                       userdept = usergrp.FirstOrDefault().dm.department_name,
                                                                       useryear = usergrp.FirstOrDefault().um.currentyear,
                                                                       userSemester = usergrp.FirstOrDefault().um.currentsemester,
                                                                       registeron = usergrp.FirstOrDefault().um.created_on,
                                                                       purchasedYear = usergrp.FirstOrDefault().pm.year,
                                                                       purchasedSemester = usergrp.FirstOrDefault().pm.semester// subjectunittype = usergrp.Key.subject_unit_type

                                                                   }).ToList();

                        foreach (var Tgrp in adminanalyseUsmUserActivitiesbundle)
                        {
                            AdminAnalyzeByTrailUserMultipleModel Trailaaps = new AdminAnalyzeByTrailUserMultipleModel();
                            Trailaaps.user_id = Tgrp.userid;
                            Trailaaps.user_name = Tgrp.username;
                            Trailaaps.user_role = Tgrp.userrole;
                            //Trailaaps.purchased_count = Tgrp.usergroup.Select(x => x.usm == null ? 0 : x.usm.count).Sum(); 

                            Trailaaps.univ_name = Tgrp.usergroup.FirstOrDefault().univ.university_name;
                            Trailaaps.univ_id = Tgrp.usergroup.FirstOrDefault().univ.univ_id;
                            Trailaaps.mobileno = Tgrp.usermobile;
                            Trailaaps.year = Tgrp.useryear;
                            Trailaaps.semester = Tgrp.userSemester;
                            Trailaaps.registered_on = Tgrp.registeron.Date.ToString("dd-MM-yyyy");
                            Trailaaps.departmentName = Tgrp.userdept;
                            Trailaaps.purchasedyear = Tgrp.purchasedYear;
                            Trailaaps.purchasedsemester = Tgrp.purchasedSemester;
                            Trailaaps.purchased_content_count = Tgrp.usergroup.Where(x => x.pm.subject_unit_type == 1 && x.pm.os_type == 1).Count();
                            Trailaaps.purchased_qa_android_count = Tgrp.usergroup.Where(x => x.pm.subject_unit_type == 4 && x.pm.os_type == 2).Count();
                            Trailaaps.purchased_qa_desktop_count = Tgrp.usergroup.Where(x => x.pm.subject_unit_type == 2 && x.pm.os_type == 1).Count();
                            Trailaaps.purchased_combo_count = Tgrp.usergroup.Where(x => x.pm.subject_unit_type == 3 && x.pm.os_type == 1).Count();
                            Trailaaps.purchased_count = Tgrp.usergroup.Where(x => x.pm.os_type == 1 || x.pm.os_type == 2).Count();
                            userpurchaseData.Add(Trailaaps);
                        }


                        var res = (from aap in userpurchaseData
                                   orderby aap.purchased_combo_count descending, aap.purchased_qa_android_count descending, aap.purchased_qa_desktop_count descending, aap.purchased_content_count descending
                                   group aap by new { aap.user_id, aap.purchasedyear, aap.purchasedsemester } into resultrep
                                   select new
                                   {
                                       user_id = resultrep.Key.user_id,
                                       subjectgroup = resultrep

                                   }).ToList();

                        foreach (var grp in res)
                        {
                            AdminAnalyzeByTrailUserMultipleModel aaps = new AdminAnalyzeByTrailUserMultipleModel();
                            aaps.user_id = grp.user_id;
                            //aaps.total_purchased_content = grp.subjectgroup.Select(x => x.total_purchased_content).Sum();
                            //aaps.total_purchased_qa_android = grp.subjectgroup.Select(x => x.total_purchased_qa_android).Sum();
                            //aaps.total_purchased_qa_desktop = grp.subjectgroup.Select(x => x.total_purchased_qa_desktop).Sum();
                            aaps.purchased_content_count = grp.subjectgroup.Select(x => x.purchased_content_count).Sum();
                            aaps.purchased_qa_desktop_count = grp.subjectgroup.Select(x => x.purchased_qa_desktop_count).Sum();
                            aaps.purchased_combo_count = grp.subjectgroup.Select(x => x.purchased_combo_count).Sum();
                            aaps.purchased_qa_android_count = grp.subjectgroup.Select(x => x.purchased_qa_android_count).Sum();
                            aaps.purchased_count = grp.subjectgroup.Select(x => x.purchased_count).Sum();


                            aaps.user_name = grp.subjectgroup.FirstOrDefault().user_name;
                            aaps.user_role = grp.subjectgroup.FirstOrDefault().user_role;
                            //aaps.purchased_count = Tgrp.usergroup.Select(x => x.usm == null ? 0 : x.usm.count).Sum(); 
                            // aaps.purchased_count = grp.subjectgroup.FirstOrDefault().purchased_count;
                            aaps.univ_name = grp.subjectgroup.FirstOrDefault().univ_name;
                            aaps.univ_id = grp.subjectgroup.FirstOrDefault().univ_id;
                            aaps.mobileno = grp.subjectgroup.FirstOrDefault().mobileno;
                            aaps.year = grp.subjectgroup.FirstOrDefault().year;
                            aaps.semester = grp.subjectgroup.FirstOrDefault().semester;
                            aaps.registered_on = grp.subjectgroup.FirstOrDefault().registered_on;
                            aaps.departmentName = grp.subjectgroup.FirstOrDefault().departmentName;
                            aaps.purchasedyear = grp.subjectgroup.FirstOrDefault().purchasedyear;
                            aaps.purchasedsemester = grp.subjectgroup.FirstOrDefault().purchasedsemester;
                            userData.Add(aaps);
                        }


                    }


                    if (TraStartDate != "0" && TraEndDate != "0")
                    {
                        DateTime tra_start_date = DateTime.ParseExact(TraStartDate + " " + "00:00:00 AM", "dd-MM-yyyy hh:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);
                        DateTime tra_end_date = DateTime.ParseExact(TraEndDate + " " + "11:59:59 PM", "dd-MM-yyyy hh:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);

                        var adminanalyseUTSUserActivities = (from univ in contextsdce.university_master
                                                             join um in contextsdce.user_master on univ.univ_id equals um.univ_id
                                                             join cm in contextsdce.college_master on um.collegeid equals cm.college_id
                                                             join dm in contextsdce.department_master on um.DepartmentID equals dm.department_id
                                                             join uts in contextsdce.user_trial_subject on um.user_id equals uts.user_id // into leftuts
                                                             join pm in contextsdce.package_master on uts.subject_id equals pm.subject_id// into leftuts
                                                             //from uts in leftuts.DefaultIfEmpty()                                                     
                                                             where uts.created_on >= tra_start_date && uts.created_on <= tra_end_date // && testarray.Contains(um.mobile)
                                                             && univ.univ_id == UnivId && rolelist.Contains(um.role_id) && pm.is_bundle == 0
                                                             group new { um, cm, uts, univ, dm, pm } by new { um.user_id, um.mobile, pm.year, pm.semester } into usergrp
                                                             select new
                                                             {
                                                                 userid = usergrp.Key.user_id,
                                                                 username = usergrp.FirstOrDefault().um.user_name,
                                                                 userrole = usergrp.FirstOrDefault().um.role_id == 1 ? "Student" : "Staff",
                                                                 usermobile = usergrp.Key.mobile,
                                                                 usergroup = usergrp,
                                                                 userdept = usergrp.FirstOrDefault().dm.department_name,
                                                                 useryear = usergrp.FirstOrDefault().um.currentyear,
                                                                 userSemester = usergrp.FirstOrDefault().um.currentsemester,
                                                                 registeron = usergrp.FirstOrDefault().um.created_on,
                                                                 purchasedyear = usergrp.FirstOrDefault().pm.year,
                                                                 purchasedSemester = usergrp.FirstOrDefault().pm.semester
                                                             }).ToList();

                        foreach (var Tgrp in adminanalyseUTSUserActivities)
                        {
                            AdminAnalyzeByTrailUserMultipleModel Trailaaps = new AdminAnalyzeByTrailUserMultipleModel();
                            Trailaaps.user_id = Tgrp.userid;
                            Trailaaps.user_name = Tgrp.username;
                            Trailaaps.user_role = Tgrp.userrole;
                            //Trailaaps.trail_count = Tgrp.usergroup.Select(x => x.uts == null ? 0 : 1).Sum();
                            Trailaaps.trail_count = Tgrp.usergroup.Select(x => x.uts.user_trial_subject_id).Distinct().Count();
                            Trailaaps.univ_name = Tgrp.usergroup.FirstOrDefault().univ.university_name;
                            Trailaaps.univ_id = Tgrp.usergroup.FirstOrDefault().univ.univ_id;
                            Trailaaps.mobileno = Tgrp.usermobile;
                            Trailaaps.year = Tgrp.useryear;
                            Trailaaps.semester = Tgrp.userSemester;
                            Trailaaps.registered_on = Tgrp.registeron.ToString("dd-MM-yyyy");
                            Trailaaps.departmentName = Tgrp.userdept;
                            Trailaaps.purchasedyear = Tgrp.purchasedyear;
                            Trailaaps.purchasedsemester = Tgrp.purchasedSemester;
                            userData.Add(Trailaaps);
                        }
                    }

                    if (UsgStartDate != "0" && UsgEndDate != "0")
                    {
                        DateTime usg_start_date = DateTime.ParseExact(UsgStartDate + " " + "00:00:00 AM", "dd-MM-yyyy hh:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);
                        DateTime usg_end_date = DateTime.ParseExact(UsgEndDate + " " + "11:59:59 PM", "dd-MM-yyyy hh:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);

                        var adminanalyseUSRHUserActivities = (from univ in contextsdce.university_master
                                                              join um in contextsdce.user_master on univ.univ_id equals um.univ_id
                                                              join cm in contextsdce.college_master on um.collegeid equals cm.college_id
                                                              join dm in contextsdce.department_master on um.DepartmentID equals dm.department_id
                                                              join usrh in contextsdce.user_subject_read_history on um.user_id equals usrh.user_id // into leftuts
                                                              join pm in contextsdce.package_master on usrh.subject_id equals pm.subject_id // into leftuts
                                                              // from usrh in leftuts.DefaultIfEmpty()
                                                              where usrh.last_read_on >= usg_start_date && usrh.last_read_on <= usg_end_date // && testarray.Contains(um.mobile)
                                                              && univ.univ_id == UnivId && rolelist.Contains(um.role_id) && pm.is_bundle == 0
                                                              group new { um, cm, usrh, univ, dm, pm } by new { um.user_id, um.mobile, pm.year, pm.semester } into usergrp
                                                              select new
                                                              {
                                                                  userid = usergrp.Key.user_id,
                                                                  username = usergrp.FirstOrDefault().um.user_name,
                                                                  userrole = usergrp.FirstOrDefault().um.role_id == 1 ? "Student" : "Staff",
                                                                  usermobile = usergrp.Key.mobile,
                                                                  usergroup = usergrp,
                                                                  userdept = usergrp.FirstOrDefault().dm.department_name,
                                                                  useryear = usergrp.FirstOrDefault().um.currentyear,
                                                                  userSemester = usergrp.FirstOrDefault().um.currentsemester,
                                                                  registeron = usergrp.FirstOrDefault().um.created_on,
                                                                  purchasedyear = usergrp.FirstOrDefault().pm.year,
                                                                  purchasedSemester = usergrp.FirstOrDefault().pm.semester
                                                              }).ToList();

                        foreach (var Tgrp in adminanalyseUSRHUserActivities)
                        {
                            AdminAnalyzeByTrailUserMultipleModel Trailaaps = new AdminAnalyzeByTrailUserMultipleModel();
                            Trailaaps.user_id = Tgrp.userid;
                            Trailaaps.user_name = Tgrp.username;
                            Trailaaps.user_role = Tgrp.userrole;
                            Trailaaps.Usage_hours = Tgrp.usergroup.Select(x => x.usrh.user_id).Distinct().Count();
                            Trailaaps.univ_name = Tgrp.usergroup.FirstOrDefault().univ.university_name;
                            Trailaaps.univ_id = Tgrp.usergroup.FirstOrDefault().univ.univ_id;
                            Trailaaps.mobileno = Tgrp.usermobile;
                            Trailaaps.year = Tgrp.useryear;
                            Trailaaps.semester = Tgrp.userSemester;
                            Trailaaps.registered_on = Tgrp.registeron.ToString("dd-MM-yyyy");
                            Trailaaps.departmentName = Tgrp.userdept;
                            Trailaaps.purchasedyear = Tgrp.purchasedyear;
                            Trailaaps.purchasedsemester = Tgrp.purchasedSemester;
                            userData.Add(Trailaaps);
                        }
                    }

                }
                CultureInfo provider = CultureInfo.InvariantCulture;
                string format = "d";
                var userFinalData1 = (from ud in userData
                                          // join dm in department_master on ud.de
                                      orderby ud.user_name
                                      group ud by new { ud.user_id, ud.purchasedyear, ud.purchasedsemester } into grpusers
                                      select new
                                      {
                                          user_id = grpusers.Key.user_id,
                                          user_name = grpusers.FirstOrDefault().user_name,
                                          user_role = grpusers.FirstOrDefault().user_role,
                                          purchased_content_count = grpusers.Select(x => x.purchased_content_count).Sum(),
                                          purchased_qa_desktop_count = grpusers.Select(x => x.purchased_qa_desktop_count).Sum(),
                                          purchased_qa_android_count = grpusers.Select(x => x.purchased_qa_android_count).Sum(),
                                          purchased_combo_count = grpusers.Select(x => x.purchased_combo_count).Sum(),
                                          purchased_count = grpusers.Select(x => x.purchased_count).Sum(),
                                          trail_count = grpusers.Select(x => x.trail_count).Sum(),
                                          Usage_hours = grpusers.Select(x => x.Usage_hours).Sum(),
                                          univ_name = grpusers.FirstOrDefault().univ_name,
                                          univ_id = grpusers.FirstOrDefault().univ_id,
                                          mobileno = grpusers.FirstOrDefault().mobileno,
                                          departmentName = grpusers.FirstOrDefault().departmentName,
                                          year = grpusers.FirstOrDefault().year,
                                          semester = grpusers.FirstOrDefault().semester,
                                          // registered_date = DateTime.ParseExact(grpusers.FirstOrDefault().registered_on, "dd/mm/yyyy", null),
                                          registered_on = grpusers.FirstOrDefault().registered_on,
                                          purchasedyear = grpusers.FirstOrDefault().purchasedyear,
                                          purchasedsemester = grpusers.FirstOrDefault().purchasedsemester

                                      }).ToList();

                userFinalData = (from result in userFinalData1
                                 select new AdminAnalyzeByTrailUserMultipleModel
                                 {
                                     user_id = result.user_id,
                                     user_name = result.user_name,
                                     user_role = result.user_role,
                                     purchased_content_count = result.purchased_content_count,
                                     purchased_qa_desktop_count = result.purchased_qa_desktop_count,
                                     purchased_qa_android_count = result.purchased_qa_android_count,
                                     purchased_combo_count = result.purchased_combo_count,
                                     purchased_count = result.purchased_count,
                                     trail_count = result.trail_count,
                                     Usage_hours = result.Usage_hours,
                                     univ_name = result.univ_name,
                                     univ_id = result.univ_id,
                                     mobileno = result.mobileno,
                                     departmentName = result.departmentName,
                                     year = result.year,
                                     semester = result.semester,
                                     //registered_date = result.registered_on.SafeParse(),
                                     registered_on = result.registered_on,
                                     purchasedyear = result.purchasedyear,
                                     purchasedsemester = result.purchasedsemester
                                 }).ToList();
            }
            catch (Exception ex)
            {
                Log.WriteLogMessage("AdminAnalysservice", "AdminAnalysservice", "UpdatePreparationOrderStatus", ex.Message, "error");
                // throw ex;
            }
            return userFinalData;
        }



        public List<AdminAnalyzeByTrailUserMultipleModel> GetAnalyseDataByUuniversity()
        {
            List<AdminAnalyzeByTrailUserMultipleModel> userData = new List<AdminAnalyzeByTrailUserMultipleModel>();
            List<AdminAnalyzeByTrailUserMultipleModel> userFinalData = new List<AdminAnalyzeByTrailUserMultipleModel>();

            List<int> rolelist = new List<int>();
            rolelist.Add(1);
            rolelist.Add(2);

            try
            {
                using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
                {



                    var ReguserData = (from univ in contextsdce.university_master
                                       join um in contextsdce.user_master on univ.univ_id equals um.univ_id
                                       join col in contextsdce.college_master on univ.univ_id equals col.university_id
                                       where um.collegeid == col.college_id && um.active_status == 1 && rolelist.Contains(um.role_id)
                                       group new { um, univ } by new { univ.univ_id, univ.university_name } into usergrp
                                       select new AdminAnalyzeByTrailUserMultipleModel
                                       {
                                           univ_id = usergrp.Key.univ_id,
                                           univ_name = usergrp.FirstOrDefault().univ.university_name,
                                           registered_count = usergrp.Select(x => x.um.user_id).Count()

                                       }).ToList();

                    userData.AddRange(ReguserData);



                    var PuruserData = (from univ in contextsdce.university_master
                                       join um in contextsdce.user_master on univ.univ_id equals um.univ_id
                                       join cm in contextsdce.college_master on um.collegeid equals cm.college_id
                                       join usm in contextsdce.user_subscribe_master on um.user_id equals usm.user_id
                                       where usm.payment_status == 2

                                       group new { um, usm, cm, univ } by new { univ.univ_id, univ.university_name } into usergrp
                                       select new AdminAnalyzeByTrailUserMultipleModel
                                       {
                                           univ_id = usergrp.Key.univ_id,
                                           univ_name = usergrp.FirstOrDefault().univ.university_name,
                                           purchased_count = usergrp.Select(x => x.usm.count).Sum()

                                       }).ToList();

                    userData.AddRange(PuruserData);



                    var TrailuserData = (from univ in contextsdce.university_master
                                         join um in contextsdce.user_master on univ.univ_id equals um.univ_id
                                         join uts in contextsdce.user_trial_subject on um.user_id equals uts.user_id
                                         group new { um, uts, univ } by new { univ.univ_id, univ.university_name } into usergrp
                                         select new AdminAnalyzeByTrailUserMultipleModel
                                         {
                                             univ_id = usergrp.Key.univ_id,
                                             univ_name = usergrp.FirstOrDefault().univ.university_name,
                                             trail_count = usergrp.Select(x => x.uts.user_trial_subject_id).Count()

                                         }).ToList();

                    userData.AddRange(TrailuserData);



                    var UsguserData = (from univ in contextsdce.university_master
                                       join um in contextsdce.user_master on univ.univ_id equals um.univ_id
                                       join usrh in contextsdce.user_subject_read_history on um.user_id equals usrh.user_id
                                       group new { usrh, univ } by new { univ.univ_id, univ.university_name } into usergrp
                                       select new AdminAnalyzeByTrailUserMultipleModel
                                       {
                                           univ_id = usergrp.Key.univ_id,
                                           univ_name = usergrp.FirstOrDefault().univ.university_name,
                                           Usage_hours = usergrp.Select(x => x.usrh.user_id).Distinct().Count()

                                       }).ToList();

                    userData.AddRange(UsguserData);



                    userFinalData = (from ud in userData
                                     orderby ud.univ_name
                                     group ud by ud.univ_id into grpusers
                                     select new AdminAnalyzeByTrailUserMultipleModel
                                     {
                                         univ_id = grpusers.Key,
                                         purchased_count = grpusers.Select(x => x.purchased_count).Sum(),
                                         trail_count = grpusers.Select(x => x.trail_count).Sum(),
                                         //   Total_Usage_hours = string.Format("{0:00}:{1:00}:{2:00}", grpusers.Sum(x => x.Usage_hours) / 3600, (grpusers.Sum(x => x.Usage_hours) / 60) % 60, grpusers.Sum(x => x.Usage_hours) % 60),
                                         Total_Usage_hours = grpusers.Sum(x => x.Usage_hours).ToString(),
                                         univ_name = grpusers.FirstOrDefault().univ_name,
                                         registered_count = grpusers.Select(x => x.registered_count).Sum()

                                     }).ToList();
                }

            }
            catch (Exception Ex)
            {

                throw Ex;
            }
            return userFinalData;
        }



        public List<AdminAnalyzeByTrailSubjectModel> GetAnalyseSubjectDataByUuniversity()
        {
            List<AdminAnalyzeByTrailSubjectModel> userData = new List<AdminAnalyzeByTrailSubjectModel>();
            List<AdminAnalyzeByTrailSubjectModel> userFinalData = new List<AdminAnalyzeByTrailSubjectModel>();

            try
            {
                using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
                {

                    var ReguserData = (from univ in contextsdce.university_master
                                       join sub in contextsdce.subject_master on univ.univ_id equals sub.UniversityID
                                       where univ.university_type == 1
                                       group new { sub, univ } by new { univ.univ_id, univ.university_name } into usergrp
                                       select new AdminAnalyzeByTrailSubjectModel
                                       {
                                           univ_id = usergrp.Key.univ_id,
                                           univ_name = usergrp.FirstOrDefault().univ.university_name,
                                           actual_subject_count = usergrp.Select(x => x.sub.subject_id).Distinct().Count()

                                       }).ToList();

                    userData.AddRange(ReguserData);


                    // Start purchase subjects
                    List<AdminAnalyzeByTrailSubjectModel> userPurchaseData = new List<AdminAnalyzeByTrailSubjectModel>();

                    var adminactivities = (from usm in contextsdce.user_subscribe_master
                                           join usd in contextsdce.user_subscribe_details on usm.user_subscribe_master_id equals usd.user_subscribe_master_id
                                           join pm in contextsdce.package_master on usd.package_id equals pm.package_id
                                           join univ in contextsdce.university_master on pm.univ_id equals univ.univ_id
                                           join sub in contextsdce.subject_master on pm.subject_id equals sub.subject_id
                                           where pm.is_bundle == 0 && usm.payment_status == 2
                                           && univ.university_type == 1
                                           group new { sub, univ } by new { univ.univ_id, univ.university_name, sub.subject_id } into subjectpurchasegrp

                                           select new AdminAnalyzeByTrailSubjectModel
                                           {
                                               univ_id = subjectpurchasegrp.Key.univ_id,
                                               subject_id = subjectpurchasegrp.Key.subject_id,
                                               univ_name = subjectpurchasegrp.Key.university_name,

                                           }).ToList();

                    userPurchaseData.AddRange(adminactivities);

                    var adminActivitiesBundle = (from usm in contextsdce.user_subscribe_master
                                                 join usd in contextsdce.user_subscribe_details on usm.user_subscribe_master_id equals usd.user_subscribe_master_id
                                                 join pm in contextsdce.package_master on usd.package_id equals pm.package_id
                                                 join pd in contextsdce.package_details on pm.package_id equals pd.package_id
                                                 join univ in contextsdce.university_master on pm.univ_id equals univ.univ_id
                                                 join sub in contextsdce.subject_master on pd.subject_id equals sub.subject_id
                                                 where pm.is_bundle == 1 && usm.payment_status == 2 && univ.university_type == 1
                                                 group new { sub, univ } by new { univ.univ_id, univ.university_name, sub.subject_id } into subjectpurchasegrp

                                                 select new AdminAnalyzeByTrailSubjectModel
                                                 {
                                                     univ_id = subjectpurchasegrp.Key.univ_id,
                                                     subject_id = subjectpurchasegrp.Key.subject_id,
                                                     univ_name = subjectpurchasegrp.Key.university_name,

                                                 }).ToList();

                    userPurchaseData.AddRange(adminActivitiesBundle);

                    var purchaseFinal = (from purfinal in userPurchaseData
                                         group purfinal by purfinal.univ_id into purchasegrp
                                         select new AdminAnalyzeByTrailSubjectModel
                                         {
                                             univ_id = purchasegrp.Key,
                                             purchased_count = purchasegrp.Select(x => x.subject_id).Distinct().Count(),
                                             univ_name = purchasegrp.FirstOrDefault().univ_name,

                                         }).ToList();
                    userData.AddRange(purchaseFinal);


                    var TrailuserData = (from univ in contextsdce.university_master
                                         join um in contextsdce.user_master on univ.univ_id equals um.univ_id
                                         join uts in contextsdce.user_trial_subject on um.user_id equals uts.user_id
                                         join sub in contextsdce.subject_master on uts.subject_id equals sub.subject_id
                                         where univ.university_type == 1
                                         group new { sub, univ } by new { univ.univ_id, univ.university_name } into subjectTrailgrp
                                         select new AdminAnalyzeByTrailSubjectModel
                                         {
                                             univ_id = subjectTrailgrp.Key.univ_id,
                                             univ_name = subjectTrailgrp.FirstOrDefault().univ.university_name,
                                             trail_count = subjectTrailgrp.Select(x => x.sub.subject_id).Distinct().Count()

                                         }).ToList();

                    userData.AddRange(TrailuserData);



                    var UsguserData = (from univ in contextsdce.university_master
                                       join um in contextsdce.user_master on univ.univ_id equals um.univ_id
                                       join usrh in contextsdce.user_subject_read_history on um.user_id equals usrh.user_id
                                       join sub in contextsdce.subject_master on usrh.subject_id equals sub.subject_id
                                       where univ.university_type == 1 && sub.UniversityID == univ.univ_id
                                       group new { sub, univ } by new { univ.univ_id, univ.university_name } into subjectusggrp
                                       select new AdminAnalyzeByTrailSubjectModel
                                       {
                                           univ_id = subjectusggrp.Key.univ_id,
                                           univ_name = subjectusggrp.FirstOrDefault().univ.university_name,
                                           Usage_Count = subjectusggrp.Select(x => x.sub.subject_id).Distinct().Count()

                                       }).ToList();

                    userData.AddRange(UsguserData);



                    userFinalData = (from ud in userData
                                     orderby ud.univ_name
                                     group ud by ud.univ_id into grpusers
                                     select new AdminAnalyzeByTrailSubjectModel
                                     {
                                         univ_id = grpusers.Key,
                                         purchased_count = grpusers.Select(x => x.purchased_count).Sum(),
                                         trail_count = grpusers.Select(x => x.trail_count).Sum(),
                                         Usage_Count = grpusers.Select(x => x.Usage_Count).Sum(),
                                         univ_name = grpusers.FirstOrDefault().univ_name,
                                         actual_subject_count = grpusers.Select(x => x.actual_subject_count).Sum()

                                     }).ToList();
                }

            }
            catch (Exception Ex)
            {

                throw Ex;
            }
            return userFinalData;
        }

        /// <summary>
        /// DateWise_Sales_Report
        /// </summary>
        /// <returns></returns>
        public List<Datewise_Sales_Report> DateWise_Sales_Report()
        {
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                List<Datewise_Sales_Report> DateWise_Sales = new List<Datewise_Sales_Report>();

                try
                {
                    //DateTime CreatedOn_start_date = DateTime.ParseExact(StartDate + " " + "00:00:00 AM", "dd-MM-yyyy hh:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);
                    //DateTime CreatedOn_End_date = DateTime.ParseExact(EndDate + " " + "11:59:59 PM", "dd-MM-yyyy hh:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);

                    //                    select univ.university_name University, CAST(py.TxnDate as DATE) TxnDate, count(usm.payment_ref_no)TotalOrders, SUM(py.TxnAmount) TotalAmount
                    //from university_master univ join user_master um on um.univ_id = univ.univ_id
                    //join user_subscribe_master usm on usm.user_id = um.user_id
                    //join payment_master py on py.user_subscribe_master_id = usm.user_subscribe_master_id
                    //where usm.payment_status = 2 and py.TxnStatus = 2
                    //and CAST(usm.created_on as DATE) >= '2016-09-25'
                    //group by  univ.university_name, CAST(py.TxnDate as DATE)
                    //order by  univ.university_name, CAST(py.TxnDate as DATE)

                    var DateWise_Sales1 = (from univ in contextsdce.university_master
                                           join um in contextsdce.user_master on univ.univ_id equals um.univ_id
                                           join usm in contextsdce.user_subscribe_master on um.user_id equals usm.user_id
                                           join pm in contextsdce.payment_master on usm.user_subscribe_master_id equals pm.user_subscribe_master_id
                                           where usm.payment_status == 2 && pm.TxnStatus == "2" && um.active_status==1
                                           && usm.order_status != 2 
                                           //&& usm.created_on >= CreatedOn_start_date && usm.created_on <= CreatedOn_End_date
                                           orderby usm.created_on, univ.university_name
                                           //group new { univ, usm, pm, um } by new { univ.univ_id, usm.created_on } into sales
                                           select new
                                           {
                                               univ_id = univ.univ_id,
                                               universityShortname = univ.university_shortname,
                                               universityName = univ.university_name,
                                               TxnDate = System.Data.Entity.DbFunctions.TruncateTime(pm.TxnDate),
                                               user_id = um.user_id.ToString(),
                                               Orderno = usm.payment_ref_no.ToString(),
                                               TotalAmount = pm.TxnAmount
                                           }).ToList();
                    DateWise_Sales = (from sales in DateWise_Sales1
                                          //&& usm.created_on >= CreatedOn_start_date && usm.created_on <= CreatedOn_End_date
                                      orderby sales.TxnDate, sales.universityName
                                      group new { sales } by new { sales.univ_id, sales.TxnDate } into sales
                                      select new Datewise_Sales_Report
                                      {
                                          universityName = sales.FirstOrDefault().sales.universityName,
                                          universityShortName = sales.FirstOrDefault().sales.universityShortname,
                                          TxnDate = sales.FirstOrDefault().sales.TxnDate.Value.Date,
                                          TotalOrders = sales.Select(x => x.sales.Orderno).Count(),
                                          TotalAmount = sales.Select(x => x.sales.TotalAmount).Sum()
                                      }).ToList();
                    return DateWise_Sales;
                }
                catch (Exception ex)
                {
                    contextsdce.Dispose();
                    Log.WriteLogMessage(PageName, "AdminService", "DateWise_Sales_Report", ex.Message, "error");
                    throw ex;
                }
                finally
                {
                    contextsdce.Dispose();
                }
            }
        }

        /// <summary>
        /// SemesterBatchReport for All university
        /// </summary>
        /// <returns></returns>
        public List<SemBatchReport> SemesterBatchReport()
        {
            List<SemBatchReport> semreport = new List<SemBatchReport>();

            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                try
                {

                    semreport = (from sbd in contextsdce.sms_batch_data
                                 join um in contextsdce.user_master on sbd.mobile equals um.mobile into lftum
                                 from um in lftum.DefaultIfEmpty()
                                 join byd in contextsdce.batch_year_master on sbd.batch_year_id equals byd.batch_year_id
                                 join unvm in contextsdce.university_master on sbd.university_id equals unvm.univ_id
                                 group new { sbd, unvm, byd, um } by new { sbd.university_id, sbd.year, sbd.batch_year_id } into g
                                 select new SemBatchReport
                                 {
                                     universityId = g.FirstOrDefault().sbd.university_id,
                                     universityName = g.FirstOrDefault().unvm.university_name,
                                     BatchYear = g.FirstOrDefault().byd.batch_year,
                                     BatchYearId = g.FirstOrDefault().sbd.batch_year_id,
                                     Year = g.FirstOrDefault().sbd.year,
                                     SMSusers = g.Select(x => x.sbd.mobile).Count(),
                                     Registeredusers = g.Select(x => x.um.mobile).Distinct().Count()
                                 }).OrderBy(x => x.universityId).ToList();

                    return semreport;
                }
                catch (Exception ex)
                {
                    Log.WriteLogMessage(PageName, "SemesterBatchReport", "SemesterBatchReport", ex.Message, "error");
                    throw ex;

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

        /// <summary>
        /// Excel reports for sms batch data
        /// </summary>
        /// <param name="univId"></param>
        /// <param name="year"></param>
        /// <param name="batchyearId"></param>
        /// <param name="rpt_type"></param>
        /// <returns></returns>
        public List<SemBatchReport> ExportSMSdataReport(int univId, int year, int batchyearId, int rpt_type)
        {
            List<SemBatchReport> smsreport = new List<SemBatchReport>();

            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                try
                {
                    if (rpt_type == 1)
                    {
                        smsreport = (from sbd in contextsdce.sms_batch_data
                                     join um in contextsdce.user_master on sbd.mobile equals um.mobile
                                     join byd in contextsdce.batch_year_master on sbd.batch_year_id equals byd.batch_year_id
                                     join unvm in contextsdce.university_master on sbd.university_id equals unvm.univ_id
                                     where sbd.university_id == univId && sbd.year == year && sbd.batch_year_id == batchyearId
                                     select new SemBatchReport
                                     {
                                         universityName = unvm.university_name,
                                         BatchYear = byd.batch_year,
                                         Year = sbd.year,
                                         UserName = um.user_name,
                                         Mobile = um.mobile
                                     }).ToList();

                    }
                    else if (rpt_type == 2)
                    {
                        var report = (from sbd in contextsdce.sms_batch_data
                                      join um in contextsdce.user_master on sbd.mobile equals um.mobile into lftum
                                      from um in lftum.DefaultIfEmpty()
                                      join byd in contextsdce.batch_year_master on sbd.batch_year_id equals byd.batch_year_id
                                      join unvm in contextsdce.university_master on sbd.university_id equals unvm.univ_id
                                      where sbd.university_id == univId && sbd.year == year && sbd.batch_year_id == batchyearId
                                      && sbd.mobile != um.mobile
                                      select new
                                      {
                                          univName = unvm.university_name,
                                          batchyear = byd.batch_year,
                                          year = sbd.year,
                                          smsmobile = sbd.mobile,
                                      }).ToList();

                        smsreport = (from t in report
                                     select new SemBatchReport
                                     {
                                         universityName = t.univName,
                                         BatchYear = t.batchyear,
                                         Year = t.year,
                                         Mobile = t.smsmobile
                                     }).ToList();
                    }
                    else
                    {
                        smsreport = (from sbd in contextsdce.sms_batch_data
                                     join byd in contextsdce.batch_year_master on sbd.batch_year_id equals byd.batch_year_id
                                     where sbd.university_id == univId && sbd.year == year && sbd.batch_year_id == batchyearId
                                     select new SemBatchReport
                                     {
                                         universityId = sbd.university_id,
                                         BatchYear = byd.batch_year,
                                         Year = sbd.year,
                                         Mobile = sbd.mobile
                                     }).ToList();
                    }
                    return smsreport;
                }
                catch (Exception ex)
                {
                    Log.WriteLogMessage(PageName, "ExportSMSdataReport", "ExportSMSdataReport", ex.Message, "error");
                    throw ex;

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

    }
}