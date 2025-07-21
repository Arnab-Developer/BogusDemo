namespace BogusDemo.ApplicationTest.Commands;

public partial class DeleteDepartmentCommandTest
{
    [Fact]
    public async Task Handler_WorkProperly_GivenValidInput()
    {
        // Arrange
        var department = new Department("Test Department");
        department.CreateRoom("R001");
        _command = new DeleteDepartmentCommand(1);

        _repoMock
            .Setup(r => r.GetAsync(1, _ct))
            .ReturnsAsync(department);

        _repoMock.Setup(r => r.DeleteAsync(department, _ct));
        _repoMock.Setup(r => r.SaveChangesAsync(_ct));

        // Act
        var isSuccess = await _commandHandler.Handle(_command, _ct);

        // Assert
        isSuccess.ShouldBeTrue();
        department.Rooms.ShouldBeEmpty();

        _repoMock.Verify(r => r.GetAsync(1, _ct), Times.Once());
        _repoMock.Verify(r => r.DeleteAsync(department, _ct), Times.Once());
        _repoMock.Verify(r => r.SaveChangesAsync(_ct), Times.Once());
        _repoMock.VerifyNoOtherCalls();
    }
}