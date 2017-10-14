using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motors.Core.Providers
{
    public class ConsoleWriter
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
