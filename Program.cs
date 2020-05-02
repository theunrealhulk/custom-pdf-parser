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
                DirectoryInfo directoryInfo = new DirectoryInfo("/media/usb/SSD/work/Cshap/pdf-simples");
                int i=0;
                var files = directoryInfo.GetFiles();
                while (i < files.Count())
                {
                    var f = files[i];
                    if (f.Extension==".pdf")
                    {
                        Dictionary<int, List<string>> output = new Dictionary<int, List<string>>();
                        output = DDPdftxt.ReadDDPdf(f.FullName);
                         
         
                    }
                    i++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }

    }
}
