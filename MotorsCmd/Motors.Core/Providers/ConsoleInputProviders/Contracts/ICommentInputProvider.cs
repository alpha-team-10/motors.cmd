using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motors.Core.Providers.ConsoleInputProviders.Contracts
{
    public interface ICommentInputProvider
    {
        IList<string> CreateComment();
        IList<string> UpdateComment();
        IList<string> RemoveComment();

    }
}
