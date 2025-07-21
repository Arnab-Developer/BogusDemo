namespace BogusDemo.Application.Commands;

public record DeleteRoomCommand(int DepartmentId, int RoomId) : IRequest<bool>;

public class DeleteRoomCommandHandler : IRequestHandler<DeleteRoomCommand, bool>
{
    private readonly IDepartmentRepo _departmentRepo;

    public DeleteRoomCommandHandler(IDepartmentRepo departmentRepo)
    {
        _departmentRepo = departmentRepo;
    }

    async Task<bool> IRequestHandler<DeleteRoomCommand, bool>.Handle(
        DeleteRoomCommand request, CancellationToken ct)
    {
        var department = await _departmentRepo.GetAsync(request.DepartmentId, ct)
            .ConfigureAwait(false);

        department.DeleteRoom(request.RoomId);
        await _departmentRepo.SaveChangesAsync(ct).ConfigureAwait(false);
        return true;
    }
}