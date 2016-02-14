using System;
using SqlModeller.Interfaces;
using SqlModeller.Model;
using SqlModeller.Model.GroupBy;

namespace SqlModeller.Compiler.SqlServer.GroupByCompilers
{
    public class GroupByColumnCompiler : IGroupByColumnCompiler<GroupByColumn>
    {
        public string Compile(IGroupByColumn value, SelectQuery query, IQueryParameterManager parameters)
        {
            var select = value as GroupByColumn;

            return string.Format("{0}{1}{2}",
                select.TableAlias,
                string.IsNullOrWhiteSpace(select.TableAlias) ? null : ".",
                select.Field.Name
                );
        }
    }
}
