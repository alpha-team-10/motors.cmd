﻿using Motors.Core.Commands.Contracts;
using Motors.Core.Factories.Contracts;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motors.Core.Factories
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IKernel kernel;

        public CommandFactory(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public ICommand CreateCommand(string commandName)
        {
            return this.kernel.Get<ICommand>(commandName);
        }
    }
}
