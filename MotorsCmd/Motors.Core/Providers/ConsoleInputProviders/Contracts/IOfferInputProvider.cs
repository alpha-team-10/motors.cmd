using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motors.Core.Providers.ConsoleInputProviders.Contracts
{
    public interface IOfferInputProvider
    {
        IList<string> CreateOfferInput();
        IList<string> RemoveOfferInput();
        IList<string> UpdateOfferInput();
        IList<string> ListAllOffersInput();
        IList<string> DetailsOfferInput();
    }
}
