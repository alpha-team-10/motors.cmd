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
    public class LogoutUserCommand : ICommand
    {
        private readonly IMotorSystemContext context;
        private readonly IUserInputProvider userInputProvider;
        private readonly IMemoryCacheProvider memCache;

        public LogoutUserCommand(IMotorSystemContext context,IUserInputProvider userInputProvider ,IMemoryCacheProvider memCache)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            Guard.WhenArgument(userInputProvider, "userInputProvider").IsNull().Throw(); 
            Guard.WhenArgument(memCache, "memCache").IsNull().Throw();

            this.context = context;
            this.userInputProvider = userInputProvider;
            this.memCache = memCache;
        }

        public string Execute()
        {
            var input = this.userInputProvider.LogoutUserInput();
            bool quit = input[0] == "y";

            if (quit)
            {
                this.memCache.MemoryCache["user"] = new User();
                return "See you soon ...";
            }
            else
            {
                return $"Thanks for staying {((User)this.memCache.MemoryCache["user"]).Username}...";
            }
            
        }
    }
}
