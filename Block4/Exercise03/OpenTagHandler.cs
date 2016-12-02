﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03
{
    public class OpenTagHandler : IHandler
    {
        public string Process(IContext context, string text)
        {
            TagContext tagContext = context as TagContext;
            if (tagContext == null)
            {
                return null;
            }

            int tagDelimiter = text.IndexOf('>');
            string[] tagElements = text.Substring(1, tagDelimiter).Split(new char[] { '=', ' ' });

            Tag tag;
            if (tagElements.Length == 1)
            {
                tag = new Tag(tagElements[0]);
            }
            else
            {
                int len = tagElements[2].Length;
                int attrValue = int.Parse(tagElements[2].Substring(0, len - 2));
                tag = new Tag(tagElements[0], tagElements[1], attrValue);
            }

            tagContext.PushTag(tag);

            return text.Substring(tagDelimiter + 1);
        }
    }
}
