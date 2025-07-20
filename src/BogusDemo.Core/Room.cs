using Ardalis.GuardClauses;

namespace BogusDemo.Core;

/// <summary>The room class.</summary>
public class Room : BaseModel
{
    private string _roomNumber;
    private readonly Department? _department;

    /// <summary>Create a new object of the room class.</summary>
    /// <param name="number">The number of the room.</param>
    public Room(string number)
    {
        _roomNumber = Guard.Against.NullOrWhiteSpace(number);
    }

    /// <summary>Gets the number of the room.</summary>
    public string RoomNumber
    {
        get
        {
            return _roomNumber;
        }
    }

    /// <summary>Gets the department of the room.</summary>
    public Department? Department
    {
        get
        {
            return _department;
        }
    }

    /// <summary>Change the number of the room.</summary>
    /// <param name="number">The new room number.</param>
    public void ChangeRoomNumber(string number)
    {
        _roomNumber = Guard.Against.NullOrWhiteSpace(number);
    }
}