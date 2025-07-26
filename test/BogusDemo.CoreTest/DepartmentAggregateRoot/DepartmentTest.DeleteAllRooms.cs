namespace BogusDemo.CoreTest.DepartmentAggregateRoot;

public partial class DepartmentTest
{
    [Fact]
    public void DeleteAllRoom_WorkProperly_GivenValidInput()
    {
        // Arrange
        var inputName = new Faker().Random.String2(10);
        _department.CreateRoom(inputName);

        // Act
        _department.DeleteAllRooms();

        // Assert
        _department.Rooms.ShouldBeEmpty();
    }
}