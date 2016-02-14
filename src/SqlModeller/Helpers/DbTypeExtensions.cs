using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlModeller.Helpers
{
    public static class DbTypeExtensions
    {
        public static bool IsStringType(this DbType value)
        {
            switch (value)
            {
                case DbType.AnsiString: 
                case DbType.Date: 
                case DbType.DateTime: 
                case DbType.Guid: 
                case DbType.String: 
                case DbType.Time: 
                case DbType.AnsiStringFixedLength: 
                case DbType.StringFixedLength: 
                case DbType.Xml: 
                case DbType.DateTime2: 
                case DbType.DateTimeOffset:
                    return true;
            }
            return false;
        }
    }
}
