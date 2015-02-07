using System.Collections.Generic;
using SqlModdler.Interfaces;
using SqlModdler.Model;
using SqlModdler.Model.Select;

namespace SqlModdler.Compiler.SqlServer.SelectComilers
{
    public class AllColumnSelectorCompiler : IColumnSelectorCompiler<AllColumnSelector>
    {
        public string Compile(IColumnSelector value, SelectQuery query, IQueryParameterManager parameters)
        {
            return "*";
        }
    }
}