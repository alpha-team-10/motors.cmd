using Bytes2you.Validation;
using Motors.Core.Commands.Contracts;
using Motors.Core.Providers.ConsoleInputProviders.Contracts;
using Motors.Core.Providers.Contracts;
using Motors.Data;
using Motors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motors.Core.Commands.Other
{
    public class LoginUserCommand : ICommand
    {
        private readonly IUserInputProvider userInputProvider;
        private readonly IMotorSystemContext context;
        private readonly IHelperMethods helpers;
        private readonly IMemoryCacheProvider memCache;

        public LoginUserCommand(IUserInputProvider userInputProvider, IMotorSystemContext context,
            IHelperMethods helpers, IMemoryCacheProvider memCache)
        {
            Guard.WhenArgument(userInputProvider, "userInputProvider").IsNull().Throw();
            Guard.WhenArgument(context, "context").IsNull().Throw();
            Guard.WhenArgument(helpers, "helpers").IsNull().Throw();
            Guard.WhenArgument(memCache, "memCache").IsNull().Throw();

            this.userInputProvider = userInputProvider;
            this.context = context;
            this.helpers = helpers;
            this.memCache = memCache;
        }

        public string Execute()
        {
            var input = this.userInputProvider.LoginUserInput();
            var username = input[0];
            var password = input[1];
            User userFromDb;
            try
            {
                userFromDb = this.context.Users
                    .Single(u => u.Username == username);
            }
            catch
            {
                return $"no username: {username} exists";
            }

            var saltFromDb = userFromDb.Salt;
            var saltedPassword = this.helpers.GenerateSHA256Hash(password, saltFromDb);

            if(saltedPassword == userFromDb.Password)
            {
                this.memCache.MemoryCache["user"] = userFromDb.Id;
                return "Successfully logged";
            }
            else
            {
                return "Incorrect Password";
            }
        }
    }
}
