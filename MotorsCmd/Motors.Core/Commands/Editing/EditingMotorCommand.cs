using Bytes2you.Validation;
using Motors.Core.Commands.Contracts;
using Motors.Core.Providers.Contracts.ConsoleInputProviders;
using Motors.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motors.Core.Commands.Editing
{
    public class EditingMotorCommand : ICommand
    {
        private readonly IMotorSystemContext motorSystemContext;
        private readonly IMotorcycleInputProvider motorcycleInputProvider;

        public EditingMotorCommand(IMotorSystemContext context, IMotorcycleInputProvider motorcycleInputProvider)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            Guard.WhenArgument(motorcycleInputProvider, "motorcycleInputProvider").IsNull().Throw();

            this.motorSystemContext = context;
            this.motorcycleInputProvider = motorcycleInputProvider;
        }

        public string Execute()
        {
            var input = this.motorcycleInputProvider.UpdateMotorcycleInput();
            var motorToEditId = input[0];

            return $"Offer with ID: {motorToEditId} was edited";
        }
    }
}
