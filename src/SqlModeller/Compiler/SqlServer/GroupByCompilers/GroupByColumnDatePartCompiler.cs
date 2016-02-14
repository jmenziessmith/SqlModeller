using SqlModeller.Interfaces;
using SqlModeller.Model;
using SqlModeller.Model.GroupBy;

namespace SqlModeller.Compiler.SqlServer.GroupByCompilers
{
    public class GroupByColumnDatePartCompiler : IGroupByColumnCompiler<GroupByColumnDatePart>
    {
        public string Compile(IGroupByColumn value, SelectQuery query, IQueryParameterManager parameters)
        {
            var select = value as GroupByColumnDatePart;

            var format = "DATEADD({0},0, DATEDIFF({0},0, {1}{2}{3}))";
  
            return string.Format(format,
                select.DatePart.ToSqlString(),
                select.TableAlias,
                string.IsNullOrWhiteSpace(select.TableAlias) ? null : ".",
                select.Field.Name
                );
        }
    }
}