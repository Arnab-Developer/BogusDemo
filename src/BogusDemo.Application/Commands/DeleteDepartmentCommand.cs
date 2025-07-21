using BogusDemo.Infra;
using MediatR;

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
        await _departmentRepo.DeleteAsync(request.DepartmentId, ct).ConfigureAwait(false);
        await _departmentRepo.SaveChangesAsync(ct).ConfigureAwait(false);
        return true;
    }
}