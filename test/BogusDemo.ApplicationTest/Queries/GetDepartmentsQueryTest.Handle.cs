namespace BogusDemo.ApplicationTest.Queries;

public partial class GetDepartmentsQueryTest
{
    [Theory]
    [InlineData(1, "d1", "r1", "d2", "r2")]
    [InlineData(2, "d3", "r3", "d4", "r4")]
    public async Task Handle_ReturnProperData_GivenPageSizeTwo(
        int pageNumber, params string[] data)
    {
        // Arrange
        _query = new GetDepartmentsQuery(pageNumber, 2);

        // Act
        var departmentDTOs = await _queryHandler.Handle(_query, _ct);

        // Assert
        departmentDTOs.Count().ShouldBe(2);

        departmentDTOs.ElementAt(0).Name.ShouldBe(data[0]);
        departmentDTOs.ElementAt(0).Rooms.ElementAt(0).RoomNumber.ShouldBe(data[1]);

        departmentDTOs.ElementAt(1).Name.ShouldBe(data[2]);
        departmentDTOs.ElementAt(1).Rooms.ElementAt(0).RoomNumber.ShouldBe(data[3]);
    }

    [Fact]
    public async Task Handle_ReturnProperData_GivenPageSizeFour()
    {
        // Arrange
        _query = new GetDepartmentsQuery(1, 4);

        // Act
        var departmentDTOs = await _queryHandler.Handle(_query, _ct);

        // Assert
        departmentDTOs.Count().ShouldBe(4);

        departmentDTOs.ElementAt(0).Name.ShouldBe("d1");
        departmentDTOs.ElementAt(0).Rooms.ElementAt(0).RoomNumber.ShouldBe("r1");

        departmentDTOs.ElementAt(1).Name.ShouldBe("d2");
        departmentDTOs.ElementAt(1).Rooms.ElementAt(0).RoomNumber.ShouldBe("r2");

        departmentDTOs.ElementAt(2).Name.ShouldBe("d3");
        departmentDTOs.ElementAt(2).Rooms.ElementAt(0).RoomNumber.ShouldBe("r3");

        departmentDTOs.ElementAt(3).Name.ShouldBe("d4");
        departmentDTOs.ElementAt(3).Rooms.ElementAt(0).RoomNumber.ShouldBe("r4");
    }
}