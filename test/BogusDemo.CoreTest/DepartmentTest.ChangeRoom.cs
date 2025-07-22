namespace BogusDemo.CoreTest;

public partial class DepartmentTest
{
    [Fact]
    public void ChangeRoom_WorkProperly_GivenValidInput()
    {
        // Arrange
        var inputName = new Faker().Random.String2(10);
        _department.CreateRoom("Room 001");

        // Act
        _department.ChangeRoom(0, inputName);

        // Assert
        _department.Rooms.Count.ShouldBe(1);
        _department.Rooms[0].RoomNumber.ShouldBe(inputName);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void ChangeRoom_ThrowException_GivenInvalidInput(string number)
    {
        // Arrange
        _department.CreateRoom("Room 001");

        // Act
        var changeRoom = () => _department.ChangeRoom(0, number);

        // Assert
        var exception = changeRoom.ShouldThrow<ArgumentException>();
        exception.Message.ShouldBe("Required input value was empty. (Parameter 'value')");
    }
}