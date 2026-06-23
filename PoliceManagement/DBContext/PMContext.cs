using Microsoft.EntityFrameworkCore;
using PoliceManagement.Entities;
using PoliceManagement.Mappings;

namespace PoliceManagement.DBContext
{
    public class PMContext : DbContext
    {
        public PMContext(DbContextOptions<PMContext> options) : base(options)
        {

        }

        public DbSet<PMEntity> PoliceRecords { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PMMapping());

        }


    }

}
