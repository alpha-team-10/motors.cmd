using Bytes2you.Validation;
using Motors.Core.Commands.Contracts;
using Motors.Core.Providers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motors.Core.Commands
{
    public class HelpCommand : ICommand
    {
        public string Execute()
        {
           return "help text for later";
        }
    }
}
