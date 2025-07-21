namespace BogusDemo.ApplicationTest.Commands;

public partial class ChangeDepartmentNameCommandTest
{
    private ChangeDepartmentNameCommand? _command;
    private readonly IRequestHandler<ChangeDepartmentNameCommand, bool> _commandHandler;
    private readonly Mock<IDepartmentRepo> _repoMock;
    private readonly CancellationToken _ct;

    public ChangeDepartmentNameCommandTest()
    {        
        _repoMock = new Mock<IDepartmentRepo>();
        _commandHandler = new ChangeDepartmentNameCommandHandler(_repoMock.Object);
        _ct = CancellationToken.None;
    }
}