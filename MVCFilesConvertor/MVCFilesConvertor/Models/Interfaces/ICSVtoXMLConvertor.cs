using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MVCFilesConvertor.Models.Interfaces
{
    public interface ICSVtoXMLConvertor
    {
        // convert of CSV file to XML
        string ReadFromCSVformatAndSaveIntoXMLformat(HttpPostedFileBase fileInCSVformat);
    }
}
