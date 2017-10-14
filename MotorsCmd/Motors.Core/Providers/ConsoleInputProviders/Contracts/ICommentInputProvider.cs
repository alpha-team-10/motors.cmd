using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motors.Core.Providers.ConsoleInputProviders.Contracts
{
    public interface ICommentInputProvider
    {
        IList<string> CreateCommentInput();
        IList<string> UpdateCommentInput();
        IList<string> RemoveCommentInput();

    }
}
