﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motors.Core.Providers.Contracts.ConsoleInputProviders
{
    public interface IMotorcycleInputProvider
    {
        IList<string> CreateMotorcycleInput();
        IList<string> UpdateMotorcycleInput();
        IList<string> RemoveMotorcycleInput();
    }
}
