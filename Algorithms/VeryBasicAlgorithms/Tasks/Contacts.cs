namespace Tasks
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// https://www.hackerrank.com/challenges/ctci-contacts/problem?h_r=next-challenge&h_v=zen
    /// </summary>
    //Contacts.HandleOperation(op, contact);
    public class Contacts
    {
        public class WordTree
        {
            private Node rootNode;

            private class Node
            {
                public bool IsCompleteWord { get; set; }
                public Dictionary<char, Node> Children { get; set; }

                public int ChildWordsCount { get; set; }

                public Node GetOrAddChild(char character)
                {
                    return !Children.ContainsKey(character)
                        ? Children[character] = NewNode()
                        : Children[character];
                }

                public Node FindChild(char character)
                {
                    return Children.ContainsKey(character)
                        ? Children[character]
                        : null;
                }

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
                //AddWord(rootNode, word, 0);
                Node node = rootNode;
                for (int i = 0; i < word.Length; i++)
                {
                    char character = word[i];
                    Node child = node.GetOrAddChild(character);
                    child.ChildWordsCount++;

                    if (i == word.Length)
                    {
                        child.IsCompleteWord = true;
                    }

                    node = child;
                }
            }

 

            //private void AddWord(Node node, string word, int index)
            //{
            //    char character = word[index];

            //    Node child = node.GetOrAddChild(character);
            //    node.ChildWordsCount++;

            //    if (index == word.Length - 1)
            //    {
            //        child.IsCompleteWord = true;
            //        return;
            //    }

            //    AddWord(child, word, ++index);
            //}

            public int CountWordsStartsWith(string prefix)
            {
                var node = FindNode(prefix);
                if (node != null)
                {
                    return node.ChildWordsCount;
                    //return CountChildren(node);
                }
                else
                {
                    return 0;
                }
            }

            private Node FindNode(string prefix)
            {
                Node node = rootNode;
                for (int i = 0; i < prefix.Length; i++)
                {
                    char character = prefix[i];
                    Node child = node.FindChild(character);
                    if (child == null)
                    {
                        return null;
                    }

                    node = child;
                }

                return node;
                //Node node = rootNode;
                //int index = 0;
                //while (index < prefix.Length)
                //{
                //    char character = prefix[index++];
                //    if (!node.Children.ContainsKey(character))
                //    {
                //        return null;
                //    }

                //    node = node.Children[character];
                //}

                //return node;
            }

            //private int CountChildren(Node node)
            //{
            //    int count = 0;
            //    foreach (var child in node.Children)
            //    {
            //        if (child.Value.IsCompleteWord)
            //        {
            //            count++;
            //        }
            //        count += CountChildren(child.Value);
            //    }

            //    return count;
            //}
        }

        private WordTree wordTree = new WordTree();

        public void AddContact(string name)
        {
            wordTree.AddWord(name);
        }

        public int CountContactsThatStartsWith(string partialName)
        {
            return wordTree.CountWordsStartsWith(partialName);
        }

        #region statics
        private static Contacts instance = new Contacts();

        public static void HandleOperation(string operation, string contact)
        {
            if (operation == "add")
            {
                instance.AddContact(contact);
            }
            else if (operation == "find")
            {
                Console.WriteLine(instance.CountContactsThatStartsWith(contact));
            }
            else
            {
                Console.WriteLine("Unknows operation");
            }
        }
        #endregion
    }
}
