using System.Collections.Generic;
using SqlModeller.Compiler.SqlServer.Base;
using SqlModeller.Interfaces;

namespace SqlModeller.Compiler.SqlServer.WhereCompilers
{
    public class WhereFilterCompiler : CompilerRegistry<IWhereFilter, IWhereCompiler>
    {
        protected override void Register()
        {
            registeredCompilers = new List<IWhereCompiler>()
            {
                new ColumnColumnWhereFilterCompiler(),
                new ColumnValueWhereFilterCompiler(),
                new WhereFilterCollectionCompiler(),
                new SqlWhereFilterCompiler(),
            };
        } 
    }
}