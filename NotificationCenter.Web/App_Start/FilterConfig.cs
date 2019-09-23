using System.Web;
using System.Web.Mvc;
using NotificationCenter.Web.Filters;

namespace NotificationCenter.Web.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new NotificationCenterAuthorizeAttribute());
            filters.Add(new HandleErrorAttribute());
            filters.Add(new RequireHttpsAttribute());
        }
    }
}
