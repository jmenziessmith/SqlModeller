namespace SqlModdler.Interfaces
{
    public interface IWhereCompiler : ISqlStatementCompiler<IWhereFilter>
    {
    }


    public interface IWhereCompiler<T> : IWhereCompiler
    {
    }
}