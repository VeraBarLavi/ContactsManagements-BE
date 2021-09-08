using Microsoft.EntityFrameworkCore;

namespace Contacts.DB
{    public class AppDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=ContactsDB;Integrated Security=True");
        }
    }
}
