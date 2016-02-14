using System.Collections.Generic;
using SqlModeller.Compiler.SqlServer.Base;
using SqlModeller.Interfaces;

namespace SqlModeller.Compiler.SqlServer.GroupByCompilers
{
    public class GroupByColumCollectionCompiler : CompilerRegistry<IGroupByColumn, IGroupByColumnCompiler>
    {
        protected override void Register()
        {
            registeredCompilers = new List<IGroupByColumnCompiler>()
            {
                new GroupByColumnCompiler(),
                new GroupByColumnDatePartCompiler()
            };
        } 
    }
}