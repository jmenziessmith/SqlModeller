using System.Data;

namespace SqlModeller.Compiler.SqlServer
{
    public static class ToStringHelper
    {
        public static string ValueString(string value, DbType type)
        {
            switch (type)
            {
                case DbType.String:
                case DbType.StringFixedLength:
                case DbType.AnsiString:
                case DbType.AnsiStringFixedLength:
                    return string.Format("'{0}'", value);

                case DbType.DateTime:
                case DbType.DateTime2:
                    return string.Format("'{0}'", value);
            }
            return value;
        }
    }
}
