using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MVCFilesConvertor.Models
{
    public static class WorkingWithInputAndOutputFiles
    {
        public static string SaveInputFile(HttpPostedFileBase inputFile)
        {
            string path="";
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
    }
}