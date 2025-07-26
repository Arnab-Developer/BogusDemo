namespace BogusDemo.ApplicationTest.Queries;

public partial class GetDepartmentsQueryTest : IClassFixture<DatabaseFixture>
{
    private readonly DatabaseFixture _databaseFixture;
    private GetDepartmentsQuery? _query;
    private readonly IRequestHandler<GetDepartmentsQuery, IEnumerable<DepartmentDTO>> _queryHandler;
    private readonly CancellationToken _ct;

    public GetDepartmentsQueryTest(DatabaseFixture databaseFixture)
    {
        _databaseFixture = databaseFixture;
        _queryHandler = new GetDepartmentsQueryHandler(_databaseFixture.Context);
        _ct = new CancellationToken();
    }
}