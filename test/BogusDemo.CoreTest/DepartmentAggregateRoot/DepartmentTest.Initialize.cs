namespace BogusDemo.CoreTest.DepartmentAggregateRoot;

public partial class DepartmentTest
{
    [Fact]
    public void InitializeProperly_GivenValidInput()
    {
        // Assert
        _department.ShouldNotBeNull();
        _department.Name.ShouldBe("Test Department");
        _department.Rooms.ShouldBeEmpty();
    }

    [Fact]
    public void ThrowsException_GivenEmptyInput()
    {
        // Act
        var func = () => new Department("");

        // Assert
        var exception = func.ShouldThrow<ArgumentException>();
        exception.Message.ShouldBe("Required input name was empty. (Parameter 'name')");
    }
}