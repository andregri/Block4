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
        private string tag;
        public override string Message
        {
            get
            {
                return String.Format("Expected closing tag {0} at line {1}.", tag, line);
            }
        }

        public XmlParseFileException(int line, string tag)
        {
            this.line = line;
            this.tag = tag;
        }
    }
}
