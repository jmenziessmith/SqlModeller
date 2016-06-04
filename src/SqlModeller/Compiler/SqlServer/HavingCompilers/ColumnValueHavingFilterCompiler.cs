using System.Data;
using SqlModeller.Helpers;
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

            var valueString = parameters.Parameterize(having.RightValue.Value, having.RightValue.Type, having.ParameterAlias ?? having.LeftColumn.Field.Name);

            if (having.IsNullValue != null)
            {
                string isnullQuotes = having.RightValue.Type.IsStringType() ? "'" : null;

                return string.Format("{0}({1}ISNULL({2},{3})) {4} {5}",
                    having.Aggregate.ToSqlString(),
                    having.Aggregate == Aggregate.Bit || having.Aggregate == Aggregate.BitMax ? "0+" : null, // fix bit field aggregation for nulls
                    having.LeftColumn.FullName,
                    isnullQuotes + having.IsNullValue + isnullQuotes,
                    having.Operator.ToSqlString(),
                    valueString
                );
            }
            
            return string.Format("{0}({1}{2}) {3} {4}",
                having.Aggregate.ToSqlString(),
                having.Aggregate == Aggregate.Bit || having.Aggregate == Aggregate.BitMax ? "0+" : null, // fix bit field aggregation for nulls
                having.LeftColumn.FullName,
                having.Operator.ToSqlString(),
                valueString
                );
        }

        
    }
}