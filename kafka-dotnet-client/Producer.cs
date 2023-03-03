using Confluent.Kafka;
using static Confluent.Kafka.ConfigPropertyNames;

namespace test.kafka.client
{
    internal class Producer
    {
        private readonly Func<string> _read;
        private readonly Action _cancel;
        private readonly IProducer<Null, string> _producer;

        public Producer(Func<string> read, Action cancel)
        {
            _read = read ?? throw new ArgumentNullException();
            _cancel = cancel;

            var producerConfig = new ConsumerConfig
            {
                BootstrapServers = "localhost:29092",
            };
            _producer = new ProducerBuilder<Null, string>(producerConfig).Build();

        }


        public void Start()
        {
            var msg = "";
            while (true)
            {
                msg = _read();

                if (msg == ":qa")
                    break;

                _producer.Produce("test", new Message<Null, string>() { Value = msg });
            }
            _cancel();

        }
    }
}
