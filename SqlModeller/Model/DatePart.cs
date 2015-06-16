namespace SqlModeller.Model
{
    public enum DatePart
    {
        // standard
        Year,
        Quarter,
        Month,
        Dayofyear,
        Day,
        Week,
        Weekday,
        Hour,
        Minute,
        Second,
        Millisecond,
        Microsecond,
        Nanosecond,
        Zoffset,
        ISO_WEEK, 
    }

    public static class DatePartExtensions
    {
        public static string ToSqlString(this DatePart value)
        {
            return value.ToString().ToUpper();
        }
    }
}