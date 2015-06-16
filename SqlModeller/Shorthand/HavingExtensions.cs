using System;
using System.Data;
using SqlModeller.Model;
using SqlModeller.Model.Having;
using SqlModeller.Model.Where;

namespace SqlModeller.Shorthand
{
    public static partial class Shorthand
    {
 
        public static SelectQuery Having(this SelectQuery query, Combine groupingOperator)
        {
            query.HavingFilters.GroupingOperator = groupingOperator;
            return query;
        }



        // Having COLLECTION
 
        public static SelectQuery HavingCollection(this SelectQuery query, Combine groupingOperator, HavingFilterCollection collection)
        { 
            query.HavingFilters.HavingCollection(groupingOperator, collection);
            return query;
        }
        public static HavingFilterCollection HavingCollection(this HavingFilterCollection query, Combine groupingOperator, HavingFilterCollection collection)
        {
            collection.GroupingOperator = groupingOperator;
            query.Add(collection);
            return query;
        }
         

        // Having SQL 
        public static SelectQuery Having(this SelectQuery query, string sql)
        {
            query.HavingFilters.Having(sql);
            return query;
        }

        public static HavingFilterCollection Having(this HavingFilterCollection query, string sql)
        {
            query.Add(new SqlHavingFilter(sql));
            return query;
        }


        // Having COLUMN VALUE
 
        public static SelectQuery HavingColumnValue(this SelectQuery query, Aggregate aggregate, Table leftTable, string leftField, Compare comparison, string rightValue, DbType rightType, string parameterAlias = null)
        {
            query.HavingFilters.HavingColumnValue(aggregate, leftTable.Alias, leftField, comparison, rightValue, rightType, parameterAlias);
            return query;
        }
        public static SelectQuery HavingColumnValue(this SelectQuery query, Aggregate aggregate, string leftTableAlias, string leftField, Compare comparison, string rightValue, DbType rightType, string parameterAlias = null)
        {
            query.HavingFilters.HavingColumnValue(aggregate, leftTableAlias, leftField, comparison, rightValue, rightType, parameterAlias);
            return query;
        }
        public static HavingFilterCollection HavingColumnValue(this HavingFilterCollection query, Aggregate aggregate, Table leftTable, string leftField, Compare comparison, string rightValue, DbType rightType, string parameterAlias = null)
        {
            query.HavingColumnValue(aggregate, leftTable.Alias, leftField, comparison, rightValue, rightType, parameterAlias);
            return query;
        }
        public static HavingFilterCollection HavingColumnValue(this HavingFilterCollection query, Aggregate aggregate, string leftTableAlias, string leftField, Compare comparison, string rightValue, DbType rightType, string parameterAlias = null)
        {
            var HavingFilter = new ColumnValueHavingFilter()
                              {
                                  Aggregate = aggregate,
                                  LeftColumn = new Column(leftTableAlias, leftField),
                                  Operator = comparison,
                                  RightValue = new LiteralValue(rightValue, rightType),
                                  ParameterAlias = parameterAlias
                              };
            query.Add(HavingFilter);
            return query;
        }

        // int
        public static SelectQuery HavingColumnValue(this SelectQuery query, Aggregate aggregate, Table leftTable, string leftField, Compare comparison, int rightValue, string parameterAlias = null)
        {
            query.HavingColumnValue(aggregate, leftTable.Alias, leftField, comparison, rightValue, parameterAlias);
            return query;
        }
        public static SelectQuery HavingColumnValue(this SelectQuery query, Aggregate aggregate, string leftTableAlias, string leftField, Compare comparison, int rightValue, string parameterAlias = null)
        {
            query.HavingFilters.HavingColumnValue(aggregate, leftTableAlias, leftField, comparison, rightValue, parameterAlias);
            return query;
        }
        public static HavingFilterCollection HavingColumnValue(this HavingFilterCollection query, Aggregate aggregate, Table leftTable, string leftField, Compare comparison, int rightValue, string parameterAlias = null)
        {
            query.HavingColumnValue(aggregate, leftTable.Alias, leftField, comparison, rightValue, parameterAlias);
            return query;
        }
        public static HavingFilterCollection HavingColumnValue(this HavingFilterCollection query, Aggregate aggregate, string leftTableAlias, string leftField, Compare comparison, int rightValue, string parameterAlias = null)
        {
            query.HavingColumnValue(aggregate, leftTableAlias, leftField, comparison, rightValue.ToString(), DbType.Int32, parameterAlias);
            return query;
        }


        // long
        public static SelectQuery HavingColumnValue(this SelectQuery query, Aggregate aggregate, Table leftTable, string leftField, Compare comparison, long rightValue, string parameterAlias = null)
        {
            query.HavingColumnValue(aggregate, leftTable.Alias, leftField, comparison, rightValue, parameterAlias);
            return query;
        }
        public static SelectQuery HavingColumnValue(this SelectQuery query, Aggregate aggregate, string leftTableAlias, string leftField, Compare comparison, long rightValue, string parameterAlias = null)
        {
            query.HavingFilters.HavingColumnValue(aggregate, leftTableAlias, leftField, comparison, rightValue, parameterAlias);
            return query;
        }
        public static HavingFilterCollection HavingColumnValue(this HavingFilterCollection query, Aggregate aggregate, Table leftTable, string leftField, Compare comparison, long rightValue, string parameterAlias = null)
        {
            query.HavingColumnValue(aggregate, leftTable.Alias, leftField, comparison, rightValue, parameterAlias);
            return query;
        }
        public static HavingFilterCollection HavingColumnValue(this HavingFilterCollection query, Aggregate aggregate, string leftTableAlias, string leftField, Compare comparison, long rightValue, string parameterAlias = null)
        {
            query.HavingColumnValue(aggregate, leftTableAlias, leftField, comparison, rightValue.ToString(), DbType.Int64, parameterAlias);
            return query;
        }
         

        // double
        public static SelectQuery HavingColumnValue(this SelectQuery query, Aggregate aggregate, Table leftTable, string leftField, Compare comparison, double rightValue, string parameterAlias = null)
        {
            query.HavingColumnValue(aggregate, leftTable.Alias, leftField, comparison, rightValue, parameterAlias);
            return query;
        }
        public static SelectQuery HavingColumnValue(this SelectQuery query, Aggregate aggregate, string leftTableAlias, string leftField, Compare comparison, double rightValue, string parameterAlias = null)
        {
            query.HavingFilters.HavingColumnValue(aggregate, leftTableAlias, leftField, comparison, rightValue, parameterAlias);
            return query;
        }
        public static HavingFilterCollection HavingColumnValue(this HavingFilterCollection query, Aggregate aggregate, Table leftTable, string leftField, Compare comparison, double rightValue, string parameterAlias = null)
        {
            query.HavingColumnValue(aggregate, leftTable.Alias, leftField, comparison, rightValue, parameterAlias);
            return query;
        }
        public static HavingFilterCollection HavingColumnValue(this HavingFilterCollection query, Aggregate aggregate, string leftTableAlias, string leftField, Compare comparison, double rightValue, string parameterAlias = null)
        {
            query.HavingColumnValue(aggregate, leftTableAlias, leftField, comparison, rightValue.ToString(), DbType.Double, parameterAlias);
            return query;
        }

        // decimal
        public static SelectQuery HavingColumnValue(this SelectQuery query, Aggregate aggregate, Table leftTable, string leftField, Compare comparison, decimal rightValue, string parameterAlias = null)
        {
            query.HavingColumnValue(aggregate, leftTable.Alias, leftField, comparison, rightValue, parameterAlias);
            return query;
        }
        public static SelectQuery HavingColumnValue(this SelectQuery query, Aggregate aggregate, string leftTableAlias, string leftField, Compare comparison, decimal rightValue, string parameterAlias = null)
        {
            query.HavingFilters.HavingColumnValue(aggregate, leftTableAlias, leftField, comparison, rightValue, parameterAlias);
            return query;
        }
        public static HavingFilterCollection HavingColumnValue(this HavingFilterCollection query, Aggregate aggregate, Table leftTable, string leftField, Compare comparison, decimal rightValue, string parameterAlias = null)
        {
            query.HavingColumnValue(aggregate, leftTable.Alias, leftField, comparison, rightValue, parameterAlias);
            return query;
        }
        public static HavingFilterCollection HavingColumnValue(this HavingFilterCollection query, Aggregate aggregate, string leftTableAlias, string leftField, Compare comparison, decimal rightValue, string parameterAlias = null)
        {
            query.HavingColumnValue(aggregate, leftTableAlias, leftField, comparison, rightValue.ToString(), DbType.Decimal, parameterAlias);
            return query;
        }

        // string
        public static SelectQuery HavingColumnValue(this SelectQuery query, Aggregate aggregate, Table table, string leftField, Compare comparison, string rightValue, string parameterAlias = null)
        {
            query.HavingColumnValue(aggregate, table.Alias, leftField, comparison, rightValue, parameterAlias);
            return query;
        }
        public static SelectQuery HavingColumnValue(this SelectQuery query, Aggregate aggregate, string leftTableAlias, string leftField, Compare comparison, string rightValue, string parameterAlias = null)
        {
            query.HavingFilters.HavingColumnValue(aggregate, leftTableAlias, leftField, comparison, rightValue, parameterAlias);
            return query;
        }
        public static HavingFilterCollection HavingColumnValue(this HavingFilterCollection query, Aggregate aggregate, Table leftTable, string leftField, Compare comparison, string rightValue, string parameterAlias = null)
        {
            query.HavingColumnValue(aggregate, leftTable.Alias, leftField, comparison, rightValue, parameterAlias);
            return query;
        }
        public static HavingFilterCollection HavingColumnValue(this HavingFilterCollection query, Aggregate aggregate, string leftTableAlias, string leftField, Compare comparison, string rightValue, string parameterAlias = null)
        {
            query.HavingColumnValue(aggregate, leftTableAlias, leftField, comparison, rightValue, DbType.String, parameterAlias);
            return query;
        }


        // DateTime
        public static SelectQuery HavingColumnValue(this SelectQuery query, Aggregate aggregate, Table leftTable, string leftField, Compare comparison, DateTime rightValue, string parameterAlias = null)
        {
            query.HavingColumnValue(aggregate, leftTable.Alias, leftField, comparison, rightValue, parameterAlias);
            return query;
        }
        public static SelectQuery HavingColumnValue(this SelectQuery query, Aggregate aggregate, string leftTableAlias, string leftField, Compare comparison, DateTime rightValue, string parameterAlias = null)
        {
            query.HavingFilters.HavingColumnValue(aggregate, leftTableAlias, leftField, comparison, rightValue, parameterAlias);
            return query;
        }
        public static HavingFilterCollection HavingColumnValue(this HavingFilterCollection query, Aggregate aggregate, Table leftTable, string leftField, Compare comparison, DateTime rightValue, string parameterAlias = null)
        {
            query.HavingColumnValue(aggregate, leftTable.Alias, leftField, comparison, rightValue, parameterAlias);
            return query;
        }
        public static HavingFilterCollection HavingColumnValue(this HavingFilterCollection query, Aggregate aggregate, string leftTableAlias, string leftField, Compare comparison, DateTime rightValue, string parameterAlias = null)
        {
            query.HavingColumnValue(aggregate, leftTableAlias, leftField, comparison, rightValue.ToString("yyyy-MM-dd HH:mm:ss"), DbType.DateTime2, parameterAlias);
            return query;
        }





    }
}
