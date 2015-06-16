using SqlModeller.Interfaces;

namespace SqlModeller.Model.Select
{
    public class ColumnDatePartSelector :ColumnSelector , IColumnSelector
    {
        public DatePart DatePart { get; set; }

        public ColumnDatePartSelector(string tableAlias, string fieldName, string alias, DatePart datePart, Aggregate aggregate) : base(tableAlias, fieldName, alias, aggregate)
        {
            DatePart = datePart;
        }
    }
}
