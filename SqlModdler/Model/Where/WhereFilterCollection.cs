using System.Collections.Generic;
using SqlModdler.Interfaces;

namespace SqlModdler.Model.Where
{
    public class WhereFilterCollection : List<IWhereFilter>, IWhereFilter
    { 
        public Combine GroupingOperator { get; set; }
        public WhereFilterCollection NestedFilters { get; set; }
    }

}