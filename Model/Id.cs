namespace Us.FolkV3.Api.Model;

public abstract class Id
{
    public int Value { get; }

    protected Id(int value)
    {
        Value = Util.RequireNonNull(value, "value");
        if (value < 0)
        {
            throw new ArgumentException("value must be greater than 0");
        }
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public override bool Equals(object o)
    {
        if (this == o)
        {
            return true;
        }
        if (o == null || !GetType().Equals(o.GetType()))
        {
            return false;
        }
        return Value.Equals(((Id) o).Value);
    }

    public override string ToString()
    {
        return Value.ToString();
    }

}
