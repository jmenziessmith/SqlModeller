using SqlModeller.Interfaces;

namespace SqlModeller.Model.Where
{
    public class ColumnValueWhereFilter : IWhereFilter
    {
        public Column LeftColumn { get; set; }
        public LiteralValue RightValue { get; set; }
        public Compare Operator { get; set; }

        /// <summary>
        /// Optional value, used for naming parameters. If not set, the field name will be used
        /// </summary>
        public string ParameterAlias { get; set; }
    }
}