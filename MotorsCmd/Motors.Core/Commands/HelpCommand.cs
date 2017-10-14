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
        private readonly IWriter writer;

        public HelpCommand(IWriter writer)
        {
            Guard.WhenArgument(writer, "writer").IsNull().Throw();

            this.writer = writer;
        }

        public void Execute(IList<string> parameters = null)
        {
            writer.Write("help text for later");
        }
    }
}
