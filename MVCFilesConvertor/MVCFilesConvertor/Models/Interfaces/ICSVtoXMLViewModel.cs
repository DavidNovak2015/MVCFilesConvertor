using System.Web;

namespace MVCFilesConvertor.Models.Interfaces
{
    public interface ICSVtoXMLViewModel
    {
        // convert of CSV file to XML
        string ConvertCSVtoXML(HttpPostedFileBase fileInCSVformat);
    }
}
