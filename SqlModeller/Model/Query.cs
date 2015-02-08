using System.Collections.Generic;

namespace SqlModeller.Model
{
    public class Query
    {
        public List<CommonTableExpression> CommonTableExpressions { get; set; }
        public SelectQuery SelectQuery { get; set; }

        public Query()
        {
            CommonTableExpressions = new List<CommonTableExpression>();
        }
    }
}