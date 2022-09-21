namespace Us.FolkV3.Api.Model.Param;

public class AddressParam
{
    public string Street { get; }
    public HouseNumber HouseNumber { get; }
    public string City { get; }

    public AddressParam(string street, HouseNumber houseNumber, string city)
    {
        Street = Util.RequireNonNull(street, "street");
        HouseNumber = Util.RequireNonNull(houseNumber, "houseNumber");
        City = Util.RequireNonNull(city, "city");
    }

    public static AddressParam Create(string street, HouseNumber houseNumber, string city) =>
        new AddressParam(street, houseNumber, city);
}
