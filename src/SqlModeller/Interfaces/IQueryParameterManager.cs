using System.Data;

namespace SqlModeller.Interfaces
{
    public interface IQueryParameterManager
    {
        string Parameterize(string value, DbType type, string alias = null);
    }
}
