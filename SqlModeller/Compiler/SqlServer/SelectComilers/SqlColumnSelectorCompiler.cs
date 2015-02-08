using SqlModeller.Interfaces;
using SqlModeller.Model;
using SqlModeller.Model.Select;

namespace SqlModeller.Compiler.SqlServer.SelectComilers
{
    public class SqlColumnSelectorCompiler : IColumnSelectorCompiler<SqlColumnSelector>
    {
        public string Compile(IColumnSelector value, SelectQuery query, IQueryParameterManager parameters)
        {
            var select = value as SqlColumnSelector;
            return select.Sql;
        }
    }
}