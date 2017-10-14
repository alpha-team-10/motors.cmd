using Motors.Core.Commands.Contracts;

namespace Motors.Core.Factories.Contracts
{
    public interface ICommandFactory
    {
        ICommand CreateCommand(string name);
    }
}
