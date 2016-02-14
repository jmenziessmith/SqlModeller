using System.Data;
using SqlModeller.Interfaces;

namespace SqlModeller.Compiler.QueryParameterManagers
{
    public class NoQueryParameterManager : IQueryParameterManager
    {
        
        public string Parameterize(string value, DbType type, string alias = null)
        {
            return value;
        }
    }
}