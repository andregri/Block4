using System;
using Exercise03;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03.Handler
{
    public class CloseTagHandler : IHandler
    {
        public int Process(IContext context, string text)
        {
            TagContext tagContext = context as TagContext;
            if (tagContext == null)
            {
                throw new ArgumentException("TagHandler needs TagContext.");
            }

            string tagName = text.Substring(2, text.IndexOf('>') - 2);
            Tag tag;
            try
            {
                tag = (Tag)tagContext.Pop();
            }
            catch (InvalidOperationException e)
            {
                throw new MissingOpeningTagException(tagName, e);
            }

            if (tag.Name != tagName)
            {
                throw new MissingClosingTagException(tagName);
            }

            return text.Length;
        }
    }
}
