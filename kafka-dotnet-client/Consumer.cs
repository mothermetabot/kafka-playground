using Confluent.Kafka;
using static Confluent.Kafka.ConfigPropertyNames;

namespace test.kafka.client
{
    internal class Consumer
    {
        private readonly Action<string> _write;
        private readonly CancellationToken _token;
        private readonly IConsumer<Ignore, string> _consumer;

        public Consumer(Action<string> write, CancellationToken token)
        {
            _write = write ?? throw new ArgumentNullException();
            _token = token;

            var consumerConfig = new ConsumerConfig
            {
                GroupId = "foo1",
                BootstrapServers = "localhost:29092",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
            _consumer = new ConsumerBuilder<Ignore, string>(consumerConfig).Build();

        }

        public void Start()
        {
            _consumer.Subscribe("test");
            while (!_token.IsCancellationRequested)
            {
                var result = _consumer.Consume(_token);

                _write(result.Message.Value);
            }
        }
    }
}
