using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace Pdfparser
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo("/media/jc/SSD/work/Cshap/pdf-simples");
                int i=0;
                var files = directoryInfo.GetFiles();
                 Dictionary<int, List<string>> output = new Dictionary<int, List<string>>();
                 //looping throught all files 
                while (i < files.Count())
                {
                    var f = files[i];
                    if (f.Extension==".pdf")
                    {
                        output = PDFDataReader.ReadDDPdf(f.FullName);// get a pdf content in the directory
                        /*
                        Debugging the output
                        -log the current parsed pdf in the console
                        */
                        var props = PDFDataReader.LoadDataTemplate("/media/jc/SSD/work/Cshap/custom-pdf-parser/data-template.json");
                        //extract data from pdf using data template

                        /*
                         Debugging the output
                        -log the loaded props names 
                        -log the prorps that got match in the current pdf
                        */

                        //store the extracted data 
                        
                    }
                    i++;
                }
                //outpout the extracted data (json,csv,xlsx)
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }

    }
}
