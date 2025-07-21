namespace BogusDemo.Infra;

public class BogusDemoContext(DbContextOptions<BogusDemoContext> options)
    : DbContext(options)
{
    public DbSet<Department> Departments { get; set; }

    public DbSet<Room> Rooms { get; set; }
}