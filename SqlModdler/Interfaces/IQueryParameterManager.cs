using System.Data;

namespace SqlModdler.Interfaces
{
    public interface IQueryParameterManager
    {
        string Parameterize(string value, DbType type, string alias = null);
    }
}
