using SendReservation.Models;

namespace UnitTest
{
    public class MessageFactoryTest
    {
        private MessageFactory uut;
       public MessageFactoryTest()
        {
            uut=new MessageFactory();
        }
        [Fact]
        public void Test1()
        {
            DateTime testTime= DateTime.Now;
            var message= uut.produceMessage(testTime);
            Assert.Equal(message.timestamp = testTime,testTime);
        }
    }
}