namespace BogusDemo.Application.Commands;

public record DeleteDepartmentCommand(int DepartmentId) : IRequest<bool>;

public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand, bool>
{
    private readonly IDepartmentRepo _departmentRepo;

    public DeleteDepartmentCommandHandler(IDepartmentRepo departmentRepo)
    {
        _departmentRepo = departmentRepo;
    }

    async Task<bool> IRequestHandler<DeleteDepartmentCommand, bool>.Handle(
        DeleteDepartmentCommand request, CancellationToken ct)
    {
        var department = await _departmentRepo.GetAsync(request.DepartmentId, ct)
            .ConfigureAwait(false);

        department.DeleteAllRooms();
        await _departmentRepo.DeleteAsync(department, ct).ConfigureAwait(false);
        await _departmentRepo.SaveChangesAsync(ct).ConfigureAwait(false);
        return true;
    }
}