using SqlModeller.Interfaces;

namespace SqlModeller.Model.Select
{
    public class OrderByColumnSelector : IColumnSelector
    { 
        public string Alias { get; set; }

        public OrderByColumnSelector(string alias)
        {
            Alias = alias;
        }
    }
}