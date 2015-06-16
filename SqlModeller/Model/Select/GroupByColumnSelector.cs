using SqlModeller.Interfaces;

namespace SqlModeller.Model.Select
{
    public class GroupByColumnSelector : IColumnSelector
    { 
        public string Alias { get; set; }
        public int Index { get; set; }

        public GroupByColumnSelector(string alias, int index = 0)
        {
            Alias = alias;
            Index = index;
        }
    }
}