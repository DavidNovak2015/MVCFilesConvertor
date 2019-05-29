using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCFilesConvertor.Models;
using MVCFilesConvertor.Models.Interfaces;
using System.IO;

namespace MVCFilesConvertor.Controllers
{
    public class CSVtoXMLController : Controller
    {
        //Autofac
        private readonly ICSVtoXMLViewModel cSVtoXMLViewModel;

        //Autofac
        public CSVtoXMLController(ICSVtoXMLViewModel iCSVtoXMLViewModel)
        {
            cSVtoXMLViewModel = iCSVtoXMLViewModel;
        }

        // form view for input file
        public ActionResult CSVtoXML()
        {
            return View(cSVtoXMLViewModel);
        }

        // convert of CSV file to XML
        [HttpPost]
        public ActionResult CSVtoXML(CSVtoXMLViewModel cSVtoXMLViewModel)
        {
            if (!ModelState.IsValid)
                return View(cSVtoXMLViewModel);

            TempData["Message"] = cSVtoXMLViewModel.ConvertCSVtoXML(cSVtoXMLViewModel.CSVfile);

            return View();
        }
    }
}