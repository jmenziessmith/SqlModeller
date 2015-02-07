using System.Data;
using SqlModdler.Interfaces;

namespace SqlModdler.Compiler.QueryParameterManagers
{
    public class NoQueryParameterManager : IQueryParameterManager
    {
        
        public string Parameterize(string value, DbType type, string alias = null)
        {
            return value;
        }
    }
}