using System;
using Handler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03
{
    public class Tag
    {
        public string Name
        {
            get; set;
        }
        public string Attribute
        {
            get; set;
        }
        public int Value
        {
            get; set;
        }

        public Tag(string name, string attribute, int value)
        {
            this.Name = name;
            this.Attribute = attribute;
            this.Value = value;
        }

        public Tag(string name) : this(name, null, 0) { }
    }

    public class TagContext : IContext
    {
        private static Stack<Tag> tagStack;

        public int Depth
        {
            get
            {
                return tagStack.Count;
            }
        }

        public void PushTag(Tag tag)
        {
            if (tag != null)
            {
                tagStack.Push(tag);
            }
        }

        public Tag PopTag()
        {
            return tagStack.Pop();
        }
    }
}
