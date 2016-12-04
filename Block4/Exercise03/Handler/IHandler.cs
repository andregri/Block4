using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03.Handler
{
    public interface IHandler
    {
        int Process(IContext context, string text);
    }

    public interface IContext
    {
        void Push(object input);
        object Pop();
    }
}
