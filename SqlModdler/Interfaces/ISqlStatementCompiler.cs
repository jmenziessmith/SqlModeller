using System.Collections.Generic;
using SqlModdler.Model;

namespace SqlModdler.Interfaces
{
    public interface ISqlStatementCompiler<T>
    {
        string Compile(T value, SelectQuery query, IQueryParameterManager parameters);
    }
}