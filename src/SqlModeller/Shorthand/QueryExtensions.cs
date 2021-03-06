﻿using SqlModeller.Compiler.Model;
using SqlModeller.Compiler.SqlServer;
using SqlModeller.Model;

namespace SqlModeller.Shorthand
{
    public static partial class Shorthand
    {
        
        public static Query Select(this Query query, SelectQuery selectQuery)
        {
            query.SelectQuery = selectQuery;
            return query;
        }
        
        public static CompiledQuery Compile(this Query query, bool useParameters = true)
        {
            return new QueryCompiler().Compile(query, useParameters);
        } 
    }
}