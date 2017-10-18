using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Motors.Core.Providers.Contracts
{
    public interface IMemoryCacheProvider
    {
        MemoryCache MemoryCache { get;  }
    }
}
