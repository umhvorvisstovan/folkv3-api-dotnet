namespace Us.FolkV3.Api.Model;

public class HouseNumber
{
    public int Number { get; }
    public char? Letter { get; }
    public string Value { get; }
    public bool HasLetter { get { return Letter != null; } }

    private HouseNumber(int number, char? letter = null)
    {
        Number = number;
        Letter = letter;
        Value = $"{number}{letter}";
    }

    public static HouseNumber Create(int number, char? letter = null)
    {
        return new HouseNumber(number, letter);
    }

    public static HouseNumber Create(string value)
    {
        value = Util.RequireNonNull(value, "value").Trim();
        char? letter = ExtractLetter(value);
        var number = int.Parse(letter == null ? value : value.Substring(0, value.Length - 1));
        return new HouseNumber(number, letter);
    }

    public override int GetHashCode()
    {
        return Util.HashCode(Number, Letter);
    }

    public override bool Equals(object obj)
    {
        if (obj == this)
        {
            return true;
        }
        if (!(obj is HouseNumber))
        {
            return false;
        }
        var other = (HouseNumber)obj;
        return Number.Equals(other.Number) && (Letter == null ? other.Letter == null : Letter.Equals(other.Letter));
    }

    public override string ToString()
    {
        return Value;
    }

    private static char? ExtractLetter(string value)
    {
        if (value.Length > 1 && char.IsLetter(value[value.Length - 1]))
        {
            return value[value.Length - 1];
        }
        return null;
    }
}
