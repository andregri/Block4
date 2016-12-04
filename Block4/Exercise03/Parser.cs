using System;
using Exercise03.Handler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Exercise03
{
    public class Parser
    {
        private static Dictionary<char, IHandler> handlers;
        private static IHandler defaultHandler;

        private Dictionary<IHandler, IContext> contexts;
        private IContext defaultContext;

        public TagContext Tags
        {
            get;
            private set;
        }

        public DataContext Data
        {
            get;
            private set;
        }

        static Parser()
        {
            defaultHandler = new DefaultHandler();
            handlers = new Dictionary<char, IHandler>();
            handlers['<'] = new TagHandler();
        }

        public Parser()
        {
            Data = new DataContext();
            Tags = new TagContext();
            contexts = new Dictionary<IHandler, IContext>();
            contexts[handlers['<']] = Tags;
            defaultContext = Data;
        }

        public void Parse(TextReader reader)
        {
            int lineNumber = 0;
            string line;

            reader.ReadLine();
            while ((line = reader.ReadLine()) != null)
            {
                try
                {
                    ParseLine(line);
                }
                catch(MissingTagException e)
                {
                    throw new XmlParseFileException(lineNumber, e);
                }
                
                lineNumber++;
            }

            if (Tags.Depth > 0)
            {
                throw new XmlParseFileException(lineNumber,
                    new MissingClosingTagException(((Tag)Tags.Pop()).Name));
            }
        }

        public void ParseLine(string line)
        {
            line = line.Replace("\t", "");

            int processedLine = 0;
            IHandler h;
            while (processedLine < line.Length)
            {
                if (handlers.TryGetValue(line[0], out h))
                {
                    processedLine = h.Process(contexts[h], line);
                }
                else
                {
                    processedLine = defaultHandler.Process(defaultContext, line);
                }
                line = line.Substring(processedLine);
            }
        }
    }
}
