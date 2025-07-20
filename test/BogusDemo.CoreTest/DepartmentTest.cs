using BogusDemo.Core;

namespace BogusDemo.CoreTest;

public partial class DepartmentTest
{
    private readonly Department _department;

    public DepartmentTest()
    {
        _department = new Department("Test Department");
    }
}