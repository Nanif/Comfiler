using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace SITE.Filters
{
    public class AoutoFilter: AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            // if (filterContext.HttpContext.Session["UserName"]==null)
            if (false)
            {
                //filterContext.Result = new RedirectResult("/Account/Login");
            }
        }
    }
}