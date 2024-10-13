using FMP.Models;
using Microsoft.EntityFrameworkCore;

namespace FMP.APPDB
{
    public class DBConfig:DbContext
    {
        public DbSet<Ticket> tickets { get; set; }
        public DbSet<Movie> movies { get; set; }
        public DbSet<Customer> customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=FMPDB;Integrated Security=True");
        }
    }
}
