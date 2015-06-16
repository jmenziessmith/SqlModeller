using System.Collections.Generic;

namespace SqlModeller.Model
{
    public class Query
    {
        public List<CommonTableExpression> CommonTableExpressions { get; set; }
        public SelectQuery SelectQuery { get; set; }
        public List<QueryParameter> Parameters { get; set; }

        public Query()
        {
            CommonTableExpressions = new List<CommonTableExpression>();
            Parameters = new List<QueryParameter>();
        }
    }
}