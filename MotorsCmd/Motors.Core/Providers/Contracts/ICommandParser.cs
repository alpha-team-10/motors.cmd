using Motors.Core.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motors.Core.Providers.Contracts
{
    public interface ICommandParser
    {
        ICommand ParseCommand(string fullCommand);
    }
}
