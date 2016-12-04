using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03.Handler
{
    public class TagHandler : IHandler
    {
        private Dictionary<char, IHandler> handlers;
        private IHandler defaultHandler;

        public TagHandler()
        {
            defaultHandler = new OpenTagHandler();
            handlers = new Dictionary<char, IHandler>();
            handlers.Add('/', new CloseTagHandler());
        }

        public int Process(IContext context, string line)
        {
            IHandler h = null;
            handlers.TryGetValue(line[1], out h);

            if (h == null)
            {
                h = new OpenTagHandler();
                return h.Process(context, line);
            }
            else
            {
                return h.Process(context, line);
            }
        }
    }
}
