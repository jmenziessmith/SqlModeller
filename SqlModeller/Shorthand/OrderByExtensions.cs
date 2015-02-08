using SqlModeller.Model;
using SqlModeller.Model.Order;

namespace SqlModeller.Shorthand
{
    public static partial class Shorthand
    {
        public static SelectQuery OrderBy(this SelectQuery query, Table table, string field, OrderDir direction = OrderDir.Asc)
        {
            query.OrderBy(table.Alias, field, direction);
            return query;
        }

        public static SelectQuery OrderBy(this SelectQuery query, string tableAlias, string field, OrderDir direction = OrderDir.Asc)
        {
            var orderBy = new OrderByColumn(tableAlias, field, direction);
            query.OrderByColumns.Add(orderBy);
            return query;
        }  

        public static SelectQuery OrderByDesc(this SelectQuery query, Table table, string field)
        {
            query.OrderByDesc(table.Alias, field);
            return query;
        }

        public static SelectQuery OrderByDesc(this SelectQuery query, string tableAlias, string field)
        {
            query.OrderBy(tableAlias, field, OrderDir.Desc);
            return query;
        }
    }
}
