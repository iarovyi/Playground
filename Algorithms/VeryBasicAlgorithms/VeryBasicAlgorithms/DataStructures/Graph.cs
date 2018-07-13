using System.Collections.Generic;
using System.Threading.Tasks;

namespace VeryBasicAlgorithms.DataStructures
{
    using System;
    using System.Diagnostics;
    using System.Text;

    /// <summary>
    /// implements the graph API using the adjacency-lists representation
    /// </summary>
    [DebuggerDisplay("Graph  {ToString()}")]
    public class Graph
    {
        private readonly List<int>[] AdjacentList;
        private int edgeCount = 0;
        private readonly int size;

        public Graph(int size)
        {
            this.size = size;
            AdjacentList = new List<int>[size];
            for (int i = 0; i < AdjacentList.Length; i++)
            {
                AdjacentList[i] = new List<int>();
            }
        }

        public int EdgeCount => edgeCount;

        public List<int> GetAdjacent(int i)
        {
            return AdjacentList[i];
        }

        public int GetSize() => size;

        public void AddEdge(int a, int b)
        {
            if (a < 0 || a >= size) { throw new ArgumentOutOfRangeException(nameof(a)); }
            if (b < 0 || b >= size) { throw new ArgumentOutOfRangeException(nameof(b)); }

            AdjacentList[a].Add(b);
            AdjacentList[b].Add(a);
            edgeCount++;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < AdjacentList.Length; i++)
            {
                sb.AppendFormat("{0}:{1}", i, string.Join(',', AdjacentList[i]));
                sb.Append(Environment.NewLine);
            }
            return sb.ToString();
        }


        public static void Main()
        {
            var graph = new Graph(20);
            graph.AddEdge(1,2);
            graph.AddEdge(2, 3);

            graph.ToString();
        }
    }

    public class DepthFirstSearch
    {
        private bool[] marked;

        public DepthFirstSearch(Graph graph)
        {
            marked = new bool[graph.GetSize()];
        }

        private void Search(Graph graph, int i)
        {

        }

        public static void Main()
        {

        }
    }
}
