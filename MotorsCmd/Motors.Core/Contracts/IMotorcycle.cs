using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motors.Core.Contracts
{
    public interface IMotorcycle : IModel
    {
        int Power { get; }

        int Category { get; }

        DateTime ProductionDate { get; }

        decimal Kms { get; }
       
    }
}
