using ConsumeMessages.Data;
using ConsumeMessages.Model;

namespace UnitTest
{
    public class HandleMessageTest
    {
        private HandleMessages uut;
        public HandleMessageTest()
        {
            uut = new HandleMessages(new MessageContext());
        }
        [Fact]
        public void Test1()
        {

        }
    }
}