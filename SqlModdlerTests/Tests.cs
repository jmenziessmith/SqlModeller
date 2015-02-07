using System;
using NUnit.Framework;
using SqlModdler;
using SqlModdler.Model;
using SqlModdler.Model.Where;
using SqlModdler.Shorthand;

namespace SqlModdlerTests
{
    [TestFixture]
    public class Tests
    {

        [Test]
        public void TestShorthand()
        {
            var campaignTable = new Table("c", "Campaign");
            var facebookCampaignTable = new Table("fc", "FacebookCampaign");
            var adGroupTable = new Table("ag", "AdGroup");

            var cteQuery = new SelectQuery()

            // SELECT
                .SelectRowNumber("_ROW")
                    .SelectCount("_COUNT")
                    .SelectGroupKey("_GROUP_KEY")
                    .Select("1 as ONE")
                    .SelectAll()
                    .Select(campaignTable, "ID", "C_ID", Aggregate.Min) // should not aggregate, its the group by
                    .Select(facebookCampaignTable, "ID", "FC_ID", Aggregate.Min)
                    .Select(facebookCampaignTable, "NAME", "FC_NAME", Aggregate.Avg)
                    .Select(adGroupTable, "NAME", "AG_NAME", Aggregate.Sum)
            // FROM
                .From(campaignTable)
                    .LeftJoin(facebookCampaignTable, "CampaignID", campaignTable, "ID")
                    .Join(adGroupTable, "CampaignID", campaignTable, "ID", JoinType.InnerJoin, "AND 1 = 0")
            // WHERE
                .Where(Combine.And)
                    .WhereColumnColumn(facebookCampaignTable, "ID", Compare.NotEqual, campaignTable, "ID")
                    .WhereCollection(Combine.Or,new WhereFilterCollection()
                        .WhereColumnColumn(facebookCampaignTable, "Value1", Compare.GreaterThan, campaignTable, "Value2")
                        .WhereColumnValue(facebookCampaignTable, "Value3", Compare.LessThan, 1)
                    )
                    .WhereColumnValue(facebookCampaignTable.Alias, "Value3", Compare.NotEqual, "HELLO")
                    .WhereColumnValue(facebookCampaignTable.Alias, "StartDate", Compare.NotEqual, DateTime.Now)
                    .Where("fc.Name IS NOT NULL")
            // GROUP BY
                .GroupBy(campaignTable, "ID")
            // ORDER BY
                .OrderBy(campaignTable, "ID", OrderDir.Asc)
                       .OrderByDesc(adGroupTable, "ID");

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
