using Motors.Core.Providers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;

namespace Motors.Core.Providers
{
    public class MemoryCacheProvider : IMemoryCacheProvider
    {
        public MemoryCacheProvider()
        {
            MemoryCache = new MemoryCache("memCache");
        }

        public MemoryCache MemoryCache { get; private set; }
    }
}
