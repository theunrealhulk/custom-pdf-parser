using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pdfparser
{
    ///
    public static class PDFDataExtracter
    {   
        /// <summary>
        /// Get Dictionary (pageNumber,Page text as list of lines)
        /// </summary>
        /// <param name="path"> path to the pdf file</param>
        /// <returns></returns>
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
    }
}
