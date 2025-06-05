using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Odishadtet.DAL;
using Odishadtet.Models;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Web.UI;
using System.Data;
using ClosedXML.Excel;
using System.IO;
using Odishadtet.General;

namespace Odishadtet.Controllers
{
    [CustomAuthorization]
    public class AdminActivityController : Controller
    {
        static IAdminService _AdminRepository;


        public AdminActivityController(IAdminService adminRepository)
        {
            _AdminRepository = adminRepository;
        }

        // GET: AdminActivitya
        public ActionResult OrderStatusForPreparation()
        {
            List<AdminActivityModel> adminactivity;
            adminactivity = _AdminRepository.OrderStatusPrparation();
            return View(adminactivity);
        }

        public ActionResult OpenOrderDetails()
        {
            //int userId,string preparedBy, string orderRefNo, string comments, int preparaionstatus
            //string UpdatePreparationStatus = "";
            //if (HttpContext.Session["loginUserID"] != null)
            //{
            //    UpdatePreparationStatus = _AdminRepository.UpdatePreparationOrderStatus(Convert.ToInt32(HttpContext.Session["loginUserID"].ToString()), HttpContext.Session["loginUserFullName"].ToString(), orderRefNo, comments, preparaionstatus);

            //}
            //return View(UpdatePreparationStatus);
            return View();
        }


        //public ActionResult DeliveryAddressPageDetails()
        //{
        //    List<AdminActivityModel> DeliveryAddress = new List<AdminActivityModel>();
        //    if (HttpContext.Session["loginUserID"] != null)
        //    {
        //        DeliveryAddress = _AdminRepository.GetOrderDeliveryAddressDetails(Convert.ToInt32(HttpContext.Session["loginUserID"].ToString()));
        //    }
        //    return View(DeliveryAddress);
        //}

        public ActionResult ActivationExtendDays()
        {

            return View();
        }

        // GET: AdminActivity/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminActivity/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminActivity/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminActivity/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminActivity/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminActivity/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminActivity/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public JsonResult OpenOrders(JqSearchIn si)
        {
            string mapuniv = HttpContext.Session["MappedUniversities"].ToString();

            var GridData = _AdminRepository.LoadGridOrdersPreparation(si, mapuniv);

            return Json(GridData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult OpenOrdersQCstatus(JqSearchIn si)
        {
            string mapuniv = HttpContext.Session["MappedUniversities"].ToString();

            var QCGridData = _AdminRepository.LoadOpenOrdersQC_Status(si, mapuniv);

            return Json(QCGridData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult OpenOrdersDetails()
        {
            return View();
        }

        //public JsonResult OpenOrders(JqSearchIn si)
        //{
        //    var GridData = _AdminRepository.LoadGridOpenOrders(si);

        //    return Json(GridData, JsonRequestBehavior.AllowGet);
        //}

        public ActionResult OpenOrdersOualityCheck()
        {
            return View();
        }

        public ActionResult OpenOrdersDeliveryStatus()
        {
            return View();
        }

        public JsonResult OpenOrdersDeliveryStatusgrid(JqSearchIn si)
        {
            string mapuniv = HttpContext.Session["MappedUniversities"].ToString();

            var QCGridData = _AdminRepository.LoadDeliveryOrdersStatus(si, mapuniv);

            return Json(QCGridData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AllOrdersStatusBuy_Cod_grid(JqSearchIn si)
        {
            var QCGridData = _AdminRepository.LoadAllOrdersbuyCODStatus(si);

            return Json(QCGridData, JsonRequestBehavior.AllowGet);
        }


        public JsonResult AllOrdersStatusBuy_Online_grid(JqSearchIn si, string Pdate)
        {
            var QCGridData = new JQGrid();
            string mapuniv = HttpContext.Session["MappedUniversities"].ToString();

            if (Pdate != null)
            {
                QCGridData = _AdminRepository.LoadAllOrdersbuyOnlineStatus(si, mapuniv, Pdate);
            }
            else
            {
                QCGridData = _AdminRepository.LoadAllOrdersbuyOnlineStatus(si, mapuniv);
            }
            return Json(QCGridData, JsonRequestBehavior.AllowGet);
        }


        public JsonResult AllOrderstoCancel_Refund_grid(JqSearchIn si, string Pdate)
        {

            var QCGridData = new JQGrid();
            string mapuniv = HttpContext.Session["MappedUniversities"].ToString();

            if (Pdate != null)
            {
                QCGridData = _AdminRepository.LoadAllSuccessOrdersforCancelRefund(si, mapuniv, Pdate);
            }
            else
            {
                QCGridData = _AdminRepository.LoadAllSuccessOrdersforCancelRefund(si, mapuniv);
            }
            return Json(QCGridData, JsonRequestBehavior.AllowGet);


        }



        public JsonResult SpecialOfferFreeOrders_grid(JqSearchIn si)
        {
            var QCGridData = new JQGrid();
            string mapuniv = HttpContext.Session["MappedUniversities"].ToString();

            QCGridData = _AdminRepository.LoadFreeOrders_status(si, mapuniv);

            return Json(QCGridData, JsonRequestBehavior.AllowGet);
        }


        public ActionResult SubjectActivationHistoryReport()
        {
            //int RecordpageCount = Convert.ToInt32(ConfigurationManager.AppSettings["RecordpageCount"]);
            //IEnumerable<ActivationReport> modelList = new List<ActivationReport>();
            //return View(modelList.ToPagedList(pagesize ?? 1, RecordpageCount));
            return View();

        }



        public ActionResult OpenOrderPaymentStatus()
        {
            return View();
        }
        public ActionResult AllOrderStatusDetailsbuyCOD()
        {
            return View();
        }

        public ActionResult AllOrderStatusDetailsbuyOnline()
        {
            return View();
        }
        public ActionResult AllOrderCancelRefundStatus()
        {
            return View();
        }
        public ActionResult OverAllOrderSummary()
        {
            return View();
        }


        public ActionResult AdminProductDetails(int PackageId)
        {
            //singlePackagedetails pckges = null;
            //if (HttpContext.Session["loginUserID"] != null)
            //{
            //    pckges = _AdminRepository.GetSinglePackagewithlogin(Convert.ToInt64(HttpContext.Session["loginUserID"].ToString()), PackageId);
            //}
            //else
            //{

            //    pckges = _AdminRepository.GetSinglePackage(PackageId);
            //}
            return View();
        }
        //  return View();
        public ActionResult SubjectActivationExtension()
        {
            return View();
        }

        public ActionResult SubjectUpload()
        {
            return View();
        }

        public ActionResult SubjectUploadPartalView()
        {
            return View();
        }

        public ActionResult SubjectUploadSummary()
        {
            return View();
        }

        public ActionResult FreeSpecialOfferOrders()
        {
            return View();
        }

        public void GetSubjectActivationHistory_DateWise_Details_Report(int UnivId, string ActStartDate, string ActEndDate, string UserRole)
        {
            try
            {
                var data = _AdminRepository.SubjectActivationHistory_DateWise_Details_Report(UnivId, ActStartDate,  ActEndDate,  UserRole);
                DataTable dt = new DataTable("AnalyzeReport");
                dt.Columns.Add("SNo");
                dt.Columns.Add("User Name");
                dt.Columns.Add("User Role");
                dt.Columns.Add("Mobile");
          
                dt.Columns.Add("Department");
                dt.Columns.Add("Activated Year");
                dt.Columns.Add("Activated Semester");
        
                dt.Columns.Add("Subject Name");
                dt.Columns.Add("Subject Type");
                dt.Columns.Add("Activated By");
                dt.Columns.Add("Activated On", typeof(DateTime));
                dt.Columns.Add("Days Extended");
                dt.Columns.Add("Extended Date", typeof(DateTime));


                foreach (var s in data)
                {
                    DataRow dr = dt.NewRow();
                    dr["SNo"] = dt.Rows.Count + 1;
                    dr["User Name"] = s.userName;
                    dr["User Role"] = s.userRole;
                    dr["Mobile"] = s.userMobile;                 
                    dr["Department"] = s.departmentname;
                    dr["Activated Year"] = s.subjectYear;
                    dr["Activated Semester"] = s.subjectSemester;                  
                    dr["Subject Name"] = s.subjectname;
                    dr["Subject Type"] = s.subjectType;
                    dr["Activated By"] = s.ActivateduserName;
                    dr["Activated On"] = s.Activated_on.Date;
                    dr["Days Extended"] = s.subjectextensiondays;
                    dr["Extended Date"] = s.subjectexpiryextensiondt.Date;

                    dt.Rows.Add(dr);
                }
              
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dt);
                    wb.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    wb.Style.Font.Bold = true;
                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    string filename = "attachment;filename=SubjectActivationReportUserwise.xlsx";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", filename);

                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Response.End();
                    }
                }
            }
            catch (Exception ex)
            {
                Log.WriteLogMessage("AdminActivity", "GetSubjectActivationHistory_DateWise_Details_Report", "GetSubjectActivationHistory_DateWise_Details_Report", ex.Message, "error");
                throw ex;
            }
        }

      

       

    }
}
