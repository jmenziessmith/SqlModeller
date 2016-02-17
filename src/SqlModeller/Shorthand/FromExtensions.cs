using SqlModeller.Model;
using SqlModeller.Model.From;
using System;
using System.Collections.Generic;

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



        public static List<TableJoin> Join(this List<TableJoin> list, string table, string tableAlias, string joinField, string foreignColumnTableAlias, string foreignColumnField, JoinType joinType = JoinType.Join, string extra = null)
        {
            var joinTable = new Table(tableAlias, table);
            list.Join(joinTable, joinField, foreignColumnTableAlias, foreignColumnField, joinType, extra);
            return list;
        }
        public static List<TableJoin> Join(this List<TableJoin> list, Table joinTable, string joinField, string foreignColumnTableAlias, string foreignColumnField, JoinType joinType = JoinType.Join, string extra = null)
        {
            var column = new JoinColumn(foreignColumnTableAlias, foreignColumnField);
            list.Join(joinTable, joinField, column, joinType, extra);
            return list;
        }
        public static List<TableJoin> Join(this List<TableJoin> list, Table joinTable, string joinField, Table foreignTable, string foreignColumnField, JoinType joinType = JoinType.Join, string extra = null)
        {
            var column = new JoinColumn(foreignTable.Alias, foreignColumnField);
            list.Join(joinTable, joinField, column, joinType, extra);
            return list;
        }
        public static List<TableJoin> Join(this List<TableJoin> list, Table table, string joinField, JoinColumn foreignColumn, JoinType joinType = JoinType.Join, string extra = null)
        {
            var join = new TableJoin()
            {
                JoinType = joinType,
                JoinTable = table,
                JoinField = new Field(joinField),
                ForeignColumn = foreignColumn,
                Extra = extra
            };

            list.Add(join);
            return list;
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




        public static SelectQuery GroupedJoin(this SelectQuery query, Table joinTable, string joinField, Table foreignTable, string foreignColumnField, Func<List<TableJoin>,List<TableJoin>> groupedJoins, JoinType joinType = JoinType.Join, string extra = null)
        {
            var column = new JoinColumn(foreignTable.Alias, foreignColumnField);
            query.GroupedJoin(joinTable, joinField, column, groupedJoins.Invoke(new List<TableJoin>()), joinType, extra);
            return query;
        }
        public static SelectQuery GroupedJoin(this SelectQuery query, string table, string tableAlias, string joinField, string foreignColumnTableAlias, string foreignColumnField, List<TableJoin> groupedJoins, JoinType joinType = JoinType.Join, string extra = null)
        {
            var joinTable = new Table(tableAlias, table);
            query.GroupedJoin(joinTable, joinField, foreignColumnTableAlias, foreignColumnField, groupedJoins, joinType, extra);
            return query;
        }
        public static SelectQuery GroupedJoin(this SelectQuery query, Table joinTable, string joinField, string foreignColumnTableAlias, string foreignColumnField, List<TableJoin> groupedJoins, JoinType joinType = JoinType.Join, string extra = null)
        {
            var column = new JoinColumn(foreignColumnTableAlias, foreignColumnField);
            query.GroupedJoin(joinTable, joinField, column, groupedJoins, joinType, extra);
            return query;
        }
        public static SelectQuery GroupedJoin(this SelectQuery query, Table joinTable, string joinField, Table foreignTable, string foreignColumnField, List<TableJoin> groupedJoins, JoinType joinType = JoinType.Join, string extra = null)
        {
            var column = new JoinColumn(foreignTable.Alias, foreignColumnField);
            query.GroupedJoin(joinTable, joinField, column, groupedJoins, joinType, extra);
            return query;
        }
        public static SelectQuery GroupedJoin(this SelectQuery query, Table table, string joinField, JoinColumn foreignColumn, List<TableJoin> groupedJoins, JoinType joinType = JoinType.Join, string extra = null)
        {
            var join = new GroupedTableJoin()
            {
                JoinType = joinType,
                JoinTable = table,
                JoinField = new Field(joinField),
                ForeignColumn = foreignColumn,
                Extra = extra,
                GroupedJoins = groupedJoins
            };

            query.TableJoins.Add(join);
            return query;
        }
    }
}
