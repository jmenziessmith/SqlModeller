namespace SqlModeller.Interfaces
{
    public interface IGroupByColumnCompiler : ISqlStatementCompiler<IGroupByColumn>
    {
    }

    public interface IGroupByColumnCompiler<T> : IGroupByColumnCompiler
    {
    }
}