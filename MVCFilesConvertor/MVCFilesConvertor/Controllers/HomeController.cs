using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCFilesConvertor.Models;

namespace MVCFilesConvertor.Controllers
{
    // offer display 
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        // link display to output file
        public ActionResult GetOutputFile(string result)
        {
            if (result.Contains("Chyba"))
                TempData["Error"] = result;
            else
                TempData["OutputFilePath"] = result; 

            return View();
        }

        // delete of saved files
        public ActionResult DeleteSavedFiles()
        {
            TempData["Deletion"] = WorkingWithInputAndOutputFiles.DeleteSavedFiles();
            return RedirectToAction("Index", "Home");
        }
    }
}