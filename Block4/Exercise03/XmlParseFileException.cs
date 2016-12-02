using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03
{
    class XmlParseFileException : ApplicationException
    {
        private int line;
        private string tagName;
        public override string Message
        {
            get
            {
                return String.Format("Expected closing tag {0} at line {1}.", tagName, line);
            }
        }

        public XmlParseFileException(int line, string tagName)
        {
            this.line = line;
            this.tagName = tagName;
        }
    }
}
