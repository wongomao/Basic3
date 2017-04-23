using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloDI
{
    public class Salutation
    {
        private readonly IMessageWriter _writer;

        public Salutation(IMessageWriter writer)
        {
            if (writer == null)
                throw new ArgumentNullException("writer");
            this._writer = writer;
        }

        public void Exclaim()
        {
            this._writer.Write("Hello DI!");
        }
    }
}
