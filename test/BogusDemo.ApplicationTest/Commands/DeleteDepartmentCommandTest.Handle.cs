namespace BogusDemo.ApplicationTest.Commands;

public partial class DeleteDepartmentCommandTest
{
    [Fact]
    public async Task Handler_WorkProperly_GivenValidInput()
    {
        // Arrange
        _command = new DeleteDepartmentCommand(1);
        var department = new Department("Test Department");

        _repoMock.Setup(r => r.DeleteAsync(1, _ct));
        _repoMock.Setup(r => r.SaveChangesAsync(_ct));

        // Act
        var isSuccess = await _commandHandler.Handle(_command, _ct);

        // Assert
        isSuccess.ShouldBeTrue();

        _repoMock.Verify(r => r.DeleteAsync(1, _ct), Times.Once());
        _repoMock.Verify(r => r.SaveChangesAsync(_ct), Times.Once());
        _repoMock.VerifyNoOtherCalls();
    }
}