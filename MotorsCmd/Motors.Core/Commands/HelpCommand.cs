using Bytes2you.Validation;
using Motors.Core.Commands.Contracts;
using Motors.Core.Providers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motors.Core.Commands
{
    public class HelpCommand : ICommand
    {
        public string Execute()
        {
            var helpCommands = new List<string> {
                "currentuser - check currently logged user",
                "login - login with your credentials",
                "register - register an account",
                "listoffers - list offers by filtering",
                "details - more information about an offer by ID",
                "comment - comment an offer",
                "deleteoffer - delete offer by ID",
                "changepassword - change password of currently logged user",
                "logout - logoff with your user"
            };

            return string.Join("\n", helpCommands);
        }
    }
}
