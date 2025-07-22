namespace BogusDemo.Application.Commands;

/// <summary>A command to update a room in a department.</summary>
/// <param name="DepartmentId">The id of the existing department.</param>
/// <param name="RoomId">The id of the existing room.</param>
/// <param name="RoomNumber">The new number of the room.</param>
public record ChangeRoomCommand(int DepartmentId, int RoomId, string RoomNumber) : IRequest<bool>;

public class ChangeRoomCommandHandler : IRequestHandler<ChangeRoomCommand, bool>
{
    private readonly IDepartmentRepo _departmentRepo;

    public ChangeRoomCommandHandler(IDepartmentRepo departmentRepo)
    {
        _departmentRepo = departmentRepo;
    }

    async Task<bool> IRequestHandler<ChangeRoomCommand, bool>.Handle(
        ChangeRoomCommand request, CancellationToken ct)
    {
        var department = await _departmentRepo.GetAsync(request.DepartmentId, ct)
            .ConfigureAwait(false);

        department.ChangeRoom(request.RoomId, request.RoomNumber);
        await _departmentRepo.SaveChangesAsync(ct).ConfigureAwait(false);
        return true;
    }
}
