using Bytes2you.Validation;
using Motors.Core.Commands.Contracts;
using Motors.Core.Providers.Contracts;
using Motors.Data;
using System.Collections.Generic;

namespace Motors.Core.Commands.Adding
{
    public class CreateMotorCommand : ICommand
    {
        private readonly IMotorSystemContext context;
        //private readonly ICommandFactory factory;
        private readonly IWriter writer;

        public CreateMotorCommand(IMotorSystemContext context/*, ICommandFactory factory*/, IWriter writer)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            //Guard.WhenArgument(factory, "factory").IsNull().Throw();
            Guard.WhenArgument(writer, "writer").IsNull().Throw();

            this.context = context;
            //this.factory = factory;
            this.writer = writer;
        }

        public void Execute(IList<string> parameters)
        {
            writer.Write("Motorcycle with ID" +/*{this.context.Motorcycle.Count-1}*/ "was created.");
        }
    }
}
