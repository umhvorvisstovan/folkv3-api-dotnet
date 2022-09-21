using System.Globalization;

namespace Us.FolkV3.Api;

internal static class Util
{
    public static T RequireNonNull<T>(T value, string name)
    {
        if (value == null)
        {
            throw new ArgumentNullException($"{name} must not be null");
        }
        return value;
    }

    public static int HashCode(params Object[] elements)
    {
        if (elements == null)
        {
            return 0;
        }
        int result = 1;
        foreach (var element in elements)
        {
            result = 31 * result + (element == null ? 0 : element.GetHashCode());
        }
        return result;
    }

    public static long CurrentTimeMillis() =>
        new DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds();

    public static string ToISOString(this DateTime dateTime) =>
        dateTime.ToString("s", CultureInfo.InvariantCulture);
}
