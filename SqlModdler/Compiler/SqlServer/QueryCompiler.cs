using System.Collections.Generic;
using SqlModdler.Compiler.Model;
using SqlModdler.Compiler.QueryParameterManagers;
using SqlModdler.Interfaces;
using SqlModdler.Model;

namespace SqlModdler.Compiler.SqlServer
{
    public class QueryCompiler
    {
        public CompiledQuery Compile(Query query, bool useParameters = true)
        {
            var result = new CompiledQuery();

            var parameters = new List<QueryParameter>();

            IQueryParameterManager parameterManager = useParameters 
                ? (IQueryParameterManager) new QueryParameterManager(parameters) 
                : new NoQueryParameterManager();

            // Common Table Expressions
            var cteCompiler = new CommmonTableExpressionCompiler();
            foreach (var cte in query.CommonTableExpressions)
            {
                var compiledCte = cteCompiler.Compile(cte, parameterManager);
                result.CommonTableExpressions.Add(compiledCte);
            }

            // Select Query
            var selectQueryCompiler = new SelectQueryCompiler();
            result.SelectQuery = selectQueryCompiler.Compile(query.SelectQuery, parameterManager);

            // Parameters
            var parameterCompiler = new ParameterCompiler();
            foreach (var param in parameters)
            {
                var compiledParam = parameterCompiler.Compile(param);
                result.Parameters.Add(compiledParam);
            }

            return result;
        }
    }
}