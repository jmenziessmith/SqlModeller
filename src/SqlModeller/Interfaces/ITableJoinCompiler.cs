using System;
namespace SqlModeller.Interfaces
{
    public interface ITableJoinCompiler : ISqlStatementCompiler<ITableJoin>
    {
    }

    public interface ITableJoinCompiler<T> : ITableJoinCompiler
    {
    }

}
