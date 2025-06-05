using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Odishadtet.DAL;
using System.Web.Script.Serialization;
using System.Web.Http;
using Odishadtet.Models;
using LearnEngineeringPortalService_ITI;
using TNDET.DataAccess;
using System.Xml.Linq;
using Odishadtet.DAL;
using Odishadtet.General;

namespace Odishadtet.DAL
{
    /// <summary>
    ///  To Disply Product and Details
    /// </summary>
    /// <returns></returns>
    /// 
    public class ProductService : IProductService
    {
        string pkgCoverpath = ConfigurationManager.AppSettings["SubjectCoverPath"].ToString();
        string PageName = "ProductService.cs";

        public void DoWork()
        {
        }
        /// <summary>
        ///  To Get Pacakages based Department Details
        /// </summary>
        /// <returns></returns>
        public List<Departmentdetails> GetDepartmentDetails()
        {
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                List<Departmentdetails> depart_package = new List<Departmentdetails>();

                try
                {
                    depart_package = (from dept in contextsdce.department_master
                                      join pckg in contextsdce.package_master on dept.department_id equals pckg.department_id into result
                                      from pckg in result.DefaultIfEmpty()
                                      where dept.active_status == 1
                                      select new
                                      {
                                          deptId = dept.department_id,
                                          deptName = dept.department_name,
                                          package_ = pckg.package_id,
                                          deptimgpath = dept.dept_img_path,
                                          keywords = pckg.keywords
                                      }).GroupBy(t => t.deptId).Select(g => new Departmentdetails
                                      {
                                          DepartmentId = g.FirstOrDefault().deptId,
                                          DepartmentName = g.FirstOrDefault().deptName,
                                          packageCount = g.Count(),
                                          DeptImagePath = g.FirstOrDefault().deptimgpath,
                                          SearchKeywords = g.FirstOrDefault().keywords

                                      }).ToList();

                    return depart_package;
                }
                catch (Exception ex)
                {
                    contextsdce.Dispose();
                    Log.WriteLogMessage(PageName, "Product", "GetDepartmentDetails", ex.Message, "error");
                    throw;
                }
                finally
                {
                    contextsdce.Dispose();
                }
            }


        }
        /// <summary>
        /// To Get Subject Details based On Department
        /// </summary>
        /// <param name="departmentID"></param>
        /// <returns></returns>
        public List<SubjectDetails> GetSubjectDetails(int departmentID)
        {
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {


                List<SubjectDetails> subject_details = new List<SubjectDetails>();
                try
                {
                    subject_details = (from dept in contextsdce.department_master
                                       join dpsm in contextsdce.department_subject_mapping on dept.department_id equals dpsm.department_id
                                       join subj in contextsdce.subject_master on dpsm.subject_id equals subj.subject_id
                                       join unm in contextsdce.subject_unit_master on subj.subject_id equals unm.subject_id
                                       join pckg in contextsdce.package_master on subj.subject_id equals pckg.subject_id
                                       where subj.active_status == 1 && pckg.subject_id == unm.unit_id
                                       select new
                                       {
                                           depart_id = dept.department_id,
                                           deptName = dept.department_name,
                                           packageid = pckg.package_id,
                                           subjectid = subj.subject_id,
                                           subjName = subj.subject_name,
                                           unitid = unm.unit_id,
                                           unitcode = unm.unit_code,
                                           unitname = unm.unit_name,

                                       }).GroupBy(t => t.unitid).Select(g => new SubjectDetails
                                       {
                                           deprtId = g.FirstOrDefault().depart_id,
                                           deprtName = g.FirstOrDefault().deptName,
                                           subj_ID = g.FirstOrDefault().subjectid,
                                           subj_Name = g.FirstOrDefault().subjName,
                                           PackageCount = g.Count(),
                                           UnitId = g.FirstOrDefault().unitid,
                                           UnitCode = g.FirstOrDefault().unitcode,
                                           UnitName = g.FirstOrDefault().unitname
                                       }).ToList();


                    if (departmentID > 0)
                    {
                        var datanew = subject_details.ToList();
                        subject_details.Clear();
                        subject_details.AddRange(datanew.Where(x => x.deprtId == departmentID));
                    }
                    return subject_details;

                }
                catch (Exception ex)
                {
                    contextsdce.Dispose();
                    Log.WriteLogMessage(PageName, "Product", "GetSubjectDetails", ex.Message, "error");
                    throw;
                }
                finally
                {
                    contextsdce.Dispose();
                }

            }
        }

        /// <summary>
        /// To Get Packages Details for Department and Subject
        /// </summary>
        /// <param name="departId"></param>
        /// <param name="subjectid"></param>
        /// <returns></returns>
        public List<Packagedetails> GetPackageDetails(int departId, long subjectid)
        {
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {


                List<Packagedetails> package_details = new List<Packagedetails>();

                try
                {
                    package_details = (from pckg in contextsdce.package_master
                                       join dm in contextsdce.department_master on pckg.department_id equals dm.department_id
                                       where dm.department_id == departId && pckg.activestatus == 1
                                       select new Packagedetails
                                       {
                                           departID = pckg.department_id,
                                           subjectID = pckg.subject_id,
                                           UnitId = pckg.subject_id,
                                           subj_Parent_unitId = pckg.subject_id,
                                           packageId = pckg.package_id,
                                           packageCode = pckg.package_code,
                                           packageName = pckg.package_name,
                                           packSellingprice = pckg.selling_price,
                                           packActprice = pckg.actual_price,
                                           pckg_Shortdesc = pckg.short_desc,
                                           pckg_longdesc = pckg.long_desc,
                                           pckgeCoverpath = pkgCoverpath,
                                           packageDuration = pckg.package_duration_days

                                       }).ToList();

                    if (departId > 0 && subjectid > 0)
                    {
                        var datanew = package_details.ToList();
                        package_details.Clear();
                        package_details.AddRange(datanew.Where(x => x.departID == departId && x.subjectID == subjectid));
                    }

                    return package_details;
                }
                catch (Exception ex)
                {
                    contextsdce.Dispose();
                    Log.WriteLogMessage(PageName, "Product", "GetPackageDetails", ex.Message, "error");
                    throw;
                }
                finally
                {
                    contextsdce.Dispose();
                }

            }
        }
        /// <summary>
        /// To Get Single packages details
        /// </summary>
        /// <param name="PackageId"></param>
        /// <returns></returns>
        public List<singlePackagedetails> GetSinglePackageDetails(int PackageId)
        {
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                List<singlePackagedetails> singlePackage = new List<singlePackagedetails>();
                try
                {
                    singlePackage = (from pckge in contextsdce.package_master
                                     join dm in contextsdce.department_master on pckge.department_id equals dm.department_id

                                     where pckge.package_id == PackageId
                                     //&& pckge.activestatus==1
                                     select new singlePackagedetails
                                     {
                                         packageId = pckge.package_id,
                                         pckgeCoverpath = pckge.cover_path,
                                         packageName = pckge.package_name,
                                         packageQuickDesc = pckge.short_desc,
                                         packageDesc = pckge.long_desc,
                                         packageKeyword = pckge.keywords,
                                         packSellingprice = pckge.selling_price,
                                         packageStatus = pckge.activestatus == 1 ? "Available" : "Not Available",
                                         packageViedeo = pckge.package_video_url

                                     }).ToList();
                    return singlePackage;
                }
                catch (Exception ex)
                {
                    contextsdce.Dispose();
                    Log.WriteLogMessage(PageName, "Product", "GetSinglePackageDetailsold", ex.Message, "error");
                    throw;
                }
                finally
                {
                    contextsdce.Dispose();
                }
            }

        }

        public singlePackagedetails GetSinglePackage(int PackageId)
        {
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                singlePackagedetails pd = new singlePackagedetails();
                // List singlePackage = new List();
                try
                {
                    var displyname = (from pm in contextsdce.package_master where pm.package_id == PackageId select new { displayPackName = pm.package_display_name, displayUniv = pm.univ_id, displyDepart = pm.department_id }).FirstOrDefault();

                    var singlePackages = (from pckge in contextsdce.package_master
                                          join dm in contextsdce.department_master on pckge.department_id equals dm.department_id
                                          join rm in contextsdce.regulation_master on pckge.rule_id equals rm.rule_id
                                          join univ in contextsdce.university_master on pckge.univ_id equals univ.univ_id
                                          join ucd in contextsdce.user_cart_details on pckge.package_id equals ucd.package_id into lftucd
                                          from ucd in lftucd.DefaultIfEmpty()
                                          where pckge.package_display_name.Equals(displyname.displayPackName.ToString())
                                          && pckge.department_id.Equals(displyname.displyDepart) && pckge.univ_id.Equals(displyname.displayUniv)
                                          && pckge.activestatus == 1 && pckge.univ_id == rm.university_id
                                          orderby pckge.package_name
                                          group new { pckge, ucd, dm, univ, rm } by pckge.package_display_name into g
                                          select new { packagename = g.Key, packageDetail = g }
                                        );


                    foreach (var package in singlePackages)
                    {

                        pd.packageName = package.packagename;
                        List<string> Content_packs = new List<string>();
                        List<string> QA_packs = new List<string>();
                        List<string> Bundle_packs = new List<string>();


                        pd.packageId = package.packageDetail.FirstOrDefault().pckge.package_id;
                        pd.departmentName = package.packageDetail.FirstOrDefault().dm.department_name;
                        pd.universityName = package.packageDetail.FirstOrDefault().univ.university_name;
                        pd.universityId = package.packageDetail.FirstOrDefault().univ.univ_id;
                        pd.packageQuickDesc = package.packageDetail.FirstOrDefault().pckge.short_desc;
                        pd.packageDesc = package.packageDetail.FirstOrDefault().pckge.long_desc;
                        pd.packageKeyword = package.packageDetail.FirstOrDefault().pckge.keywords;
                        pd.packageViedeo = package.packageDetail.FirstOrDefault().pckge.package_video_url == null ? "NoVideo" : ConfigurationManager.AppSettings["VideoUrl"] + package.packageDetail.FirstOrDefault().pckge.univ_id + "/" + package.packageDetail.FirstOrDefault().rm.rule_name + "/" + package.packageDetail.FirstOrDefault().pckge.package_video_url;
                        if (package.packageDetail.FirstOrDefault().pckge.is_bundle == 0 && package.packageDetail.FirstOrDefault().pckge.is_offer_package == 1)
                        {
                            pd.trialpackage = ConfigurationManager.AppSettings["trialdownload"] + package.packageDetail.FirstOrDefault().pckge.univ_id + "/" + package.packageDetail.FirstOrDefault().rm.rule_name + "/" + package.packageDetail.FirstOrDefault().pckge.package_display_name.Replace(" ", "_") + "_Trial.exe";
                            pd.packageDescfull = ConfigurationManager.AppSettings["LongDesc"] + package.packageDetail.FirstOrDefault().pckge.univ_id + "/" + package.packageDetail.FirstOrDefault().rm.rule_name + "/" + package.packageDetail.FirstOrDefault().pckge.package_display_name.Replace(' ', '_') + ".pdf";
                        }
                        else if (package.packageDetail.FirstOrDefault().pckge.is_bundle == 1)
                        {
                            pd.trialpackage = "NoBundleFile";
                            pd.packageDescfull = "NoBundleFile";
                        }
                        else
                        {
                            pd.trialpackage = "No file";
                            pd.packageDescfull = "No file";
                        }
                        foreach (var pack in package.packageDetail)
                        {

                            switch (pack.pckge.subject_unit_type)
                            {


                                case 1:

                                    Content_packs.Add(pack.pckge.package_id.ToString());
                                    Content_packs.Add(pack.pckge.selling_price.ToString());
                                    Content_packs.Add(pack.pckge.actual_price.ToString());
                                    Content_packs.Add(pack.pckge.current_status == 0 ? "0" : "1");
                                    Content_packs.Add("no");

                                    break;

                                case 2:
                                    QA_packs.Add(pack.pckge.package_id.ToString());
                                    QA_packs.Add(pack.pckge.selling_price.ToString());
                                    QA_packs.Add(pack.pckge.actual_price.ToString());
                                    QA_packs.Add(pack.pckge.current_status == 0 ? "0" : "1");
                                    QA_packs.Add("no");

                                    break;

                                case 3:
                                    Bundle_packs.Add(pack.pckge.package_id.ToString());
                                    Bundle_packs.Add(pack.pckge.selling_price.ToString());
                                    Bundle_packs.Add(pack.pckge.actual_price.ToString());
                                    Bundle_packs.Add(pack.pckge.current_status == 0 ? "0" : "1");
                                    Bundle_packs.Add("no");

                                    break;

                                default:
                                    break;
                            }

                        }

                        pd.Bundlepacks = Bundle_packs;
                        pd.Contentpacks = Content_packs;
                        pd.QApacks = QA_packs;

                    }

                    return pd;
                }
                catch (Exception ex)
                {
                    contextsdce.Dispose();
                    Log.WriteLogMessage(PageName, "Product", "GetSinglePackageDetailsWithoutLogin", ex.Message, "error");
                    throw;
                }
                finally
                {
                    contextsdce.Dispose();
                }
            }

        }

        public singlePackagedetails GetSinglePackagewithlogin(long UserId, int PackageId)
        {
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                singlePackagedetails pd = new singlePackagedetails();
                // List singlePackage = new List();
                try
                {
                    var displyname = (from pm in contextsdce.package_master where pm.package_id == PackageId select new { displayPackName = pm.package_display_name, displayUniv = pm.univ_id, displyDepart = pm.department_id }).FirstOrDefault();

                    var singlePackages = (from pckge in contextsdce.package_master
                                          join dm in contextsdce.department_master on pckge.department_id equals dm.department_id
                                          join rm in contextsdce.regulation_master on pckge.rule_id equals rm.rule_id
                                          join univ in contextsdce.university_master on pckge.univ_id equals univ.univ_id
                                          join ucd in contextsdce.user_cart_details on UserId equals ucd.user_id into lftucd
                                          from ucd in lftucd.DefaultIfEmpty()
                                              //where ucd.user_id==UserId
                                          where pckge.package_display_name.Equals(displyname.displayPackName.ToString())
                                          && pckge.department_id.Equals(displyname.displyDepart) && pckge.univ_id.Equals(displyname.displayUniv)
                                          && pckge.activestatus == 1 && pckge.univ_id == rm.university_id
                                          orderby pckge.package_name
                                          group new { pckge, ucd, dm, univ, rm } by pckge.package_display_name into g
                                          select new { packagename = g.Key, packageDetail = g }
                                        );

                    //  Log.WriteLogMessage(PageName, "Product", "GetSinglePackageDetailswithLoginPackCount", singlePackages.Count().ToString(), "error");

                    foreach (var package in singlePackages)
                    {

                        pd.packageName = package.packagename;
                        List<string> Content_packs = new List<string>();
                        List<string> QA_packs = new List<string>();
                        List<string> Bundle_packs = new List<string>();

                        pd.packageId = package.packageDetail.FirstOrDefault().pckge.package_id;
                        pd.departmentName = package.packageDetail.FirstOrDefault().dm.department_name;
                        pd.universityName = package.packageDetail.FirstOrDefault().univ.university_name;
                        pd.universityId = package.packageDetail.FirstOrDefault().univ.univ_id;
                        pd.packageQuickDesc = package.packageDetail.FirstOrDefault().pckge.short_desc;
                        pd.packageDesc = package.packageDetail.FirstOrDefault().pckge.long_desc;
                        pd.packageKeyword = package.packageDetail.FirstOrDefault().pckge.keywords;
                        pd.packageViedeo = package.packageDetail.FirstOrDefault().pckge.package_video_url == null ? "NoVideo" : ConfigurationManager.AppSettings["VideoUrl"] + package.packageDetail.FirstOrDefault().pckge.univ_id + "/" + package.packageDetail.FirstOrDefault().rm.rule_name + "/" + package.packageDetail.FirstOrDefault().pckge.package_video_url;
                        if (package.packageDetail.FirstOrDefault().pckge.is_bundle == 0 && package.packageDetail.FirstOrDefault().pckge.is_offer_package == 1)
                        {
                            pd.trialpackage = ConfigurationManager.AppSettings["trialdownload"] + package.packageDetail.FirstOrDefault().pckge.univ_id + "/" + package.packageDetail.FirstOrDefault().rm.rule_name + "/" + package.packageDetail.FirstOrDefault().pckge.package_display_name.Replace(" ", "_") + "_Trial.exe";
                            pd.packageDescfull = ConfigurationManager.AppSettings["LongDesc"] + package.packageDetail.FirstOrDefault().pckge.univ_id + "/" + package.packageDetail.FirstOrDefault().rm.rule_name + "/" + package.packageDetail.FirstOrDefault().pckge.package_display_name.Replace(' ', '_') + ".pdf";
                        }
                        else if (package.packageDetail.FirstOrDefault().pckge.is_bundle == 1)
                        {
                            pd.trialpackage = "NoBundleFile";
                            pd.packageDescfull = "NoBundleFile";
                        }
                        else
                        {
                            pd.trialpackage = "No file";
                            pd.packageDescfull = "No file";
                        }
                        foreach (var pack in package.packageDetail)
                        {


                            switch (pack.pckge.subject_unit_type)
                            {


                                case 1:
                                    if (Content_packs.Count == 0)
                                    {
                                        Content_packs.Add(pack.pckge.package_id.ToString());
                                        Content_packs.Add(pack.pckge.selling_price.ToString());
                                        Content_packs.Add(pack.pckge.actual_price.ToString());
                                        Content_packs.Add(pack.pckge.current_status == 0 ? "0" : "1");
                                        if (pack.ucd == null)
                                        {
                                            Content_packs.Add("no");
                                        }
                                        else if (pack.ucd != null && pack.ucd.package_id.ToString() == pack.pckge.package_id.ToString())
                                        {
                                            Content_packs.Add(pack.ucd == null ? "no" : pack.ucd.package_id.ToString() == pack.pckge.package_id.ToString() ? "yes" : "no");
                                        }
                                    }

                                    else
                                    {
                                        if (pack.ucd != null && pack.ucd.package_id.ToString() == pack.pckge.package_id.ToString())
                                        {
                                            Content_packs.Add(pack.ucd == null ? "no" : pack.ucd.package_id.ToString() == pack.pckge.package_id.ToString() ? "yes" : "no");
                                        }
                                    }
                                    break;

                                case 2:
                                    if (QA_packs.Count == 0)
                                    {
                                        QA_packs.Add(pack.pckge.package_id.ToString());
                                        QA_packs.Add(pack.pckge.selling_price.ToString());
                                        QA_packs.Add(pack.pckge.actual_price.ToString());
                                        QA_packs.Add(pack.pckge.current_status == 0 ? "0" : "1");
                                        if (pack.ucd == null)
                                        {
                                            QA_packs.Add("no");
                                        }
                                        else if (pack.ucd != null && pack.ucd.package_id.ToString() == pack.pckge.package_id.ToString())
                                        {
                                            QA_packs.Add(pack.ucd == null ? "no" : pack.ucd.package_id.ToString() == pack.pckge.package_id.ToString() ? "yes" : "no");
                                        }
                                    }
                                    else
                                    {
                                        if (pack.ucd != null && pack.ucd.package_id.ToString() == pack.pckge.package_id.ToString())
                                        {
                                            QA_packs.Add(pack.ucd == null ? "no" : pack.ucd.package_id.ToString() == pack.pckge.package_id.ToString() ? "yes" : "no");
                                        }

                                    }
                                    break;

                                case 3:
                                    if (Bundle_packs.Count == 0)
                                    {
                                        Bundle_packs.Add(pack.pckge.package_id.ToString());
                                        Bundle_packs.Add(pack.pckge.selling_price.ToString());
                                        Bundle_packs.Add(pack.pckge.actual_price.ToString());
                                        Bundle_packs.Add(pack.pckge.current_status == 0 ? "0" : "1");
                                        if (pack.ucd == null)
                                        {
                                            Bundle_packs.Add("no");
                                        }
                                        else if (pack.ucd != null && pack.ucd.package_id.ToString() == pack.pckge.package_id.ToString())
                                        {
                                            Bundle_packs.Add(pack.ucd == null ? "no" : pack.ucd.package_id.ToString() == pack.pckge.package_id.ToString() ? "yes" : "no");
                                        }
                                    }
                                    else
                                    {

                                        if (pack.ucd != null && pack.ucd.package_id.ToString() == pack.pckge.package_id.ToString())
                                        {
                                            Bundle_packs.Add(pack.ucd == null ? "no" : pack.ucd.package_id.ToString() == pack.pckge.package_id.ToString() ? "yes" : "no");
                                        }

                                    }
                                    break;

                                default:
                                    break;
                            }

                        }
                        if (Content_packs.Count == 4)
                        {
                            Content_packs.Add("no");
                        }
                        if (QA_packs.Count == 4)
                        {
                            QA_packs.Add("no");
                        }
                        if (Bundle_packs.Count == 4)
                        {
                            Bundle_packs.Add("no");
                        }
                        pd.Bundlepacks = Bundle_packs;
                        pd.Contentpacks = Content_packs;
                        pd.QApacks = QA_packs;

                    }

                    return pd;
                }
                catch (Exception ex)
                {
                    contextsdce.Dispose();
                    Log.WriteLogMessage(PageName, "Product", "GetSinglePackageDetailswithLogin", ex.Message, "error");
                    throw;
                }
                finally
                {
                    contextsdce.Dispose();
                }
            }

        }
        /// <summary>
        /// To Get Department Related Packages for single Department
        /// </summary>
        /// <param name="DepartmentId"></param>
        /// <returns></returns>
        public List<Packagedetails> GetDepartmentRelatedPackagesDetails(int DepartmentId)
        {
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {


                List<Packagedetails> relatedPackage = new List<Packagedetails>();
                try
                {
                    relatedPackage = (from pckg in contextsdce.package_master
                                      join dpm in contextsdce.department_master on pckg.department_id equals dpm.department_id
                                      where dpm.department_id == DepartmentId && pckg.activestatus == 1

                                      select new Packagedetails
                                      {
                                          packageId = pckg.package_id,
                                          packageCode = pckg.package_code,
                                          pckgeCoverpath = pkgCoverpath,
                                          packageName = pckg.package_name,
                                          packSellingprice = pckg.selling_price,
                                          packActprice = pckg.actual_price,
                                          packageDuration = pckg.package_duration_days

                                      }).ToList();
                    return relatedPackage;
                }
                catch (Exception ex)
                {
                    contextsdce.Dispose();
                    Log.WriteLogMessage(PageName, "Product", "GetDepartmentRelatedPackagesDetails", ex.Message, "error");
                    throw;
                }
                finally
                {
                    contextsdce.Dispose();
                }

            }
        }
        /// <summary>
        /// To Get Avilable Discount Coupens for Cart Items
        /// </summary>
        /// <returns></returns>
        public List<CoupenAvailability> GetAvailableDiscountCoupens()
        {
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {


                List<CoupenAvailability> coupens = new List<CoupenAvailability>();
                try
                {
                    coupens = (from pdm in contextsdce.promo_discount_master
                               where pdm.discount_expiryon >= DateTime.Today && pdm.active_status == 1
                               select new CoupenAvailability
                               {
                                   DiscountCode = pdm.discount_code,
                                   DiscountName = pdm.discount_name,
                                   DiscountPrice = pdm.discount_price,
                                   ExtendedDays = pdm.discount_extend_days
                               }).ToList();
                    return coupens;
                }
                catch (Exception ex)
                {
                    contextsdce.Dispose();
                    Log.WriteLogMessage(PageName, "Product", "GetAvailableDiscountCoupens", ex.Message, "error");
                    throw;
                }
                finally
                {
                    contextsdce.Dispose();
                }
            }

        }
        /// <summary>
        /// To Applying Discount Coupent for cart using Discount Code
        /// </summary>
        /// <param name="discountCode"></param>
        /// <returns></returns>
        public string ApplyDiscountCoupenForUser(string discountCode)
        {
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {

                JavaScriptSerializer jsSerializer = new JavaScriptSerializer();

                List<CoupenAvailability> checkCoupens = new List<CoupenAvailability>();
                try
                {
                    checkCoupens = (from pdm in contextsdce.promo_discount_master
                                    where pdm.discount_code == discountCode && pdm.discount_expiryon >= DateTime.Today
                                    && pdm.active_status == 1
                                    select new CoupenAvailability
                                    {
                                        DiscountPrice = pdm.discount_price,
                                        ExtendedDays = pdm.discount_extend_days
                                    }).ToList();
                    if (checkCoupens.Any())
                    {
                        return jsSerializer.Serialize(checkCoupens);
                    }
                    else
                    {
                        return "Discount Coupen Not Avaliable";
                    }

                }
                catch (Exception ex)
                {
                    contextsdce.Dispose();
                    Log.WriteLogMessage(PageName, "Product", "ApplyDiscountCoupenForUser", ex.Message, "error");
                    throw;
                }
                finally
                {
                    contextsdce.Dispose();
                }
            }

        }
        /// <summary>
        /// To Check Available pacakges details for single package
        /// </summary>
        /// <param name="packageid"></param>
        /// <returns></returns>
        public string CheckAvailablePackageDetails(int packageid)
        {
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                List<Packagedetails> checkPackages = new List<Packagedetails>();
                try
                {
                    checkPackages = (from pm in contextsdce.package_master
                                     join ppm in contextsdce.promo_package_mapping on pm.package_id equals ppm.package_id
                                     where pm.package_id == packageid && pm.activestatus == 1
                                     select new Packagedetails
                                     {
                                         packageId = pm.package_id,
                                         packageCode = pm.package_code,
                                         pckgeCoverpath = pkgCoverpath,
                                         packageName = pm.package_name,
                                         packSellingprice = pm.selling_price,
                                         packActprice = pm.actual_price,
                                         packageDuration = pm.package_duration_days

                                     }).ToList();

                    if (checkPackages.Any())
                    {
                        return jsSerializer.Serialize(checkPackages);
                    }
                    else
                    {
                        return "Package Not Available";
                    }
                }
                catch (Exception ex)
                {
                    contextsdce.Dispose();
                    Log.WriteLogMessage(PageName, "Product", "ApplyDiscountCoupenForUser", ex.Message, "error");
                    throw;
                }
                finally
                {
                    contextsdce.Dispose();
                }
            }
        }
        /// <summary>
        /// To Get University Details
        /// </summary>
        /// <returns></returns>
        public List<Universitydetails> GetUniversityDetails()
        {
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                List<Universitydetails> UniversityDetails = new List<Universitydetails>();
                try
                {
                    UniversityDetails = (from um in contextsdce.university_master
                                         select new Universitydetails
                                         {
                                             Universityid = um.univ_id,
                                             UniversityName = um.university_name,
                                             Univcode = um.university_code,

                                         }).Distinct().ToList();

                    return UniversityDetails;
                }
                catch (Exception ex)
                {
                    contextsdce.Dispose();
                    Log.WriteLogMessage(PageName, "Product", "GetUniversityDetails", ex.Message, "error");
                    throw;
                }
                finally
                {
                    contextsdce.Dispose();
                }
            }

        }
        /// <summary>
        /// To Get University details for Logged in User based on Type
        /// </summary>
        /// <param name="univtype"></param>
        /// <param name="loginUserid"></param>
        /// <returns></returns>
        public List<Universitydetails> GetUniversityDetails(int univtype, int loginUserid)
        {
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                if (loginUserid > 0)
                {
                    var univdetails = (from um in contextsdce.university_master
                                       join ums in contextsdce.user_master on um.univ_id equals ums.univ_id
                                       where ums.user_id == loginUserid
                                       select um).FirstOrDefault();
                    univtype = Convert.ToInt32(univdetails.university_type);
                }
                if (univtype == 0)
                {
                    var univdetails = (from um in contextsdce.university_master select um).FirstOrDefault();
                    univtype = univdetails.univ_id;
                }
                List<Universitydetails> UniversityDetails = new List<Universitydetails>();
                try
                {
                    UniversityDetails = (from um in contextsdce.university_master
                                         where um.university_type == univtype
                                         select new Universitydetails
                                         {
                                             Universityid = um.univ_id,
                                             UniversityName = um.university_name,
                                             Univcode = um.university_code,

                                         }).Distinct().ToList();

                    return UniversityDetails;
                }
                catch (Exception ex)
                {
                    contextsdce.Dispose();
                    Log.WriteLogMessage(PageName, "Product", "GetUniversityDetails", ex.Message, "error");
                    throw;
                }
                finally
                {
                    contextsdce.Dispose();
                }
            }

        }
        /// <summary>
        ///  To Get Department Details Based on University and University Type
        /// </summary>
        /// <param name="univId"></param>
        /// <param name="univtype"></param>
        /// <returns></returns>
        public List<Departmentdetails> GetDepartmentList(int univId, int univtype)
        {
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {

                if (univId == 0 && univtype == 1)
                {
                    var univMaster = (from um in contextsdce.university_master select um).FirstOrDefault();
                    univId = univMaster.univ_id;
                }
                if (univId == 0 && univtype == 2)
                {
                    var univMaster = (from um in contextsdce.university_master where um.university_type == univtype select um).FirstOrDefault();
                    univId = univMaster.univ_id;
                }
                if (univId == 0)
                {
                    var univMaster = (from um in contextsdce.university_master select um).FirstOrDefault();
                    univId = univMaster.univ_id;
                }
                List<Departmentdetails> department = new List<Departmentdetails>();
                try
                {
                    department = (from dept in contextsdce.department_master
                                  where dept.UniversityID == univId && (dept.department_id < 15 || dept.department_id > 18)
                                  && dept.active_status == 1
                                  select new Departmentdetails
                                  {
                                      DepartmentId = dept.department_id,
                                      UniversityId = dept.UniversityID,
                                      DepartmentName = dept.department_name.TrimEnd()
                                  }).Distinct().OrderBy(x => x.DepartmentName).ToList();

                    return department;

                }
                catch (Exception ex)
                {
                    contextsdce.Dispose();
                    Log.WriteLogMessage(PageName, "Product", "GetDepartmentList", ex.Message, "error");
                    throw ex;
                }
                finally
                {
                    contextsdce.Dispose();
                }
            }
        }
        /// <summary>
        /// To Get Packages Deatils for University Based Department pacakges for single user and University Type
        /// </summary>
        /// <param name="univId"></param>
        /// <param name="departmentId"></param>
        /// <param name="userId"></param>
        /// <param name="univtype"></param>
        /// <returns></returns>
        public List<Packagedetails> GetPackageDetails(int univId, int departmentId, int userId, int univtype)
        {
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                if (univId > 0 && univtype == 0)
                {
                    var univMaster = (from um in contextsdce.university_master where um.univ_id == univId select um).FirstOrDefault();
                    univtype = univMaster.university_type ?? 0;
                }
                if (univId == 0 && univtype == 1)
                {
                    var univMaster = (from um in contextsdce.university_master where um.university_type == univtype select um).FirstOrDefault();
                    univId = univMaster.univ_id;
                }
                if (univId == 0 && univtype == 2)
                {
                    var univMaster = (from um in contextsdce.university_master where um.university_type == univtype select um).FirstOrDefault();
                    univId = univMaster.univ_id;
                }
                if (departmentId == 0 && univId > 0 && univtype == 1)
                {
                    var deptMaster = (from dm in contextsdce.department_master
                                      where dm.UniversityID == univId && (dm.department_id < 15 || dm.department_id > 18) && dm.active_status == 1
                                      select dm).OrderBy(x => x.department_name.TrimEnd()).FirstOrDefault();
                    departmentId = deptMaster.department_id;
                }
                if (departmentId == 0 && univId > 0 && univtype == 2)
                {
                    var deptMaster = (from dm in contextsdce.department_master
                                      where dm.UniversityID == univId && (dm.department_id < 15 || dm.department_id > 18) && dm.active_status == 1
                                      select dm).OrderBy(x => x.department_name.TrimEnd()).FirstOrDefault();
                    departmentId = deptMaster.department_id;
                }
                if (univId == 0 && departmentId == 0)
                {
                    var univMaster = (from um in contextsdce.university_master select um).FirstOrDefault();
                    univId = univMaster.univ_id;

                    var deptMaster = (from dm in contextsdce.department_master
                                      where dm.UniversityID == univId && (dm.department_id < 15 || dm.department_id > 18) && dm.active_status == 1
                                      select dm).OrderBy(x => x.department_name.TrimEnd()).FirstOrDefault();
                    departmentId = deptMaster.department_id;
                }


                List<Packagedetails> packages = new List<Packagedetails>();

                try
                {
                    if (userId == 0)
                    {

                        var packagedetails = (from pckg in contextsdce.package_master
                                              join dm in contextsdce.department_master on pckg.department_id equals dm.department_id
                                              join rm in contextsdce.regulation_master on pckg.rule_id equals rm.rule_id
                                              where dm.department_id == departmentId && pckg.activestatus == 1 && pckg.univ_id == univId
                                               && dm.active_status == 1 && rm.active_status == 1
                                              && pckg.univ_id == rm.university_id
                                              orderby pckg.package_name
                                              group new { pckg, rm } by new { pckg.package_display_name } into g
                                              select new { packagename = g.Key.package_display_name, packageDetail = g }
                                              );

                        foreach (var package in packagedetails)
                        {
                            Packagedetails pd = new Packagedetails();
                            pd.packageCode = package.packagename;
                            List<string> Contentpacks = new List<string>();
                            List<string> QApacks = new List<string>();
                            List<string> Bundlepacks = new List<string>();

                            pd.packageName = package.packageDetail.FirstOrDefault().pckg.package_name;
                            pd.departID = package.packageDetail.FirstOrDefault().pckg.department_id;
                            pd.IsBundle = package.packageDetail.FirstOrDefault().pckg.is_bundle;
                            pd.UniversityId = package.packageDetail.FirstOrDefault().pckg.univ_id;
                            pd.semester = package.packageDetail.FirstOrDefault().pckg.semester;
                            pd.IsOfferpakage = package.packageDetail.FirstOrDefault().pckg.is_offer_package;
                            pd.Regulation = package.packageDetail.FirstOrDefault().rm.rule_name;


                            if (pd.IsOfferpakage == 1)
                            {
                                pd.trialpackage = ConfigurationManager.AppSettings["trialdownload"] + package.packageDetail.FirstOrDefault().pckg.univ_id + "/" + package.packageDetail.FirstOrDefault().rm.rule_name + "/" + package.packageDetail.FirstOrDefault().pckg.package_display_name.Replace(" ", "_") + "_Trial.exe";
                            }
                            else
                            {
                                pd.trialpackage = "No file";
                            }



                            foreach (var pack in package.packageDetail)
                            {
                                switch (pack.pckg.subject_unit_type)
                                {
                                    case 1:
                                        Contentpacks.Add(pack.pckg.package_id.ToString());
                                        Contentpacks.Add(pack.pckg.selling_price.ToString());
                                        Contentpacks.Add(pack.pckg.actual_price.ToString());
                                        Contentpacks.Add(pack.pckg.current_status == 0 ? "0" : "1");
                                        break;

                                    case 2:
                                        QApacks.Add(pack.pckg.package_id.ToString());
                                        QApacks.Add(pack.pckg.selling_price.ToString());
                                        QApacks.Add(pack.pckg.actual_price.ToString());
                                        QApacks.Add(pack.pckg.current_status == 0 ? "0" : "1");
                                        break;

                                    case 3:
                                        Bundlepacks.Add(pack.pckg.package_id.ToString());
                                        Bundlepacks.Add(pack.pckg.selling_price.ToString());
                                        Bundlepacks.Add(pack.pckg.actual_price.ToString());
                                        Bundlepacks.Add(pack.pckg.current_status == 0 ? "0" : "1");
                                        break;

                                    default:
                                        break;
                                }

                            }
                            pd.Bundle_packages = Bundlepacks;
                            pd.Content_packages = Contentpacks;
                            pd.QA_packages = QApacks;
                            packages.Add(pd);
                        }
                    }
                    else
                    {
                        var packagedetails = (from pckg in contextsdce.package_master
                                              join rm in contextsdce.regulation_master on pckg.rule_id equals rm.rule_id
                                              join ucd in contextsdce.user_cart_details on pckg.package_id equals ucd.package_id into ucad
                                              from ucadlist in ucad.Where(ucad => ucad.user_id == userId).DefaultIfEmpty()
                                              join dm in contextsdce.department_master on pckg.department_id equals dm.department_id
                                              where dm.department_id == departmentId && pckg.activestatus == 1 && pckg.univ_id == univId
                                              && dm.active_status == 1 && rm.active_status == 1
                                              && pckg.univ_id == rm.university_id
                                              orderby pckg.package_name
                                              group new { pckg, ucadlist, rm } by new { pckg.package_display_name } into g
                                              select new { packagename = g.Key.package_display_name, packageDetail = g }
                                             );

                        foreach (var package in packagedetails)
                        {
                            Packagedetails pd = new Packagedetails();
                            pd.packageCode = package.packagename;
                            List<string> Contentpacks = new List<string>();
                            List<string> QApacks = new List<string>();
                            List<string> Bundlepacks = new List<string>();

                            pd.packageName = package.packageDetail.FirstOrDefault().pckg.package_name;
                            pd.departID = package.packageDetail.FirstOrDefault().pckg.department_id;
                            pd.IsBundle = package.packageDetail.FirstOrDefault().pckg.is_bundle;
                            pd.UniversityId = package.packageDetail.FirstOrDefault().pckg.univ_id;
                            pd.semester = package.packageDetail.FirstOrDefault().pckg.semester;
                            pd.IsOfferpakage = package.packageDetail.FirstOrDefault().pckg.is_offer_package;
                            pd.Regulation = package.packageDetail.FirstOrDefault().rm.rule_name;

                            if (pd.IsOfferpakage == 1)
                            {
                                pd.trialpackage = ConfigurationManager.AppSettings["trialdownload"] + package.packageDetail.FirstOrDefault().pckg.univ_id + "/" + package.packageDetail.FirstOrDefault().rm.rule_name + "/" + package.packageDetail.FirstOrDefault().pckg.package_display_name.Replace(" ", "_") + "_Trial.exe";
                            }
                            else
                            {
                                pd.trialpackage = "No file";
                            }

                            foreach (var pack in package.packageDetail)
                            {

                                switch (pack.pckg.subject_unit_type)
                                {
                                    case 1:
                                        Contentpacks.Add(pack.pckg.package_id.ToString());
                                        Contentpacks.Add(pack.pckg.selling_price.ToString());
                                        Contentpacks.Add(pack.pckg.actual_price.ToString());
                                        Contentpacks.Add(pack.pckg.current_status == 0 ? "0" : "1");
                                        Contentpacks.Add(pack.ucadlist == null ? "no" : pack.ucadlist.package_id.ToString() == pack.pckg.package_id.ToString() ? "yes" : "no");

                                        break;

                                    case 2:
                                        QApacks.Add(pack.pckg.package_id.ToString());
                                        QApacks.Add(pack.pckg.selling_price.ToString());
                                        QApacks.Add(pack.pckg.actual_price.ToString());
                                        QApacks.Add(pack.pckg.current_status == 0 ? "0" : "1");
                                        QApacks.Add(pack.ucadlist == null ? "no" : pack.ucadlist.package_id.ToString() == pack.pckg.package_id.ToString() ? "yes" : "no");

                                        break;

                                    case 3:
                                        Bundlepacks.Add(pack.pckg.package_id.ToString());
                                        Bundlepacks.Add(pack.pckg.selling_price.ToString());
                                        Bundlepacks.Add(pack.pckg.actual_price.ToString());
                                        Bundlepacks.Add(pack.pckg.current_status == 0 ? "0" : "1");
                                        Bundlepacks.Add(pack.ucadlist == null ? "no" : pack.ucadlist.package_id.ToString() == pack.pckg.package_id.ToString() ? "yes" : "no");

                                        break;

                                    default:
                                        break;
                                }

                            }
                            pd.Bundle_packages = Bundlepacks;
                            pd.Content_packages = Contentpacks;
                            pd.QA_packages = QApacks;
                            packages.Add(pd);
                        }

                    }



                    return packages;

                }
                catch (Exception ex)
                {
                    contextsdce.Dispose();
                    Log.WriteLogMessage(PageName, "Product", "GetPackageDetails", ex.Message, "error");
                    throw ex;
                }
                finally
                {
                    contextsdce.Dispose();
                }
            }

        }
        /// <summary>
        /// To get Semester based on University and University type
        /// </summary>
        /// <param name="univId"></param>
        /// <param name="univType"></param>
        /// <returns></returns>
        public List<Semester_Regulation> GetSemester(int univId, int univType)
        {
            List<Semester_Regulation> semeter = new List<Semester_Regulation>();


            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {

                if (univId == 0 && univType == 0)
                {
                    var univMaster = (from um in contextsdce.university_master select um).FirstOrDefault();
                    univId = univMaster.univ_id;
                }
                if (univId == 0 && univType > 0)
                {
                    var univMaster = (from um in contextsdce.university_master where um.university_type == univType select um).FirstOrDefault();
                    univId = univMaster.univ_id;
                }

                JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                try
                {
                    semeter = (from usm in contextsdce.univ_semester_master
                               where usm.univ_id == univId
                               select new Semester_Regulation
                               {
                                   Universityid = usm.univ_id,
                                   Semester = usm.semester_name,
                                   Year = usm.sem_year,
                                   SemDisplay = usm.sem_display


                               }).ToList();

                    return semeter;
                }
                catch (Exception ex)
                {
                    contextsdce.Dispose();
                    Log.WriteLogMessage(PageName, "Product", "GetSemester", ex.Message, "error");
                    throw ex;
                }
                finally
                {
                    contextsdce.Dispose();
                }
            }

        }
        /// <summary>
        ///  To Get Regulation for user based on University
        /// </summary>
        /// <param name="univ_id"></param>
        /// <returns></returns>
        public List<Semester_Regulation> GetRegulation(int univ_id)
        {
            List<Semester_Regulation> regulation = new List<Semester_Regulation>();
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                if (univ_id == 0)
                {
                    var univMaster = (from um in contextsdce.university_master select um).FirstOrDefault();
                    univ_id = univMaster.univ_id;
                }
                try
                {
                    regulation = (from rm in contextsdce.regulation_master
                                  where rm.university_id == univ_id
                                  select new Semester_Regulation
                                  {
                                      Universityid = rm.university_id,
                                      Regulation = rm.rule_name

                                  }).ToList();

                    return regulation;
                }
                catch (Exception ex)
                {
                    contextsdce.Dispose();
                    Log.WriteLogMessage(PageName, "Product", "GetSemester", ex.Message, "error");
                    throw ex;
                }
                finally
                {
                    contextsdce.Dispose();
                }
            }

        }
        /// <summary>
        /// To Get univeristy Details single user to see the packages from another university
        /// </summary>
        /// <param name="univ_Type"></param>
        /// <returns></returns>
        public List<Universitydetails> GetUniversityId_UnivType(int univ_Type)
        {
            List<Universitydetails> UniversityDetails = new List<Universitydetails>();

            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                try
                {
                    UniversityDetails = (from um in contextsdce.university_master
                                         where um.university_type == univ_Type
                                         select new Universitydetails
                                         {
                                             Universityid = um.univ_id,
                                             UniversityName = um.university_name,

                                         }).ToList();

                    return UniversityDetails;
                }
                catch (Exception ex)
                {
                    contextsdce.Dispose();
                    Log.WriteLogMessage(PageName, "Product", "GetUniversityId_UnivType", ex.Message, "error");
                    throw ex;
                }
                finally
                {
                    contextsdce.Dispose();
                }
            }

        }
        /// <summary>
        /// To get packages details based on department and subject
        /// </summary>
        /// <param name="departId"></param>
        /// <param name="subjectid"></param>
        /// <returns></returns>

        public List<Packagedetails> GetPackages(int departId, long subjectid)
        {
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {


                List<Packagedetails> package_details = new List<Packagedetails>();

                try
                {


                    var packagedetails = (from pckg in contextsdce.package_master
                                          join dm in contextsdce.department_master on pckg.department_id equals dm.department_id
                                          where dm.department_id == departId && pckg.activestatus == 1
                                          orderby pckg.package_name
                                          group pckg by new { pckg.package_display_name } into g
                                          select new { packagename = g.Key.package_display_name, packageDetail = g }
                                          );

                    foreach (var packages in packagedetails)
                    {
                        Packagedetails pd = new Packagedetails();
                        pd.packageName = packages.packagename;
                        List<string> Contentpacks = new List<string>();
                        List<string> QApacks = new List<string>();
                        List<string> Bundlepacks = new List<string>();
                        foreach (var pack in packages.packageDetail)
                        {
                            pd.departID = pack.department_id;
                            pd.IsBundle = pack.is_bundle;
                            pd.CurrentStatus = (int)pack.current_status;
                            pd.UniversityId = pack.univ_id;
                            switch (pack.subject_unit_type)
                            {
                                case 1:
                                    Contentpacks.Add(pack.package_id.ToString());
                                    Contentpacks.Add(pack.selling_price.ToString());
                                    Contentpacks.Add(pack.actual_price.ToString());
                                    break;

                                case 2:
                                    QApacks.Add(pack.package_id.ToString());
                                    QApacks.Add(pack.selling_price.ToString());
                                    QApacks.Add(pack.actual_price.ToString());
                                    break;

                                case 3:
                                    Bundlepacks.Add(pack.package_id.ToString());
                                    Bundlepacks.Add(pack.selling_price.ToString());
                                    Bundlepacks.Add(pack.actual_price.ToString());
                                    break;

                                default:
                                    break;
                            }

                        }
                        pd.Bundle_packages = Bundlepacks;
                        pd.Content_packages = Contentpacks;
                        pd.QA_packages = QApacks;
                        package_details.Add(pd);
                    }
                    //  package_details.Distinct();

                    if (departId > 0 && subjectid > 0)
                    {
                        var datanew = package_details.ToList();
                        package_details.Clear();
                        package_details.AddRange(datanew.Where(x => x.departID == departId && x.subjectID == subjectid));
                    }

                    return package_details;
                }
                catch (Exception ex)
                {
                    contextsdce.Dispose();
                    Log.WriteLogMessage(PageName, "Product", "GetPackageDetails", ex.Message, "error");
                    throw;
                }
                finally
                {
                    contextsdce.Dispose();
                }

            }
        }

        public string FeedbackMail(string collegeName, string subjectName, string userName, long mobileNumber, string emailId, string message)
        {
            using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
            {
                try
                {

                    //string suptMailId = "support@learnengg.com";

                    string msgBody = "<div style='margin-left:20px;width:550px;border:1px dashed gray;font-family:verdana,tahoma,sans-serif;font-size:12px'>" +
                        "<p style='color:#61778d;margin-left:14px;margin-right:14px'>" +
                " Name: " + "<b>" + userName + "</b>" + "</p>" +
            "<br>" +
             "<p style='color:#61778d;margin-left:14px;margin-right:14px'>" +
                " College Name: " + "<b>" + collegeName + "</b>" + "</p>" +
            "<br>" +
             "<p style='color:#61778d;margin-left:14px;margin-right:14px'>" +
                " Subject Name: " + "<b>" + subjectName + "</b>" + "</p>" +
            "<br>" +
             "<p style='color:#61778d;margin-left:14px;margin-right:14px'>" +
                " Mobile Number: " + "<b>" + mobileNumber + "</b>" + "</p>" +
            "<br>" +
             "<p style='color:#61778d;margin-left:14px;margin-right:14px'>" +
                " Email Id: " + "<b>" + emailId + "</b>" + "</p>" +
            "<br>" +
             "<p style='color:#61778d;margin-left:14px;margin-right:14px'>" +
                "FeedBack Message: " + "<b>" + message + "</b>" + "</p>" +
            "<br>" +

             "</div>";

                    FeedbackViewModel fvm = new FeedbackViewModel();
                    fvm.collegeName = collegeName;
                    fvm.name = userName;
                    fvm.subjectName = subjectName;
                    fvm.mobileNumber = Convert.ToString(mobileNumber);
                    fvm.email = emailId;
                    fvm.message = message;
                    int result = new FeedbackAccess().SaveFeedback(fvm);
                    string fromMail = ConfigurationManager.AppSettings["FeedBackFromMail"];
                    string toMail = ConfigurationManager.AppSettings["FeedBackToMail"];
                    // MailHelper mail = new MailHelper();
                    MailHelper.SendMail(toMail, "User Feedback", msgBody, fromMail);

                    if (msgBody != null)
                    {
                        return "1";
                    }
                    else
                    {
                        return "2";
                    }
                }
                catch
                {
                    throw;
                }
            }
        }


        /// <summary>
        /// Saves the user details for master copy usage.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="emailId">The email identifier.</param>
        /// <param name="departmentId">The department identifier.</param>
        /// <param name="semester">The semester.</param>
        /// <returns></returns>
        public string SaveUserDetailsForMasterCopyUsage(string userName, string emailId, long mobile, string departmentName, int semester)
        {
            int result = 0;
            try
            {
                string Randomcode = Registration_Conformation(mobile, emailId);
                var Ud = new mastercopy_usage_details
                {
                    user_name = userName,
                    email_id = emailId,
                    mobile = mobile,
                    department_name = departmentName,
                    semester = semester,
                    is_otp_verified = 0,
                    requested_on = DateTime.Now,
                    otp_code = Randomcode
                };

                using (learnengg_payment_portal_entities contextsdce = new learnengg_payment_portal_entities())
                {
                    contextsdce.mastercopy_usage_details.Add(Ud);
                    contextsdce.SaveChanges();
                    result = Ud.mastercopy_usage_id;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            XDocument xdoc = new XDocument(new XElement("LastId", new XAttribute("LastInsertId", result)));
            return xdoc.ToString();
        }

        /// <summary>
        /// Registrations the conformation.
        /// </summary>
        /// <param name="mobileNo">The mobile no.</param>
        /// <param name="ToEmailID">To email identifier.</param>
        /// <returns></returns>
        public string Registration_Conformation(long mobileNo, string ToEmailID)
        {
            string message = "";
            try
            {
                CallSendSMS ob = new CallSendSMS();

                string sOTP = ob.CreateRandomPassword(6);

                //Send Mail to User About his Activaiton Code
                string mailcontent = MailHelper.EmailBody_OTP("User Account Detailes", mobileNo + "", sOTP, "");
                MailHelper.SendMail(ToEmailID, "Learnengg - Activation Code (OTP)", mailcontent);
                message = sOTP;
            }
            catch (Exception)
            {
                throw;
            }
            return message;
        }

        /// <summary>
        /// Registrations the otp conformation.
        /// </summary>
        /// <param name="mastercopy_usage_id">The mastercopy usage identifier.</param>
        /// <param name="OTPCode">The otp code.</param>
        /// <returns></returns>
        public string Registration_OTPConformation(long mastercopy_usage_id, string OTPCode)
        {
            string message = "0";

            try
            {
                using (learnengg_payment_portal_entities context = new learnengg_payment_portal_entities())
                {
                    var OTPcheck = (from uud in context.mastercopy_usage_details where uud.otp_code == OTPCode && uud.mastercopy_usage_id == mastercopy_usage_id select uud);
                    if (OTPcheck.Count() > 0)
                    {
                        OTPcheck.FirstOrDefault().is_otp_verified = 1;
                        context.SaveChanges();
                        message = ConfigurationManager.AppSettings["LicenseDate"].ToString() + ":" + DateTime.Now.ToString("yyyy/MM/dd");

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            XDocument xdoc = new XDocument(new XElement("LicenseDate", new XAttribute("LicenseExtDate", message)));
            message = xdoc.ToString();
            return message;
        }

        /// <summary>
        /// Registrations the re send otp.
        /// </summary>
        /// <param name="mastercopy_usage_id">The mastercopy usage identifier.</param>
        /// <returns></returns>
        public string Registration_ReSendOTP(long mastercopy_usage_id)
        {
            string message = "0";
            try
            {
                CallSendSMS ob = new CallSendSMS();
                using (learnengg_payment_portal_entities context = new learnengg_payment_portal_entities())
                {
                    var OTPcheck = (from uud in context.mastercopy_usage_details where uud.mastercopy_usage_id == mastercopy_usage_id select uud);
                    if (OTPcheck.Count() > 0)
                    {
                        string sOTP = OTPcheck.FirstOrDefault().otp_code;
                        long mobileNo = (long)OTPcheck.FirstOrDefault().mobile;
                        string ToEmailID = OTPcheck.FirstOrDefault().email_id;

                        //Send Mail to User About his Activaiton Code
                        string mailcontent = MailHelper.EmailBody_OTP("User Account Detailes", mobileNo + "", sOTP, "");
                        MailHelper.SendMail(ToEmailID, "Learnengg - Activation Code (OTP)", mailcontent);
                        message = sOTP;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            XDocument xdoc = new XDocument(new XElement("OTP", new XAttribute("OTPCode", message)));
            message = xdoc.ToString();
            return message;
        }

    }
}