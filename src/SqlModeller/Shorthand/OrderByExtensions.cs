using SqlModeller.Model;
using SqlModeller.Model.Order;

namespace SqlModeller.Shorthand
{
    public static partial class Shorthand
    {
        public static SelectQuery OrderBy(this SelectQuery query, Table table, string field, OrderDir direction = OrderDir.Asc, Aggregate aggregate = Aggregate.None)
        {
            query.OrderBy(table.Alias, field, direction, aggregate);
            return query;
        }

        public static SelectQuery OrderBy(this SelectQuery query, string tableAlias, string field, OrderDir direction = OrderDir.Asc, Aggregate aggregate = Aggregate.None)
        {
            var orderBy = new OrderByColumn(tableAlias, field, direction, aggregate);
            query.OrderByColumns.Add(orderBy);
            return query;
        }

        public static SelectQuery OrderByDesc(this SelectQuery query, Table table, string field, Aggregate aggregate = Aggregate.None)
        {
            query.OrderByDesc(table.Alias, field, aggregate);
            return query;
        }

        public static SelectQuery OrderByDesc(this SelectQuery query, string tableAlias, string field, Aggregate aggregate = Aggregate.None)
        {
            query.OrderBy(tableAlias, field, OrderDir.Desc, aggregate);
            return query;
        }
    }
}
