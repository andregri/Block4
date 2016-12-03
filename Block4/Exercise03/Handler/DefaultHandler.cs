using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03.Handler
{
    class DefaultHandler : IHandler
    {
        public int Process(IContext context, string text)
        {
            int closingTagDelimeter = text.IndexOf('<');
            string value = text.Substring(0, text.Length - closingTagDelimeter);

            context.Push(value);

            return closingTagDelimeter;
        }
    }
}
