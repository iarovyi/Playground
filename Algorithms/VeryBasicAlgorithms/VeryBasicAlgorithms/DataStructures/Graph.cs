namespace VeryBasicAlgorithms.DataStructures
{
    using System;
    using System.Diagnostics;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;

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
            graph.AddEdge(6, 3);

            graph.AddEdge(10, 8);
            graph.AddEdge(9, 8);
            graph.AddEdge(9, 7);
            graph.AddEdge(7, 5);

            graph.ToString();
            var search = new DepthFirstSearch(graph, 1);
            var @false = search.IsConnected(5);
            var @true = search.IsConnected(6);
            bool isCorrect = @false == false && @true == true;
            Console.WriteLine(isCorrect ? "Can find" : "Incorrect");
        }
    }

    public class BreathFirstSearch
    {
        private bool[] marked;

        public BreathFirstSearch(Graph graph, int i)
        {
            marked = new bool[graph.GetSize()];
            Search(graph, i);
        }

        public bool IsConnected(int j)
        {
            return marked[j];
        }

        private void Search(Graph graph, int i)
        {
            var queue = new Queue<int>();
            queue.Enqueue(i);
            marked[i] = true;

            while (queue.Count > 0)
            {
                int j = queue.Dequeue();
                foreach (int adjacent in graph.GetAdjacent(j))
                {
                    if (!marked[adjacent])
                    {
                        marked[adjacent] = true;
                        queue.Enqueue(adjacent);
                    }
                }
            }
        }
    }

    public class DepthFirstSearch
    {
        private bool[] marked;

        public DepthFirstSearch(Graph graph, int i)
        {
            marked = new bool[graph.GetSize()];
            Search(graph, i);
        }

        public bool IsConnected(int j)
        {
            return marked[j];
        }

        private void Search(Graph graph, int i)
        {
            var stack = new Stack<int>();
            stack.Push(i);
            marked[i] = true;

            while (stack.Any())
            {
                var j = stack.Pop();
                foreach (int adjacent in graph.GetAdjacent(j))
                {
                    if (!marked[adjacent])
                    {
                        marked[adjacent] = true;
                        stack.Push(adjacent);
                    }
                }
            }

            //var adjacentNodes = graph.GetAdjacent(i);
            //for (int j = 0; j < adjacentNodes.Count; j++)
            //{
            //    var adjacentNode = adjacentNodes[j];
            //    if (!marked[adjacentNode])
            //    {
            //        marked[adjacentNode] = true;
            //        Search(graph, adjacentNode);
            //    }
            //}
        }
    }
}
