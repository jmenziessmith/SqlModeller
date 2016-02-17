using SqlModeller.Interfaces;

namespace SqlModeller.Model.From
{
    public class TableJoin : ITableJoin
    {
        public JoinType JoinType { get; set; }
        public Table JoinTable { get; set; }
        public Field JoinField { get; set; }
        public JoinColumn ForeignColumn { get; set; }
        public string Extra { get; set; }
    }
}