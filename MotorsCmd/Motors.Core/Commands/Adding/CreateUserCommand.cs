using Bytes2you.Validation;
using Motors.Core.Commands.Contracts;
using Motors.Core.Factories.Contracts;
using Motors.Core.Providers;
using Motors.Core.Providers.ConsoleInputProviders;
using Motors.Core.Providers.ConsoleInputProviders.Contracts;
using Motors.Core.Providers.Contracts;
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
        private readonly IMemoryCacheProvider memCache;
        private readonly IHelperMethods helpers;

        public CreateUserCommand(IMotorSystemContext context, IUserInputProvider user, IModelFactory userModel,
            IMemoryCacheProvider memCache, IHelperMethods helpers)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            Guard.WhenArgument(user, "user").IsNull().Throw();
            Guard.WhenArgument(userModel, "userModel").IsNull().Throw();
            Guard.WhenArgument(memCache, "memCache").IsNull().Throw();
            Guard.WhenArgument(helpers, "helpers").IsNull().Throw();

            this.context = context;
            this.user = user;
            this.userModel = userModel;
            this.memCache = memCache;
            this.helpers = helpers;
        }

        public string Execute()
        {
            var userInput = this.user.RegisterUserInput();

            var username = userInput[0];
            var password = userInput[1];
            var mail = userInput[2];

            var salt = Guid.NewGuid().ToString();
            string saltedPass = this.helpers.GenerateSHA256Hash(password, salt);

            var user = userModel.CreateUser(username, saltedPass, mail, salt);

            context.Users.Add(user);

            context.SaveChanges();
            this.memCache.MemoryCache["user"] = user.Id;

            context.SaveChanges();

            return $"User with username {username} was created!";
        }
    }
}
