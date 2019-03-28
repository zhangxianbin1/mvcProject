using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcProject.Models;
using mvcProject.FilterCs;
using Newtonsoft.Json;
using mvcProject.common;

namespace mvcProject.Controllers
{
    [Session]
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult UserInfo(int id = 0)
        {
            test1Entities test = new test1Entities();
            user userinfo = new user();
            if (id != 0)
            {
                userinfo = test.user.Where(a => a.ID == id).SingleOrDefault();
            }
            return View(userinfo);
        }
        [HttpPost]
        public string UserInfo(user model)
        {
            try
            {
                test1Entities test = new test1Entities();
                user userinfo = test.user.Where(a => a.ID == model.ID).SingleOrDefault();

                if (userinfo == null)
                {
                    userinfo = new user();
                }
                userinfo.USERID = model.USERID;
                userinfo.PASSWORD = model.PASSWORD;
                if (model.ID == 0)
                {
                    userinfo.ISVALID = 1;
                    test.user.Add(userinfo);
                }
                test.SaveChanges();
            }
            catch (Exception ex)
            {
                return getJsonResult.jsonResult(ex.Message);
            }
            return getJsonResult.jsonResult();
        }
        public string deleteUser(int id)
        {
            try {
                test1Entities test = new test1Entities();
                user userinfo = test.user.Where(a => a.ID == id).SingleOrDefault();
                if (userinfo != null)
                {
                    userinfo.ISVALID = 0;
                }
                test.SaveChanges();
            }
            catch (Exception ex)
            {
                return getJsonResult.jsonResult(ex.Message);
            }
            return getJsonResult.jsonResult();
        }
        public string getUserList(int pageIndex = 0, int pageSize = 10)
        {
            List<user> userList=new List<user> ();
            int count = 0;
            try {
                test1Entities test = new test1Entities();
                userList = test.user.OrderBy(a => a.ID).ToList();
                count = userList.Count;
                userList = userList.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            }
            catch (Exception ex)
            {
                return getJsonResult.jsonResult(ex.Message);
            }
            return JsonConvert.SerializeObject(new { message = "", data = userList, count = count });
        }
    }
}