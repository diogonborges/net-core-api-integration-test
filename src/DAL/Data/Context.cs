using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class Context : DbContext
    {
        public DbSet<Application> Applications { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ApplicationConfiguration());
        }
    }
}
