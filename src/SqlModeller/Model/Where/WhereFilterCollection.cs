using System.Collections.Generic;
using SqlModeller.Interfaces;

namespace SqlModeller.Model.Where
{
    public class WhereFilterCollection : List<IWhereFilter>, IWhereFilter
    { 
        public Combine GroupingOperator { get; set; }
        public WhereFilterCollection NestedFilters { get; set; }
    }

}