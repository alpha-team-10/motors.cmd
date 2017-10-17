using Bytes2you.Validation;
using Motors.Core.Commands.Contracts;
using Motors.Core.Providers.Contracts;
using Motors.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motors.Core.Commands.Listing
{
    public class ListOffersCommand : ICommand
    {
        private readonly IWriter writer;
        private readonly IMotorSystemContext context;

        public ListOffersCommand(IWriter writer, IMotorSystemContext context)
        {
            Guard.WhenArgument(writer, "writer").IsNull().Throw();
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.writer = writer;
            this.context = context;
        }

        public string Execute()
        {
            // get all offers with min details
            // collect or return result

            return "nqkvi oferti";
        }
    }
}
