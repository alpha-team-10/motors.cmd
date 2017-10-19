using Bytes2you.Validation;
using Motors.Core.Contracts;
using Motors.Core.Providers.Contracts;
using Motors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
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
        private readonly IMemoryCacheProvider memCache;

        private StringBuilder sb = new StringBuilder();

        public Engine(IWriter writer, IReader reader, ICommandProcessor processor, IMemoryCacheProvider memCache)
        {
            Guard.WhenArgument(writer, "writer").IsNull().Throw();
            Guard.WhenArgument(reader, "reader").IsNull().Throw();
            Guard.WhenArgument(processor, "processor").IsNull().Throw();
            Guard.WhenArgument(memCache, "memCache").IsNull().Throw();

            this.writer = writer;
            this.reader = reader;
            this.commandProcessor = processor;
            this.memCache = memCache;
        }

        public void Run()
        {
            this.memCache.MemoryCache["user"] = -1;
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
