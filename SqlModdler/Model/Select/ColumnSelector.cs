using SqlModdler.Interfaces;

namespace SqlModdler.Model.Select
{
    public class ColumnSelector : Column, IColumnSelector
    {
        public string Alias { get; set; }
        public Aggregate Aggregate { get; set; }

        public ColumnSelector(string tableAlias, string fieldName, string alias, Aggregate aggregate)
            : base(tableAlias, fieldName)
        {
            Alias = alias;
            Aggregate = aggregate;
        }
    }
}