namespace SendReservation.Models
{
    public class MessageFactory: IProduceMessage
    {
        public Message produceMessage(DateTime time)
        {
            Message msg = new Message
            {
                //messageId = (int)DateTime.UtcNow.Ticks,
                timestamp = time
            };
            return msg;
        }
    }
}
