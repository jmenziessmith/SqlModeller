using System.Collections.Generic;
using SqlModeller.Interfaces;

namespace SqlModeller.Model.Having
{
    public class HavingFilterCollection : List<IHavingFilter>, IHavingFilter
    { 
        public Combine GroupingOperator { get; set; }
        public HavingFilterCollection NestedFilters { get; set; }
    }

}