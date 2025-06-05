using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Odishadtet.DAL;
using Odishadtet.Models;

namespace Odishadtet.APIServiceControllers
{
    public class APIUserViewCartDetailsController : ApiController
    {
        static IStudentService _repository;

        public APIUserViewCartDetailsController(IStudentService repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("repository");
            }

            _repository = repository;
        }
                
        [HttpGet]
        public string UpdateTrailPackageOnline(int userid, int packageid)
        {
            string result = _repository.UpdateTrailPackageOnline(userid, packageid);
            return result;
        }


        [HttpGet]
        public int RemoveUser(long userMobile, long adminMobile)
        {
            int result =  _repository.RemoveUser(userMobile, adminMobile);
            return result;
        }


        [HttpGet]
        public string UpdatePackagesWithoutPayment(int userid, int packageid)
        {
            string result = _repository.UpdatePackagesWithoutPayment(userid, packageid);
            return result;
        }

        [HttpGet]
        public string UpdatePackagesWithoutPaymentforSemester(long UserId, long univ_id, int subject_unit_type, int semester, int rule_id)
        {
            string result = _repository.UpdatePackagesWithoutPaymentforSemester(UserId, univ_id, subject_unit_type,  semester,  rule_id);
            return result;
        }      



        public List<userViewCart> GetViewCartDetails(long userId)
        {
            List<userViewCart> viewCart = _repository.GetViewCartDetails(userId);

            return viewCart;
        }
        

        public List<userViewCart> GetViewCartDetails_BeforeLogin(string packageID)
        {
            List<userViewCart> viewCart = _repository.GetViewCartDetails_beforeLogin(packageID);

            return viewCart;
        }

        public int GetViewCartCount(int userId)
        {
            int viewCount = _repository.GetViewCartCount(userId);
            return viewCount;
        }
        public List<DeliveryOptionMode> GetDeliveryMode()
        {
           List<DeliveryOptionMode> dom= _repository.GetDeliveryMode();
            return dom;
        }

        public int GetRemovePackage(int userId,int PackageID)
        {
            int result = _repository.RemovePackage(userId,PackageID);
            return result;
        }

        
        public int GetUpdateDeliveryMode(int userId,int DeliveryModeId)
        {
            int result = _repository.UpdateDeliveryMode(userId,DeliveryModeId);
            return result;
        }
        // GET: api/APIUserViewCartDetails
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/APIUserViewCartDetails/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/APIUserViewCartDetails
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/APIUserViewCartDetails/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/APIUserViewCartDetails/5
        public void Delete(int id)
        {
        }


        public string GetUserPassword(string EncPass)
        {
            string result = "";
            result = _repository.GetPasswordString(EncPass);
            return result;
        }

        public string GetUserEncPassword(string Pass)
        {
            string result = "";
            result = _repository.GetEncPasswordString(Pass);
            return result;
        }
    }
}
