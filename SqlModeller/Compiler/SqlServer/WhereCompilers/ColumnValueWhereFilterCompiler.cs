using System.Data;
using SqlModeller.Interfaces;
using SqlModeller.Model;
using SqlModeller.Model.Where;

namespace SqlModeller.Compiler.SqlServer.WhereCompilers
{
    public class ColumnValueWhereFilterCompiler : IWhereCompiler<ColumnValueWhereFilter>
    {
        public string Compile(IWhereFilter filter, SelectQuery query, IQueryParameterManager parameters)
        {
            var where = filter as ColumnValueWhereFilter;

            var valueString = ValueString(where.RightValue.Value, where.RightValue.Type);
            valueString = parameters.Parameterize(valueString, where.RightValue.Type, where.LeftColumn.Field.Name);

            return string.Format("{0}.{1} {2} {3}",
                where.LeftColumn.TableAlias,
                where.LeftColumn.Field.Name,
                where.Operator.ToSqlString(),
                valueString
                );
        }

        private string ValueString(string value, DbType type)
        {
            switch (type)
            {
                case DbType.String:
                case DbType.StringFixedLength:
                case DbType.AnsiString:
                case DbType.AnsiStringFixedLength:
                    return string.Format("'{0}'", value);

                case DbType.DateTime:
                case DbType.DateTime2:
                    return string.Format("'{0}'", value);
            }
            return value;
        }
    }
}