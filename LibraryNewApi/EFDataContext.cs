using LibraryNewApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagmentAPI
{
    public class EFDataContext: DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=libraryDB;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}
