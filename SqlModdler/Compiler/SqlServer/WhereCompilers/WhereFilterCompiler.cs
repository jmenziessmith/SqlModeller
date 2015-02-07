using System.Collections.Generic;
using SqlModdler.Compiler.SqlServer.Base;
using SqlModdler.Interfaces;

namespace SqlModdler.Compiler.SqlServer.WhereCompilers
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