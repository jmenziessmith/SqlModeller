using SqlModeller.Model;
using SqlModeller.Model.From;

namespace SqlModeller.Shorthand
{
    public static partial class Shorthand
    {
        // FROM 

        public static SelectQuery From(this SelectQuery query, string table, string tableAlias)
        {
            var fromTable = new Table(tableAlias, table);
            query.From(fromTable);
            return query;
        }
        public static SelectQuery From(this SelectQuery query, Table table)
        {
            query.FromTable = table;
            return query;
        } 

        //JOIN 

        public static SelectQuery Join(this SelectQuery query, string table, string tableAlias, string joinField, string foreignColumnTableAlias, string foreignColumnField, JoinType joinType = JoinType.Join, string extra = null)
        {
            var joinTable = new Table(tableAlias, table);
            query.Join(joinTable, joinField, foreignColumnTableAlias, foreignColumnField, joinType, extra);
            return query;
        }
        public static SelectQuery Join(this SelectQuery query, Table joinTable, string joinField, string foreignColumnTableAlias, string foreignColumnField, JoinType joinType = JoinType.Join, string extra = null)
        {
            var column = new JoinColumn(foreignColumnTableAlias, foreignColumnField);
            query.Join(joinTable, joinField, column, joinType, extra);
            return query;
        }
        public static SelectQuery Join(this SelectQuery query, Table joinTable, string joinField, Table foreignTable, string foreignColumnField, JoinType joinType = JoinType.Join, string extra = null)
        {
            var column = new JoinColumn(foreignTable.Alias, foreignColumnField);
            query.Join(joinTable, joinField, column, joinType, extra);
            return query;
        }
        public static SelectQuery Join(this SelectQuery query, Table table, string joinField, JoinColumn foreignColumn, JoinType joinType = JoinType.Join, string extra = null)
        {
            var join = new TableJoin()
                       {
                           JoinType = joinType,
                           JoinTable = table,
                           JoinField = new Field(joinField),
                           ForeignColumn = foreignColumn,
                           Extra = extra
                       };

            query.TableJoins.Add(join);
            return query;
        }


        public static SelectQuery LeftJoin(this SelectQuery query, string table, string tableAlias, string joinField, string foreignColumnTableAlias, string foreignColumnField, string extra = null)
        {
            query.Join(table, tableAlias, joinField, foreignColumnTableAlias, foreignColumnField, JoinType.LeftJoin, extra);
            return query;
        }
        public static SelectQuery LeftJoin(this SelectQuery query, Table joinTable, string joinField, string foreignColumnTableAlias, string foreignColumnField, string extra = null)
        {
            query.Join(joinTable, joinField, foreignColumnTableAlias, foreignColumnField, JoinType.LeftJoin, extra);
            return query;
        }
        public static SelectQuery LeftJoin(this SelectQuery query, Table joinTable, string joinField, Table foreignTable, string foreignColumnField, string extra = null)
        {
            query.Join(joinTable, joinField, foreignTable.Alias, foreignColumnField, JoinType.LeftJoin, extra);
            return query;
        }

        public static SelectQuery LeftJoin(this SelectQuery query, Table table, string joinField, JoinColumn foreignColumn, string extra = null)
        {
            query.Join(table, joinField, foreignColumn, JoinType.LeftJoin, extra);
            return query;
        }  

    }
}
