using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Odishadtet.Models
{
    public class CustomeAPIAuthorization : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var session = HttpContext.Current.Session;
            if (session != null)
            {
                
            }
                object data = "";
            if (actionContext.ActionArguments.TryGetValue("data", out data))
            {
                data = data + "Injected!";
                actionContext.ActionArguments["data"] = data;
            }
            // pre-processing
            Debug.WriteLine("ACTION 1 DEBUG pre-processing logging");
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var objectContent = actionExecutedContext.Response.Content as ObjectContent;
            if (objectContent != null)
            {
                var type = objectContent.ObjectType; //type of the returned object
                var value = objectContent.Value; //holding the returned value
            }

            Debug.WriteLine("ACTION 1 DEBUG  OnActionExecuted Response " + actionExecutedContext.Response.StatusCode.ToString());
        }
    }
}