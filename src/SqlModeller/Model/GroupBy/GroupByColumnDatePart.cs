using SqlModeller.Interfaces;

namespace SqlModeller.Model.GroupBy
{
    public class GroupByColumnDatePart : Column, IGroupByColumn
    {
        public DatePart DatePart { get; set; }

        public GroupByColumnDatePart(string tableAlias, string fieldName, DatePart datePart)
            : base(tableAlias, fieldName)
        {
            DatePart = datePart;
        }
    }
}