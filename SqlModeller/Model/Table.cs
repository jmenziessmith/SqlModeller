namespace SqlModeller.Model
{
    public class Table
    {
        public Table(string alias, string tableName)
        {
            Alias = alias;
            TableName = tableName;
        }

        public string Alias { get; set; }
        public string TableName { get; set; }
    }
}