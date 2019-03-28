using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace mvcProject.common
{
    public class getJsonResult
    {
        public static string jsonResult()
        {
            return JsonConvert.SerializeObject(new { message = "" });
        }
        public static string jsonResult(string message)
        {
            return JsonConvert.SerializeObject(new { message = message });
        }
        public static string jsonResult(Object data)
        {
            return JsonConvert.SerializeObject(new { message = "", data = data });
        }
        public static string jsonResult(List<Object> List)
        {
            return JsonConvert.SerializeObject(new { message = "", data = List, count = List.Count });
        }
    }
}