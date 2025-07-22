namespace BogusDemo.Application.Commands;

/// <summary>A command to change the name of a department.</summary>
/// <param name="Id">The id of the existing department.</param>
/// <param name="Name">The new name of the department.</param>
public record ChangeDepartmentNameCommand(int Id, string Name) : IRequest<bool>;

public class ChangeDepartmentNameCommandHandler : IRequestHandler<ChangeDepartmentNameCommand, bool>
{
    private readonly IDepartmentRepo _departmentRepo;

    public ChangeDepartmentNameCommandHandler(IDepartmentRepo departmentRepo)
    {
        _departmentRepo = departmentRepo;
    }

    async Task<bool> IRequestHandler<ChangeDepartmentNameCommand, bool>.Handle(
        ChangeDepartmentNameCommand request, CancellationToken ct)
    {
        var department = await _departmentRepo.GetAsync(request.Id, ct).ConfigureAwait(false);
        department.ChangeName(request.Name);
        await _departmentRepo.SaveChangesAsync(ct).ConfigureAwait(false);
        return true;
    }
}