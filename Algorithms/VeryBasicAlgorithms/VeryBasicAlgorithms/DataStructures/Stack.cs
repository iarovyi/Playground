namespace VeryBasicAlgorithms
{
    using System;

    /// <summary>
    /// 1) Linked list
    /// 2) array
    /// </summary>

    class Stack
    {
        private int[] items;
        private int index = -1;

        public Stack(int size)
        {
            items = new int[size];
        }

        public void Push(int item)
        {
            if (GetSize() == items.Length) { throw new InvalidOperationException("Stack is full"); }
            items[++index] = item;
        }

        public int Pop()
        {
            return items[index--];
        }

        public int GetSize()
        {
            return index + 1;
        }


        public static void Main()
        {
            var stack = new Stack(10);
            stack.Push(100);
            stack.Push(101);
            bool isCorrect = stack.Pop() == 101
                      && stack.Pop() == 100;

            Console.WriteLine(isCorrect ? "Works fine" : "Incorrect");
        }
    }

    public class StackWithLinkedList
    {
        private Node Tail;

        private class Node
        {
            public int Value { get; set; }
            public Node Next { get; set; }
        }

        public void Push(int value)
        {
            Tail = new Node()
            {
                Value = value,
                Next = Tail
            };
        }

        public int Pop()
        {
            if (Tail == null) { throw new InvalidOperationException("Stack is empty");}

            var value = Tail.Value;
            Tail = Tail.Next;
            return value;
        }

        public int GetSize()
        {
            int count = 0;
            Node current = Tail;
            while (current != null)
            {
                count++;
                current = current.Next;
            }

            return count;
        }

        public static void Main()
        {
            StackWithLinkedList stack = new StackWithLinkedList();
            stack.Push(1);
            stack.Push(2);
            Console.WriteLine($"{(stack.GetSize() == 2? "Size is correct" : "Size is incorrect")}");
            stack.Push(3);
            int three = stack.Pop();
            int two = stack.Pop();
            int one = stack.Pop();
            bool isCorrect = one == 1 && two == 2 && three == 3;
            Console.WriteLine($"Stack is {(isCorrect?"correct" : "incorrect")}");
        }
    }
}
