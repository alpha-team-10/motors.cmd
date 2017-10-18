using Bytes2you.Validation;
using Motors.Core.Commands.Contracts;
using Motors.Core.Factories.Contracts;
using Motors.Core.Providers.ConsoleInputProviders;
using Motors.Core.Providers.ConsoleInputProviders.Contracts;
using Motors.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motors.Core.Commands.Adding
{
    public class CreateUserCommand : ICommand
    {
        private readonly IMotorSystemContext context;
        private readonly IUserInputProvider user;
        private readonly IModelFactory userModel;

        public CreateUserCommand(IMotorSystemContext context, IUserInputProvider user, IModelFactory userModel)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            Guard.WhenArgument(user, "user").IsNull().Throw();
            Guard.WhenArgument(userModel, "userModel").IsNull().Throw();

            this.context = context;
            this.user = user;
            this.userModel = userModel;
        }

        public string Execute()
        {
            var userInput = this.user.RegisterUserInput();


            var username = userInput[0];
            var password = userInput[1];
            var mail = userInput[2];

            var user = userModel.CreateUser(userInput[0], userInput[1], userInput[2], "fefsergfdwesrgd");

            context.Users.Add(user);
            context.SaveChanges();

            return $"User with username {username} was created!";
        }
    }
}
