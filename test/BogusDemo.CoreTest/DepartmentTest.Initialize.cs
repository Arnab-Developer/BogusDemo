namespace BogusDemo.CoreTest;

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
}