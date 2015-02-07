using System;

namespace SqlModdler.Model
{
    public enum Combine
    {
        And, 
        AndNot,
        Or,
        OrNot
    }

    public static class BooleanOperatorExtensions
    {
        public static string ToSqlString(this Combine value)
        {
            switch (value)
            {
                case Combine.And:
                    return "AND";
                case Combine.AndNot:
                    return "AND NOT";
                case Combine.Or:
                    return "OR";
                case Combine.OrNot:
                    return "OR NOT";
            }
            throw new NotImplementedException();
        }
    }
}