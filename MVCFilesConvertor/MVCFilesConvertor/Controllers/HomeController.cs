using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFilesConvertor.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetOutputFile(string result)
        {
            if (result.Contains("Chyba"))
                TempData["Error"] = result;
            else
                TempData["OutputFilePath"] = result;

            return View();
        }
    }
}