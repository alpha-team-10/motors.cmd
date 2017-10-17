using Motors.Core.Commands.Contracts;
using Motors.Core.Contracts;
using Motors.Core.Factories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Motors.Core.Commands.Adding
{
    public class RegisterUserCommand : ICommand
    {
        private readonly IUser user;
        private readonly ICommandFactory factory;

        public RegisterUserCommand(IUser user, ICommandFactory factory)
        {
            
        }

        public void Execute(IList<string> parameters)
        {
            throw new NotImplementedException();
        }
    }
}
