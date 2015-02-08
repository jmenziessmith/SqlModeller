using SqlModeller.Interfaces;

namespace SqlModeller.Model.Having
{
    public class ColumnValueHavingFilter : IHavingFilter
    {
        public Aggregate Aggregate { get; set; }
        public Column LeftColumn { get; set; }
        public LiteralValue RightValue { get; set; }
        public Compare Operator { get; set; }
    }
}