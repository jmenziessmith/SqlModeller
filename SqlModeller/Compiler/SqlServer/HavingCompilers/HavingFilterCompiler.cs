using System.Collections.Generic;
using SqlModeller.Compiler.SqlServer.Base;
using SqlModeller.Interfaces;

namespace SqlModeller.Compiler.SqlServer.HavingCompilers
{
    public class HavingFilterCompiler : CompilerRegistry<IHavingFilter, IHavingCompiler>
    {
        protected override void Register()
        {
            registeredCompilers = new List<IHavingCompiler>()
            { 
                new SqlHavingFilterCompiler(),
                new ColumnValueHavingFilterCompiler(),
                new HavingFilterCollectionCompiler(),
            };
        } 
    }
}