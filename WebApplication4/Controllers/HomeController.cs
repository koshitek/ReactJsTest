using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace WebApplication4.Controllers
{
    public class GiftangoProviderException //: Exception
    {
        public int Code { get; set; }
        public string RequestId { get; set; }
        public Dictionary<string, List<string>> ValidationErrors { get; set; }
        public string Message { get; set; }
        //private string ErrorMessage { get; set; }
        //public GiftangoProviderException(SerializationInfo info, StreamingContext context)
        //{
        //    if (info != null)
        //        ErrorMessage = "";
        //}
        public override string ToString()
        {
            var validDationErrorString = new StringBuilder();
            if (Message.Contains("Validation errors occurred"))
            {
                foreach (var error in ValidationErrors)
                {
                    validDationErrorString.Append(error.Key + ": ");
                    foreach (var value in error.Value)
                    {
                        validDationErrorString.Append(value);
                    }
                }
                return validDationErrorString.ToString();
            }
            return Message;
        }
    }

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            dynamic testJson =
                JsonConvert.DeserializeObject(
                   "{\"Message\":\"Validation errors occurred.\",\"Code\":3,\"RequestId\":\"8074ebad-71df-4857-9764-deaeebd2cfae\",\"ValidationErrors\":{\"Payment\":[\"The field is invalid.\"],\"StreetAddress1\":[\"The field StreetAddress1 must be a string with a minimum length of 4 and a maximum length of 255.\"]}}"
                    , typeof(GiftangoProviderException));
            var output = testJson.ToString();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}