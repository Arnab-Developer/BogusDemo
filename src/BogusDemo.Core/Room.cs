using Ardalis.GuardClauses;

namespace BogusDemo.Core;

/// <summary>The room class.</summary>
public class Room : BaseModel
{
    private string _roomNumber;
    private Department? _department;

    public Room()
    {
        _roomNumber = string.Empty;
        _department = null;
    }

    /// <summary>Create a new object of the room class.</summary>
    /// <param name="number">The number of the room.</param>
    public Room(string number)
    {
        _roomNumber = Guard.Against.NullOrWhiteSpace(number);
        _department = null;
    }

    /// <summary>Gets the number of the room.</summary>
    public string RoomNumber
    {
        get
        {
            return _roomNumber;
        }
        private set
        {
            _roomNumber = Guard.Against.NullOrWhiteSpace(value);
        }
    }

    /// <summary>Gets the department of the room.</summary>
    public Department? Department
    {
        get
        {
            return _department;
        }
        private set
        {
            _department = value;
        }
    }

    /// <summary>Change the number of the room.</summary>
    /// <param name="number">The new room number.</param>
    internal void ChangeRoomNumber(string number)
    {
        _roomNumber = Guard.Against.NullOrWhiteSpace(number);
    }
}