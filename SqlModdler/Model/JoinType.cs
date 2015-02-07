using System;

namespace SqlModdler.Model
{
    public enum JoinType
    {
        Join,
        LeftJoin,
        InnerJoin
    }

    public static class JoinTypeExtensions
    {
        public static string ToSqlString(this JoinType joinType)
        {
            switch (joinType)
            {
                case JoinType.Join:
                    return "JOIN";
                case JoinType.LeftJoin:
                    return "LEFT JOIN";
                case JoinType.InnerJoin:
                    return "INNER JOIN";
            }

            throw new NotImplementedException();
        }
    }
}