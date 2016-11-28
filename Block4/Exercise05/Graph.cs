using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise05
{
    public class Graph
    {
        private List<int>[] child;

        public List<int>[] Children
        {
            get { return child; }
            set { child = value; }
        }

        public Graph(List<int>[] child)
        {
            Children = child;
        }

        public int numberOfNodes
        {
            get { return child.Length; }
        }

        public void FindSubgraph()
        {
            List<int> currentSubgraph = new List<int>();
            bool[] visited = new bool[numberOfNodes];

            for (int i = 0; i < numberOfNodes; i++)
            {
                if (visited[i] != true)
                {
                    currentSubgraph.Add());
                }
            }
        }
    }
}

/* void TraverseDFSRecursive(node)
{
if (not visited[node])
{
visited[node] = true
print node
foreach child node c of node
{
TraverseDFSRecursive(c);
}
}
}*/
