using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MVCFilesConvertor.Models
{
    public static class WorkingWithInputAndOutputFiles
    {
        private static string path = "";

        // create own directory in AppData, saving the inserted CSV file
        public static string SaveInputFile(HttpPostedFileBase inputFile)
        {
            //string path="";
            try
            {
                path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MVCFilesConvertor");
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
            }
            catch (Exception ex)
            {
                return $"Chyba. Nepodařilo se vytvořit složku na ceste:\n\n {path}\n\n Popis chyby:\n\n {ex.Message.ToString()}";
            }
            
            try
            {
                inputFile.SaveAs($"{path}\\{inputFile.FileName}");
                return $"{path}\\{inputFile.FileName}";
            }
            catch (Exception ex)
            {
                return $"Chyba. Nepodařilo se uložit soubor {inputFile.FileName} na cestě:\n\n {path}.\n\n Popis chyby: {ex.Message.ToString()}";
            }
        }

        //Get path for saving XML file
        public static string GetPathForXMLfile()
        {
            //string path = "";
            try
            {
                return path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MVCFilesConvertor\\DataXML.xml");
                
            }
            catch (Exception ex)
            {
                return $"Chyba. Nepodařilo se zjistit cestu k uložení dat ve formátu XML. \n\n Popis chyby:\n\n {ex.Message.ToString()}";
            }
        }

        // delete of saved files 
        public static string DeleteSavedFiles()
        {
            //string path = "";
            try
            {
                path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MVCFilesConvertor");
                if (Directory.Exists(path))
                {
                    Directory.Delete(path, true);
                    return $"Složka se všemi soubory byla z umístění:\n\n {path}\n\n odstraněna";
                }
                else
                    return $"Složka v umístění:\n\n {path}\n\n neexistuje";
            }
            catch (Exception ex)
            {
                return $"Nepodařilo se odstranit složku na umístění: \n\n {path}\n\n Ostraňte prosím složku ručně \n\n Popis chyby: \n\n {ex.Message.ToString()}";
            }
        }
    }
}