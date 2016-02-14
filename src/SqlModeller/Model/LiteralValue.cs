using System.Data;

namespace SqlModeller.Model
{
    public class LiteralValue
    {
        public string Value { get; set; }
        public DbType Type { get; set; }

        public LiteralValue(string value, DbType type)
        {
            Value = value;
            Type = type;
        }
    }
}