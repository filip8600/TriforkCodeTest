using SendReservation.Models;

public interface IProduceMessage
{
    public Message produceMessage(DateTime time);
}