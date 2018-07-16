namespace Tasks.Specs
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Node = CheckIfBinarySearchTree.Node;

    [TestClass]
    public class CheckIfBinarySearchTreeSpecs
    {
        [TestMethod]
        public void Can_recognize_binary_tree()
        {
            Node root = new Node()
            {
                data = 4,
                left = new Node()
                {
                    data = 2,
                    left = new Node()
                    {
                        data = 1
                    },
                    right = new Node()
                    {
                        data = 3
                    }
                },
                right = new Node()
                {
                    data = 6,
                    left = new Node()
                    {
                        data = 5
                    },
                    right = new Node()
                    {
                        data = 7
                    }
                }
            };
            var task = new CheckIfBinarySearchTree();

            bool result = task.checkBST(root);
            result.Should().Be(true);
        }

        [TestMethod]
        public void Can_recognize_non_binary_tree()
        {
            Node root = new Node()
            {
                data = 3,
                left = new Node()
                {
                    data = 2,
                    left = new Node()
                    {
                        data = 1
                    }
                },
                right = new Node()
                {
                    data = 5,
                    left = new Node()
                    {
                        data = 6
                    },
                    right = new Node()
                    {
                        data = 1
                    }
                }
            };
            var task = new CheckIfBinarySearchTree();

            bool result = task.checkBST(root);
            result.Should().Be(false);
        }
    }
}
