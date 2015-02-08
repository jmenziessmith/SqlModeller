using System;
using System.Data;
using SqlModeller.Model;
using SqlModeller.Model.Where;

namespace SqlModeller.Shorthand
{
    public static partial class Shorthand
    {
 
        public static SelectQuery Where(this SelectQuery query, Combine groupingOperator)
        {
            query.WhereFilters.GroupingOperator = groupingOperator;
            return query;
        }



        // WHERE COLLECTION
 
        public static SelectQuery WhereCollection(this SelectQuery query, Combine groupingOperator, WhereFilterCollection collection)
        { 
            query.WhereFilters.WhereCollection(groupingOperator, collection);
            return query;
        }
        public static WhereFilterCollection WhereCollection(this WhereFilterCollection query, Combine groupingOperator, WhereFilterCollection collection)
        {
            collection.GroupingOperator = groupingOperator;
            query.Add(collection);
            return query;
        }

        // WHERE COLUMN COLUMN
 
        public static SelectQuery WhereColumnColumn(this SelectQuery query, Table leftTable, string leftField, Compare comparison, Table rightTable, string rightField)
        {
            query.WhereColumnColumn(leftTable.Alias, leftField, comparison, rightTable.Alias, rightField);
            return query;
        }
        public static SelectQuery WhereColumnColumn(this SelectQuery query, string leftTableAlias, string leftField, Compare comparison, string rightTableAlias, string rightField)
        {
            query.WhereFilters.WhereColumnColumn(leftTableAlias, leftField, comparison, rightTableAlias, rightField);
            return query;
        }

        public static WhereFilterCollection WhereColumnColumn(this WhereFilterCollection query, Table leftTable, string leftField, Compare comparison, Table rightTable, string rightField)
        {
            query.WhereColumnColumn(leftTable.Alias, leftField, comparison, rightTable.Alias, rightField);
            return query;
        }
        public static WhereFilterCollection WhereColumnColumn(this WhereFilterCollection query, string leftTableAlias, string leftField, Compare comparison, string rightTableAlias, string rightField)
        {
            var whereFilter = new ColumnColumnWhereFilter()
                              {
                                  LeftColumn = new Column(leftTableAlias, leftField),
                                  Operator = comparison,
                                  RightColumn = new Column(rightTableAlias, rightField)
                              };
            query.Add(whereFilter);
            return query;
        }


        // WHERE SQL 
        public static SelectQuery Where(this SelectQuery query, string sql)
        {
            query.WhereFilters.Where(sql);
            return query;
        }

        public static WhereFilterCollection Where(this WhereFilterCollection query, string sql)
        {
            query.Add(new SqlWhereFilter(sql));
            return query;
        }


        // WHERE COLUMN VALUE
 
        public static SelectQuery WhereColumnValue(this SelectQuery query, Table leftTable, string leftField, Compare comparison, string rightValue, DbType rightType)
        {
            query.WhereFilters.WhereColumnValue(leftTable.Alias, leftField, comparison, rightValue, rightType);
            return query;
        }
        public static SelectQuery WhereColumnValue(this SelectQuery query, string leftTableAlias, string leftField, Compare comparison, string rightValue, DbType rightType)
        {
            query.WhereFilters.WhereColumnValue(leftTableAlias, leftField, comparison, rightValue, rightType);
            return query;
        } 
        public static WhereFilterCollection WhereColumnValue(this WhereFilterCollection query, Table leftTable, string leftField, Compare comparison, string rightValue, DbType rightType)
        {
            query.WhereColumnValue(leftTable.Alias, leftField, comparison, rightValue, rightType);
            return query;
        }
        public static WhereFilterCollection WhereColumnValue(this WhereFilterCollection query, string leftTableAlias, string leftField, Compare comparison, string rightValue, DbType rightType)
        {
            var whereFilter = new ColumnValueWhereFilter()
                              {
                                  LeftColumn = new Column(leftTableAlias, leftField),
                                  Operator = comparison,
                                  RightValue = new LiteralValue(rightValue, rightType)
                              };
            query.Add(whereFilter);
            return query;
        }

        // int
        public static SelectQuery WhereColumnValue(this SelectQuery query, Table leftTable, string leftField, Compare comparison, int rightValue)
        {
            query.WhereColumnValue(leftTable.Alias, leftField, comparison, rightValue);
            return query;
        }
        public static SelectQuery WhereColumnValue(this SelectQuery query, string leftTableAlias, string leftField, Compare comparison, int rightValue)
        {
            query.WhereFilters.WhereColumnValue(leftTableAlias, leftField, comparison, rightValue);
            return query;
        }
        public static WhereFilterCollection WhereColumnValue(this WhereFilterCollection query, Table leftTable, string leftField, Compare comparison, int rightValue)
        {
            query.WhereColumnValue(leftTable.Alias, leftField, comparison, rightValue);
            return query;
        }
        public static WhereFilterCollection WhereColumnValue(this WhereFilterCollection query, string leftTableAlias, string leftField, Compare comparison, int rightValue)
        {
            query.WhereColumnValue(leftTableAlias, leftField, comparison, rightValue.ToString(), DbType.Int32);
            return query;
        }


        // long
        public static SelectQuery WhereColumnValue(this SelectQuery query, Table leftTable, string leftField, Compare comparison, long rightValue)
        {
            query.WhereColumnValue(leftTable.Alias, leftField, comparison, rightValue);
            return query;
        }
        public static SelectQuery WhereColumnValue(this SelectQuery query, string leftTableAlias, string leftField, Compare comparison, long rightValue)
        {
            query.WhereFilters.WhereColumnValue(leftTableAlias, leftField, comparison, rightValue);
            return query;
        }
        public static WhereFilterCollection WhereColumnValue(this WhereFilterCollection query, Table leftTable, string leftField, Compare comparison, long rightValue)
        {
            query.WhereColumnValue(leftTable.Alias, leftField, comparison, rightValue);
            return query;
        }
        public static WhereFilterCollection WhereColumnValue(this WhereFilterCollection query, string leftTableAlias, string leftField, Compare comparison, long rightValue)
        {
            query.WhereColumnValue(leftTableAlias, leftField, comparison, rightValue.ToString(), DbType.Int64);
            return query;
        }
         

        // double
        public static SelectQuery WhereColumnValue(this SelectQuery query, Table leftTable, string leftField, Compare comparison, double rightValue)
        {
            query.WhereColumnValue(leftTable.Alias, leftField, comparison, rightValue);
            return query;
        }
        public static SelectQuery WhereColumnValue(this SelectQuery query, string leftTableAlias, string leftField, Compare comparison, double rightValue)
        {
            query.WhereFilters.WhereColumnValue(leftTableAlias, leftField, comparison, rightValue);
            return query;
        }
        public static WhereFilterCollection WhereColumnValue(this WhereFilterCollection query, Table leftTable, string leftField, Compare comparison, double rightValue)
        {
            query.WhereColumnValue(leftTable.Alias, leftField, comparison, rightValue);
            return query;
        }
        public static WhereFilterCollection WhereColumnValue(this WhereFilterCollection query, string leftTableAlias, string leftField, Compare comparison, double rightValue)
        {
            query.WhereColumnValue(leftTableAlias, leftField, comparison, rightValue.ToString(), DbType.Double);
            return query;
        }

        // decimal
        public static SelectQuery WhereColumnValue(this SelectQuery query, Table leftTable, string leftField, Compare comparison, decimal rightValue)
        {
            query.WhereColumnValue(leftTable.Alias, leftField, comparison, rightValue);
            return query;
        }
        public static SelectQuery WhereColumnValue(this SelectQuery query, string leftTableAlias, string leftField, Compare comparison, decimal rightValue)
        {
            query.WhereFilters.WhereColumnValue(leftTableAlias, leftField, comparison, rightValue);
            return query;
        }
        public static WhereFilterCollection WhereColumnValue(this WhereFilterCollection query, Table leftTable, string leftField, Compare comparison, decimal rightValue)
        {
            query.WhereColumnValue(leftTable.Alias, leftField, comparison, rightValue);
            return query;
        }
        public static WhereFilterCollection WhereColumnValue(this WhereFilterCollection query, string leftTableAlias, string leftField, Compare comparison, decimal rightValue)
        {
            query.WhereColumnValue(leftTableAlias, leftField, comparison, rightValue.ToString(), DbType.Decimal);
            return query;
        }

        // string
        public static SelectQuery WhereColumnValue(this SelectQuery query, Table table, string leftField, Compare comparison, string rightValue)
        {
            query.WhereColumnValue(table.Alias, leftField, comparison, rightValue);
            return query;
        }
        public static SelectQuery WhereColumnValue(this SelectQuery query, string leftTableAlias, string leftField, Compare comparison, string rightValue)
        {
            query.WhereFilters.WhereColumnValue(leftTableAlias, leftField, comparison, rightValue);
            return query;
        }
        public static WhereFilterCollection WhereColumnValue(this WhereFilterCollection query, Table leftTable, string leftField, Compare comparison, string rightValue)
        {
            query.WhereColumnValue(leftTable.Alias, leftField, comparison, rightValue);
            return query;
        }
        public static WhereFilterCollection WhereColumnValue(this WhereFilterCollection query, string leftTableAlias, string leftField, Compare comparison, string rightValue)
        {
            query.WhereColumnValue(leftTableAlias, leftField, comparison, rightValue, DbType.String);
            return query;
        }


        // DateTime
        public static SelectQuery WhereColumnValue(this SelectQuery query, Table leftTable, string leftField, Compare comparison, DateTime rightValue)
        {
            query.WhereColumnValue(leftTable.Alias, leftField, comparison, rightValue);
            return query;
        }
        public static SelectQuery WhereColumnValue(this SelectQuery query, string leftTableAlias, string leftField, Compare comparison, DateTime rightValue)
        {
            query.WhereFilters.WhereColumnValue(leftTableAlias, leftField, comparison, rightValue);
            return query;
        }
        public static WhereFilterCollection WhereColumnValue(this WhereFilterCollection query, Table leftTable, string leftField, Compare comparison, DateTime rightValue)
        {
            query.WhereColumnValue(leftTable.Alias, leftField, comparison, rightValue);
            return query;
        }
        public static WhereFilterCollection WhereColumnValue(this WhereFilterCollection query, string leftTableAlias, string leftField, Compare comparison, DateTime rightValue)
        {
            query.WhereColumnValue(leftTableAlias, leftField, comparison, rightValue.ToString("yyyy-MM-dd HH:mm:ss"), DbType.DateTime2);
            return query;
        }





    }
}
