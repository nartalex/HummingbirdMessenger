﻿using System.Data.Entity;

namespace Hummingbird.Model
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<ChatMember> ChatMembers { get; set; }

        public DatabaseContext() : base("name=DefaultConnection")
        {
            
        }
    }
    public class AppDbInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            base.Seed(context);
        }
    }
}
