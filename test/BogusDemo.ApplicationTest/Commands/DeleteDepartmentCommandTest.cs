namespace BogusDemo.ApplicationTest.Commands;

public partial class DeleteDepartmentCommandTest
{
    private DeleteDepartmentCommand? _command;
    private readonly IRequestHandler<DeleteDepartmentCommand, bool> _commandHandler;
    private readonly Mock<IDepartmentRepo> _repoMock;
    private readonly CancellationToken _ct;

    public DeleteDepartmentCommandTest()
    {
        _repoMock = new Mock<IDepartmentRepo>();
        _commandHandler = new DeleteDepartmentCommandHandler(_repoMock.Object);
        _ct = CancellationToken.None;
    }
}