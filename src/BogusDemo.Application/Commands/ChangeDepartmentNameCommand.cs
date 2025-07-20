using BogusDemo.Infra;
using MediatR;

namespace BogusDemo.Application.Commands;

public record ChangeDepartmentNameCommand(int Id, string Name) : IRequest<bool>;

public class ChangeDepartmentNameCommandHandler : IRequestHandler<ChangeDepartmentNameCommand, bool>
{
    private readonly IDepartmentRepo _departmentRepo;

    public ChangeDepartmentNameCommandHandler(IDepartmentRepo departmentRepo)
    {
        _departmentRepo = departmentRepo;
    }

    async Task<bool> IRequestHandler<ChangeDepartmentNameCommand, bool>.Handle(
        ChangeDepartmentNameCommand request,
        CancellationToken ct)
    {
        var department = await _departmentRepo.GetAsync(request.Id, ct).ConfigureAwait(false);
        department.ChangeName(request.Name);
        await _departmentRepo.SaveChangesAsync(ct).ConfigureAwait(false);
        return true;
    }
}