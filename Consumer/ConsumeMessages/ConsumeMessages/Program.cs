using ConsumeMessages;
using ConsumeMessages.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ConsumeMessages.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MessageContext>(options =>
    options.UseSqlServer());

// Add services to the container.
var app = builder.Build();

// Configure the HTTP request pipeline.


IHandleMessages messageHandler = new HandleMessages(new MessageContext(@"Server=localhost;Database=master;Trusted_Connection=True;"));
var t = new Task(() => new HandleMessageQueue(messageHandler));
t.Start();

app.Run();

