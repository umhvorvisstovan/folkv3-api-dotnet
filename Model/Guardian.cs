namespace Us.FolkV3.Api.Model;

public class Guardian
{
    public Name Name { get; }
    public Address Address { get; }
    public Guardian(Name name, Address address)
    {
        Name = Util.RequireNonNull(name, "name");
        Address = Util.RequireNonNull(address, "address");
    }
}
