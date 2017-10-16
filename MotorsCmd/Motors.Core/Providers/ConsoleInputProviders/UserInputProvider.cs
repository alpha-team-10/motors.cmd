using Motors.Core.Contracts;
using Motors.Core.Providers.ConsoleInputProviders.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motors.Core.Providers.ConsoleInputProviders
{
    public class UserInputProvider : IUserInputProvider
    {

        private IList<IUser> users;

        public IList<string> LoginUserInput()
        {
            throw new NotImplementedException();
        }

        public IList<string> RegisterUserInput()
        {
            throw new NotImplementedException();
        }
    }
}
