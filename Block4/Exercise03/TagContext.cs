using System;
using Exercise03.Handler;
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
        private static Stack<Tag> tagStack = new Stack<Tag>();

        public int Depth
        {
            get
            {
                return tagStack.Count;
            }
        }

        public void Push(object tag)
        {
            Tag t = tag as Tag;
            if (t != null)
            {
                tagStack.Push(t);
            }
        }

        public object Pop()
        {
            return tagStack.Pop();
        }
    }
}
