using System.Web;
using System.Web.Mvc;

namespace NuevoFormatoDiscrepancias
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
