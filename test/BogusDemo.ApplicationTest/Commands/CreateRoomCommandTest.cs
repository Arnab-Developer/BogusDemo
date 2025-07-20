namespace BogusDemo.ApplicationTest.Commands;

public partial class CreateRoomCommandTest
{
    private readonly CreateRoomCommand _command;
    private readonly IRequestHandler<CreateRoomCommand, bool> _commandHandler;
    private readonly Mock<IDepartmentRepo> _repoMock;
    private readonly CancellationToken _ct;

    public CreateRoomCommandTest()
    {
        _command = new CreateRoomCommand(1, "R001");
        _repoMock = new Mock<IDepartmentRepo>();
        _commandHandler = new CreateRoomCommandHandler(_repoMock.Object);
        _ct = CancellationToken.None;
    }
}