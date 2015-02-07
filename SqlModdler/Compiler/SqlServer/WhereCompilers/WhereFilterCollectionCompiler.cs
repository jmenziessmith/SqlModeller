using System.Collections.Generic;
using System.Linq;
using SqlModdler.Interfaces;
using SqlModdler.Model;
using SqlModdler.Model.Where;

namespace SqlModdler.Compiler.SqlServer.WhereCompilers
{
    public class WhereFilterCollectionCompiler : IWhereCompiler<WhereFilterCollection>
    {
        public string Compile(IWhereFilter filter, SelectQuery selectQuery, IQueryParameterManager parameters)
        {
            var whereFilters = filter as WhereFilterCollection;

            if (!whereFilters.Any())
            {
                return "(1 = 1)";
            }

            var whereCompiler = new WhereFilterCompiler();
            
            var operatorString = whereFilters.GroupingOperator.ToSqlString();

            var result = string.Empty;
            bool first = true;
            foreach (var where in whereFilters)
            {

                result += string.Format("\n\t {0} {1}",
                            !first ? operatorString : null,
                            whereCompiler.Compile(where, selectQuery,parameters)
                          );

                first = false;
            }

            return string.Format("({0} \n\t )",result);
        }
    }
}