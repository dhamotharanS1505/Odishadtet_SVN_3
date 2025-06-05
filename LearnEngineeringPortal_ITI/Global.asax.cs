using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;
using Microsoft.Practices.Unity;
using Odishadtet.APIServiceControllers;
using Odishadtet.DAL;
//using Odishadtet.DAL;
using TNDET.Helper;
using Unity.WebApi;
using Odishadtet.Models;
using Odishadtet.Controllers;
using TNDET.API_ITI_ServiceControllers;

namespace TNDET 
{
    public class MvcApplication : System.Web.HttpApplication
    {

        void ConfigureApi(HttpConfiguration config)
        {
            var unity = new UnityContainer();
            unity.RegisterType<APIProductHomeController>().RegisterType<IProductService, ProductService>(new HierarchicalLifetimeManager());
            unity.RegisterType<APIProductDetailsController>().RegisterType<IProductService, ProductService>(new HierarchicalLifetimeManager());
            unity.RegisterType<APIPaymentCartController>().RegisterType<IPaymentService, PaymentService>(new HierarchicalLifetimeManager());
            unity.RegisterType<APIUserViewCartDetailsController>().RegisterType<IStudentService, StudentService>(new HierarchicalLifetimeManager());
            unity.RegisterType<APIUserDashBoardController>().RegisterType<IStudentService, StudentService>(new HierarchicalLifetimeManager());
            unity.RegisterType<APIAdminActivityController>().RegisterType<IAdminService, AdminService>(new HierarchicalLifetimeManager());
            unity.RegisterType<APIAdminAnalyzeActivityController>().RegisterType<IAdminAnalyzeService, AdminAnalyzeService>(new HierarchicalLifetimeManager());
            unity.RegisterType<APIAdminReportController>().RegisterType<IAdminReportService, AdminReportService>(new HierarchicalLifetimeManager());
            unity.RegisterType<APIAdminDashBoardReportsController>().RegisterType<IAdminReportService, AdminReportService>(new HierarchicalLifetimeManager());
            unity.RegisterType<APICollegeGroupAdminDashBoardReportsController>().RegisterType<ICollegeGroupAdminReportService, CollegeGroupAdminReportService>(new HierarchicalLifetimeManager());

            unity.RegisterType<APIStudentUserDashBoardController>().RegisterType<IStudentUserService, StudentUserService>(new HierarchicalLifetimeManager());

            config.DependencyResolver = new IoCContainer(unity);
        }


        protected void Application_Start()
        {

            // Disable the MVC version response header
            System.Web.Mvc.MvcHandler.DisableMvcResponseHeader = true;

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            UnityConfig.RegisterComponents();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ConfigureApi(GlobalConfiguration.Configuration);
            Bootstrapper.Initialise();
            //Session.Timeout = 60;
        }
        protected void Application_BeginRequest()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();

            // CORS setup
            string origin = HttpContext.Current.Request.Headers["Origin"];
            string[] allowedOrigins = new string[] { "http://localhost:8081", "http://testlearn.learnengg.com" , "https://iptportal.com" };

            if (!string.IsNullOrEmpty(origin) && allowedOrigins.Contains(origin))
            {
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", origin);
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Authorization");
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Credentials", "true"); // if needed
            }

            // Handle preflight requests
            if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            {
                HttpContext.Current.Response.StatusCode = 200;
                HttpContext.Current.Response.End();
            }



        }
    }
}
