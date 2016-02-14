using System;

namespace SqlModeller.Model
{
    public enum JoinType
    {
        Join,
        LeftJoin,
        RightJoin,
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
                case JoinType.RightJoin:
                    return "RIGHT JOIN";
                case JoinType.InnerJoin:
                    return "INNER JOIN";
            }

            throw new NotImplementedException();
        }
    }
}