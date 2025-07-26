namespace BogusDemo.ApplicationTest.Queries;

public partial class GetDepartmentsQueryTest
{
    [Theory]
    [InlineData(1, 2, "d1", "r1", "d2", "r2")]
    [InlineData(2, 2, "d3", "r3", "d4", "r4")]
    public async Task Handle_ReturnProperData_GivenValidInput(
        int pageNumber, int pageSize, params string[] data)
    {
        // Arrange
        _query = new GetDepartmentsQuery(pageNumber, pageSize);

        // Act
        var departmentDTOs = await _queryHandler.Handle(_query, _ct);

        // Assert
        departmentDTOs.Count().ShouldBe(pageSize);

        departmentDTOs.ElementAt(0).Name.ShouldBe(data[0]);
        departmentDTOs.ElementAt(0).Rooms.ElementAt(0).RoomNumber.ShouldBe(data[1]);

        departmentDTOs.ElementAt(1).Name.ShouldBe(data[2]);
        departmentDTOs.ElementAt(1).Rooms.ElementAt(0).RoomNumber.ShouldBe(data[3]);
    }
}