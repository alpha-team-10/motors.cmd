using Bytes2you.Validation;
using Motors.Core.Commands.Contracts;
using Motors.Core.Providers.Contracts;
using Motors.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motors.Core.Commands.Other
{
    public class CurrentUserCommand : ICommand
    {
        private readonly IMotorSystemContext context;
        private readonly IMemoryCacheProvider cache;

        public CurrentUserCommand(IMemoryCacheProvider cache, IMotorSystemContext contex)
        {
            Guard.WhenArgument(cache, "cache").IsNull().Throw();
            Guard.WhenArgument(contex, "context").IsNull().Throw();

            this.context = contex;
            this.cache = cache;
        }

        public string Execute()
        {
            int currentUserId = int.Parse(this.cache.MemoryCache["user"].ToString());
            if (currentUserId > 0)
            {
                var username = this.context.Users.Find(currentUserId).Username;
                return $"You are currently logged with -> {username}";
            }
            else
            {
                return "no user logged";
            }

        }
    }
}
