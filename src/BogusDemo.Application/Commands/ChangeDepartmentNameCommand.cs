using BogusDemo.Infra;
using MediatR;

namespace BogusDemo.Application.Commands;

public record ChangeDepartmentNameCommand(int Id, string Name) : IRequest<bool>;

public class ChangeDepartmentNameCommandHandler : IRequestHandler<ChangeDepartmentNameCommand, bool>
{
    private readonly BogusDemoContext _context;

    public ChangeDepartmentNameCommandHandler(BogusDemoContext context)
    {
        _context = context;
    }

    async Task<bool> IRequestHandler<ChangeDepartmentNameCommand, bool>.Handle(
        ChangeDepartmentNameCommand request,
        CancellationToken ct)
    {
        var department = _context.Departments.First(d => d.Id == request.Id);
        department.ChangeName(request.Name);
        await _context.SaveChangesAsync(ct).ConfigureAwait(false);
        return true;
    }
}