using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motors.Core.Providers.Contracts
{
    public interface IHelperMethods
    {
        string GenerateSHA256Hash(string input, string salt);

    }
}
