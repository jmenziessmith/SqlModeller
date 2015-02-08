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
        public SelectQuery()
        {
            SelectColumns = new List<IColumnSelector>();
            TableJoins = new List<TableJoin>();
            GroupByColumns = new List<Column>();
            WhereFilters = new WhereFilterCollection();
            HavingFilters = new HavingFilterCollection();
            OrderByColumns = new List<OrderByColumn>();
        }

        public List<IColumnSelector> SelectColumns { get; set; }
        public Table FromTable { get; set; }
        public List<TableJoin> TableJoins { get; set; }
        public List<Column> GroupByColumns { get; set; }
        public List<OrderByColumn> OrderByColumns { get; set; }
        public WhereFilterCollection WhereFilters { get; set; }
        public HavingFilterCollection HavingFilters { get; set; }

        public int? RowOffset { get; set; }
        public int? RowLimit { get; set; }
    }
}