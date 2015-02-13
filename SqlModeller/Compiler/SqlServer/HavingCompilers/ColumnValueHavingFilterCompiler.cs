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

            //var valueString = ToStringHelper.ValueString(having.RightValue.Value, having.RightValue.Type);
            var valueString = parameters.Parameterize(having.RightValue.Value, having.RightValue.Type, having.LeftColumn.Field.Name);

            return string.Format("{0}({1}{2}) {3} {4}",
                having.Aggregate.ToSqlString(),
                having.Aggregate == Aggregate.Bit ? "0+" : null, // fix bit field aggregation for nulls
                having.LeftColumn.FullName,
                having.Operator.ToSqlString(),
                valueString
                );
        }

        
    }
}