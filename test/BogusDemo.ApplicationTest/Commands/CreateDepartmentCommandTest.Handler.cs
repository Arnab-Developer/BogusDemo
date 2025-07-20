namespace BogusDemo.ApplicationTest.Commands;

public partial class CreateDepartmentCommandTest
{
    [Fact]
    public async Task Handler_WorkProperly_GivenValidInput()
    {
        // Arrange
        _repoMock.Setup(r => r.AddAsync(It.IsAny<Department>(), _ct));
        _repoMock.Setup(r => r.SaveChangesAsync(_ct));

        // Act
        var isSuccess = await _commandHandler.Handle(_command, _ct);

        // Assert
        isSuccess.ShouldBeTrue();

        _repoMock.Verify(
            r => r.AddAsync(It.Is<Department>(d => d.Name == "Test Department"), _ct),
            Times.Once());

        _repoMock.Verify(r => r.SaveChangesAsync(_ct), Times.Once());
        _repoMock.VerifyNoOtherCalls();
    }
}