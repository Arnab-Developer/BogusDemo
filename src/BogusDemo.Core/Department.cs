using Ardalis.GuardClauses;

namespace BogusDemo.Core;

/// <summary>The department model class.</summary>
public class Department : BaseModel
{
    private string _name;
    private readonly IList<Room> _rooms;

    public Department()
    {
        _name = string.Empty;
        _rooms = new List<Room>();
    }

    /// <summary>Create a new object of department class.</summary>
    /// <param name="name">The name of the department.</param>
    public Department(string name)
    {
        _name = Guard.Against.NullOrWhiteSpace(name);
        _rooms = new List<Room>();
    }

    /// <summary>Gets the name of the department.</summary>
    public string Name
    {
        get
        {
            return _name;
        }
        private set
        {
            _name = value;
        }
    }

    /// <summary>Gets the rooms of the department.</summary>
    public IReadOnlyList<Room> Rooms
    {
        get
        {
            return _rooms.AsReadOnly();
        }
    }

    /// <summary>Change the name of the department.</summary>
    /// <param name="name">The new name.</param>
    public void ChangeName(string name)
    {
        _name = Guard.Against.NullOrWhiteSpace(name);
    }

    /// <summary>Create a new room in the department.</summary>
    /// <param name="number">The new room number.</param>
    public void CreateRoom(string number)
    {
        var room = new Room(number);
        _rooms.Add(room);
    }

    /// <summary>Change the room of the department.</summary>
    /// <param name="id">The id of the room.</param>
    /// <param name="number">The new number of the room.</param>
    public void ChangeRoom(int id, string number)
    {
        var room = _rooms.First(r => r.Id == id);
        room.ChangeRoomNumber(number);
    }
}