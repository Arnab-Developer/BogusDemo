using Microsoft.EntityFrameworkCore;

namespace BogusDemo.ApplicationTest.Queries;

public partial class GetDepartmentsQueryTest
{
    private GetDepartmentsQuery? _query;
    private readonly IRequestHandler<GetDepartmentsQuery, IEnumerable<DepartmentDTO>> _queryHandler;
    private readonly CancellationToken _ct;

    public GetDepartmentsQueryTest()
    {
        var context = new BogusDemoContext(new DbContextOptionsBuilder<BogusDemoContext>()
            .UseInMemoryDatabase("testdb")
            .Options);

        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
        SeedData(context);

        _queryHandler = new GetDepartmentsQueryHandler(context);
        _ct = new CancellationToken();
    }

    private static void SeedData(BogusDemoContext context)
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
        
        context.Departments.AddRange(departments);
        context.SaveChanges();
    }
}