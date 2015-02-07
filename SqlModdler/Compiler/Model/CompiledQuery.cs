using System.Collections.Generic;
using System.Linq;
using SqlModdler.Model;

namespace SqlModdler.Compiler.Model
{
    public class CompiledQuery
    { 
        public List<CompiledQueryParameter> Parameters { get; set; }
        public List<CompiledCommonTableExpression> CommonTableExpressions { get; set; }
        public CompiledSelectQuery SelectQuery { get; set; }

        public CompiledQuery()
        {
            Parameters = new List<CompiledQueryParameter>(); 
            CommonTableExpressions = new List<CompiledCommonTableExpression>();
        }

        public string Sql
        {
            get { return GetSql(); }
        }


        public string ParameterSql
        {
            get { return GetParameterSql(); }
        }

        private string GetSql()
        {
            var result = string.Empty;

            if (CommonTableExpressions.Any())
            {
                result += "; WITH ";
            }

            foreach (var cte in CommonTableExpressions)
            {
                result += string.Format("\n\n{0} AS (\n\n{1}\n\n) /* {0} */ ,", cte.Alias, cte.SelectQuery.Sql);
            }

            result = result.TrimEnd(',');

            result += "\n\n" + SelectQuery.Sql;

            return result;
        }


        private string GetParameterSql()
        {
            var result = string.Empty;

            foreach (var param in Parameters)
            {
                result += param.Sql + "\n";
            }

            return result;
        }

    }
}