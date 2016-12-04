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
        public MissingTagException ex
        {
            get;
            private set;
        }

        public override string Message
        {
            get
            {
                return String.Format("{0} at line {1}.", ex.Message, line);
            }
        }

        public XmlParseFileException(int line, MissingTagException inner)
            : base(null, inner)
        {
            this.line = line;
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
                return String.Format("Expected closing tag {0}", TagName);
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
                return String.Format("Missing opening tag for {0}", TagName);
            }
        }

        public MissingOpeningTagException(string tag, Exception inner)
            : base(tag, inner) { }

        public MissingOpeningTagException(string tag)
            : this(tag, null) { }
    }
}
