using RabbitMQ.Client;
using SendReservation;
using SendReservation.Models;
using System.Text.Json;

var connectionFactory = new ConnectionFactory() { HostName = "localhost" };
IProduceMessage messageFactory=new MessageFactory();
var queueHandler = new QueueHandler(connectionFactory);

while (true)
{
    Message message = messageFactory.produceMessage(DateTime.UtcNow);
    string stringMessage = JsonSerializer.Serialize(message);
    queueHandler.sendMessage(stringMessage);
    Thread.Sleep(1000);
}
