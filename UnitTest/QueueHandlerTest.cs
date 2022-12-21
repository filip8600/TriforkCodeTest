using SendReservation;
using NSubstitute;
using RabbitMQ.Client;
using SendReservation.Models;
using System.Text;

namespace UnitTest
{
    public class QueueHandlerTest
    {
        private QueueHandler uut;
        private IProduceMessage fakeMessageFactory;
        private IAsyncConnectionFactory fakeConnection;
        public QueueHandlerTest()
        {
            fakeMessageFactory=Substitute.For<IProduceMessage>();
             fakeConnection = Substitute.For<IAsyncConnectionFactory>();
            uut = new QueueHandler(fakeConnection);
        }
        [Fact]
        public void ConstructorCreateConnection()
        {
            fakeConnection.Received(1).CreateConnection();

        }
        [Fact]
        public void ConstructorCreateChannel()
        {
            fakeConnection.Received(1).CreateConnection().CreateModel();
        }

        [Fact]
        public void ConstructorCreateQueue()
        {
            fakeConnection.Received(1).CreateConnection().CreateModel().BasicPublish("","");
        }
        [Fact]
        public void MessageIsSent()
        {
            DateTime testTime = DateTime.Now;
            var messageFactory = new MessageFactory();
            var message = messageFactory.produceMessage(testTime);
            uut.sendMessage("simpleMessage");
            var body= Encoding.UTF8.GetBytes("simpleTestMessage");
            fakeConnection.Received().CreateConnection().CreateModel().BasicPublish(
                exchange: "",
                         routingKey: "triforkQueue",
                         basicProperties: null,
                         body: body);
        }
    }
}