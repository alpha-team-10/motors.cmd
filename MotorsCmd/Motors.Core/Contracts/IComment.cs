﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motors.Core.Contracts
{
    public interface IComment
    {
        string Content { get; }

        string Author { get; }
    }
}
