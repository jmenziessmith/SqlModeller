using System.Data;
using SqlModeller.Interfaces;
using SqlModeller.Model;
using SqlModeller.Model.Having;

namespace SqlModeller.Compiler.SqlServer.HavingCompilers
{
    public class ColumnValueHavingFilterCompiler : IHavingCompiler<ColumnValueHavingFilter>
    {
        public string Compile(IHavingFilter filter, SelectQuery query, IQueryParameterManager parameters)
        {
            var having = filter as ColumnValueHavingFilter;

            var valueString = ToStringHelper.ValueString(having.RightValue.Value, having.RightValue.Type);
            valueString = parameters.Parameterize(valueString, having.RightValue.Type, having.LeftColumn.Field.Name);

            return string.Format("{0}({1}.{2}) {3} {4}",
                having.Aggregate.ToSqlString(),
                having.LeftColumn.TableAlias,
                having.LeftColumn.Field.Name,
                having.Operator.ToSqlString(),
                valueString
                );
        }

        
    }
}