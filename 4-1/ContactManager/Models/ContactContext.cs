using Microsoft.EntityFrameworkCore;

namespace ContactManager.Models
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options)
            : base(options)
        { }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = "FR", Name = "Friend" },
                new Category { CategoryId = "WK", Name = "Work" },
                new Category { CategoryId = "FM", Name = "Family", }
                );
       
        
            modelBuilder.Entity<Contact>().HasData(
                new Contact
                {
                    ContactId = 1,
                    Fname = "Delores",
                    Lname = "Del Rio",
                    Phone = "555-987-6543",
                    Email = "delores@hotmail.com",
                    CategoryId = "FR"
                },
                new Contact
                {
                    ContactId = 2,
                    Fname = "Efren",
                    Lname = "Herrera",
                    Phone = "555-456-7890",
                    Email = "efren@aol.com",
                    CategoryId = "WK"
                },
                new Contact
                {
                    ContactId = 3,
                    Fname = "Mary Ellen",
                    Lname = "Walton",
                    Phone = "555-123-4567",
                    Email = "MaryEllen@yahoo.com",
                    CategoryId = "FM"
                }
                );
        }
    }
}
