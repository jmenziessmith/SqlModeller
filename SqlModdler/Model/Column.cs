namespace SqlModdler.Model
{
    public class Column
    {
        public string TableAlias { get; set; }
        public Field Field { get; set; }
        
        public Column(string tableAlias, string fieldName)
        {
            TableAlias = tableAlias;
            Field = new Field(fieldName); 
        }
    }
}