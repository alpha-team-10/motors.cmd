using Motors.Core.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motors.Core.Commands.Abstractions
{
    public class Command : ICommand
    {
        public Command()
        {

        }


        public void Execute(IList<string> parameters)
        {
            throw new NotImplementedException();
        }
    }
}
