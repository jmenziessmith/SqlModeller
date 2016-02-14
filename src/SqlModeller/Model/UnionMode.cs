
namespace SqlModeller.Model
{
    public enum UnionMode
    {
        Union,
        UnionAll
    }

    public static class UnionModeExtensions
    {
        public static string ToSqlString(this UnionMode value)
        {
            switch (value)
            {
                case UnionMode.UnionAll:
                    return "UNION ALL";
            }
            return value.ToString().ToUpper();
        }
    }
}
