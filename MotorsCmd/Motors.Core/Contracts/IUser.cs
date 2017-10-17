using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motors.Core.Contracts
{
    public interface IUser
    {
        string Username { get; }
    
        string Password { get; }

        string Mail { get; }

        string Salt { get; }
    }
}
