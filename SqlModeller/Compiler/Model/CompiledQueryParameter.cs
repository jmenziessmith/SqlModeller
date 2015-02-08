using SqlModeller.Model;

namespace SqlModeller.Compiler.Model
{
    public class CompiledQueryParameter : QueryParameter
    {
        public string Sql { get; set; }
    }
}