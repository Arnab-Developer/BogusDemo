namespace BogusDemo.Application.Commands;

/// <summary>A command to create a room inside a department.</summary>
/// <param name="DepartmentId">The id of the existing department.</param>
/// <param name="RoomNumber">The number of the room.</param>
public record CreateRoomCommand(int DepartmentId, string RoomNumber) : IRequest<bool>;

public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, bool>
{
    private readonly IDepartmentRepo _departmentRepo;

    public CreateRoomCommandHandler(IDepartmentRepo departmentRepo)
    {
        _departmentRepo = departmentRepo;
    }

    async Task<bool> IRequestHandler<CreateRoomCommand, bool>.Handle(
        CreateRoomCommand request, CancellationToken ct)
    {
        var department = await _departmentRepo.GetAsync(request.DepartmentId, ct)
            .ConfigureAwait(false);

        department.CreateRoom(request.RoomNumber);
        await _departmentRepo.SaveChangesAsync(ct).ConfigureAwait(false);
        return true;
    }
}