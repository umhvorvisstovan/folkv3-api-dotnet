namespace Us.FolkV3.Api.Model;

public class Address
{
    public string StreetAndNumbers { get; }
    public string Street { get; }
    public HouseNumber HouseNumber { get; }
    public string Apartment { get; }
    public string PostalCode { get; }
    public string City { get; }
    public Country Country { get; }
    public DateTime? From { get; }
    public bool IsComplete { get { return HasStreet && HasHouseNumber && HasPostalCode && HasCity && HasCountry; } }
    public bool HasStreetAndNumbers { get { return StreetAndNumbers != null; } }
    public bool HasStreet { get { return Street != null; } }
    public bool HasHouseNumber { get { return HouseNumber != null; } }
    public bool HasApartment { get { return Apartment != null; } }
    public bool HasPostalCode { get { return PostalCode != null; } }
    public bool HasCity { get { return City != null; } }
    public bool HasCountry { get { return Country != null; } }

    public Address(string streetAndNumbers, string street, HouseNumber houseNumber, string apartment, string postalCode, string city, Country country, DateTime? from)
    {
        StreetAndNumbers = streetAndNumbers;
        Street = street;
        HouseNumber = houseNumber;
        Apartment = apartment;
        PostalCode = postalCode;
        City = city;
        Country = country;
        From = from;
    }

    public override string ToString()
    {
        return $"{nameof(Address)} {{Street: {Street}; HouseNumber: {HouseNumber}; Apartment: {Apartment}; PostalCode: {PostalCode}; City: {City}; Country: {Country}; From: {From}}}";
    }

    public override int GetHashCode()
    {
        return Util.HashCode(Street, HouseNumber, Apartment, PostalCode, City, Country, From);
    }

    public override bool Equals(object that)
    {
        if (this == that)
        {
            return true;
        }
        if (!(that is Address))
        {
            return false;
        }
        var other = (Address)that;
        return Equals(Street, other.Street)
            && Equals(HouseNumber, other.HouseNumber)
            && Equals(Apartment, other.Apartment)
            && Equals(PostalCode, other.PostalCode)
            && Equals(City, other.City)
            && Equals(Country, other.Country)
            && Equals(From, other.From);
    }
}
