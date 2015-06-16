using SqlModeller.Interfaces;

namespace SqlModeller.Model.GroupBy
{
    public class GroupByColumn : Column, IGroupByColumn
    {
        public GroupByColumn(string tableAlias, string fieldName) : base(tableAlias, fieldName)
        {
        }


    }
}
