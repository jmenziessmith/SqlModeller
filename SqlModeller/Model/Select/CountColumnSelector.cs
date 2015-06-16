using SqlModeller.Interfaces;

namespace SqlModeller.Model.Select
{
    public class CountColumnSelector : IColumnSelector
    { 
        public string Alias { get; set; }
        public string FieldName { get; set; }
        public CountColumnSelector(string alias, string fieldName)
        {
            Alias = alias;
            FieldName = fieldName;
        }
    }
}