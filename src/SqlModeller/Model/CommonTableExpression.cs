namespace SqlModeller.Model
{
    public class CommonTableExpression
    {
        public string Alias { get; set; }
        public SelectQuery Query { get; set; }
    }
}