namespace Tasks
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// https://www.hackerrank.com/challenges/ctci-contacts/problem?h_r=next-challenge&h_v=zen
    /// </summary>
    //Contacts.HandleOperation(op, contact);
    public static class Contacts
    {
        public class WordTree
        {
            private Node rootNode;

            private class Node
            {
                public bool IsCompleteWord { get; set; }
                public Dictionary<char, Node> Children { get; set; }

                public static Node NewNode()
                {
                    return new Node()
                    {
                        IsCompleteWord = false,
                        Children = new Dictionary<char, Node>(26)
                    };
                }
            }

            public WordTree()
            {
                rootNode = Node.NewNode();
            }

            public void AddWord(string word)
            {
                AddWord(rootNode, word, 0);
            }

            private void AddWord(Node node, string word, int index)
            {
                char character = word[index];

                Node child = !node.Children.ContainsKey(character)
                    ? node.Children[character] = Node.NewNode() 
                    : node.Children[character];

                if (index == word.Length - 1)
                {
                    child.IsCompleteWord = true;
                    return;
                }

                AddWord(child, word, ++index);
            }

            public int CountWordsStartsWith(string prefix)
            {
                var node = FindNode(prefix);
                if (node != null)
                {
                    return CountChildren(node);
                }
                else
                {
                    return 0;
                }
            }

            private Node FindNode(string prefix)
            {
                Node node = rootNode;
                int index = 0;
                while (index < prefix.Length)
                {
                    char character = prefix[index++];
                    if (!node.Children.ContainsKey(character))
                    {
                        return null;
                    }

                    node = node.Children[character];
                }

                return node;
            }

            private int CountChildren(Node node)
            {
                int count = 0;
                foreach (var child in node.Children)
                {
                    if (child.Value.IsCompleteWord)
                    {
                        count++;
                    }
                    count += CountChildren(child.Value);
                }

                return count;
            }
        }

        private static WordTree wordTree = new WordTree();

        public static void HandleOperation(string operation, string contact)
        {
            if (operation == "add")
            {
                AddContact(contact);
            }
            else if (operation == "find")
            {
                Console.WriteLine(CountContactsThatStartsWith(contact));
            }
            else
            {
                Console.WriteLine("Unknows operation");
            }
        }

        public static void AddContact(string name)
        {
            wordTree.AddWord(name);
        }

        public static int CountContactsThatStartsWith(string partialName)
        {
            return wordTree.CountWordsStartsWith(partialName);
        }
    }
}
