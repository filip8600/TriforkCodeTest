using ConsumeMessages;
using ConsumeMessages.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.


IHandleMessages messageHandler = new HandleMessages();
HandleMessageQueue queueHandler=new HandleMessageQueue(messageHandler);

app.Run();

