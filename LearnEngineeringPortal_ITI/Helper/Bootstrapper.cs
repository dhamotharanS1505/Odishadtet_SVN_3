using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Odishadtet.DAL;
using Unity.Mvc5;

namespace TNDET.Helper
{
    public static class Bootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container)); 

            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            container.RegisterType<IProductService, ProductService>(); 
            container.RegisterType<IPaymentService, PaymentService>();
            container.RegisterType<IStudentService, StudentService>();
            container.RegisterType<IAdminService, AdminService>();
            container.RegisterType<IAdminAnalyzeService, AdminAnalyzeService>();
            container.RegisterType<IAdminReportService, AdminReportService>();
            container.RegisterType<ICollegeGroupAdminReportService, CollegeGroupAdminReportService>();


            container.RegisterType<IStudentUserService, StudentUserService>();

            RegisterTypes(container);
            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {

        }
    }
}