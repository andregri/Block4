using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Exercise05;

namespace ClassTest
{
    [TestClass]
    public class UnitTest05
    {
        private void AreEqual(Dictionary<int, int[]> expected, Dictionary<int, int[]> actual)
        {
            CollectionAssert.AreEquivalent(expected.Keys, actual.Keys);
            foreach (int k in expected.Keys)
            {
                CollectionAssert.AreEquivalent(expected[k], actual[k]);
            }
        }

        //graph
        Dictionary<int, int[]> g = new Dictionary<int, int[]>()
        {
            {1, new int[] {3, 4} },
            {2, new int[] { } },
            {3, new int[] {4} }
        };

        Dictionary<int, int[]> expected1 = new Dictionary<int, int[]>()
        {
            {1, new int[] {3, 4} },
            {3, new int[] {4} }
        };

        Dictionary<int, int[]> expected2 = new Dictionary<int, int[]>()
        {
            {2, new int[] { } }
        };

        Graph graph;
        [TestInitialize]
        public void Initialize()
        {
            graph = new Graph(g);
        }

        [TestMethod]
        public void FindSubgraphTestNode1()
        {
            Dictionary<int, int[]> actual = graph.FindSubgraph(1);
            AreEqual(expected1, actual);
        }

        [TestMethod]
        public void FindSubgraphTestNode2()
        {
            Dictionary<int, int[]> actual = graph.FindSubgraph(2);
            AreEqual(expected2, actual);
        }

        [TestMethod]
        public void FindAllSubgraph()
        {
            Dictionary<int, int[]>[] actual = graph.FindAllSubgraph();
            Dictionary<int, int[]>[] expected = new Dictionary<int, int[]>[2];
            expected[0] = expected1;
            expected[1] = expected2;

            Assert.AreEqual(expected.Length, actual.Length);
            AreEqual(expected[0], actual[0]);
            AreEqual(expected[1], actual[1]);
        }
    }
}
