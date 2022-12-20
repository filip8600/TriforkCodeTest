using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ConsumeMessages.Model;

namespace ConsumeMessages.Data
{
    public class MessageContext : DbContext
    {
        private readonly string _connectionString;
        public MessageContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        public MessageContext() 
        {
            _connectionString = @"Server=localhost;Database=master;Trusted_Connection=True;";
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }


        public MessageContext(DbSet<Message> message)
        {
            Message = message;
        }

        public DbSet<ConsumeMessages.Model.Message> Message { get; set; } = default!;
    }
}
