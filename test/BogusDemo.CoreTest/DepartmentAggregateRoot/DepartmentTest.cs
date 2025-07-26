namespace BogusDemo.CoreTest.DepartmentAggregateRoot;

public partial class DepartmentTest
{
    private readonly Department _department;

    public DepartmentTest()
    {
        _department = new Department("Test Department");
    }
}