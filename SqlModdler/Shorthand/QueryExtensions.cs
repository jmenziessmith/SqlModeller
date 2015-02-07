using SqlModdler.Compiler.Model;
using SqlModdler.Compiler.SqlServer;
using SqlModdler.Model;

namespace SqlModdler.Shorthand
{
    public static partial class Shorthand
    {
        public static CompiledQuery Compile(this Query query, bool useParameters = true)
        {
            return new QueryCompiler().Compile(query, useParameters);
        }
    }
}