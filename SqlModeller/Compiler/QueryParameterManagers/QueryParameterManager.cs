using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using SqlModeller.Interfaces;
using SqlModeller.Model;

namespace SqlModeller.Compiler.QueryParameterManagers
{
    public class QueryParameterManager : IQueryParameterManager
    {
        private List<QueryParameter> _parameters;

        public QueryParameterManager(List<QueryParameter> parameters)
        {
            _parameters = parameters;
        }

        public string Parameterize(string value, DbType type, string alias = null)
        {
            var match = FindMatch(value, type, alias);
            if (match != null)
            {
                return match.ParameterName;
            }

            var newParameter = NewParameter(value, type, alias);

            return newParameter.ParameterName;
        }

        private QueryParameter FindMatch(string value, DbType type, string alias)
        {
            return _parameters.FirstOrDefault(x => x.Alias == alias 
                                                && x.Value == value 
                                                && x.DataType == type);
        }

        private QueryParameter NewParameter(string value, DbType type, string alias)
        {
            if (alias != null)
            {
                const string aliasPattern = "[a-zA-Z0-9]*";
                var regex = new Regex(aliasPattern);
                if (!regex.IsMatch(alias))
                {
                    alias = null;
                }
            }

            var result = new QueryParameter()
                         {
                             ID = GetNewID(),
                             Alias = alias,
                             DataType = type,
                             Value = value
                         };
             

            result.ParameterName = string.Format("@p{0}{1}{2}",
                                        result.ID,
                                        result.Alias != null ? "_" : null,
                                        result.Alias
                                        );

            _parameters.Add(result);

            return result;
        }

        private int GetNewID()
        {
            if (_parameters.Any())
            {
                return _parameters.Max(x => x.ID) + 1;
            }
            return 0;
        }
    }
}
