namespace SqlModdler.Compiler.Model
{
    public class CompiledCommonTableExpression
    {
        public string Alias { get; set; }
        public CompiledSelectQuery SelectQuery { get; set; }
    }
}