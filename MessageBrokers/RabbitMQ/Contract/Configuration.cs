namespace Contract
{
    using RabbitMQ.Client;

    public static class Configuration
    {
        public static void RegisterQueues(IModel channel)
        {
            channel.QueueDeclare(queue: "hello",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);
        }
    }
}
