using SqlModeller.Interfaces;
using SqlModeller.Model;
using SqlModeller.Model.Select;

namespace SqlModeller.Compiler.SqlServer.SelectCompilers
{
    public class AllColumnSelectorCompiler : IColumnSelectorCompiler<AllColumnSelector>
    {
        public string Compile(IColumnSelector value, SelectQuery query, IQueryParameterManager parameters)
        {
            return "*";
        }
    }
}