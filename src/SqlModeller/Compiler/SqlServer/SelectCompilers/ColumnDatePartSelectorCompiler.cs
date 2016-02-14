using SqlModeller.Helpers;
using SqlModeller.Interfaces;
using SqlModeller.Model;
using SqlModeller.Model.Select;

namespace SqlModeller.Compiler.SqlServer.SelectCompilers
{
    public class ColumnDatePartSelectorCompiler : IColumnSelectorCompiler<ColumnDatePartSelector>
    {
        public string Compile(IColumnSelector value, SelectQuery query, IQueryParameterManager parameters)
        {
            var select = value as ColumnDatePartSelector;


            var format = "DATEADD({0},0, DATEDIFF({0},0, {1}{2}{3}))";
             
            if (select.Aggregate != Aggregate.None)
            {
                var isInGroupBy = AggregateHelpers.IsInGroupBy(query, select);

                // if its in the group by, dont aggregate it
                if (!isInGroupBy)
                {
                    return string.Format("{5}(" + format + ") AS {4}",
                        select.DatePart.ToSqlString(),
                        select.TableAlias,
                        string.IsNullOrWhiteSpace(select.TableAlias) ? null : ".",
                        select.Field.Name,
                        select.Alias,
                        select.Aggregate.ToSqlString()
                        );
                }
            }

            return string.Format(format + " AS {4}",
                select.DatePart.ToSqlString(),
                select.TableAlias,
                string.IsNullOrWhiteSpace(select.TableAlias) ? null : ".",
                select.Field.Name,
                select.Alias
                );
        }
    }
}
