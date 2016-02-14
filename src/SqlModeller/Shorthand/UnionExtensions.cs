using SqlModeller.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlModeller.Shorthand
{
    public static partial class Shorthand
    {
        public static UnionSelectQuery Union(this SelectQuery query, SelectQuery secondQuery)
        {
            var unionQuery = query as UnionSelectQuery;
            if (unionQuery != null)
            {
                unionQuery.Add(secondQuery, UnionMode.Union);
            }
            else
            {
                unionQuery = new UnionSelectQuery(query, secondQuery, UnionMode.Union);
            }

            return unionQuery;
        }
        public static UnionSelectQuery UnionAll(this SelectQuery query, SelectQuery secondQuery)
        {
            var unionQuery = query as UnionSelectQuery;
            if (unionQuery != null)
            {
                unionQuery.Add(secondQuery, UnionMode.UnionAll);
            }
            else
            {
                unionQuery = new UnionSelectQuery(query, secondQuery, UnionMode.UnionAll);
            }

            return unionQuery;
        }
    }
}
