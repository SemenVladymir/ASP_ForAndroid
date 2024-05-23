using ASP_ForAndroid.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_ForAndroid.Context
{
    public class RegistrationContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public RegistrationContext(DbContextOptions<RegistrationContext> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-MV43C0T;Database=UserBase;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
