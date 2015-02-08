using System.Data;

namespace SqlModeller.Model
{
    public class QueryParameter
    {
        public int ID { get; set; }
        public string ParameterName { get; set; }
        public DbType DataType { get; set; }
        public string Value { get; set; }
        public string Alias { get; set; }
    }
}
