using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BogusDemo.Infra;

internal class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BogusDemoContext>
{
    public BogusDemoContext CreateDbContext(string[] args)
    {
        var constr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BogusDemo;Integrated Security=True";

        var context = new BogusDemoContext(new DbContextOptionsBuilder<BogusDemoContext>()
            .UseSqlServer(constr)
            .Options);

        return context;
    }
}