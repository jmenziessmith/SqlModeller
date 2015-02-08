using System.Collections.Generic;
using SqlModeller.Compiler.SqlServer.Base;
using SqlModeller.Interfaces;

namespace SqlModeller.Compiler.SqlServer.SelectComilers
{
    public class SelectColumnsCompiler : CompilerRegistry<IColumnSelector, IColumnSelectorCompiler>
    {
        protected override void Register()
        {
            registeredCompilers = new List<IColumnSelectorCompiler>()
            {
                new AllColumnSelectorCompiler(),
                new ColumnSelectorCompiler(),
                new CountColumnSelectorCompiler(),
                new RowNumberColumnSelectorCompiler(),
                new TotalColumnSelectorCompiler(),
                new GroupByColumnSelectorCompiler(),
                new SqlColumnSelectorCompiler(),
            };
        } 
    }
}