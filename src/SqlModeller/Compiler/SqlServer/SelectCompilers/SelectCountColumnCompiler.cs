using SqlModeller.Interfaces;
using SqlModeller.Model;
using SqlModeller.Model.Select;

namespace SqlModeller.Compiler.SqlServer.SelectCompilers
{
    public class CountColumnSelectorCompiler : IColumnSelectorCompiler<CountColumnSelector>
    {
        public string Compile(IColumnSelector value, SelectQuery query, IQueryParameterManager parameters)
        {
            var select = value as CountColumnSelector;
            return string.Format("COUNT({1}) AS {0}", select.Alias, select.FieldName);
        }
    }
}