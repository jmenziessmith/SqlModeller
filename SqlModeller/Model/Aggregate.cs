namespace SqlModeller.Model
{
    public enum Aggregate
    {
        None,

        Min,
        Max,
        Sum,
        Avg,
        Count,
    }

    public static class AggregateExtensions
    {
        public static string ToSqlString(this Aggregate value)
        {
            if (value == Aggregate.None)
            {
                return null;
            }

            return value.ToString().ToUpper();
        }
    }
}