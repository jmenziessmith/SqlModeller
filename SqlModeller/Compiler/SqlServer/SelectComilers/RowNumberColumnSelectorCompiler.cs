using System.Collections.Generic;
using SqlModeller.Interfaces;
using SqlModeller.Model;
using SqlModeller.Model.Select;

namespace SqlModeller.Compiler.SqlServer.SelectComilers
{
    public class RowNumberColumnSelectorCompiler : IColumnSelectorCompiler<RowNumberColumnSelector>
    {
        public string Compile(IColumnSelector value, SelectQuery query, IQueryParameterManager parameters)
        {
            var select = value as RowNumberColumnSelector;
            string orderBy = new SelectQueryCompiler().CompileOrderBy(query);
            orderBy = orderBy.Replace("\n\t", " ").Replace("\n", " ").Replace("  ", " ");

            if (select.Alias == null)
            {
                return string.Format("( ROW_NUMBER() OVER({0}) ) ", orderBy);
            }
            return string.Format("( ROW_NUMBER() OVER({0}) ) AS {1}", orderBy, select.Alias);
        }
    }
}