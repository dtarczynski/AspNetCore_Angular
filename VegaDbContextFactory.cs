using aspnetcore_spa.Persistence;
using Microsoft.EntityFrameworkCore;

namespace aspnetcore_spa
{
    public class VegaDbContextFactory : Microsoft.EntityFrameworkCore.Design.IDesignTimeDbContextFactory<VegaDbContext>
    {
        public VegaDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<VegaDbContext>();
        builder.UseSqlServer("server=localhost; database=vega; user id=sa; password=Kaczka1234");
        return new VegaDbContext(builder.Options);
    }
    }
}