using Motors.Core.Contracts;
using Motors.Core.Factories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motors.Core.Commands.Adding
{
    public class RegisterUserCommand
    {
        private readonly IUser user;
        private readonly ICommandFactory factory;

        public RegisterUserCommand(IUser user, ICommandFactory factory)
        {
            
        }



    }
}
