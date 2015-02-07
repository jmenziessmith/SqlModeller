using SqlModdler.Interfaces;
using SqlModdler.Model;
using SqlModdler.Model.Select;

namespace SqlModdler.Compiler.SqlServer.SelectComilers
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