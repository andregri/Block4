using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03
{
    public abstract class TagHandler
    {
        protected struct attribute
        {
            string name;
            int value;
        }

        protected Stack<attribute> tagStack;

        public int tagCount
        {
            get
            {
                return tagStack.Count; 
            }
        }
    }
}
