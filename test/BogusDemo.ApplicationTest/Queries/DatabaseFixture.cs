using Microsoft.EntityFrameworkCore;

namespace BogusDemo.ApplicationTest.Queries;

public class DatabaseFixture : IDisposable
{
    private readonly BogusDemoContext _context;
    private bool disposedValue;

    public DatabaseFixture()
    {
        _context = new BogusDemoContext(new DbContextOptionsBuilder<BogusDemoContext>()
            .UseInMemoryDatabase("testdb")
            .Options);

        _context.Database.EnsureCreated();
        SeedData();
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
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                // TODO: dispose managed state (managed objects)
            }

            // TODO: free unmanaged resources (unmanaged objects) and override finalizer
            // TODO: set large fields to null

            _context.Database.EnsureDeleted();
            _context.Dispose();

            disposedValue = true;
        }
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

    // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
    ~DatabaseFixture()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(false);
    }
}