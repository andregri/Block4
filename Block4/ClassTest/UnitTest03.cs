using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exercise03;
using Exercise03.Handler;

namespace ClassTest
{
    [TestClass]
    public class UnitTest03
    {
        string lineNoAttr = "<name>Peter</name>";
        string lineWithAttr = "<name attr=\"1\">Peter</name>";

        [TestMethod]
        public void ProcessTagTestNoAttribute()
        {
            int result = 0;
            TagContext tagContext = new TagContext();

            //opening tag
            OpenTagHandler openH = new OpenTagHandler();
            result += openH.Process(tagContext, lineNoAttr);
            Assert.AreEqual(lineNoAttr.IndexOf('>') + 1, result);

            //data handler
            DataContext dataContext = new DataContext();
            DefaultHandler defaultH = new DefaultHandler();
            result += defaultH.Process(dataContext, lineNoAttr.Substring(result));
            Assert.AreEqual("Peter", (string)dataContext.Pop());
            Assert.AreEqual(lineNoAttr.LastIndexOf('<'), result);

            //closing tag
            CloseTagHandler closeH = new CloseTagHandler();
            result += closeH.Process(tagContext, lineNoAttr.Substring(result));
            Assert.AreEqual(lineNoAttr.Length, result);
        }

        [TestMethod]
        public void ProcessTagTestWithAttribute()
        {
            TagContext context = new TagContext();
            OpenTagHandler handler = new OpenTagHandler();
            int result = handler.Process(context, lineWithAttr);

            Tag tag = (Tag)context.Pop();
            Assert.AreEqual("name", tag.Name);
            Assert.AreEqual("attr", tag.Attribute);
            Assert.AreEqual(1, tag.Value);
            Assert.AreEqual(lineWithAttr.IndexOf('>') + 1, result);
        }

        [TestMethod]
        public void ParserTest()
        {
            string file = @"../../file.xml";
            string[] expected = {"Peter", "21", "Games", "C#", "Java" };
            TextReader reader = new StreamReader(file);
            Parser parser = new Parser();
            parser.Parse(reader);
            string[] values = parser.Data.ToArray();

            CollectionAssert.AreEqual(expected, values);
        }

        [TestMethod]
        [ExpectedException(typeof(XmlParseFileException))]
        public void TestNotClosedTag()
        {
            string file = @"../../wrong1.xml";
            TextReader reader = new StreamReader(file);
            Parser parser = new Parser();
            parser.Parse(reader);
        }

        [TestMethod]
        [ExpectedException(typeof(XmlParseFileException))]
        public void TestNotOpenedTag()
        {
            string file = @"../../wrong2.xml";
            TextReader reader = new StreamReader(file);
            Parser parser = new Parser();
            parser.Parse(reader);
        }
    }
}
