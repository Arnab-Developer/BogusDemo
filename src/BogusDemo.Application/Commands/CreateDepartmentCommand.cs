using BogusDemo.Core;
using BogusDemo.Infra;
using MediatR;

namespace BogusDemo.Application.Commands;

public record CreateDepartmentCommand(string Name) : IRequest<bool>;

public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, bool>
{
    private readonly IDepartmentRepo _departmentRepo;

    public CreateDepartmentCommandHandler(IDepartmentRepo departmentRepo)
    {
        _departmentRepo = departmentRepo;
    }

    async Task<bool> IRequestHandler<CreateDepartmentCommand, bool>.Handle(
        CreateDepartmentCommand request,
        CancellationToken ct)
    {
        var department = new Department(request.Name);
        await _departmentRepo.AddAsync(department, ct).ConfigureAwait(false);
        await _departmentRepo.SaveChangesAsync(ct).ConfigureAwait(false);
        return true;
    }
}