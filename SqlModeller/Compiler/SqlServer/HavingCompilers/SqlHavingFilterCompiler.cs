using SqlModeller.Interfaces;
using SqlModeller.Model;
using SqlModeller.Model.Having;

namespace SqlModeller.Compiler.SqlServer.HavingCompilers
{
    public class SqlHavingFilterCompiler : IHavingCompiler<SqlHavingFilter>
    {
        public string Compile(IHavingFilter filter, SelectQuery query, IQueryParameterManager parameters)
        {
            var having = filter as SqlHavingFilter;
            return having.Sql;
        }
    }
}