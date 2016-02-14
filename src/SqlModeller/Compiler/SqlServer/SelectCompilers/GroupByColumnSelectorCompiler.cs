using SqlModeller.Interfaces;
using SqlModeller.Model;
using SqlModeller.Model.GroupBy;
using SqlModeller.Model.Select;

namespace SqlModeller.Compiler.SqlServer.SelectCompilers
{
    public class GroupByColumnSelectorCompiler : IColumnSelectorCompiler<GroupByColumnSelector>
    {
        public string Compile(IColumnSelector value, SelectQuery query, IQueryParameterManager parameters)
        {
            var select = value as GroupByColumnSelector;

            if (query.GroupByColumns.Count >= select.Index + 1 )
            {
                // date part column selector
                if (query.GroupByColumns[select.Index] is GroupByColumnDatePart)
                {
                    var selector = query.GroupByColumns[select.Index] as GroupByColumnDatePart;

                    if (selector != null)
                    {
                        var column = new ColumnDatePartSelector(selector.TableAlias,
                                    selector.Field.Name,
                                    select.Alias,
                                    selector.DatePart,
                                    Aggregate.None);

                        var result = new ColumnDatePartSelectorCompiler().Compile(column, query, parameters);
                        return result;
                    }
                }


                // simple column selector
                if (query.GroupByColumns[select.Index] is GroupByColumn)
                {
                    var selector = query.GroupByColumns[select.Index] as GroupByColumn;

                    if (selector != null)
                    {
                        var column = new ColumnSelector(selector.TableAlias,
                                    selector.Field.Name,
                                    select.Alias,
                                    Aggregate.None);

                        var result = new ColumnSelectorCompiler().Compile(column, query, parameters);
                        return result;
                    }
                }
            }

            // cannot find the group key column
            return string.Format("null AS {0}", select.Alias);
        }
    }
}