using System.Collections.Generic;
using SqlModdler.Compiler.Model;
using SqlModdler.Interfaces;
using SqlModdler.Model;

namespace SqlModdler.Compiler.SqlServer
{
    public class CommmonTableExpressionCompiler
    {
        public CompiledCommonTableExpression Compile(CommonTableExpression cte, IQueryParameterManager parameters)
        {
            var result = new CompiledCommonTableExpression();
            result.Alias = cte.Alias;

            var selectQueryCompiler = new SelectQueryCompiler();
            result.SelectQuery = selectQueryCompiler.Compile(cte.Query, parameters);
            result.SelectQuery.OrderBy = null; // order by is not allowd in CTE, but may have been used for over( ) statements

            return result;
        }
    }
}