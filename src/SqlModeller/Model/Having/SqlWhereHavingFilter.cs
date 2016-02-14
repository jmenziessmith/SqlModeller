using SqlModeller.Interfaces;

namespace SqlModeller.Model.Having
{
    public class SqlHavingFilter : IHavingFilter
    {
        public string Sql { get; set; }

        public SqlHavingFilter(string sql)
        {
            Sql = sql;
        }
    }
}