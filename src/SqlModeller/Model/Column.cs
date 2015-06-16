namespace SqlModeller.Model
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


        public string FullName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(TableAlias))
                {
                    return Field.Name;
                }
                return string.Format("{0}.{1}", TableAlias, Field.Name);
            }
        }
    }
}