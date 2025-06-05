using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Odishadtet.Models;

namespace Odishadtet.DAL
{
    public interface IProductService
    {
        void DoWork();

        List<Departmentdetails> GetDepartmentDetails();

        List<SubjectDetails> GetSubjectDetails(int departmentID);

        List<Packagedetails> GetPackageDetails(int departId, long subjectid);

        List<singlePackagedetails> GetSinglePackageDetails(int PackageId);

       singlePackagedetails GetSinglePackage(int PackageId);

        singlePackagedetails GetSinglePackagewithlogin(long UserId, int PackageId);


        List<Packagedetails> GetDepartmentRelatedPackagesDetails(int DepartmentId);

        List<CoupenAvailability> GetAvailableDiscountCoupens();

        string ApplyDiscountCoupenForUser(string discountCode);

        string CheckAvailablePackageDetails(int packageid);

        List<Universitydetails> GetUniversityDetails(int univtype, int loginUserid);

        List<Universitydetails> GetUniversityDetails();

        List<Departmentdetails> GetDepartmentList(int univId, int univtype);

        List<Packagedetails> GetPackageDetails(int univId, int departmentId,int userId, int univtype);

        List<Semester_Regulation> GetSemester(int univId,int univType);

        List<Semester_Regulation> GetRegulation(int univ_id);

        List<Universitydetails> GetUniversityId_UnivType(int univ_Type);

        List<Packagedetails> GetPackages(int departId, long subjectid);

        string FeedbackMail(string collegeName, string subjectName, string userName, long mobileNumber, string emailId, string message);

        string SaveUserDetailsForMasterCopyUsage(string userName, string emailId, long mobile, string departmentName, int semester);

        string Registration_OTPConformation(long mastercopy_usage_id, string OTPCode);

        string Registration_ReSendOTP(long mastercopy_usage_id);

    }
}
