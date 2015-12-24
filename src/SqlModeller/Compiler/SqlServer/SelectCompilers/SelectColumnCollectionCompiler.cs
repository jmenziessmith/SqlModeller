using System.Collections.Generic;
using SqlModeller.Compiler.SqlServer.Base;
using SqlModeller.Interfaces;

namespace SqlModeller.Compiler.SqlServer.SelectCompilers
{
    public class SelectColumnCollectionCompiler : CompilerRegistry<IColumnSelector, IColumnSelectorCompiler>
    {
        protected override void Register()
        {
            registeredCompilers = new List<IColumnSelectorCompiler>()
            {
                new AllColumnSelectorCompiler(),
                new ColumnSelectorCompiler(),
                new CountColumnSelectorCompiler(),
                new RowNumberColumnSelectorCompiler(),
                new OrderByColumnSelectorCompiler(),
                new TotalColumnSelectorCompiler(),
                new GroupByColumnSelectorCompiler(),
                new SqlColumnSelectorCompiler(),
            };
        } 
    }
}