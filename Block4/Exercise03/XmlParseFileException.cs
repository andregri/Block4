using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03
{
    public class XmlParseFileException : ApplicationException
    {
        private int line;
        private string tagName;
        public MissingTagException ex
        {
            get;
            private set;
        }

        public override string Message
        {
            get
            {
                return String.Format("Expected {0} at line {1}.", ex.Message, line);
            }
        }

        public XmlParseFileException(int line, string tagName, MissingTagException inner)
            : base(null, inner)
        {
            this.line = line;
            this.tagName = tagName;
            ex = inner;
        }
    }

    public abstract class MissingTagException : ApplicationException
    {
        public string TagName
        {
            get;
            private set;
        }

        public MissingTagException(string tag, Exception inner) : base(null, inner)
        {
            TagName = tag;
        }

        public MissingTagException(string tag)
            : this(tag, null) { }
    }

    public class MissingClosingTagException : MissingTagException
    {
        public override string Message
        {
            get
            {
                return String.Format("closing tag {0}", TagName);
            }
        }

        public MissingClosingTagException(string tag, Exception inner)
            : base(tag, inner) { }

        public MissingClosingTagException(string tag)
            : this(tag, null) { }
    }

    public class MissingOpeningTagException : MissingTagException
    {
        public override string Message
        {
            get
            {
                return String.Format("opening tag {0}", TagName);
            }
        }

        public MissingOpeningTagException(string tag, Exception inner)
            : base(tag, inner) { }

        public MissingOpeningTagException(string tag)
            : this(tag, null) { }
    }
}
