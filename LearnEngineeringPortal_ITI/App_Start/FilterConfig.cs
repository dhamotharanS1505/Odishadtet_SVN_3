using System.Web;
using System.Web.Mvc;
using Odishadtet.Models;

namespace TNDET 
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new SessionTrack(),1);
            filters.Add(new HandleErrorAttribute(),2);

        }
    }
}
