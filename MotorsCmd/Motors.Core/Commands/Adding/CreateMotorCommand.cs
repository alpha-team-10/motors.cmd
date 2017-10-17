using Bytes2you.Validation;
using Motors.Core.Commands.Contracts;
using Motors.Core.Providers.Contracts;
using Motors.Core.Providers.Contracts.ConsoleInputProviders;
using Motors.Data;
using Motors.Models;
using System.Collections.Generic;
using System.Linq;

namespace Motors.Core.Commands.Adding
{
    public class CreateMotorCommand : ICommand
    {
        private readonly IMotorSystemContext context;
        //private readonly SOMEMODELFACTORY factory;
        private readonly IWriter writer;
        private readonly IMotorcycleInputProvider motorcycleInputProvider;

        public CreateMotorCommand(IMotorSystemContext context/*, SOMEMODELFACTORY factory*/, 
            IMotorcycleInputProvider motorcycleInputProvider)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            //Guard.WhenArgument(factory, "factory").IsNull().Throw();
            Guard.WhenArgument(motorcycleInputProvider, "motorcycleInputProvider").IsNull().Throw();

            this.context = context;
            //this.factory = factory;
            this.motorcycleInputProvider = motorcycleInputProvider;
        }

        public string Execute()
        {
            List<string> input = motorcycleInputProvider.CreateMotorcycleInput().ToList();
            // create the motor with input, add it ot database
            // var motor = modefactory.createMotor(input)
            // database.motors.add(motor);
            return "Motorcycle with ID" +/*{this.context.Motorcycle.Count-1}*/ "was created.";
        }
    }
}
