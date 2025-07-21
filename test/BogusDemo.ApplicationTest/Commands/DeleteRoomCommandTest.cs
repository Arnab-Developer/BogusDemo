namespace BogusDemo.ApplicationTest.Commands;

public partial class DeleteRoomCommandTest
{
    private DeleteRoomCommand? _command;
    private readonly IRequestHandler<DeleteRoomCommand, bool> _commandHandler;
    private readonly Mock<IDepartmentRepo> _repoMock;
    private readonly CancellationToken _ct;

    public DeleteRoomCommandTest()
    {
        _repoMock = new Mock<IDepartmentRepo>();
        _commandHandler = new DeleteRoomCommandHandler(_repoMock.Object);
        _ct = CancellationToken.None;
    }
}