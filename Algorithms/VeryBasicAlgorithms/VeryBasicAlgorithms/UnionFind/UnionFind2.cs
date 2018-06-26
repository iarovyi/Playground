namespace VeryBasicAlgorithms.UnionFind
{
    using System;

    public class UnionFind2
    {
        private int[] tree;

        public UnionFind2(int size)
        {
            tree = new int[size];
            for (int i = 0; i < size; i++)
            {
                tree[i] = i;
            }
        }

        public void Connect(int one, int two)
        {
            tree[two] = one;
        }

        public bool IsConnected(int one, int two)
        {
            return FindRoot(one) == FindRoot(two);
        }

        private int FindRoot(int index)
        {
            int parent = tree[index];
            if (index == parent)
            {
                return index;
            }

            #region Optimization - making path shorter
            int grandParent = tree[parent];
            tree[parent] = grandParent;
            #endregion

            return FindRoot(parent);
        }

        public static void Main()
        {
            var uf = new UnionFind2(10);
            uf.Connect(1, 2);
            uf.Connect(1, 3);
            uf.Connect(2, 4);

            bool isWorking = uf.IsConnected(1, 2)
                && uf.IsConnected(1, 4)
                && uf.IsConnected(1, 3)
                && !uf.IsConnected(6, 5)
                && !uf.IsConnected(1, 5);

            Console.WriteLine(isWorking ? "Unites and finds" : "Incorrect");
        }
    }
}
