using System;

namespace SqlModeller.Model
{
    public enum Compare
    {
        LessThan, 
        LessThanOrEqual, 
        Equal,
        NotEqual,
        GreaterThanOrEqual,
        GreaterThan
    }

    public static class ComparisonOperatorExtensions
    {
        public static string ToSqlString(this Compare value)
        {
            switch (value)
            {
                case Compare.LessThan :
                    return "<";
                case Compare.LessThanOrEqual:
                    return "<=";
                case Compare.Equal:
                    return "=";
                case Compare.NotEqual:
                    return "<>";
                case Compare.GreaterThanOrEqual:
                    return ">=";
                case Compare.GreaterThan:
                    return ">";
            }
            throw new NotImplementedException();
        }
    }
}