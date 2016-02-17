using System.Collections.Generic;
using SqlModeller.Compiler.SqlServer.Base;
using SqlModeller.Interfaces;
using SqlModeller.Compiler.SqlServer.TableJoinCompilers;

namespace SqlModeller.Compiler.SqlServer.WhereCompilers
{
    public class TableJoinCompiler : CompilerRegistry<ITableJoin, ITableJoinCompiler>
    {
        protected override void Register()
        {
            registeredCompilers = new List<ITableJoinCompiler>()
            {
                new TableJoinTableJoinCompiler(),
                new GroupedTableJoinTableJoinCompiler(), 
            };
        } 
    }
}