namespace SqlModeller.Model.From
{
    public class JoinColumn
    {
        public JoinColumn(string tableAlias, string fieldName)
        {
            TableAlias = tableAlias; 
            Field = new Field(fieldName);
        }

        public string TableAlias { get; set; } 
        public Field Field { get; set; }
    }
}