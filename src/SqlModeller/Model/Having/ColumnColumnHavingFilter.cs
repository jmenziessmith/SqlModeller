using SqlModeller.Interfaces;

namespace SqlModeller.Model.Having
{
    public class ColumnColumnHavingFilter : IHavingFilter
    {
        public Column LeftColumn { get; set; }
        public Column RightColumn { get; set; }
        public Compare Operator { get; set; }
    }
}