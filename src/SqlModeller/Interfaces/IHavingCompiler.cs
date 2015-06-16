namespace SqlModeller.Interfaces
{
    public interface IHavingCompiler : ISqlStatementCompiler<IHavingFilter>
    {
    }

    public interface IHavingCompiler<T> : IHavingCompiler
    {
    }
}