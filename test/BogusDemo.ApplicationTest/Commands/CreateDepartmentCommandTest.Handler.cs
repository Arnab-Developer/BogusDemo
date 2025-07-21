namespace BogusDemo.ApplicationTest.Commands;

public partial class CreateDepartmentCommandTest
{
    [Fact]
    public async Task Handler_WorkProperly_GivenValidInput()
    {
        // Arrange
        _command = new CreateDepartmentCommand("Test Department");

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

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public async Task Handler_ThrowsException_GivenInvalidInput(string name)
    {
        // Arrange
        _command = new CreateDepartmentCommand(name);

        _repoMock.Setup(r => r.AddAsync(It.IsAny<Department>(), _ct));
        _repoMock.Setup(r => r.SaveChangesAsync(_ct));

        // Act
        var func = () => _commandHandler.Handle(_command, _ct);

        // Assert
        var exception = await func.ShouldThrowAsync<ArgumentException>();
        exception.Message.ShouldBe("Required input name was empty. (Parameter 'name')");
    }
}