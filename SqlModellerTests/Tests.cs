using System;
using NUnit.Framework;
using SqlModeller.Model;
using SqlModeller.Model.Having;
using SqlModeller.Model.Where;
using SqlModeller.Shorthand;

namespace SqlModellerTests
{
    [TestFixture]
    public class Tests
    {

        [Test]
        public void TestShorthand()
        {
            var countryTable = new Table("c", "Country");
            var teamTable = new Table("t", "Team");
            var playerTable = new Table("p", "Player");

            var cteQuery = new SelectQuery()

            // SELECT
                .SelectRowNumber("_ROW")
                    .SelectCount("_COUNT")
                    .SelectGroupKey("_GROUP_KEY")
                    .Select("1 as ONE")
                    .SelectAll()
                    .Select(countryTable, "ID", "C_ID", Aggregate.Min) // should not aggregate, its the group by
                    .Select(teamTable, "ID", "T_ID", Aggregate.Min)
                    .Select(teamTable, "Name", "T_NAME", Aggregate.Avg)
                    .Select(playerTable, "Name", "P_NAME", Aggregate.Sum)
            // FROM
                .From(countryTable)
                    .LeftJoin(teamTable, "CountryID", countryTable, "ID")
                    .Join(playerTable, "TeamID", teamTable, "ID", JoinType.InnerJoin, "AND 1 = 1")
            // WHERE
                .Where(Combine.And)
                    .Where("p.Name IS NOT NULL")
                    .WhereColumnColumn(teamTable, "ID", Compare.NotEqual, countryTable, "ID")
                    .WhereColumnValue(teamTable, "FirstName", Compare.NotEqual, "Peter")
                    .WhereColumnValue(playerTable, "StartDate", Compare.NotEqual, DateTime.Now)
                    .WhereCollection(Combine.Or, new WhereFilterCollection()
                        .WhereColumnColumn(teamTable, "Value1", Compare.GreaterThan, countryTable, "Value2")
                        .WhereColumnValue(teamTable, "Value3", Compare.LessThan, 1)
                    )
            // GROUP BY
                .GroupBy(countryTable, "ID")
            // Having
                .Having(Combine.And)
                    .Having("SUM(t.Points) > 4")
                    .HavingColumnValue(Aggregate.Sum, playerTable, "Goals", Compare.GreaterThan, 10)
                    .HavingCollection(Combine.Or,new HavingFilterCollection()
                        .HavingColumnValue(Aggregate.Min, playerTable, "RedCards", Compare.GreaterThan, 1)
                        .HavingColumnValue(Aggregate.Max, playerTable, "RedCards", Compare.LessThan, 5)
                    )
            // ORDER BY
                .OrderBy(countryTable, "ID", OrderDir.Asc)
                       .OrderByDesc(playerTable, "ID");

            var cte = new CommonTableExpression()
                      {
                          Alias = "cte1",
                          Query = cteQuery
                      };


            var query = new Query();
            query.CommonTableExpressions.Add(cte);
            query.SelectQuery = new SelectQuery()
                .SelectRowNumber("_ROW")
                .SelectTotal("_TOTAL_ROWS", 0)
                .SelectAll()
                .From(cte.Alias, cte.Alias)
                .OrderBy(cte.Alias, "_ROW")
                .Offset(10)
                .Fetch(5);

            var compiled = query.Compile();
            
            Console.WriteLine(compiled.ParameterSql);
            Console.WriteLine(compiled.Sql);

        }
        
    }
}
