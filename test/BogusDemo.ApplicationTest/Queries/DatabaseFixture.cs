using Microsoft.EntityFrameworkCore;

namespace BogusDemo.ApplicationTest.Queries;

public class DatabaseFixture : IDisposable
{
    private readonly BogusDemoContext _context;
    private bool isDisposed;

    public DatabaseFixture()
    {
        _context = new BogusDemoContext(new DbContextOptionsBuilder<BogusDemoContext>()
            .UseInMemoryDatabase("testdb")
            .Options);

        _context.Database.EnsureCreated();
        SeedData();
    }

    ~DatabaseFixture()
    {
        if (isDisposed)
        {
            return;
        }

        Dispose();
    }

    public BogusDemoContext Context
    {
        get
        {
            return _context;
        }
    }

    public void Dispose()
    {
        if (isDisposed)
        {
            return;
        }

        _context.Database.EnsureDeleted();
        _context.Dispose();

        isDisposed = true;
        GC.SuppressFinalize(this);
    }

    private void SeedData()
    {
        var department1 = new Department("d1");
        department1.CreateRoom("r1");

        var department2 = new Department("d2");
        department2.CreateRoom("r2");

        var department3 = new Department("d3");
        department3.CreateRoom("r3");

        var department4 = new Department("d4");
        department4.CreateRoom("r4");

        var departments = new List<Department>()
        {
            department1,
            department2,
            department3,
            department4
        };

        _context.Departments.AddRange(departments);
        _context.SaveChanges();
    }
}