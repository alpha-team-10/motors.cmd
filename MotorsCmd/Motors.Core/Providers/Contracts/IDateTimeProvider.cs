﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motors.Core.Providers.Contracts
{
    public interface IDateTimeProvider
    {
        DateTime GetDate();
    }
}
