using SqlModdler.Model;

namespace SqlModdler.Compiler.Model
{
    public class CompiledQueryParameter : QueryParameter
    {
        public string Sql { get; set; }
    }
}