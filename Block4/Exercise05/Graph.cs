using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise05
{
    public class Graph
    {
        private Dictionary<int, int[]> childNodes;
        private int count;

        public Graph(Dictionary<int, int[]> childNodes)
        {
            this.childNodes = childNodes;

            count = 0;
            foreach (var a in childNodes.Values)
            {
                count += a.Length > 0 ? a.Length : 1;
            }
        }

        public Dictionary<int, int[]> FindSubgraph(int node)
        {
            //use DFS algorithm
            List<int> visited = new List<int>();
            Stack<int> stack = new Stack<int>();

            stack.Push(node);
            visited.Add(node);

            Dictionary<int, int[]> subgraph = new Dictionary<int, int[]>();
            subgraph[node] = childNodes[node];

            while (stack.Count > 0)
            {
                int currentNode = stack.Pop();

                if (!childNodes.Keys.Contains(currentNode))
                {
                    break;
                }

                foreach (int childNode in childNodes[currentNode])
                {
                    if (!visited.Contains(childNode))
                    {
                        stack.Push(childNode);
                        visited.Add(childNode);
                        int[] children;
                        if (childNodes.TryGetValue(childNode, out children) && children.Length != 0)
                        {
                            subgraph[childNode] = children;
                        }
                    }
                }
            }

            return subgraph;
        }

        public Dictionary<int, int[]>[] FindAllSubgraph()
        {
            List<int> nodes = childNodes.Keys.ToList<int>();
            List<Dictionary<int, int[]>> allSubgraph = new List<Dictionary<int, int[]>>();
            List<int> visited = new List<int>();

            foreach (int currentNode in nodes)
            {
                var temp = FindSubgraph(currentNode);
                if (!visited.Contains(currentNode))
                {
                    allSubgraph.Add(temp);
                    visited.Add(currentNode);
                    foreach (var k in temp.Keys)
                    {
                        visited.AddRange(temp[k]);
                    }
                }
            }

            return allSubgraph.ToArray();
        }
    }
}
