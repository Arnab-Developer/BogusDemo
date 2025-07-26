namespace BogusDemo.CoreTest.DepartmentAggregateRoot;

public partial class DepartmentTest
{
    [Fact]
    public void CreateRoom_WorkProperly_GivenValidInput()
    {
        // Arrange
        var inputName = new Faker().Random.String2(10);

        // Act
        _department.CreateRoom(inputName);

        // Assert
        _department.Rooms.Count.ShouldBe(1);

        var room = _department.Rooms[0];
        room.RoomNumber.ShouldBe(inputName);
        room.Department.ShouldBeNull();
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void CreateRoom_ThrowException_GivenInvalidInput(string number)
    {
        // Act
        var createRoom = () => _department.CreateRoom(number);

        // Assert
        var exception = createRoom.ShouldThrow<ArgumentException>();
        exception.Message.ShouldBe("Required input number was empty. (Parameter 'number')");
    }
}