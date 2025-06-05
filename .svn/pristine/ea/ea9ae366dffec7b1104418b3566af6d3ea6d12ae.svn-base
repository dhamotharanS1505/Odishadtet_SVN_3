using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using Odishadtet.DAL;

namespace Odishadtet.Models
{
    public class AdminActivityModel
    {
        public int orderstatus { get; set; }
        public DateTime orderon { get; set; }
        public string orderrefno { get; set; }
        public string ordermobile { get; set; }
        public int prepareStatus { get; set; }
        public DateTime prepareOn { get; set; }
        public string prepareBy { get; set; }
        public string prepareComments { get; set; }
        public int qualityCheckStatus { get; set; }
        public DateTime qualityCheckOn { get; set; }
        public string qualityCheckBy { get; set; }
        public string qualityComments { get; set; }
        public string deliverstatus { get; set; }
        public DateTime deliverOn { get; set; }
        public string deliverBy { get; set; }
        public string deliveryComments { get; set; }
        public string courierName { get; set; }
        public string courierReferenceno { get; set; }
        public string courierContactno { get; set; }
        public string expectedDelivery { get; set; }
        public string denterby { get; set; }
        public DateTime denteron { get; set; }
        public string paymentstatus { get; set; }
        public DateTime payreceiveon { get; set; }
        public string payreceivedby { get; set; }
        public string comments { get; set; }
        public DateTime pmenteron { get; set; }
        public string pmenterby { get; set; }
        public DateTime activationon { get; set; }
        public string activationmobile { get; set; }
        public string ClientRefNo { get; set; }
        public string DeliveryMode { get; set; }
        public int SellingPrice { get; set; }
        public int ShippingPrice { get; set; }
        public string UserDeliveryName { get; set; }
        public string UserDeliveryaddress { get; set; }
        public long UserDeliverypincode { get; set; }
        public string UserDeliveryCity { get; set; }
        public string UserDeliveryState { get; set; }
        public string UserDeliveryCountry { get; set; }
        public long UserDeliveryMobileno { get; set; }
        public int Amount { get; set; }
        public int? Discountamt { get; set; }
        public long UserId { get; set; }

    }

    public class UserSubjectDetails
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public long Mobile { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
        public string College { get; set; }
        public string University { get; set; }
        public long SubjectId { get; set; }
        public string SubjectCode { get; set; }
        public string SubjectName { get; set; }
        public int Years { get; set; }
        public int Semester { get; set; }
        public string ExpiredDate { get; set; }
        public string DepartmentName { get; set; }
        public int UniversityId { get; set; }
        public int PackageId { get; set; }
        public string packageName { get; set; }
        public string Regulation { get; set; }
        public int SubjectUnitType { get; set; }
    }

    public class Qcstatus
    {
        public long preperedBy { get; set; }
        public string OrderRefNo { get; set; }
        public string Comments { get; set; }
        public int qc_status { get; set; }
    }

    public class Preparationstaus
    {
        public long preperedBy { get; set; }
        public string orderRefNo { get; set; }
        public string comments { get; set; }
        public int preparaionstatus { get; set; }
    }

    public class PaymentStatus
    {
        public long preperedBy { get; set; }
        public string orderRefNo { get; set; }
        public int paymentamt { get; set; }
        public int Paymentstatus { get; set; }
        public Int64 user_subscribed_masterid { get; set; }
        public Int64 created_userid { get; set; }

    }

    public class paymentrefundstatus
    {

        public long preperedBy { get; set; }
        public int paymentrefundamt { get; set; }
        public int Paymentrefundstatus { get; set; }
        public string OrderRefNo { get; set; }
    }

    public class Deliverystaus
    {
        public long preperedBy { get; set; }
        public string orderRefNo { get; set; }
        public string comments { get; set; }
        public int Deliverystatus { get; set; }
        public string DeliverBy { get; set; }
        public string DeliveryOn { get; set; }
        public string CourierName { get; set; }
        public string Courierno { get; set; }
        public string CourierContactno { get; set; }
        public int CourierExpecteddeliverydays { get; set; }
    }

    public class savesubjectactivation
    {

        public int subjectid { get; set; }
        public string subjectcode { get; set; }
        public string subjectname { get; set; }
        public string Subjectversion { get; set; }
        public int userid { get; set; }
        public int departmentid { get; set; }
        public string subjectexpirydate { get; set; }
        public string subjectexpiryextensiondate { get; set; }
        public int subjectextensiondays { get; set; }
        public int activatedby { get; set; }
    }


    public class AdminDateWiseSummary
    {
        public string dates { get; set; }
        public int ordersCount { get; set; }
        public int orderAmount { get; set; }

    }

    public class Semester_product
    {
        public int Universityid { get; set; }
        public int Semester { get; set; }
        public int Year { get; set; }
        public string SemDisplay { get; set; }
    }

    public class  keywords_longdesc_product

    {
        public string PreviousKeywords { get; set; }
        public string CurrentKeywords { get; set; }
        public string PreviousDescription { get; set; }
        public string CurrentDescription { get; set; }
        public int packageid { get; set; }
        public string Description { get; set; }
        public int universityid { get; set; }
        public int departmentid { get; set; }
        public int semester { get; set; }
        public long regulationid { get; set; }
        public string packagedisplayname { get; set; }
        public int Sessionuserid { get; set; }
        public string descrption { get; set; }
        public string quickoverview { get; set; }

    }



}