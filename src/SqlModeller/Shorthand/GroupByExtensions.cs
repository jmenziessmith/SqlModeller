using SqlModeller.Model;
using SqlModeller.Model.GroupBy;

namespace SqlModeller.Shorthand
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
            var groupBy = new GroupByColumn(tableAlias, field);
            query.GroupByColumns.Add(groupBy);
            return query;
        }


        public static SelectQuery GroupByDatePart(this SelectQuery query, Table table, string field, DatePart datePart)
        {
            return query.GroupByDatePart(table.Alias, field, datePart);
        }

        public static SelectQuery GroupByDatePart(this SelectQuery query, string tableAlias, string field, DatePart datePart)
        {
            var groupBy = new GroupByColumnDatePart(tableAlias, field, datePart);
            query.GroupByColumns.Add(groupBy);
            return query;
        }
    }
}
