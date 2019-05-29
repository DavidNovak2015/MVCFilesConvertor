using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCFilesConvertor.Models.Interfaces;
using System.IO;
using System.Text;

namespace MVCFilesConvertor.Models
{
    public class CSVtoXMLConvertor:ICSVtoXMLConvertor
    {
        private List<string> columnNames;
        private List<string> data;
        private string inputFilePath = "";

        // convert of CSV file to XML
        public string ReadFromCSVformat(HttpPostedFileBase fileInCSVformat)
        {
            bool fileCheck = CheckFileExtension(fileInCSVformat.FileName);

            if (!fileCheck)
                return "Chyba. Vstupní soubor není typu CSV";

            inputFilePath=WorkingWithInputAndOutputFiles.SaveInputFile(fileInCSVformat);

            if (inputFilePath.Contains("Chyba"))
                return inputFilePath;

            string result = GetDataFromCSVformat(ref columnNames, ref data);

            return "";
        }

        private string GetDataFromCSVformat(ref List<string> columnnames, ref List<string> data)
        {
            InitializeColumnNamesAndData();
            try
            {
                using (StreamReader reader = new StreamReader(inputFilePath, Encoding.Default))
                {

                }
            }
            catch (Exception ex)
            {

            }
            return "";
        }

        private void InitializeColumnNamesAndData()
        {
            if (columnNames == null)
                columnNames = new List<string>();

            if (data == null)
                data = new List<string>();

            columnNames.Clear(); data.Clear();
        }

        private bool CheckFileExtension(string fileNameIncludingExtension)
        {
            FileInfo fileInfo = new FileInfo(fileNameIncludingExtension);
            if (fileInfo.Extension == ".csv")
                return true;

            else
                return false;
        }
    }
}