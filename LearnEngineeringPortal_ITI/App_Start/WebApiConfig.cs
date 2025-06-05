using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.Practices.Unity;
using Odishadtet.DAL;
using TNDET.Helper;

namespace TNDET 
{
    /// <summary>
    /// WebApiConfig
    /// </summary>
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            //var container = new UnityContainer();
            //container.RegisterType<IProductService, ProductService>(new HierarchicalLifetimeManager());
            //config.DependencyResolver = new UnityResolver(container);

            // Web API routes
            // config.MapHttpAttributeRoutes();



           config.Routes.MapHttpRoute(
           name: "ActionApi",
           routeTemplate: "APIService/{controller}/{action}/{id}",
           defaults: new { id = RouteParameter.Optional }
           );

            config.Routes.MapHttpRoute(
                      name: "DefaultApi",
                      routeTemplate: "APIService/{controller}/{id}",
                      defaults: new { id = RouteParameter.Optional }
            );

            //  config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

           

        }
    }
}
