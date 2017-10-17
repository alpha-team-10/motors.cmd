using Bytes2you.Validation;
using Motors.Core.Providers.Contracts;
using Motors.Core.Providers.Contracts.ConsoleInputProviders;
using Motors.Data;
using Motors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motors.Core.Providers.ConsoleInputProviders
{
    public class MotorcycleInputProvider : IMotorcycleInputProvider
    {
        private readonly IMotorSystemContext context;
        private readonly IWriter writer;
        private readonly IReader reader;

        public MotorcycleInputProvider(IMotorSystemContext context, IWriter writer, IReader reader)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            Guard.WhenArgument(writer, "writer").IsNull().Throw();
            Guard.WhenArgument(reader, "reader").IsNull().Throw();

            this.context = context;
            this.writer = writer;
            this.reader = reader;
        }

        public IList<string> CreateMotorcycleInput()
        {
            var input = new List<string>();

            var modelsAndManufacturers = this.context.Models
                .GroupBy(m => m.Manufacturer).ToList();

            this.writer.Write("Manufacturer: ");
            for (int i = 0; i < modelsAndManufacturers.Count; i++)
            {
                this.writer.Write($"{i}. {modelsAndManufacturers[i].Key.Name}");
            }
            int selectedManufacturer = int.Parse(this.reader.Read());

            this.writer.Write("Model: ");

            var modelsOption = modelsAndManufacturers[selectedManufacturer].ToList();
            for (int i = 0; i < modelsOption.Count; i++)
            {
                this.writer.Write($"{i}. {modelsOption[i].Name}");
            }
            int selectedModel = int.Parse(this.reader.Read());

            var manufId = modelsAndManufacturers[selectedManufacturer].Key.Id.ToString();
            var modelId = modelsOption[selectedModel].Id.ToString();

            this.writer.Write("Year: ");
            var year = this.reader.Read();

            this.writer.Write("Power: ");
            var power = this.reader.Read();

            this.writer.Write("Kms: ");
            var kms = this.reader.Read();

            input.AddRange(new string[] { manufId, modelId, year, power, kms });

            return input;
        }

        public IList<string> RemoveMotorcycleInput()
        {
            throw new NotImplementedException();
        }

        public IList<string> UpdateMotorcycleInput()
        {

            throw new NotImplementedException();
        }
    }
}
