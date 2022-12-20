namespace SendReservation.Models
{
    public class MessageFactory: IProduceMessage
    {
        public Message produceMessage(DateTime time)
        {
            Message msg = new Message
            {
                messageId = 5555,
                timestamp = time
            };
            return msg;
        }
    }
}
