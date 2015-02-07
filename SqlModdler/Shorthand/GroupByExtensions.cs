using SqlModdler.Model;

namespace SqlModdler.Shorthand
{
    public static partial class Shorthand
    {
        public static SelectQuery GroupBy(this SelectQuery query, Table table, string field)
        {
            query.GroupBy(table.Alias, field);
            return query;
        }

        public static SelectQuery GroupBy(this SelectQuery query, string tableAlias, string field)
        {
            var groupBy = new Column(tableAlias, field);
            query.GroupByColumns.Add(groupBy);
            return query;
        }
    }
}
