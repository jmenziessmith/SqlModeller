using SqlModeller.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlModeller.Model;
using SqlModeller.Model.From;

namespace SqlModeller.Compiler.SqlServer.TableJoinCompilers
{
    public class GroupedTableJoinTableJoinCompiler : ITableJoinCompiler<GroupedTableJoin>
    {
        public string Compile(ITableJoin value, SelectQuery query, IQueryParameterManager parameters)
        {
            var join = value as GroupedTableJoin;

            var joinCompiler = new TableJoinTableJoinCompiler() { NewLine = null};
            var nestedJoinSql = string.Empty; 

            foreach(var nested in join.GroupedJoins)
            {
                nestedJoinSql += joinCompiler.Compile(nested, query, parameters) + " "; 
            }

            var result = string.Format("\n\t {0} ({1} AS {2} {3}) ON {2}.{4} = {5}.{6} {7} ",
                join.JoinType.ToSqlString(),
                join.JoinTable.TableName,
                join.JoinTable.Alias,
                nestedJoinSql,
                join.JoinField.Name,
                join.ForeignColumn.TableAlias,
                join.ForeignColumn.Field.Name,
                join.Extra);

            return result;
        }
    }
}
