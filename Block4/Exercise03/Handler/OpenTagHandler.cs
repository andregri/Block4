using System;
using Exercise03;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03.Handler
{
    public class OpenTagHandler : IHandler
    {
        public int Process(IContext context, string text)
        {
            TagContext tagContext = context as TagContext;
            if (tagContext == null)
            {
                throw new ArgumentException("TagHandler needs TagContext.");
            }

            int tagDelimiter = text.IndexOf('>');
            string[] tagElements = text.Substring(1, tagDelimiter - 1).Split(new char[] { '=', ' ' });

            Tag tag;
            if (tagElements.Length == 1)
            {
                tag = new Tag(tagElements[0]);
            }
            else
            {
                int len = tagElements[2].Length;
                int attrValue = int.Parse(tagElements[2].Substring(1, len - 2));
                tag = new Tag(tagElements[0], tagElements[1], attrValue);
            }

            tagContext.Push(tag);

            return tagDelimiter + 1;
        }
    }
}
