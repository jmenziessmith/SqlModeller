using System;
using System.Data;
using SqlModeller.Model;
using SqlModeller.Model.Where;
using System.Collections.Generic;

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


        // WHERE LIKE
        public static SelectQuery WhereColumnLike(this SelectQuery query, Table leftTable, string leftField, string text, LikeMode mode = LikeMode.Default)
        {
            query.WhereFilters.WhereColumnLike(leftTable, leftField, text, mode);
            return query;
        }
        public static SelectQuery WhereColumnLike(this SelectQuery query, string leftTableAlias, string leftField, string text, LikeMode mode = LikeMode.Default)
        {
            query.WhereFilters.WhereColumnLike(leftTableAlias, leftField, text, mode);
            return query;
        }

        public static WhereFilterCollection WhereColumnLike(this WhereFilterCollection query, Table leftTable, string leftField, string text, LikeMode mode = LikeMode.Default)
        {
            query.WhereColumnLike(leftTable.Alias, leftField, text, mode);
            return query;
        }
        public static WhereFilterCollection WhereColumnLike(this WhereFilterCollection query, string leftTableAlias, string leftField, string text, LikeMode mode = LikeMode.Default)
        {
            query.Add(new ColumnLikeWhereFilter()
                      {
                          LeftColumn = new Column(leftTableAlias, leftField),
                          LikeMode = mode,
                          Text = text
                      });
            return query;
        }

        // WHERE COLUMN VALUE

        public static SelectQuery WhereColumnValue(this SelectQuery query, Table leftTable, string leftField, Compare comparison, string rightValue, DbType rightType, string parameterAlias = null)
        {
            query.WhereFilters.WhereColumnValue(leftTable.Alias, leftField, comparison, rightValue, rightType, parameterAlias);
            return query;
        }
        public static SelectQuery WhereColumnValue(this SelectQuery query, string leftTableAlias, string leftField, Compare comparison, string rightValue, DbType rightType, string parameterAlias = null)
        {
            query.WhereFilters.WhereColumnValue(leftTableAlias, leftField, comparison, rightValue, rightType, parameterAlias);
            return query;
        }
        public static WhereFilterCollection WhereColumnValue(this WhereFilterCollection query, Table leftTable, string leftField, Compare comparison, string rightValue, DbType rightType, string parameterAlias = null)
        {
            query.WhereColumnValue(leftTable.Alias, leftField, comparison, rightValue, rightType, parameterAlias);
            return query;
        }
        public static WhereFilterCollection WhereColumnValue(this WhereFilterCollection query, string leftTableAlias, string leftField, Compare comparison, string rightValue, DbType rightType, string parameterAlias = null)
        {
            var whereFilter = new ColumnValueWhereFilter()
                              {
                                  LeftColumn = new Column(leftTableAlias, leftField),
                                  Operator = comparison,
                                  RightValue = new LiteralValue(rightValue, rightType),
                                  ParameterAlias = parameterAlias
                              };
            query.Add(whereFilter);
            return query;
        }

        // int
        public static SelectQuery WhereColumnValue(this SelectQuery query, Table leftTable, string leftField, Compare comparison, int rightValue, string parameterAlias = null)
        {
            query.WhereColumnValue(leftTable.Alias, leftField, comparison, rightValue, parameterAlias);
            return query;
        }
        public static SelectQuery WhereColumnValue(this SelectQuery query, string leftTableAlias, string leftField, Compare comparison, int rightValue, string parameterAlias = null)
        {
            query.WhereFilters.WhereColumnValue(leftTableAlias, leftField, comparison, rightValue, parameterAlias);
            return query;
        }
        public static WhereFilterCollection WhereColumnValue(this WhereFilterCollection query, Table leftTable, string leftField, Compare comparison, int rightValue, string parameterAlias = null)
        {
            query.WhereColumnValue(leftTable.Alias, leftField, comparison, rightValue, parameterAlias);
            return query;
        }
        public static WhereFilterCollection WhereColumnValue(this WhereFilterCollection query, string leftTableAlias, string leftField, Compare comparison, int rightValue, string parameterAlias = null)
        {
            query.WhereColumnValue(leftTableAlias, leftField, comparison, rightValue.ToString(), DbType.Int32, parameterAlias);
            return query;
        }


        // long
        public static SelectQuery WhereColumnValue(this SelectQuery query, Table leftTable, string leftField, Compare comparison, long rightValue, string parameterAlias = null)
        {
            query.WhereColumnValue(leftTable.Alias, leftField, comparison, rightValue, parameterAlias);
            return query;
        }
        public static SelectQuery WhereColumnValue(this SelectQuery query, string leftTableAlias, string leftField, Compare comparison, long rightValue, string parameterAlias = null)
        {
            query.WhereFilters.WhereColumnValue(leftTableAlias, leftField, comparison, rightValue, parameterAlias);
            return query;
        }
        public static WhereFilterCollection WhereColumnValue(this WhereFilterCollection query, Table leftTable, string leftField, Compare comparison, long rightValue, string parameterAlias = null)
        {
            query.WhereColumnValue(leftTable.Alias, leftField, comparison, rightValue, parameterAlias);
            return query;
        }
        public static WhereFilterCollection WhereColumnValue(this WhereFilterCollection query, string leftTableAlias, string leftField, Compare comparison, long rightValue, string parameterAlias = null)
        {
            query.WhereColumnValue(leftTableAlias, leftField, comparison, rightValue.ToString(), DbType.Int64, parameterAlias);
            return query;
        }
         

        // double
        public static SelectQuery WhereColumnValue(this SelectQuery query, Table leftTable, string leftField, Compare comparison, double rightValue, string parameterAlias = null)
        {
            query.WhereColumnValue(leftTable.Alias, leftField, comparison, rightValue, parameterAlias);
            return query;
        }
        public static SelectQuery WhereColumnValue(this SelectQuery query, string leftTableAlias, string leftField, Compare comparison, double rightValue, string parameterAlias = null)
        {
            query.WhereFilters.WhereColumnValue(leftTableAlias, leftField, comparison, rightValue, parameterAlias);
            return query;
        }
        public static WhereFilterCollection WhereColumnValue(this WhereFilterCollection query, Table leftTable, string leftField, Compare comparison, double rightValue, string parameterAlias = null)
        {
            query.WhereColumnValue(leftTable.Alias, leftField, comparison, rightValue, parameterAlias);
            return query;
        }
        public static WhereFilterCollection WhereColumnValue(this WhereFilterCollection query, string leftTableAlias, string leftField, Compare comparison, double rightValue, string parameterAlias = null)
        {
            query.WhereColumnValue(leftTableAlias, leftField, comparison, rightValue.ToString(), DbType.Double, parameterAlias);
            return query;
        }

        // decimal
        public static SelectQuery WhereColumnValue(this SelectQuery query, Table leftTable, string leftField, Compare comparison, decimal rightValue, string parameterAlias = null)
        {
            query.WhereColumnValue(leftTable.Alias, leftField, comparison, rightValue, parameterAlias);
            return query;
        }
        public static SelectQuery WhereColumnValue(this SelectQuery query, string leftTableAlias, string leftField, Compare comparison, decimal rightValue, string parameterAlias = null)
        {
            query.WhereFilters.WhereColumnValue(leftTableAlias, leftField, comparison, rightValue, parameterAlias);
            return query;
        }
        public static WhereFilterCollection WhereColumnValue(this WhereFilterCollection query, Table leftTable, string leftField, Compare comparison, decimal rightValue, string parameterAlias = null)
        {
            query.WhereColumnValue(leftTable.Alias, leftField, comparison, rightValue, parameterAlias);
            return query;
        }
        public static WhereFilterCollection WhereColumnValue(this WhereFilterCollection query, string leftTableAlias, string leftField, Compare comparison, decimal rightValue, string parameterAlias = null)
        {
            query.WhereColumnValue(leftTableAlias, leftField, comparison, rightValue.ToString(), DbType.Decimal, parameterAlias);
            return query;
        }

        // string
        public static SelectQuery WhereColumnValue(this SelectQuery query, Table table, string leftField, Compare comparison, string rightValue, string parameterAlias = null)
        {
            query.WhereColumnValue(table.Alias, leftField, comparison, rightValue, parameterAlias);
            return query;
        }
        public static SelectQuery WhereColumnValue(this SelectQuery query, string leftTableAlias, string leftField, Compare comparison, string rightValue, string parameterAlias = null)
        {
            query.WhereFilters.WhereColumnValue(leftTableAlias, leftField, comparison, rightValue, parameterAlias);
            return query;
        }
        public static WhereFilterCollection WhereColumnValue(this WhereFilterCollection query, Table leftTable, string leftField, Compare comparison, string rightValue, string parameterAlias = null)
        {
            query.WhereColumnValue(leftTable.Alias, leftField, comparison, rightValue, parameterAlias);
            return query;
        }
        public static WhereFilterCollection WhereColumnValue(this WhereFilterCollection query, string leftTableAlias, string leftField, Compare comparison, string rightValue, string parameterAlias = null)
        {
            query.WhereColumnValue(leftTableAlias, leftField, comparison, rightValue, DbType.String, parameterAlias);
            return query;
        }


        // DateTime
        public static SelectQuery WhereColumnValue(this SelectQuery query, Table leftTable, string leftField, Compare comparison, DateTime rightValue, string parameterAlias = null)
        {
            query.WhereColumnValue(leftTable.Alias, leftField, comparison, rightValue, parameterAlias);
            return query;
        }
        public static SelectQuery WhereColumnValue(this SelectQuery query, string leftTableAlias, string leftField, Compare comparison, DateTime rightValue, string parameterAlias = null)
        {
            query.WhereFilters.WhereColumnValue(leftTableAlias, leftField, comparison, rightValue, parameterAlias);
            return query;
        }
        public static WhereFilterCollection WhereColumnValue(this WhereFilterCollection query, Table leftTable, string leftField, Compare comparison, DateTime rightValue, string parameterAlias = null)
        {
            query.WhereColumnValue(leftTable.Alias, leftField, comparison, rightValue, parameterAlias);
            return query;
        }
        public static WhereFilterCollection WhereColumnValue(this WhereFilterCollection query, string leftTableAlias, string leftField, Compare comparison, DateTime rightValue, string parameterAlias = null)
        {
            query.WhereColumnValue(leftTableAlias, leftField, comparison, rightValue.ToString("yyyy-MM-dd HH:mm:ss"), DbType.DateTime2, parameterAlias);
            return query;
        }

        public static SelectQuery WhereColumnIn(this SelectQuery query, string leftTableAlias, string leftField, List<string> rightValues, DbType rightType, string parameterAlias = null)
        {
            query.WhereFilters.WhereColumnIn(leftTableAlias, leftField, rightValues, rightType, parameterAlias);
            return query;
        }

        public static WhereFilterCollection WhereColumnIn(this WhereFilterCollection query, string leftTableAlias, string leftField, List<string> rightValues, DbType rightType, string parameterAlias = null)
        {
            var where = new ColumnInWhereFilter()
            {
                LeftColumn = new Column(leftTableAlias, leftField),
                ParameterAlias = parameterAlias,
                RightValues = new List<LiteralValue>()
            }; 

            foreach (var v in rightValues)
            {
                where.RightValues.Add(new LiteralValue(v, rightType));
            }
            query.Add(where);
            return query;
        }


    }
}
