using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using System.Threading.Channels;
using ConsumeMessages.Model;

namespace ConsumeMessages
{
    public class HandleMessageQueue:ISendMessages
    {
        private IModel channel;
        private IHandleMessages messageHandler;
        public HandleMessageQueue(IHandleMessages messageHandler)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            var connection = factory.CreateConnection();
            channel = connection.CreateModel();
            {
                channel.QueueDeclare(queue: "triforkQueue",
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    messageHandler.Handle(message,this);
                };
                channel.BasicConsume(queue: "triforkQueue",
                                     autoAck: true,
                                     consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }

            this.messageHandler = messageHandler;
        }

        public void SendMessage(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);


            channel.BasicPublish(
                exchange: "",
                     routingKey: "triforkQueue",
                     basicProperties: null,
                     body: body);
            Console.WriteLine(" [x] Sent {0}\n\n", message);
        }
    }
}
