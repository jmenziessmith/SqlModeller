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

            //var valueString = ToStringHelper.ValueString(where.RightValue.Value, where.RightValue.Type);
            var valueString = parameters.Parameterize(where.RightValue.Value, where.RightValue.Type, where.LeftColumn.Field.Name);

            return string.Format("{0} {1} {2}",
                where.LeftColumn.FullName,
                where.Operator.ToSqlString(),
                valueString
                );
        } 
      
    }
}