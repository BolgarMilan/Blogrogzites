using Blogfelhasznalok.Models;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Mozilla;

namespace Blogfelhasznalok.Models
{
    public class UserDbContext : DbContext
    {
        public UserDbContext()
        {

        }

        public UserDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string conn = "server=localhost; database=Blogfelhasznalok; user=root; password=";

                optionsBuilder.UseMySQL(conn);
            }
        }

        public DbSet<User> Adat { get; set; } = null!;
    }
}