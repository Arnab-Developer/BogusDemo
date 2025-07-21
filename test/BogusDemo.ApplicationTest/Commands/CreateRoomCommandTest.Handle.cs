namespace BogusDemo.ApplicationTest.Commands;

public partial class CreateRoomCommandTest
{
    [Fact]
    public async Task Handler_WorkProperly_GivenValidInput()
    {
        // Arrange
        _command = new CreateRoomCommand(1, "R001");
        var department = new Department("Test Department");

        _repoMock
            .Setup(r => r.GetAsync(1, _ct))
            .ReturnsAsync(department);

        _repoMock.Setup(r => r.SaveChangesAsync(_ct));

        // Act
        var isSuccess = await _commandHandler.Handle(_command, _ct);

        // Assert
        isSuccess.ShouldBeTrue();
        department.Rooms.Count.ShouldBe(1);
        department.Rooms[0].RoomNumber.ShouldBe("R001");

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
        _command = new CreateRoomCommand(1, name);
        var department = new Department("Test Department");

        _repoMock
            .Setup(r => r.GetAsync(1, _ct))
            .ReturnsAsync(department);

        _repoMock.Setup(r => r.SaveChangesAsync(_ct));

        // Act
        var func = () => _commandHandler.Handle(_command, _ct);

        // Assert
        var exception = await func.ShouldThrowAsync<ArgumentException>();
        exception.Message.ShouldBe("Required input number was empty. (Parameter 'number')");

        department.Rooms.ShouldBeEmpty();

        _repoMock.Verify(r => r.GetAsync(1, _ct), Times.Once());
        _repoMock.Verify(r => r.SaveChangesAsync(_ct), Times.Never());
        _repoMock.VerifyNoOtherCalls();
    }
}