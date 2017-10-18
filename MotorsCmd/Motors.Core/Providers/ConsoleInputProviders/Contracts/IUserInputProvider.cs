using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motors.Core.Providers.ConsoleInputProviders.Contracts
{
    public interface IUserInputProvider
    {
        IList<string> RegisterUserInput();
        IList<string> LoginUserInput();
        IList<string> LogoutUserInput();
    }
}
