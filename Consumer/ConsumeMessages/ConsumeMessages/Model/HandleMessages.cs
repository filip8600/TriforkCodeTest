using System.Text.Json;

namespace ConsumeMessages.Model
{
    public class HandleMessages : IHandleMessages
    {
        public void Handle(string JsonMessage, ISendMessages sender)
        {
            Message? message = JsonSerializer.Deserialize<Message>(JsonMessage);
            if (message == null)
            {
                Console.WriteLine("Error decoding message");
                return;
            }
            if (message.timestamp > DateTime.UtcNow)
            {
                Console.WriteLine("Wrong timestamp");
                return;
            }
            if (message.timestamp < DateTime.UtcNow.AddMinutes(-1))
            {
                Console.WriteLine("Message to old");
                return;
            }
            if (message.timestamp.Second % 2 == 0)
            {
                Console.WriteLine("Even second. Adding to db");
            }
            else
            {
                message.timestamp = DateTime.Now;
                sender?.SendMessage(JsonSerializer.Serialize(message));

            }
        }
    }
}
