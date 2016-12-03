using System;
using Exercise03;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handler
{
    class CloseTagHandler : IHandler
    {
        public int Process(IContext context, string text)
        {
            TagContext tagContext = context as TagContext;
            if (tagContext == null)
            {
                throw new ArgumentException("TagHandler needs TagContext.");
            }

            string tagName = text.Substring(2, text.Length - 2);
            tagContext.PopTag();

            return text.Length;
        }
    }
}
