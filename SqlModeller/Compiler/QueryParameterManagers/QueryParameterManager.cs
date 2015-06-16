using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using SqlModeller.Compiler.SqlServer;
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

        public string Parameterize(string stringValue, DbType type, string alias = null)
        {
            var matchOn = ToStringHelper.ValueString(stringValue, type);
            var match = FindMatch(matchOn, type, alias);
            if (match != null)
            {
                return match.ParameterName;
            }

            var newParameter = NewParameter(stringValue, type, alias);

            return newParameter.ParameterName;
        }

        private QueryParameter FindMatch(string stringValue, DbType type, string alias)
        {
            return _parameters.FirstOrDefault(x => x.Alias == alias
                                                && x.StringValue == stringValue 
                                                && x.DataType == type);
        }

        private QueryParameter NewParameter(string stringValue, DbType type, string alias)
        {
            if (alias != null)
            {
                const string aliasPattern = "^[a-zA-Z0-9_]*$";
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
                             StringValue = ToStringHelper.ValueString(stringValue, type),
                             Value = Parse(stringValue, type)
                         };
             

            result.ParameterName = string.Format("@p{0}{1}{2}",
                                        result.ID,
                                        result.Alias != null ? "_" : null,
                                        result.Alias
                                        );

            _parameters.Add(result);

            return result;
        }

        private object Parse(string stringValue, DbType type)
        {
            switch (type)
            {
                case DbType.DateTime:
                case DbType.DateTime2:
                    return DateTime.Parse(stringValue);
            }
            return stringValue;
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
