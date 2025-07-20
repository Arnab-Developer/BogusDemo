namespace BogusDemo.ApplicationTest.Commands;

public partial class CreateDepartmentCommandTest
{
    private readonly CreateDepartmentCommand _command;
    private readonly IRequestHandler<CreateDepartmentCommand, bool> _commandHandler;
    private readonly Mock<IDepartmentRepo> _repoMock;
    private readonly CancellationToken _ct;

    public CreateDepartmentCommandTest()
    {
        _command = new CreateDepartmentCommand("Test Department");
        _repoMock = new Mock<IDepartmentRepo>();
        _commandHandler = new CreateDepartmentCommandHandler(_repoMock.Object);
        _ct = CancellationToken.None;
    }
}