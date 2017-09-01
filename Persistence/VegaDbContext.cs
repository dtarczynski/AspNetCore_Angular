using aspnetcore_spa.Models;
using Microsoft.EntityFrameworkCore;

namespace aspnetcore_spa.Persistence
{
    public class VegaDbContext : DbContext
    {
        public VegaDbContext(DbContextOptions<VegaDbContext> options) : base(options)
        {
            
        }    

        public DbSet<Make> Makes { get; set; }        

        public DbSet<Model> Models { get; set; }
    }
}