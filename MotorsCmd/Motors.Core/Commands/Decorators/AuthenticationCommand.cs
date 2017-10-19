using Bytes2you.Validation;
using Motors.Core.Commands.Contracts;
using Motors.Core.Providers.Contracts;
using Motors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motors.Core.Commands.Decorators
{
    public class AuthenticationCommand : ICommand
    {
        private readonly ICommand command;
        private readonly IMemoryCacheProvider cache;

        public AuthenticationCommand(ICommand command, IMemoryCacheProvider memCache)
        {
            Guard.WhenArgument(command, "command").IsNull().Throw();
            Guard.WhenArgument(memCache, "memCache").IsNull().Throw();

            this.command = command;
            this.cache = memCache;
        }

        public string Execute()
        {
            if(int.Parse(this.cache.MemoryCache["user"].ToString()) < 0)
            {
                return "Please login";
            }
            else
            {
                string successMsg = this.command.Execute();
                return successMsg;
            }
        }
    }
}
