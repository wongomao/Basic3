using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakePython_PdfSplit
{
    class Program
    {
        static void Main(string[] args)
        {
            Program.BuildTempFile(args);
        }


        public static void BuildTempFile(string[] args)
        {
            // use the 2nd param since the 1st param is the name of the python script to run
            // and the 2nd is the name of the pdf file to split
            if (args.Count() < 2)
            {
                Console.WriteLine("Wrong number of parameters");
                return;
            }

            try
            {
                string filename = args[1];
                byte[] pdfBytes = File.ReadAllBytes(filename);
                string pdfTempFile = Path.GetTempFileName();
                using (FileStream fs = File.Open(pdfTempFile, FileMode.OpenOrCreate))
                {
                    fs.Write(pdfBytes, 0, pdfBytes.Count());
                }

                string manifestFile = Path.GetTempFileName();
                using (StreamWriter sw = new StreamWriter(manifestFile))
                {
                    sw.WriteLine(pdfTempFile);
                }
                Console.WriteLine(manifestFile);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
