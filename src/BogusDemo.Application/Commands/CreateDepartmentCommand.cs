using BogusDemo.Core;
using BogusDemo.Infra;
using MediatR;

namespace BogusDemo.Application.Commands;

public record CreateDepartmentCommand(string Name) : IRequest<bool>;

public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, bool>
{
    private readonly BogusDemoContext _context;

    public CreateDepartmentCommandHandler(BogusDemoContext context)
    {
        _context = context;
    }

    async Task<bool> IRequestHandler<CreateDepartmentCommand, bool>.Handle(
        CreateDepartmentCommand request,
        CancellationToken ct)
    {
        var department = new Department(request.Name);
        await _context.Departments.AddAsync(department, ct).ConfigureAwait(false);
        await _context.SaveChangesAsync(ct).ConfigureAwait(false);
        return true;
    }
}