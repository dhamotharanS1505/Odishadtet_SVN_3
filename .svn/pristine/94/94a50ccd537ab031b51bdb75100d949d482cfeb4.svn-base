using Odishadtet.DAL;
using Odishadtet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TNDET.API_ITI_ServiceControllers
{
    public class APIAdminDashBoardReportsController : ApiController
    {

        static IAdminReportService _AdminRepository;

        public APIAdminDashBoardReportsController(IAdminReportService Productrepository)
        {
            if (Productrepository == null)
            {
                throw new ArgumentNullException("Productrepository");
            }

            _AdminRepository = Productrepository;
        }

        [HttpGet]
        public UserDashBoardViewModel GetUserDashBoardMain(int CollegeGrpId)
        {
            UserDashBoardViewModel UserDashBoardMain = _AdminRepository.DashBoardMain(CollegeGrpId);
            return UserDashBoardMain;
        }


        // Get: api/APIAdminDashBoardReports
        [HttpGet]
        public UseageDashBoardViewModel GetDashBoardViewData(int CollegeGrpId, int SubType = 1)
        {
            UseageDashBoardViewModel UserDashBoardMain = _AdminRepository.UsageDashBoard(CollegeGrpId,SubType);
            return UserDashBoardMain;
        }


        // Get: api/APIAdminDashBoardReports
        [HttpGet]
        public UseageDashBoardViewModel GetDashBoardTradewiseViewData(int CollegeGrpId, int SubType = 1)
        {
            UseageDashBoardViewModel UserDashBoardMain = _AdminRepository.UsageDashBoardTradewise(CollegeGrpId,SubType);
            return UserDashBoardMain;
        }


        // Get: api/APIAdminDashBoardReports
        [HttpGet]
        public RegistrationDashBoardViewModel GetDashBoardRegistrationData(int CollegeGrpId, int SubType = 1)
        {
            RegistrationDashBoardViewModel RegistrationDashBoardMain = _AdminRepository.RegistrationDashBoard(CollegeGrpId,SubType);
            return RegistrationDashBoardMain;
        }


        // Get: api/APIAdminDashBoardReports
        [HttpGet]
        public RegistrationDashBoardViewModel GetDashBoardDatewiseRegistrationData(int CollegeGrpId, int SubType = 1)
        {
            RegistrationDashBoardViewModel RegistrationDashBoardMain = _AdminRepository.RegistrationDashBoardDatewiseCount(CollegeGrpId,SubType);
            return RegistrationDashBoardMain;
        }


    }
}
