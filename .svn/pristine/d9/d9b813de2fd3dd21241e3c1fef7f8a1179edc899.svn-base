using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Odishadtet.DAL;
using Odishadtet.General;

namespace Odishadtet.Models
{
    public class SessionTrack: AuthorizeAttribute
    {

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            StudentService sm = new StudentService();

            // In a user control or page
            string sessionId = System.Web.HttpContext.Current.Session.SessionID;
            Log.WriteLogMessage("Home", "Session", "CheckAlreadyLogined", sessionId, "error");
            HttpContext ctx = HttpContext.Current;
            if (HttpContext.Current.Session["loginUserID"] == null)
            {
                sm.UserSessionDetails(sessionId, 0, filterContext.HttpContext.Request.Url.AbsolutePath);
            }
            else
            {
                sm.UserSessionDetails(sessionId, Convert.ToInt64(HttpContext.Current.Session["loginUserID"].ToString()), filterContext.HttpContext.Request.Url.AbsolutePath);
            }
        }
    }
}