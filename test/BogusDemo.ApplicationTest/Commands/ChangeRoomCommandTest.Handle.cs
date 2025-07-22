namespace BogusDemo.ApplicationTest.Commands;

public partial class ChangeRoomCommandTest
{
    [Fact]
    public async Task Handler_WorkProperly_GivenValidInput()
    {
        // Arrange
        var department = new Department("Test Department");
        department.CreateRoom("R001");
        _command = new ChangeRoomCommand(1, 0, "R002");

        _repoMock
            .Setup(r => r.GetAsync(1, _ct))
            .ReturnsAsync(department);

        _repoMock.Setup(r => r.SaveChangesAsync(_ct));

        // Act
        var isSuccess = await _commandHandler.Handle(_command, _ct);

        // Assert
        isSuccess.ShouldBeTrue();
        department.Rooms.Count.ShouldBe(1);
        department.Rooms[0].RoomNumber.ShouldBe("R002");

        _repoMock.Verify(r => r.GetAsync(1, _ct), Times.Once());
        _repoMock.Verify(r => r.SaveChangesAsync(_ct), Times.Once());
        _repoMock.VerifyNoOtherCalls();
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public async Task Handler_ThrowsException_GivenInvalidInput(string name)
    {
        // Arrange
        var department = new Department("Test Department");
        department.CreateRoom("R001");
        _command = new ChangeRoomCommand(1, 0, name);

        _repoMock
            .Setup(r => r.GetAsync(1, _ct))
            .ReturnsAsync(department);

        _repoMock.Setup(r => r.SaveChangesAsync(_ct));

        // Act
        var func = () => _commandHandler.Handle(_command, _ct);

        // Assert
        var exception = await func.ShouldThrowAsync<ArgumentException>();
        exception.Message.ShouldBe("Required input value was empty. (Parameter 'value')");

        department.Rooms.Count.ShouldBe(1);
        department.Rooms[0].RoomNumber.ShouldBe("R001");

        _repoMock.Verify(r => r.GetAsync(1, _ct), Times.Once());
        _repoMock.Verify(r => r.SaveChangesAsync(_ct), Times.Never());
        _repoMock.VerifyNoOtherCalls();
    }
}