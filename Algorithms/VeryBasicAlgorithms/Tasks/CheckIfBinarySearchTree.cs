namespace Tasks
{
    using Integer = System.Int32;

    public class CheckIfBinarySearchTree
    {
        public class Node
        {
            public int data;
            public Node left;
            public Node right;
        }

        public bool checkBST(Node node)
        {
            return checkBST(node, Integer.MinValue, Integer.MaxValue);
        }

        public bool checkBST(Node node, int min, int max)
        {
            if (node == null)
            {
                return true;
            }

            if (node.data <= min || node.data >= max)
            {
                return false;
            }

            return checkBST(node.left, min, node.data) && checkBST(node.right, node.data, max);
        }
    }
}
