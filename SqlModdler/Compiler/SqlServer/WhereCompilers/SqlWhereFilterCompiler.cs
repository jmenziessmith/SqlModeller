using SqlModdler.Interfaces;
using SqlModdler.Model;
using SqlModdler.Model.Where;

namespace SqlModdler.Compiler.SqlServer.WhereCompilers
{
    public class SqlWhereFilterCompiler : IWhereCompiler<SqlWhereFilter>
    {
        public string Compile(IWhereFilter filter, SelectQuery query, IQueryParameterManager parameters)
        {
            var where = filter as SqlWhereFilter;
            return where.Sql;
        }
    }
}