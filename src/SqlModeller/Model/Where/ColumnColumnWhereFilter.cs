using SqlModeller.Interfaces;

namespace SqlModeller.Model.Where
{
    public class ColumnColumnWhereFilter : IWhereFilter
    {
        public Column LeftColumn { get; set; }
        public Column RightColumn { get; set; }
        public Compare Operator { get; set; }
    }
}