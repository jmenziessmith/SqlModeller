using SqlModeller.Interfaces;
using SqlModeller.Model;
using SqlModeller.Model.Where;

namespace SqlModeller.Compiler.SqlServer.WhereCompilers
{
    public class ColumnInWhereFilterCompiler : IWhereCompiler<ColumnInWhereFilter>
    {
        public string Compile(IWhereFilter filter, SelectQuery query, IQueryParameterManager parameters)
        {
            var where = filter as ColumnInWhereFilter;

            var valueString = ValuesCsv(where, parameters);

            return string.Format("{0} IN ({1})",
                where.LeftColumn.FullName, 
                valueString
                );
        }

        private string ValuesCsv(ColumnInWhereFilter where, IQueryParameterManager parameters)
        {
            string result = string.Empty;

            foreach (var value in where.RightValues)
            {
                var param = parameters.Parameterize(value.Value, value.Type, where.ParameterAlias ?? where.LeftColumn.Field.Name);
                result += param + " ,";
            }
            

            return result.TrimEnd(',');
        }
      
    }
}