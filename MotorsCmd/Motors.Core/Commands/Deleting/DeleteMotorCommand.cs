using Bytes2you.Validation;
using Motors.Core.Commands.Contracts;
using Motors.Core.Providers.Contracts.ConsoleInputProviders;
using Motors.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motors.Core.Commands.Deleting
{
    public class DeleteMotorCommand : ICommand
    {
        private readonly IMotorSystemContext motorSystemContext;
        private readonly IMotorcycleInputProvider motorInputProvider;

        public DeleteMotorCommand(IMotorSystemContext context, IMotorcycleInputProvider motorInputProvider)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            Guard.WhenArgument(motorInputProvider, "motorInputProvider").IsNull().Throw();

            this.motorSystemContext = context;
            this.motorInputProvider = motorInputProvider;
        }

        public string Execute()
        {
            var input = this.motorInputProvider.RemoveMotorcycleInput();
            var motorToDeleteId = input[0];
            // find and delete offer with such id

            return $"Offer with {motorToDeleteId} was deleted!";
        }
    }
}
