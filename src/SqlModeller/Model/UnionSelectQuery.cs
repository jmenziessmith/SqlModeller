using SqlModeller.Model.From;
using System;
using System.Collections.Generic;

namespace SqlModeller.Model
{    
  
    public class UnionSelectQuery : SelectQuery
    {
        #region hidden properties
        new private Table FromTable { get; set; }
        new private List<TableJoin> TableJoins { get; set; }
        #endregion


        public SelectQuery FirstSelectQuery { get; set; }
        public List<Tuple<SelectQuery, UnionMode>> UnionSelectQueries { get; set; }

        public UnionSelectQuery(SelectQuery firstSelect, SelectQuery secondSelect, UnionMode mode)
        {
            FirstSelectQuery = firstSelect;
            UnionSelectQueries = new List<Tuple<SelectQuery, UnionMode>>();
            UnionSelectQueries.Add(new Tuple<SelectQuery, UnionMode>(secondSelect, mode));
        }

        internal void Add(SelectQuery selectQuery, UnionMode mode)
        {
            UnionSelectQueries.Add(new Tuple<SelectQuery, UnionMode>(selectQuery, mode));
        }
    }
}
