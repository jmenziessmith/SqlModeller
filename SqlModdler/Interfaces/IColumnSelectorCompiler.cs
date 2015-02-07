namespace SqlModdler.Interfaces
{
    public interface IColumnSelectorCompiler : ISqlStatementCompiler<IColumnSelector>
    { 
    }


    public interface IColumnSelectorCompiler<T> : IColumnSelectorCompiler
    {
    }
}
