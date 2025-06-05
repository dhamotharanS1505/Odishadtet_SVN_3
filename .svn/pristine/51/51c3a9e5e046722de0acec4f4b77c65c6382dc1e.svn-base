using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Odishadtet.DAL;
using Odishadtet.Models;
using System.Web;

namespace Odishadtet.APIServiceControllers
{
    public class APIProductDetailsController : ApiController
    {

        static IProductService _Productrepository;

        public APIProductDetailsController(IProductService Productrepository)
        {
            if (Productrepository == null)
            {
                throw new ArgumentNullException("Productrepository");
            }

            _Productrepository = Productrepository;
        }


        public List<singlePackagedetails> GetSinglePackageDetailss(int PackageId)
        {
            List<singlePackagedetails> gSinglePackage = _Productrepository.GetSinglePackageDetails(PackageId);

            return gSinglePackage;
        }


        public singlePackagedetails GetSinglePackage(int PackageId)
        {

            singlePackagedetails SinglePackages = _Productrepository.GetSinglePackage(PackageId);
            
            return SinglePackages;

        }

        public singlePackagedetails GetSinglePackagewithlogin(long UserId, int PackageId)
        {
            singlePackagedetails SinglePackageswithlogin = _Productrepository.GetSinglePackagewithlogin(UserId, PackageId);
            return SinglePackageswithlogin;
        }
        //[HttpGet]
        //public string InsertPackageToUserCart(int UserId, int PackageId)
        //{
        //    string strResult = _Studentrepository.InsertPackageToUserCart(UserId, PackageId);

        //    return strResult;
        //}

        //[HttpGet]
        //public string InsertToUserWishList(int UserId, int PackageId)
        //{
        //    string strResult = _Studentrepository.InsertToUserWishList(UserId, PackageId);

        //    return strResult;
        //}

         
    
        public string GetFeedbackMail(string collegeName, string subjectName, string userName, long mobileNumber, string emailId, string message)
        {
            string feedback = _Productrepository.FeedbackMail(collegeName, subjectName, userName, mobileNumber, emailId, message);
            return feedback;
        }
    }
}
