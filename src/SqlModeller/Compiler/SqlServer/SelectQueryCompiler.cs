using System.Linq;
using SqlModeller.Compiler.Model;
using SqlModeller.Compiler.SqlServer.GroupByCompilers;
using SqlModeller.Compiler.SqlServer.HavingCompilers;
using SqlModeller.Compiler.SqlServer.SelectCompilers;
using SqlModeller.Compiler.SqlServer.WhereCompilers;
using SqlModeller.Helpers;
using SqlModeller.Interfaces;
using SqlModeller.Model; 

namespace SqlModeller.Compiler.SqlServer
{
    public class SelectQueryCompiler
    {
        public CompiledSelectQuery Compile(SelectQuery selectQuery, IQueryParameterManager parameters)
        {
            var result = new CompiledSelectQuery();

            result.Select = CompileSelect(selectQuery, parameters);
            result.From = CompileFrom(selectQuery, parameters);
            result.Where = CompileWhere(selectQuery, parameters);
            result.GroupBy = CompileGroupBy(selectQuery, parameters);
            result.OrderBy = CompileOrderBy(selectQuery);
            result.Having = CompileHaving(selectQuery, parameters);

            result.OffsetLimit = CompileOffsetLimit(selectQuery);

            return result;
        }

        private string CompileOffsetLimit(SelectQuery selectQuery)
        {
            var result = string.Empty;

            if (selectQuery.RowOffset > 0 || selectQuery.RowLimit > 0)
            {
                result += string.Format("OFFSET {0} ROWS ", selectQuery.RowOffset);
            }
            if (selectQuery.RowLimit > 0)
            {
                 

                result += string.Format("{0}FETCH NEXT {1} ROWS ONLY ", 
                    string.IsNullOrEmpty(result) ? null : "\n",
                    selectQuery.RowLimit);
            }

            return result;
        }


        public virtual string CompileSelect(SelectQuery selectQuery, IQueryParameterManager parameters)
        {
            var result = "SELECT ";

            var selectCompiler = new SelectColumnCollectionCompiler();

            foreach (var column in selectQuery.SelectColumns)
            {
                result += string.Format("\n\t {0} ,",
                                selectCompiler.Compile(column, selectQuery, parameters));
            }
            result = result.TrimEnd(',');

            return result;
        }

        public virtual string CompileFrom(SelectQuery selectQuery, IQueryParameterManager parameters)
        {
            var result = "FROM ";
            result +=  string.Format("\n\t{0} AS {1} ", 
                selectQuery.FromTable.TableName, 
                selectQuery.FromTable.Alias);

            foreach (var join in selectQuery.TableJoins)
            {
                result += string.Format("\n\t {0} {1} AS {2} ON {2}.{3} = {4}.{5} {6} ",
                    join.JoinType.ToSqlString(),
                    join.JoinTable.TableName,
                    join.JoinTable.Alias,
                    join.JoinField.Name,
                    join.ForeignColumn.TableAlias,
                    join.ForeignColumn.Field.Name,
                    join.Extra);
            }
             

            return result;
        }

        public virtual string CompileWhere(SelectQuery selectQuery, IQueryParameterManager parameters)
        {
            if (selectQuery.WhereFilters == null || !selectQuery.WhereFilters.Any())
            {
                return null;
            }

            var result = "WHERE ";

            var operatorString = selectQuery.WhereFilters.GroupingOperator.ToSqlString();

            var whereCompiler = new WhereFilterCompiler();

            bool first = true;
            foreach (var where in selectQuery.WhereFilters)
            { 
                result += string.Format("\n\t {0} {1}",
                            !first ? operatorString : null,
                            whereCompiler.Compile(where, selectQuery, parameters)
                          );

                first = false;
            } 
            
            return result;
        }


        public virtual string CompileOrderBy(SelectQuery selectQuery)
        {
            if (!selectQuery.OrderByColumns.Any())
            {
                return null;
            }

            string result = "ORDER BY ";
            
            foreach (var orderBy in selectQuery.OrderByColumns)
            {
                var fieldSelector = orderBy.FullName;

                bool isInGroupBy = false;
                // need to deal with aggregates
                if (orderBy.Aggregate != Aggregate.None)
                {
                    isInGroupBy = AggregateHelpers.IsInGroupBy(selectQuery, orderBy);
                }
                if (!isInGroupBy && selectQuery.GroupByColumns.Count > 0)
                {
                    fieldSelector = string.Format("{0}({1}{2}{3}{4})",
                        orderBy.Aggregate.ToSqlString(),
                        orderBy.Aggregate == Aggregate.Bit ? "0+" : null, // fix bit field aggregation for nulls
                        orderBy.TableAlias,
                        string.IsNullOrWhiteSpace(orderBy.TableAlias) ? null : ".",
                        orderBy.Field.Name
                        );
                }
                
                
                result += string.Format("\n\t {0} {1} ,",
                    fieldSelector,
                    orderBy.Direction.ToSqlString()
                    );
                 
            }

            result = result.TrimEnd(',');

            return result;

        }

        public virtual string CompileGroupBy(SelectQuery selectQuery, IQueryParameterManager parameters)
        {
            if (!selectQuery.GroupByColumns.Any())
            {
                return null;
            }

            var result = "GROUP BY ";

            var groupCompiler = new GroupByColumCollectionCompiler();

            foreach (var column in selectQuery.GroupByColumns)
            {
                result += string.Format("\n\t {0} ,",
                                groupCompiler.Compile(column, selectQuery, parameters));
            }
            result = result.TrimEnd(',');

            return result; 
 
        }

        public virtual string CompileHaving(SelectQuery selectQuery, IQueryParameterManager parameters)
        {
            if (selectQuery.HavingFilters == null || !selectQuery.HavingFilters.Any())
            {
                return null;
            }

            var result = "HAVING ";

            var operatorString = selectQuery.HavingFilters.GroupingOperator.ToSqlString();

            var havingCompiler = new HavingFilterCompiler();

            bool first = true;
            foreach (var having in selectQuery.HavingFilters)
            {
                result += string.Format("\n\t {0} {1}",
                            !first ? operatorString : null,
                            havingCompiler.Compile(having, selectQuery, parameters)
                          );

                first = false;
            }

            return result;
        }

    }
}