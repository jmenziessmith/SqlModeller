using SqlModdler.Interfaces;

namespace SqlModdler.Model.Select
{
    public class RowNumberColumnSelector : IColumnSelector
    { 
        public string Alias { get; set; }

        public RowNumberColumnSelector(string alias)
        {
            Alias = alias;
        }
    }
}