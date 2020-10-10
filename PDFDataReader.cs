using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Pdfparser
{
        public static class PDFDataReader
    {   
        /// <summary>
        /// Get Dictionary (pageNumber,Page text as list of lines)
        /// </summary>
        /// <param name="path"> path to the pdf file</param>
        /// <returns>dictionary for all txt in pdf as string list by pdf page</returns>
        public static Dictionary<int, List<string>> ReadDDPdf(string path)
        {
            PdfReader reader = new PdfReader(path);
            Dictionary<int, List<string>> output = new Dictionary<int, List<string>>();
            //getting text from pdg page by page
            for (int i = 0; i < reader.NumberOfPages; i++)
            {
                output.Add(i + 1, (PdfTextExtractor.GetTextFromPage(reader, i + 1).Replace("\n", "|").Split('|').ToList()));
            }
            return output;
        }
        
        
        /// <summary>
        /// Get list of JsonPropData (propname,pattern, page number in the target pdf)
        /// </summary>
        /// <param name="data_template_path"> path to the json file</param>
        public static List<JsonPropData> LoadDataTemplate(string data_template_path)
        {
             List<JsonPropData> porpsList = new List<JsonPropData>() ;
            try
            {
                //read the template json file
                using (StreamReader r = new StreamReader(data_template_path))
                {
                    string json = r.ReadToEnd();
                    dynamic porps = JsonConvert.DeserializeObject(json);
                    //create JsonPropData object
                    foreach (var prop in porps)
                    {
                        JsonPropData jprop = new JsonPropData();
                        jprop.name = prop.name;
                        jprop.regex_pattern = prop.patterns.ToObject(typeof(List<string>));
                        jprop.page_number = prop.page;

                        porpsList.Add(jprop);
                    }
                    
                    //for each object parse
                }
               
            }
            catch(Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

       
            /* prop name , pattern, page number*/
            //save the data prop object

            return porpsList;
        }

        public static void LoadJson(string data_template_path)
        {
            using (StreamReader r = new StreamReader(data_template_path))
            {
                string json = r.ReadToEnd();
                
            }
        }
    }
}
