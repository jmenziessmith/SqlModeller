using System.Linq;
using SqlModeller.Model;
using SqlModeller.Model.GroupBy;
using SqlModeller.Model.Select;

namespace SqlModeller.Helpers
{
    public static class AggregateHelpers
    {
        public static bool IsInGroupBy(SelectQuery query, Column select)
        {
            bool isInGroupBy = false;

            if (select is ColumnDatePartSelector)
            {
                var dateSelect = select as ColumnDatePartSelector;

                isInGroupBy = query.GroupByColumns.OfType<GroupByColumnDatePart>().Any(x =>
                    x.Field.Name == dateSelect.Field.Name
                    && x.TableAlias == dateSelect.TableAlias
                    && x.DatePart == dateSelect.DatePart
                    );
            }
            else
            {
                isInGroupBy = query.GroupByColumns.OfType<GroupByColumn>().Any(x =>
                    x.Field.Name == select.Field.Name
                    && x.TableAlias == select.TableAlias
                    );
            }  

            return isInGroupBy;
        }
    }
}
