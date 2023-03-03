using Confluent.Kafka;
using test.kafka.client;

var cts = new CancellationTokenSource();



Console.WriteLine("Press 'c' for consumer or 'p' for producer.");
var choice = Console.ReadKey().KeyChar;

if(choice == 'c')
{
    var consumer = new Consumer(Console.WriteLine, cts.Token);
    consumer.Start();
}

else if(choice == 'p')
{
    var producer = new Producer(Console.ReadLine, cts.Cancel);
    producer.Start();
}


else
{
    Console.WriteLine("Unkown command.");
}