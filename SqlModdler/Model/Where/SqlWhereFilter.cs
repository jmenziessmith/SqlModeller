using SqlModdler.Interfaces;

namespace SqlModdler.Model.Where
{
    public class SqlWhereFilter : IWhereFilter
    {
        public string Sql { get; set; }

        public SqlWhereFilter(string sql)
        {
            Sql = sql;
        }
    }
}