using System;
using Exercise03.Handler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03
{
    public class DataContext : IContext
    {
        private List<string> data = new List<string>();

        public void Push(object input)
        {
            data.Add((string)input);
        }

        public object Pop()
        {
            return data[data.Count - 1] ?? null;
        }

        public string[] ToArray()
        {
            return data.ToArray();
        }
    }
}
