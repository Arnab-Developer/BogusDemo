namespace BogusDemo.CoreTest;

public partial class DepartmentTest
{
    [Fact]
    public void DeleteRoom_WorkProperly_GivenValidInput()
    {
        // Arrange
        var inputName = new Faker().Random.String2(10);
        _department.CreateRoom(inputName);

        // Act
        _department.DeleteRoom(0);

        // Assert
        _department.Rooms.ShouldBeEmpty();
    }
}