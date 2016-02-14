using System.Collections.Generic;
using SqlModeller.Interfaces;
using SqlModeller.Model;
using SqlModeller.Model.Select;

namespace SqlModeller.Compiler.SqlServer.SelectComilers
{
    public class TotalColumnSelectorCompiler : IColumnSelectorCompiler<TotalColumnSelector>
    {
        public string Compile(IColumnSelector value, SelectQuery query, IQueryParameterManager parameters)
        {
            var select = value as TotalColumnSelector;

            var count = "( COUNT(1) OVER () )";

            if (select.OnlyOnRowIndex == null)
            {
                return string.Format("{0} AS {1}", count, select.Alias);
            }

            var rowNumber = new RowNumberColumnSelectorCompiler().Compile(new RowNumberColumnSelector(null), query, parameters);

            return string.Format("( CASE WHEN {0} = {1} THEN {2} ELSE null END ) AS {3}", 
                rowNumber,
                select.OnlyOnRowIndex,
                count,
                select.Alias);
        }
    }
}