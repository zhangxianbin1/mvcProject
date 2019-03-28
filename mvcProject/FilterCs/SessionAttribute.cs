using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcProject.Models;

namespace mvcProject.FilterCs
{
    public class SessionAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContextBase context = filterContext.HttpContext;
            user userInfo = (user)context.Session["User"];
            if (userInfo == null)
            {
                context.Response.Redirect("/login/index");
            }
        }
    }
}