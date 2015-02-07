using SqlModdler.Interfaces;

namespace SqlModdler.Model.Select
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