using Bytes2you.Validation;
using Motors.Core.Contracts;
using Motors.Core.Providers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motors.Core
{
    public class Engine : IEngine
    {
        private const string TerminationCommand = "exit";

        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly ICommandProcessor commandProcessor;

        public Engine(IWriter writer, IReader reader, ICommandProcessor processor)
        {
            Guard.WhenArgument(writer, "writer").IsNull().Throw();
            Guard.WhenArgument(reader, "reader").IsNull().Throw();
            Guard.WhenArgument(processor, "processor").IsNull().Throw();

            this.writer = writer;
            this.reader = reader;
            this.commandProcessor = processor;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    var commandAsString = this.reader.Read();

                    if (commandAsString == TerminationCommand)
                    {
                        break;
                    }

                    string successMsg = commandProcessor.ProcessCommand(commandAsString);
                    this.writer.Write(successMsg);
                    
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    this.writer.Write("Invalid command parameters supplied or the entity with that ID for does not exist.");
                }
                catch (Exception ex)
                {
                    this.writer.Write(ex.Message);
                }
            }
        }
    }
}
