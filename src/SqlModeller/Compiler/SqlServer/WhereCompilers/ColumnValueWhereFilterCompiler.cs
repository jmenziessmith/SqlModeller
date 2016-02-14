using System.Data;
using SqlModeller.Helpers;
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
             
            var valueString = parameters.Parameterize(where.RightValue.Value, where.RightValue.Type, where.ParameterAlias ?? where.LeftColumn.Field.Name);

            if (where.IsNullValue != null)
            {
                string isnullQuotes = where.RightValue.Type.IsStringType() ? "'" : null;
                 
                return string.Format("ISNULL({0},{1}) {2} {3}",
                   where.LeftColumn.FullName,
                   isnullQuotes + where.IsNullValue + isnullQuotes ,
                   where.Operator.ToSqlString(),
                   valueString
               );
            }

            return string.Format("{0} {1} {2}",
                where.LeftColumn.FullName,
                where.Operator.ToSqlString(),
                valueString
                );
        } 
      
    }
}