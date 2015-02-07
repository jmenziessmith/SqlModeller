using SqlModdler.Interfaces;

namespace SqlModdler.Model.Select
{
    public class TotalColumnSelector : IColumnSelector
    { 
        public string Alias { get; set; }
        public int? OnlyOnRowIndex { get; set; }

        public TotalColumnSelector(string alias, int? onlyOnRowIndex)
        {
            Alias = alias;
            OnlyOnRowIndex = onlyOnRowIndex;
        }
    }
}