using ConsumeMessages.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace ConsumeMessages.Model
{
    public class HandleMessages : IHandleMessages
    {
        private readonly MessageContext _context;

        public HandleMessages(MessageContext context)
        {
            _context = context;
        }

        public async void Handle(string JsonMessage, ISendMessages sender)
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
                Console.WriteLine("Message too old");
                return;
            }
            if (message.timestamp.Second % 2 == 0)
            {
                Console.WriteLine("Even second. Adding to db");
                _context.Message.Add(message);
                _context.SaveChanges();
            }
            else
            {
                message.timestamp = DateTime.UtcNow;
                sender?.SendMessage(JsonSerializer.Serialize(message));

            }
        }
    }
}
