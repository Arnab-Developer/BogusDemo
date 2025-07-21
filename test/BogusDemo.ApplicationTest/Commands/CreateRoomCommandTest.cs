namespace BogusDemo.ApplicationTest.Commands;

public partial class CreateRoomCommandTest
{
    private CreateRoomCommand? _command;
    private readonly IRequestHandler<CreateRoomCommand, bool> _commandHandler;
    private readonly Mock<IDepartmentRepo> _repoMock;
    private readonly CancellationToken _ct;

    public CreateRoomCommandTest()
    {
        _repoMock = new Mock<IDepartmentRepo>();
        _commandHandler = new CreateRoomCommandHandler(_repoMock.Object);
        _ct = CancellationToken.None;
    }
}