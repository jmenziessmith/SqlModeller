using System.Linq;
using SqlModeller.Helpers;
using SqlModeller.Interfaces;
using SqlModeller.Model;
using SqlModeller.Model.Select;

namespace SqlModeller.Compiler.SqlServer.SelectCompilers
{
    public class OrderByColumnSelectorCompiler : IColumnSelectorCompiler<OrderByColumnSelector>
    {
        public string Compile(IColumnSelector value, SelectQuery query, IQueryParameterManager parameters)
        {
            var select = value as OrderByColumnSelector;
            var orderByColumn = query.OrderByColumns.First();
            var selectColumn = new ColumnSelector(orderByColumn.TableAlias, orderByColumn.Field.Name, select.Alias, orderByColumn.Aggregate); 

            var selectCompiler = new ColumnSelectorCompiler();
            return selectCompiler.Compile(selectColumn, query, parameters);

             
        }
    }
}