using mvcProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using mvcProject.common;

namespace mvcProject.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public string checkLogin()
        {
            string resultStr = "";
            try
            {
                string userid = Request["userid"].ToString();
                string password = Request["password"].ToString();
                test1Entities test = new test1Entities();
                user userInfo = test.user.Where(a => a.USERID == userid && a.PASSWORD == password).SingleOrDefault();
                if (userInfo != null)
                {
                    if (userInfo.ISVALID != 1)
                    {
                        resultStr = "用户已无效";
                    }
                    else
                    {
                        Session["User"] = userInfo;
                    }
                }
                else
                {
                    resultStr = "用户不存在";
                }
            }
            catch(Exception ex)
            {
                return getJsonResult.jsonResult(ex.Message); ;
            }
            return getJsonResult.jsonResult(resultStr);
        }
    }
}