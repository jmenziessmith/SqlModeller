using SqlModeller.Interfaces;

namespace SqlModeller.Model.Select
{
    public class SqlColumnSelector : IColumnSelector
    {
        public string Sql { get; set; }

        public SqlColumnSelector(string sql)
        {
            Sql = sql;
        }
    }
}