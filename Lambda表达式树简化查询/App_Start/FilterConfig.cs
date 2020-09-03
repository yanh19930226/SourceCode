using System.Web;
using System.Web.Mvc;

namespace Lambda表达式树简化查询
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}