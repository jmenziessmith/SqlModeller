using System.Linq;
using SqlModeller.Helpers;
using SqlModeller.Interfaces;
using SqlModeller.Model;
using SqlModeller.Model.Select;

namespace SqlModeller.Compiler.SqlServer.SelectComilers
{
    public class ColumnSelectorCompiler : IColumnSelectorCompiler<ColumnSelector>
    {
        public string Compile(IColumnSelector value, SelectQuery query, IQueryParameterManager parameters)
        {
            var select = value as ColumnSelector;

            if (select.Aggregate != Aggregate.None)
            {
                var isInGroupBy = AggregateHelpers.IsInGroupBy(query, select);

                // if its in the group by, dont aggregate it
                if (!isInGroupBy)
                {
                    return string.Format("{0}({1}{2}{3}{4}) AS {5}",
                        select.Aggregate.ToSqlString(),
                        select.Aggregate == Aggregate.Bit ? "0+" : null, // fix bit field aggregation for nulls
                        select.TableAlias,
                        string.IsNullOrWhiteSpace(select.TableAlias) ? null : ".",
                        select.Field.Name,
                        select.Alias);
                }
            }

            return string.Format("{0}{1}{2} AS {3}", 
                select.TableAlias, 
                string.IsNullOrWhiteSpace(select.TableAlias) ? null : ".",
                select.Field.Name, 
                select.Alias);
        }

    }
}

