using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TNDET 
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {


            //routes.IgnoreRoute("odskills/{*pathInfo}");

            ////routes.IgnoreRoute("odskills/{*pathInfo}", new { pathInfo = @".*\.(html|css|js|jpg|png|gif|ico)$" });

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.IgnoreRoute("odskills/{*pathInfo}");

            // Block direct access to a specific folder (e.g., "RestrictedFolder")
            //routes.IgnoreRoute("odskills/{*pathInfo}");


            //routes.IgnoreRoute("odskills/{*pathInfo}", new { folder = "odskills" });

            //routes.MapRoute(
            //    name: "BlockedFolder",
            //    url: "odskills/{*pathInfo}",
            //    defaults: new { controller = "Student", action = "Index" }
            //);


            //Added on 31Jan2024

            ////   routes.MapRoute(
            ////    "Student",
            ////"{id}/Student/{action}",
            ////new { controller = "Student", action = "Index", id = UrlParameter.Optional });
           

            routes.MapRoute(
             name: "Default",
             url: "{controller}/{action}/{id}",
             defaults: new { controller = "Home", action = "LoadFirst", id = UrlParameter.Optional }
         );


            routes.MapRoute(
              name: "Student",
              url: "student/{action}/{id}",
              defaults: new { controller = "Student", action = "Index", id = UrlParameter.Optional }
          );

            //End


          

            routes.MapMvcAttributeRoutes();
        }
    }
}
