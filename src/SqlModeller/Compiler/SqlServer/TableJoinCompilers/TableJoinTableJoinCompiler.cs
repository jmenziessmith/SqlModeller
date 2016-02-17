using SqlModeller.Interfaces;
using SqlModeller.Model;
using SqlModeller.Model.From;

namespace SqlModeller.Compiler.SqlServer.TableJoinCompilers
{
    public class TableJoinTableJoinCompiler : ITableJoinCompiler<TableJoin>
    {
        public string NewLine = "\n\t"; 

        public string Compile(ITableJoin value, SelectQuery query, IQueryParameterManager parameters)
        {
            var join = value as TableJoin;

            var result = string.Format("{7} {0} {1} AS {2} ON {2}.{3} = {4}.{5} {6} ",
                join.JoinType.ToSqlString(),
                join.JoinTable.TableName,
                join.JoinTable.Alias,
                join.JoinField.Name,
                join.ForeignColumn.TableAlias,
                join.ForeignColumn.Field.Name,
                join.Extra,
                NewLine);

            return result;
        }
    }
}
