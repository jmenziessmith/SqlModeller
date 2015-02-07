using SqlModdler.Model;

namespace SqlModdler.Shorthand
{
    public static partial class Shorthand
    {
        public static SelectQuery Offset(this SelectQuery query, int? offset)
        {
            query.RowOffset = offset;
            return query;
        }

        public static SelectQuery Fetch(this SelectQuery query, int? limit)
        {
            query.RowLimit = limit;
            return query;
        }

    }
}
