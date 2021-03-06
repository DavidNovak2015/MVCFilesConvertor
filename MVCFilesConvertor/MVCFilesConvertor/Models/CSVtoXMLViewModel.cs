﻿using System.ComponentModel.DataAnnotations;
using System.Web;
using MVCFilesConvertor.Models.Interfaces;

namespace MVCFilesConvertor.Models
{
    public class CSVtoXMLViewModel:ICSVtoXMLViewModel
    {
        // Autofac
        private  readonly ICSVtoXMLConvertor cSVtoXMLConvertor;

        // input file in csv format
        [Display(Name = "Vložte soubor ve formátu CSV")]
        [Required(ErrorMessage = "Vložení souboru ve formátu CSV je povinné")]
        public HttpPostedFileBase CSVfile { get; set; }

        public CSVtoXMLViewModel()
        {
            cSVtoXMLConvertor = new CSVtoXMLConvertor();
        }

        //Autofac
        public CSVtoXMLViewModel(ICSVtoXMLConvertor iCSVtoXMLConvertor)
        {
            cSVtoXMLConvertor = iCSVtoXMLConvertor;
        }
        
        // convert of CSV file to XML
        public string ConvertCSVtoXML(HttpPostedFileBase fileInCSVformat)
            {
            string outputFilePath = cSVtoXMLConvertor.ReadFromCSVformatAndSaveIntoXMLformat(fileInCSVformat);

            if (outputFilePath.Contains("Chyba"))
                return outputFilePath;

            return outputFilePath;
        }
    }
}