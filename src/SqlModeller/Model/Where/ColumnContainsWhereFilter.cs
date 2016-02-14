using SqlModeller.Interfaces;

namespace SqlModeller.Model.Where
{
    public class ColumnContainsWhereFilter : IWhereFilter
    {
        public Column LeftColumn { get; set; }
        public string Text { get; set; }
        public ContainsMode ContainsMode { get; set; }
         
    }
}