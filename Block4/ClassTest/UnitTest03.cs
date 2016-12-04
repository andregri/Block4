using System;
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
        public void OpeningTagTestNoAttribute()
        {
            TagContext context = new TagContext();
            OpenTagHandler handler = new OpenTagHandler();
            int result = handler.Process(context, lineNoAttr);

            Assert.AreEqual("name", ((Tag)context.Pop()).Name);
            Assert.AreEqual(lineNoAttr.IndexOf('>') + 1, result);    
        }

        [TestMethod]
        public void OpeningTagTestWithAttribute()
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
    }
}
