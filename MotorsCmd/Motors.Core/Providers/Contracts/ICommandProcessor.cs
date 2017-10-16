using System;

namespace Motors.Core.Providers.Contracts
{
    public interface ICommandProcessor
    { 
        string ProcessCommand(string commandAsString);
    }
}
