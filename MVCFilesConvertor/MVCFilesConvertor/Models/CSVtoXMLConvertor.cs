using System;
using System.Collections.Generic;
using System.Web;
using MVCFilesConvertor.Models.Interfaces;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace MVCFilesConvertor.Models
{
    public class CSVtoXMLConvertor:ICSVtoXMLConvertor
    {
        private List<string> columnNames;
        private List<string> data;
        private string inputFilePath = "";
        private string outputFilePath = "";

        // check of file extension, save the file, load data from CSV file
        public string ReadFromCSVformatAndSaveIntoXMLformat(HttpPostedFileBase fileInCSVformat)
        {
            bool fileCheck = CheckFileExtension(fileInCSVformat.FileName);

            if (!fileCheck)
                return "Chyba. Vstupní soubor není typu CSV";

            inputFilePath=WorkingWithInputAndOutputFiles.SaveInputFile(fileInCSVformat);

            if (inputFilePath.Contains("Chyba"))
                return inputFilePath;

            string result = GetDataFromCSVformat(ref columnNames, ref data);

            if (result.Contains("Chyba"))
                return result;

            outputFilePath = SaveIntoXMLformat();

            if (outputFilePath.Contains("Chyba"))
                return outputFilePath;

            return outputFilePath;
        }

        // File extension control
        private bool CheckFileExtension(string fileNameIncludingExtension)
        {
            FileInfo fileInfo = new FileInfo(fileNameIncludingExtension);
            if (fileInfo.Extension == ".csv")
                return true;

            else
                return false;
        }

        // Add objects into references of both collections 
        private void InitializeColumnNamesAndData()
        {
            if (columnNames == null)
                columnNames = new List<string>();

            if (data == null)
                data = new List<string>();

            columnNames.Clear(); data.Clear();
        }

        // load data from inserted CSV file and insert to two collections
        private string GetDataFromCSVformat(ref List<string> columnnames, ref List<string> data)
        {
            InitializeColumnNamesAndData();
            try
            {
                using (StreamReader reader = new StreamReader(inputFilePath, Encoding.Default))
                {
                    string dataReader = "";
                    int rownumber = 1;
                    while ( (dataReader=reader.ReadLine() ) != null)
                    {
                        string[] values = dataReader.Split(';');
                        if (rownumber == 1)
                        {
                            foreach (string columnName in values)
                            {
                                columnnames.Add(columnName);
                            }
                        }
                        else
                        {
                            foreach (string dataRow in values)
                            {
                                data.Add(dataRow);
                            }
                        }
                        rownumber ++;
                     }
                }
                return "OK";
            }
            catch (Exception ex)
            {
                return $"Chyba. Nepodařilo se načíst data z tohoto souboru:\n\n {inputFilePath}\n\n Popis chyby:\n\n {ex.Message.ToString()}";
            }
        }

        // save loaded data into XML file
        private string SaveIntoXMLformat()
        {
            outputFilePath = WorkingWithInputAndOutputFiles.GetPathForXMLfile();

            if (outputFilePath.Contains("Chyba"))
                return outputFilePath;

            try
            {
                XDocument document = new XDocument(new XDeclaration("1.1", "utf-8", null), new XElement("Data"));
                int columnIndex = 0;
                int columnNamesCount = columnNames.Count;

                foreach (string value in data)
                {
                    document.Element("Data").Add(new XElement("DataRow", new XElement(columnNames[columnIndex], value)
                                                             )
                                                );

                    if (columnIndex+1 == columnNamesCount)
                        columnIndex = 0;

                    else
                        columnIndex++;
                }
                document.Save(outputFilePath);

                return outputFilePath;

            }
            catch (Exception ex)
            {
                return $"Chyba. Uložení dat do XML souboru se nepodařilo. Popis chyby: \n\n {ex.Message.ToString()}";
            }
        }
    }
}