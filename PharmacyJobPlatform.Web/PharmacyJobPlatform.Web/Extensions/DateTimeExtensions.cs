using System.Globalization;

namespace PharmacyJobPlatform.Web.Extensions;

public static class DateTimeExtensions
{
    private static readonly TimeZoneInfo TurkeyTimeZone = ResolveTurkeyTimeZone();

    public static DateTime ToTurkeyTime(this DateTime dateTime)
    {
        var utcDateTime = dateTime.Kind switch
        {
            DateTimeKind.Unspecified => DateTime.SpecifyKind(dateTime, DateTimeKind.Utc),
            DateTimeKind.Local => dateTime.ToUniversalTime(),
            _ => dateTime
        };

        return TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, TurkeyTimeZone);
    }

    public static DateTime? ToTurkeyTime(this DateTime? dateTime)
    {
        return dateTime.HasValue ? dateTime.Value.ToTurkeyTime() : null;
    }


    public static string ToTurkeyDateString(this DateTime? dateTime)
    {
        return dateTime.HasValue ? dateTime.Value.ToTurkeyDateString() : string.Empty;
    }

    public static string ToTurkeyDateTimeString(this DateTime? dateTime)
    {
        return dateTime.HasValue ? dateTime.Value.ToTurkeyDateTimeString() : string.Empty;
    }

    public static string ToTurkeyTimeString(this DateTime? dateTime)
    {
        return dateTime.HasValue ? dateTime.Value.ToTurkeyTimeString() : string.Empty;
    }

    public static string ToTurkeyDateString(this DateTime dateTime)
    {
        return dateTime.ToTurkeyTime().ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
    }

    public static string ToTurkeyDateTimeString(this DateTime dateTime)
    {
        return dateTime.ToTurkeyTime().ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
    }

    public static string ToTurkeyTimeString(this DateTime dateTime)
    {
        return dateTime.ToTurkeyTime().ToString("HH:mm", CultureInfo.InvariantCulture);
    }

    private static TimeZoneInfo ResolveTurkeyTimeZone()
    {
        try
        {
            return TimeZoneInfo.FindSystemTimeZoneById("Turkey Standard Time");
        }
        catch (TimeZoneNotFoundException)
        {
            return TimeZoneInfo.FindSystemTimeZoneById("Europe/Istanbul");
        }
    }
}
