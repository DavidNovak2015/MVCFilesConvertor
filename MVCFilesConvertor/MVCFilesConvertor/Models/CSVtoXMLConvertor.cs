using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCFilesConvertor.Models.Interfaces;

namespace MVCFilesConvertor.Models
{
    public class CSVtoXMLConvertor:ICSVtoXMLConvertor
    {
        // convert of CSV file to XML
        public string ConvertCSVtoXML(HttpPostedFileBase fileInCSVformat)
        {
            return "";
        }
    }
}