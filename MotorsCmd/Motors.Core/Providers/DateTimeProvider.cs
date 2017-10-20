using Motors.Core.Providers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motors.Core.Providers
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime GetDate()
        {
            return DateTime.Now;
        }
    }
}
