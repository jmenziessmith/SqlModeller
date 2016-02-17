using SqlModeller.Interfaces;
using System.Collections.Generic;

namespace SqlModeller.Model.From
{
    public class GroupedTableJoin : TableJoin
    { 
        public List<TableJoin> GroupedJoins { get; set; } 
    }
}
