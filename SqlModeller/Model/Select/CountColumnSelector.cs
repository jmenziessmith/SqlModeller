using SqlModeller.Interfaces;

namespace SqlModeller.Model.Select
{
    public class CountColumnSelector : IColumnSelector
    { 
        public string Alias { get; set; }

        public CountColumnSelector(string alias)
        {
            Alias = alias;
        }
    }
}