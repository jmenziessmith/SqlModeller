using SqlModdler.Interfaces;

namespace SqlModdler.Model.Where
{
    public class ColumnValueWhereFilter : IWhereFilter
    {
        public Column LeftColumn { get; set; }
        public LiteralValue RightValue { get; set; }
        public Compare Operator { get; set; }
    }
}