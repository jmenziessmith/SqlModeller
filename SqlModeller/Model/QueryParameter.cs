using System.Data;

namespace SqlModeller.Model
{
    public class QueryParameter
    {
        public int ID { get; set; }
        public string ParameterName { get; set; }
        public DbType DataType { get; set; }
        public string StringValue { get; set; }
        public object Value { get; set; }
        public string Alias { get; set; }
    }
}
