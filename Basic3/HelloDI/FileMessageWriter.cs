using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloDI
{
    public class FileMessageWriter : IMessageWriter
    {
        public void Write(string message)
        {
            string filename = "HelloDI.txt";
            string path = System.IO.Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            path = System.IO.Path.Combine(path, filename);
            filename = new Uri(path).LocalPath;
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(filename))
            {
                file.WriteLine(message);
            }
        }
    }
}
