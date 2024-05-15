
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETUDDO.Areas.Admin.Filters
{
    public class AdminUserSecurityAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session.GetString("YoneticiRol") == null)
            {
                filterContext.HttpContext.Response.Redirect("Hata");
            }
            //else {
            //    filterContext.HttpContext.Response.Redirect("Anasayfa");
            //}
            base.OnActionExecuting(filterContext);
        }

       
    }
}
