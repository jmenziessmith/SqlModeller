using System.Linq;
using SqlModeller.Interfaces;
using SqlModeller.Model;
using SqlModeller.Model.Having;

namespace SqlModeller.Compiler.SqlServer.HavingCompilers
{
    public class HavingFilterCollectionCompiler : IHavingCompiler<HavingFilterCollection>
    {
        public string Compile(IHavingFilter filter, SelectQuery selectQuery, IQueryParameterManager parameters)
        {
            var havingFilters = filter as HavingFilterCollection;

            if (!havingFilters.Any())
            {
                return "(1 = 1)";
            }

            var HavingCompiler = new HavingFilterCompiler();
            
            var operatorString = havingFilters.GroupingOperator.ToSqlString();

            var result = string.Empty;
            bool first = true;
            foreach (var Having in havingFilters)
            {

                result += string.Format("\n\t {0} {1} ",
                            !first ? operatorString : null,
                            HavingCompiler.Compile(Having, selectQuery,parameters)
                          );

                first = false;
            }

            return string.Format("({0} \n\t )",result);
        }
    }
}