namespace BogusDemo.ApplicationTest.Commands;

public partial class ChangeRoomCommandTest
{
    private ChangeRoomCommand? _command;
    private readonly IRequestHandler<ChangeRoomCommand, bool> _commandHandler;
    private readonly Mock<IDepartmentRepo> _repoMock;
    private readonly CancellationToken _ct;

    public ChangeRoomCommandTest()
    {
        _repoMock = new Mock<IDepartmentRepo>();
        _commandHandler = new ChangeRoomCommandHandler(_repoMock.Object);
        _ct = CancellationToken.None;
    }
}