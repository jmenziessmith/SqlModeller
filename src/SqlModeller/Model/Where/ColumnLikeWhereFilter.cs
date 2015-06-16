using SqlModeller.Interfaces;

namespace SqlModeller.Model.Where
{
    public class ColumnLikeWhereFilter : IWhereFilter
    {
        public Column LeftColumn { get; set; }
        public string Text { get; set; }
        public LikeMode LikeMode { get; set; }
         
    }
}