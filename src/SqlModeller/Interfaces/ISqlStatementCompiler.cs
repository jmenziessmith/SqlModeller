using System.Collections.Generic;
using SqlModeller.Model;

namespace SqlModeller.Interfaces
{
    public interface ISqlStatementCompiler<T>
    {
        string Compile(T value, SelectQuery query, IQueryParameterManager parameters);
    }
}