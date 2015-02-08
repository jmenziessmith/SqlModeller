using System.Collections.Generic;
using SqlModeller.Interfaces;
using SqlModeller.Model;
using SqlModeller.Model.Where;

namespace SqlModeller.Compiler.SqlServer.WhereCompilers
{
    public class ColumnColumnWhereFilterCompiler : IWhereCompiler<ColumnColumnWhereFilter>
    {
        public string Compile(IWhereFilter filter, SelectQuery query, IQueryParameterManager parameters)
        {
            var where = filter as ColumnColumnWhereFilter;

            return string.Format("{0}.{1} {2} {3}.{4}",
                where.LeftColumn.TableAlias, 
                where.LeftColumn.Field.Name,
                where.Operator.ToSqlString(),
                where.RightColumn.TableAlias,
                where.RightColumn.Field.Name
                );
        }
    }
}
