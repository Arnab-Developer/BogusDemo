namespace BogusDemo.Core;

/// <summary>The base model class.</summary>
public abstract class BaseModel
{
    private readonly int _id;

    /// <summary>Gets the value of id.</summary>
    public int Id
    {
        get
        {
            return _id;
        }
    }
}