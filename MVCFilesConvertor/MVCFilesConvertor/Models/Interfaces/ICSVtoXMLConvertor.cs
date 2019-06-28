using System.Web;

namespace MVCFilesConvertor.Models.Interfaces
{
    public interface ICSVtoXMLConvertor
    {
        // convert of CSV file to XML
        string ReadFromCSVformatAndSaveIntoXMLformat(HttpPostedFileBase fileInCSVformat);
    }
}
