namespace DisruptorConsole
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using Disruptor;

    /*Disruptor - queue with multiple producers and consumers where all consumers get all events
       any data should be owned by only one thread for write access, therefore eliminating write contention
     - optionally lock-free
     - pre-allocate memory for events
        => change event properties instead of new object allocation
     - Consumer Dependency Graph
       (some consumers should be called before others)
 
      https://martinfowler.com/articles/lmax.html

      https://github.com/disruptor-net/Disruptor-net
      https://github.com/LMAX-Exchange/disruptor/wiki/Introduction
      http://lmax-exchange.github.io/disruptor/files/Disruptor-1.0.pdf
      https://labs.eleks.com/2013/01/disruptor-net.html
      https://github.com/LMAX-Exchange/disruptor/wiki/Getting-Started
      https://martinfowler.com/articles/lmax.html
      https://www.infoq.com/presentations/LMAX
      https://dev.cheremin.info/search/label/disruptor
    */
    class Program
    {
        private static readonly Random _random = new Random();
        private static readonly int _ringSize = 16;  // Must be multiple of 2

        static void Main(string[] args)
        {
            var disruptor = new Disruptor.Dsl.Disruptor<ValueEntry>(() => new ValueEntry(), _ringSize, TaskScheduler.Default);

            disruptor.HandleEventsWith(new ValueAdditionHandler());

            var ringBuffer = disruptor.Start();

            while (true)
            {
                long sequenceNo = ringBuffer.Next();

                ValueEntry entry = ringBuffer[sequenceNo];

                entry.Value = _random.Next();

                ringBuffer.Publish(sequenceNo);

                Console.WriteLine("Published entry {0}, value {1}", sequenceNo, entry.Value);

                Thread.Sleep(250);
            }
        }
    }

    public sealed class ValueEntry
    {
        public long Value { get; set; }

        public ValueEntry()
        {
            Console.WriteLine("New ValueEntry created");
        }
    }

    public class ValueAdditionHandler : IEventHandler<ValueEntry>
    {
        public void OnNext(ValueEntry data, long sequence, bool endOfBatch)
        {
        }

        public void OnEvent(ValueEntry data, long sequence, bool endOfBatch)
        {
            Console.WriteLine("Event handled: Value = {0} (processed event {1}", data.Value, sequence);
        }
    }
}
