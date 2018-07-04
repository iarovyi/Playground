namespace VeryBasicAlgorithms.DataStructures
{
    using System;

    /// <summary>
    /// Max priority queue using binary heap
    /// https://algs4.cs.princeton.edu/24pq/
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class PriorityQueue<T> where T : IComparable<T>
    {
        private T[] binaryHeap;
        private int count = 0;

        public PriorityQueue(int size)
        {
            binaryHeap = new T[size + 1];
        }

        public void Add(T item)
        {
            binaryHeap[++count] = item;
            Swim(count);
        }

        public T DequeueMax()
        {
            T max = binaryHeap[1];
            Swap(1, count);
            count--;
            Sink(1);
            return max;
        }

        private void Sink(int index)
        {
            while (2* index <= count)
            {
                if (index >= count) { break; }

                var newIndex = index * 2;

                if (newIndex + 1 < count && binaryHeap[newIndex].CompareTo(binaryHeap[newIndex + 1]) < 0){ newIndex++; }

                if(binaryHeap[index].CompareTo(binaryHeap[newIndex]) > 0){ break; }

                Swap(index, newIndex);
                index = newIndex;
            }
        }

        private void Swim(int index)
        {
            int k = index;
            while (k > 1 && binaryHeap[k].CompareTo(binaryHeap[k/2]) > 0) {
                Swap(k, k/2);
                k = k / 2;
            }
        }

        private void Swap(int i, int j)
        {
            var temp = binaryHeap[i];
            binaryHeap[i] = binaryHeap[j];
            binaryHeap[j] = temp;
        }

        public static void Main()
        {
            var priorityQueue = new PriorityQueue<string>(20);
            priorityQueue.Add("A");
            priorityQueue.Add("B");
            priorityQueue.Add("C");
            priorityQueue.Add("D");
            priorityQueue.Add("E");

            var max1 = priorityQueue.DequeueMax();
            var max2 = priorityQueue.DequeueMax();
            bool isCorrect = max1 == "E" && max2 == "D";
            Console.WriteLine(isCorrect ? "Is correct" : "Not correct");
        }
    }
}
