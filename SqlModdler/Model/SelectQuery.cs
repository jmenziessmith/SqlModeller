using System.Collections.Generic;
using SqlModdler.Interfaces;
using SqlModdler.Model.From;
using SqlModdler.Model.Order;
using SqlModdler.Model.Where;

namespace SqlModdler.Model
{
    public class SelectQuery
    {
        public SelectQuery()
        {
            SelectColumns = new List<IColumnSelector>();
            TableJoins = new List<TableJoin>();
            GroupByColumns = new List<Column>();
            WhereFilters = new WhereFilterCollection();
            OrderByColumns = new List<OrderByColumn>();
        }

        public List<IColumnSelector> SelectColumns { get; set; }
        public Table FromTable { get; set; }
        public List<TableJoin> TableJoins { get; set; }
        public List<Column> GroupByColumns { get; set; }
        public List<OrderByColumn> OrderByColumns { get; set; }
        public WhereFilterCollection WhereFilters { get; set; }

        public int? RowOffset { get; set; }
        public int? RowLimit { get; set; }

     
    }
}