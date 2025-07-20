namespace BogusDemo.CoreTest;

public partial class DepartmentTest
{
    [Fact]
    public void ChangeName_WorkProperly_GivenValidInput()
    {
        // Arrange
        var inputName = new Faker().Random.String2(10);

        // Act
        _department.ChangeName(inputName);

        // Assert
        _department.Name.ShouldBe(inputName);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void ChangeName_ThrowException_GivenInvalidInput(string name)
    {
        // Act
        var changeName = () => _department.ChangeName(name);

        // Assert
        var exception = changeName.ShouldThrow<ArgumentException>();
        exception.Message.ShouldBe("Required input name was empty. (Parameter 'name')");
    }
}