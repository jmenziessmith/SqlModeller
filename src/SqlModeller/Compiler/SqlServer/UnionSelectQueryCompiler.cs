using SqlModeller.Model;
using SqlModeller.Interfaces;

namespace SqlModeller.Compiler.SqlServer
{
    public class UnionSelectQueryCompiler : SelectQueryCompiler
    {
        public override string CompileSelect(SelectQuery selectQuery, IQueryParameterManager parameters)
        {
            var unionQuery = selectQuery as UnionSelectQuery;
            var selectCompiler = new SelectQueryCompiler();

            return selectCompiler.Compile(unionQuery.FirstSelectQuery, parameters).Sql;
        }

        public override string CompileFrom(SelectQuery selectQuery, IQueryParameterManager parameters)
        {
            var unionQuery = selectQuery as UnionSelectQuery;
            var selectCompiler = new SelectQueryCompiler();

            var result = string.Empty;

            foreach(var union in unionQuery.UnionSelectQueries)
            {
                var q = selectCompiler.Compile(union.Item1, parameters).Sql;
                result += union.Item2.ToSqlString() + "\n"; // mode
                result += "(\n" + Indent(q) + ")\n";
            }

            return result;
        }

        public string Indent(string source, string indentation = "    ")
        {
            var result = string.Empty;
            var lines = source.Split('\n');
            foreach(var l in lines)
            {
                result += indentation + l + "\n";
            }

            return result;
        }
    }
}
