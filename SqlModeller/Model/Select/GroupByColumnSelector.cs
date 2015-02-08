using SqlModeller.Interfaces;

namespace SqlModeller.Model.Select
{
    public class GroupByColumnSelector : IColumnSelector
    { 
        public string Alias { get; set; }

        public GroupByColumnSelector(string alias)
        {
            Alias = alias;
        }
    }
}