﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MVCFilesConvertor.Models.Interfaces
{
    public interface ICSVtoXMLViewModel
    {
        // convert of CSV file to XML
        string ConvertCSVtoXML(HttpPostedFileBase fileInCSVformat);
    }
}
