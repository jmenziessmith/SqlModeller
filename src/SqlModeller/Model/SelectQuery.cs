using System.Collections.Generic;
using SqlModeller.Interfaces;
using SqlModeller.Model.From;
using SqlModeller.Model.Having;
using SqlModeller.Model.Order;
using SqlModeller.Model.Where;

namespace SqlModeller.Model
{
    public class SelectQuery
    {
        public SelectQuery(bool selectDistinct = false)
        {
            SelectDistinct = selectDistinct;
            SelectColumns = new List<IColumnSelector>();
            TableJoins = new List<TableJoin>();
            GroupByColumns = new List<IGroupByColumn>();
            WhereFilters = new WhereFilterCollection();
            HavingFilters = new HavingFilterCollection();
            OrderByColumns = new List<OrderByColumn>();
        }

        public bool SelectDistinct { get; set; }
        public List<IColumnSelector> SelectColumns { get; set; }
        public Table FromTable { get; set; }
        public List<TableJoin> TableJoins { get; set; }
        public List<IGroupByColumn> GroupByColumns { get; set; }
        public List<OrderByColumn> OrderByColumns { get; set; }
        public WhereFilterCollection WhereFilters { get; set; }
        public HavingFilterCollection HavingFilters { get; set; }

        public int RowOffset { get; set; }
        public int? RowLimit { get; set; }
    }
}