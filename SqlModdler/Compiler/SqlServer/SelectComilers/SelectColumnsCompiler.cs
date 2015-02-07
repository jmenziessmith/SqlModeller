using System.Collections.Generic;
using SqlModdler.Compiler.SqlServer.Base;
using SqlModdler.Interfaces;

namespace SqlModdler.Compiler.SqlServer.SelectComilers
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