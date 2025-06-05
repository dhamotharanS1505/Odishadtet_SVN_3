using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Odishadtet.Models
{
    /// <summary>
    ///  CustomAuthorization
    /// </summary>
    public class CustomAuthorization : AuthorizeAttribute
    {

        /// public void OnAuthorization
        public override void OnAuthorization(AuthorizationContext filterContext)
        {

            HttpContext ctx = HttpContext.Current;
            if (HttpContext.Current.Session["loginUserID"] == null)
            {
                filterContext.Result = new RedirectResult("~/Home/Index");
                return;
            }

        }
       
    }
}