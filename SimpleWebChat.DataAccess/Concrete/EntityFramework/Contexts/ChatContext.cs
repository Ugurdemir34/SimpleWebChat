using Microsoft.EntityFrameworkCore;
using SimpleWebChat.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleWebChat.DataAccess.Concrete.EntityFramework.Contexts
{
    public class ChatContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=ugurdemir.database.windows.net;Database=SimpleWebChat;User ID=******;Password=******+");
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
