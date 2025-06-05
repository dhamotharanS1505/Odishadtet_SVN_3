using ClosedXML.Excel;
using Odishadtet.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using Odishadtet.General;

namespace Odishadtet.Controllers
{
    public class AdminAnalyzeActivityController : Controller
    {
        static IAdminAnalyzeService _AdminRepository;

        public AdminAnalyzeActivityController(IAdminAnalyzeService adminRepository)
        {
            _AdminRepository = adminRepository;
        }

        // GET: AdminAnalyzeActivity
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AnalyzeReportBySubjectPurchase()
        {
            return View();
        }

        public ActionResult DataAnalyzeReport()
        {
            return View();
        }
        /// <summary>
        /// Data Analyse Report for subject wise with multiple conditions
        /// </summary>
        /// <param name="UnivId"></param>
        /// <param name="PurStartDate"></param>
        /// <param name="PurEndDate"></param>
        /// <param name="TraStartDate"></param>
        /// <param name="TraEndDate"></param>
        /// <param name="UsgStartDate"></param>
        /// <param name="UsgEndDate"></param>
        /// <param name="UserRole"></param>
        public void DataAnalyseReportSubjectWise(int UnivId, string PurStartDate, string PurEndDate, string TraStartDate, string TraEndDate, string UsgStartDate, string UsgEndDate, string UserRole)
        {
            var data = _AdminRepository.GetTrailBySubjectWithMultipleCondition(UnivId, PurStartDate, PurEndDate, TraStartDate, TraEndDate, UsgStartDate, UsgEndDate, UserRole);
            if (data.Count > 0)
            {
                DataTable dt = new DataTable("AnalyzeReport");
                dt.Columns.Add("SNo");
                dt.Columns.Add("Subject Name");
                dt.Columns.Add("Year");
                dt.Columns.Add("Semester");
                dt.Columns.Add("Content Product");
                dt.Columns.Add("Q & A Android App");
                dt.Columns.Add("Q & A Desktop");
                dt.Columns.Add("Trial Count");
                dt.Columns.Add("Usage Count");

                foreach (var s in data)
                {
                    DataRow dr = dt.NewRow();
                    dr["SNo"] = dt.Rows.Count + 1;
                    dr["Subject Name"] = s.subject_name;
                    dr["Year"] = s.year;
                    dr["Semester"] = s.semester;
                    dr["Content Product"] = s.total_purchased_content;
                    dr["Q & A Android App"] = s.total_purchased_qa_android;
                    dr["Q & A Desktop"] = s.total_purchased_qa_desktop;
                    dr["Trial Count"] = s.trail_count;
                    dr["Usage Count"] = s.usagehrs;
                    dt.Rows.Add(dr);
                }
                if (PurStartDate == "0" && PurEndDate == "0")
                {
                    dt.Columns.Remove("Content Product");
                    dt.Columns.Remove("Q & A Android App");
                    dt.Columns.Remove("Q & A Desktop");
                }
                if (TraStartDate == "0" && TraEndDate == "0")
                {
                    dt.Columns.Remove("Trial Count");
                }
                if (UsgStartDate == "0" && UsgEndDate == "0")
                {
                    dt.Columns.Remove("Usage Count");
                }
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dt);
                    wb.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    wb.Style.Font.Bold = true;
                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    string filename = "attachment;filename=DataAnalyzeReportSubjectwise.xlsx";
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
        }

        /// <summary>
        ///  Data Analyze report for user wise with multiple conditions
        /// </summary>
        /// <param name="UnivId"></param>
        /// <param name="RegStartDate"></param>
        /// <param name="RegEndDate"></param>
        /// <param name="PurStartDate"></param>
        /// <param name="PurEndDate"></param>
        /// <param name="TraStartDate"></param>
        /// <param name="TraEndDate"></param>
        /// <param name="UsgStartDate"></param>
        /// <param name="UsgEndDate"></param>
        public void DataAnalyseReportUserwise(int UnivId, string RegStartDate, string RegEndDate, string PurStartDate, string PurEndDate, string TraStartDate, string TraEndDate, string UsgStartDate, string UsgEndDate, string UserRole)
        {
            try
            {
                var data = _AdminRepository.GetTrailByUserWithMultipleCondition(UnivId, RegStartDate, RegEndDate, PurStartDate, PurEndDate, TraStartDate, TraEndDate, UsgStartDate, UsgEndDate, UserRole);
                DataTable dt = new DataTable("AnalyzeReport");
                dt.Columns.Add("SNo");
                dt.Columns.Add("User Name");
                dt.Columns.Add("User Role");
                dt.Columns.Add("Mobile");
                dt.Columns.Add("University");
                dt.Columns.Add("Department");
                dt.Columns.Add("Student Year");
                dt.Columns.Add("Student Semester");
                dt.Columns.Add("Register On", typeof(DateTime));
                //dt.Columns.Add("Register On");
                dt.Columns.Add("Purchased/Trailed/Usage Year");
                dt.Columns.Add("Purchased/Trailed/Usage Semester");
                dt.Columns.Add("Trialed Users");
                dt.Columns.Add("Content");
                dt.Columns.Add("QA_desktop");
                dt.Columns.Add("QA_Android");
                dt.Columns.Add("Combo Pack");
                dt.Columns.Add("Purchased Users");
                dt.Columns.Add("Read Users");

                foreach (var s in data)
                {
                    DataRow dr = dt.NewRow();
                    dr["SNo"] = dt.Rows.Count + 1;
                    dr["User Name"] = s.user_name;
                    dr["User Role"] = s.user_role;
                    dr["Mobile"] = s.mobileno;
                    dr["University"] = s.univ_name;
                    dr["Department"] = s.departmentName;
                    dr["Student Year"] = s.year;
                    dr["Student Semester"] = s.semester;
                    dr["Register On"] = DateTime.ParseExact(s.registered_on, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture).Date;
                    // dr["Register On"] = s.registered_on;
                    dr["Purchased/Trailed/Usage Year"] = s.purchasedyear;
                    dr["Purchased/Trailed/Usage Semester"] = s.purchasedsemester;
                    dr["Trialed Users"] = s.trail_count;
                    dr["Content"] = s.purchased_content_count;
                    dr["QA_desktop"] = s.purchased_qa_desktop_count;
                    dr["QA_Android"] = s.purchased_qa_android_count;
                    dr["Combo Pack"] = s.purchased_combo_count;
                    dr["Purchased Users"] = s.purchased_count;
                    dr["Read Users"] = s.Usage_hours;


                    dt.Rows.Add(dr);
                }
                if (PurStartDate == "0" && PurEndDate == "0")
                {
                    dt.Columns.Remove("Content");
                    dt.Columns.Remove("QA_desktop");
                    dt.Columns.Remove("QA_Android");
                    dt.Columns.Remove("Combo Pack");
                    dt.Columns.Remove("Purchased Users");

                }
                if (TraStartDate == "0" && TraEndDate == "0")
                {
                    dt.Columns.Remove("Trialed Users");
                }
                if (UsgStartDate == "0" && UsgEndDate == "0")
                {
                    dt.Columns.Remove("Read Users");
                }
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dt);
                    wb.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    wb.Style.Font.Bold = true;
                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    string filename = "attachment;filename=DataAnalyzeReportUserwise.xlsx";
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
                Log.WriteLogMessage("AdminAnalyzeActivity", "DataAnalyseReportUserwise", "DataAnalyseReportUserwise", ex.Message, "error");
                throw ex;
            }
        }
        /// <summary>
        /// DatewiseSalesReport
        /// </summary>
        public void DatewiseSalesReport()
        {
            try
            {
                var SalesData = _AdminRepository.DateWise_Sales_Report();

                DataTable dtDatewiseSales = new DataTable("DatewiseSales");
                dtDatewiseSales.Columns.Add("SNo");
                dtDatewiseSales.Columns.Add("TxnDate", typeof(DateTime));
                var univ = (from sd in SalesData orderby sd.universityName select new { sd.universityName, sd.universityShortName }).Distinct().ToList();
                foreach (var u in univ)
                {
                    dtDatewiseSales.Columns.Add(u.universityShortName + " Orders", typeof(int));
                    dtDatewiseSales.Columns.Add(u.universityShortName + " Amount", typeof(int));
                }
                dtDatewiseSales.Columns.Add("TotalOrders", typeof(int));
                dtDatewiseSales.Columns.Add("TotalAmount", typeof(int));
                var txnDate = (from sd in SalesData orderby sd.TxnDate select sd.TxnDate).Distinct().ToList();


                foreach (var d in txnDate)
                {
                    DataRow dr = dtDatewiseSales.NewRow();
                    dr["SNo"] = dtDatewiseSales.Rows.Count + 1;
                    dr["TxnDate"] = d;
                    var data = (from sd in SalesData
                                where sd.TxnDate == d
                                orderby sd.universityName
                                select new
                                {
                                    txnDate = sd.TxnDate.Date,
                                    university = sd.universityName,
                                    totalOrders = sd.TotalOrders,
                                    totalAmount = sd.TotalAmount
                                }
                               ).ToList();

                    List<string> existUniv = new List<string>();
                    double colTotalAmount = 0;
                    int colTotalOrders = 0;
                    foreach (var c in data)
                    {
                        foreach (var u in univ)
                        {

                            {
                                if (u.universityName == c.university && dtDatewiseSales.Columns.Contains(u.universityShortName + " Orders"))
                                {
                                    dr[u.universityShortName + " Orders"] = c.totalOrders;
                                    colTotalOrders += Convert.ToInt32(c.totalOrders);
                                    existUniv.Add(u.universityName);
                                }
                                else if (!existUniv.Contains(u.universityName))
                                {
                                    dr[u.universityShortName + " Orders"] = 0;
                                }
                                if (u.universityName == c.university && dtDatewiseSales.Columns.Contains(u.universityShortName + " Amount"))
                                {
                                    dr[u.universityShortName + " Amount"] = c.totalAmount;
                                    colTotalAmount += Convert.ToDouble(c.totalAmount);
                                }
                                else if (!existUniv.Contains(u.universityName))
                                {
                                    dr[u.universityShortName + " Amount"] = 0;
                                }
                            }
                        }
                    }
                    dr["TotalOrders"] = colTotalOrders;
                    dr["TotalAmount"] = colTotalAmount;
                    dtDatewiseSales.Rows.Add(dr);
                }

                using (XLWorkbook wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add(dtDatewiseSales);
                    wb.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    wb.Style.Font.Bold = true;
                    ws.Row(1).InsertRowsAbove(1);
                    char[] cExcelColumn = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P' };
                    //string cellVal;
                    for (int i = 2; i <= dtDatewiseSales.Columns.Count; i++)
                    {
                        if (ws.Cell(cExcelColumn[i].ToString() + "2").Value.ToString() != "")
                        {
                            if (ws.Cell(cExcelColumn[i].ToString() + "2").Value.ToString().Contains("Orders"))
                            {

                                ws.Cell(cExcelColumn[i].ToString() + "1").Value = ws.Cell(cExcelColumn[i].ToString() + "2").Value.ToString().Replace("Orders", "");
                                // ws.Cell(cExcelColumn[i].ToString() + "2").Value = ws.Cell(cExcelColumn[i].ToString() + "2").Value.ToString().Replace(ws.Cell(cExcelColumn[i].ToString() + "1").Value.ToString(), "");
                                ws.Range(cExcelColumn[i].ToString() + "1:" + cExcelColumn[i + 1].ToString() + "1").Row(1).Merge();

                            }
                            //else if (ws.Cell(cExcelColumn[i].ToString() + "2").Value.ToString().Contains("Amount"))
                            //{
                            //    cellVal = ws.Cell(cExcelColumn[i].ToString() + "2").Value.ToString().Replace("Amount", "");
                            //    ws.Cell(cExcelColumn[i].ToString() + "2").Value = cellVal;
                            //}
                            ws.Cell(cExcelColumn[i].ToString() + "1").Style.Font.Bold = true;
                            ws.Cell(cExcelColumn[i].ToString() + "1").Worksheet.ColumnWidth = 10;
                            ws.Cell(cExcelColumn[i].ToString() + "1").Style.Fill.BackgroundColor = XLColor.SteelBlue;
                            ws.Cell(cExcelColumn[i].ToString() + "1").Style.Font.FontColor = XLColor.White;
                            ws.Cell(cExcelColumn[i].ToString() + "1").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                            ws.Cell(cExcelColumn[i].ToString() + "1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                            ws.Cell(cExcelColumn[i].ToString() + "1").Style.Alignment.WrapText = true;
                            ws.Cell(cExcelColumn[i].ToString() + "1").Style.Alignment.ShrinkToFit = true;

                            string AdjustedPriceFormula = "=Sum(" + cExcelColumn[i].ToString() + "1:" + cExcelColumn[i].ToString() + (dtDatewiseSales.Rows.Count + 2) + ")";

                            //apply your formula to the cell.
                            ws.Cells(cExcelColumn[i].ToString() + (dtDatewiseSales.Rows.Count + 3)).FormulaA1 = AdjustedPriceFormula;
                            ws.Cell(cExcelColumn[i].ToString() + (dtDatewiseSales.Rows.Count + 3)).Style.Font.Bold = true;
                            ws.Cell(cExcelColumn[i].ToString() + (dtDatewiseSales.Rows.Count + 3)).Worksheet.ColumnWidth = 10;
                            ws.Cell(cExcelColumn[i].ToString() + (dtDatewiseSales.Rows.Count + 3)).Style.Fill.BackgroundColor = XLColor.SteelBlue;
                            ws.Cell(cExcelColumn[i].ToString() + (dtDatewiseSales.Rows.Count + 3)).Style.Font.FontColor = XLColor.White;
                            ws.Cell(cExcelColumn[i].ToString() + (dtDatewiseSales.Rows.Count + 3)).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                            ws.Cell(cExcelColumn[i].ToString() + (dtDatewiseSales.Rows.Count + 3)).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            //var test=ws.Range(cExcelColumn[i].ToString() + "1:" + cExcelColumn[i + 1].ToString() + dtDatewiseSales.Rows.Count).FormulaR1C1;



                        }
                    }
                    ws.Row(1).InsertRowsAbove(1);
                    ws.Range("A1:P1").Row(1).Merge();
                    ws.Cell("A1").Value = "Datewise Sales Report";
                    ws.Cell("A1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    ws.Cell("A1").Style.Font.FontSize = 18;
                    ws.Cell("A1").Style.Font.FontName = "Calibri";
                    ws.Cell("A1").Style.Font.Bold = true;
                    ws.Cell("A1").Style.Alignment.ShrinkToFit = true;

                    wb.Style.Alignment.ShrinkToFit = true;

                    wb.Style.Alignment.WrapText = true;
                    ws.Columns().AdjustToContents();
                    ws.Rows().AdjustToContents();
                    var row1 = ws.Row(1);
                    row1.Style.Font.FontColor = XLColor.Green;
                    row1.Height = 25;
                    row1.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    row1.Style.Border.InsideBorder = XLBorderStyleValues.Medium;

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    string filename = "attachment;filename=DatewiseSalesReport" + DateTime.Now.ToString("ddMMyy_HHmmss") + ".xlsx";
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
                Log.WriteLogMessage("AdminAnalyzeActivity", "DatewiseSalesReport", "DatewiseSalesReport", ex.Message, "error");
                throw ex;
            }
        }

        /// <summary>
        /// StudentSemestersReport for registered and not registered users
        /// </summary>
        /// <returns></returns>
        public ActionResult StudentSemestersReport()
        {
            return View();
        }
        /// <summary>
        /// Excel report for sms data users
        /// </summary>
        public void ExportSMSdataReport(int univId, int year, int batchyearId, int rpt_type)
        {
            try
            {
                var data = _AdminRepository.ExportSMSdataReport(univId, year, batchyearId, rpt_type);
                DataTable dt = new DataTable("SMSDataReport");
                dt.Columns.Add("SNo");
                dt.Columns.Add("User Name");
                dt.Columns.Add("Batch year");
                dt.Columns.Add("Year");
                dt.Columns.Add("Semester");
                dt.Columns.Add("Mobile");
                dt.Columns.Add("Email");
                dt.Columns.Add("University");
                dt.Columns.Add("College");
                dt.Columns.Add("Department");

                foreach (var s in data)
                {
                    DataRow dr = dt.NewRow();
                    dr["SNo"] = dt.Rows.Count + 1;
                    dr["User Name"] = s.UserName;
                    dr["Batch year"] = s.BatchYear;
                    dr["Year"] = s.Year;
                    dr["Semester"] = s.Semester;
                    dr["Mobile"] = s.Mobile;
                    dr["Email"] = s.Email;
                    dr["University"] = s.universityName;
                    dr["College"] = s.CollegeName;
                    dr["Department"] = s.Department;

                    dt.Rows.Add(dr);
                }
                if (data.FirstOrDefault().UserName == null)
                {
                    dt.Columns.Remove("User Name");
                    dt.Columns.Remove("Semester");
                    dt.Columns.Remove("College");
                    dt.Columns.Remove("Department");
                    dt.Columns.Remove("Email");
                }
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dt);
                    wb.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    wb.Style.Font.Bold = true;
                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    string filename = "attachment;filename=StudentsSMSdata.xlsx";
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
                Log.WriteLogMessage("AdminAnalyzeActivity", "ExportSMSdataReport", "ExportSMSdataReport", ex.Message, "error");
                throw ex;
            }
        }

    }


}