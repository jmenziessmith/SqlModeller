using System.Collections.Generic;
using System.Linq;
using SqlModdler.Interfaces;
using SqlModdler.Model;
using SqlModdler.Model.Select;

namespace SqlModdler.Compiler.SqlServer.SelectComilers
{
    public class ColumnSelectorCompiler : IColumnSelectorCompiler<ColumnSelector>
    {
        public string Compile(IColumnSelector value, SelectQuery query, IQueryParameterManager parameters)
        {
            var select = value as ColumnSelector;

            if (select.Aggregate != Aggregate.None)
            {
                var isInGroupBy = query.GroupByColumns.Any(x => 
                                       x.Field.Name == select.Field.Name
                                    && x.TableAlias == select.TableAlias
                                );

                // if its in the group by, dont aggregate it
                if (!isInGroupBy)
                {
                    return string.Format("{0}({1}.{2}) AS {3}",
                        select.Aggregate.ToSqlString(),
                        select.TableAlias,
                        select.Field.Name,
                        select.Alias);
                }
            }

            return string.Format("{0}.{1} AS {2}", 
                select.TableAlias, 
                select.Field.Name, 
                select.Alias);
        }
    }
}

