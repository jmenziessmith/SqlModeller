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
        Bit,
        BitMax,
    }

    public static class AggregateExtensions
    {
        public static string ToSqlString(this Aggregate value)
        {
            if (value == Aggregate.None)
            {
                return null;
            }
            if (value == Aggregate.Bit)
            {
                return Aggregate.Min.ToString().ToUpper();
            }
            if (value == Aggregate.BitMax)
            {
                return Aggregate.Max.ToString().ToUpper();
            }

            return value.ToString().ToUpper();
        }
    }
}