using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motors.Core.Contracts
{
    public interface IOffer : IMotorcycle, IUser
    {
        decimal Price { get; }

        DateTime StartDate { get; }

        DateTime ExpireDate { get; }

    }
}
