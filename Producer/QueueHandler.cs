using RabbitMQ.Client;
using System.Text;

namespace SendReservation
{
    public class QueueHandler
    {
        private readonly IConnection connection;
        private readonly IModel channel;
        public QueueHandler(IAsyncConnectionFactory connectionFactory)
        {
            connection = connectionFactory.CreateConnection();

            channel = connection.CreateModel();

            channel.QueueDeclare(queue: "triforkQueue",
                         durable: true,
                         exclusive: false,
                         autoDelete: false,
                         arguments: null);
        }
        public void sendMessage(string message)
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
