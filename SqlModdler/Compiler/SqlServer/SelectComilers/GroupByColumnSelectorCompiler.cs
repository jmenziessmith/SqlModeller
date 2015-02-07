using System.Collections.Generic;
using SqlModdler.Interfaces;
using SqlModdler.Model;
using SqlModdler.Model.Select;

namespace SqlModdler.Compiler.SqlServer.SelectComilers
{
    public class GroupByColumnSelectorCompiler : IColumnSelectorCompiler<GroupByColumnSelector>
    {
        public string Compile(IColumnSelector value, SelectQuery query, IQueryParameterManager parameters)
        {
            var select = value as GroupByColumnSelector;

            if (query.GroupByColumns.Count == 1)
            {
                var column = new ColumnSelector(query.GroupByColumns[0].TableAlias, 
                                                query.GroupByColumns[0].Field.Name,
                                                select.Alias, 
                                                Aggregate.None);

                var result = new ColumnSelectorCompiler().Compile(column, query, parameters);
                return result;
            }

            // cannot find the group key column
            return string.Format("null AS {1}");
        }
    }
}