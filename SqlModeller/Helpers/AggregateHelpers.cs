using System.Linq;
using SqlModeller.Model;

namespace SqlModeller.Helpers
{
    public static class AggregateHelpers
    {
        public static bool IsInGroupBy(SelectQuery query, Column select)
        {
            var isInGroupBy = query.GroupByColumns.Any(x =>
                x.Field.Name == select.Field.Name
                && x.TableAlias == select.TableAlias
                );
            return isInGroupBy;
        }
    }
}
