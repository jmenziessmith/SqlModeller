using System.Collections.Generic;
using SqlModdler.Interfaces;
using SqlModdler.Model;
using SqlModdler.Model.Select;

namespace SqlModdler.Compiler.SqlServer.SelectComilers
{
    public class CountColumnSelectorCompiler : IColumnSelectorCompiler<CountColumnSelector>
    {
        public string Compile(IColumnSelector value, SelectQuery query, IQueryParameterManager parameters)
        {
            var select = value as CountColumnSelector;
            return string.Format("COUNT(1) AS {0}", select.Alias);
        }
    }
}