using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlModeller.Helpers
{
    public static class DbTypeMap
    {
        private static Dictionary<Type, DbType> TypeMap { get; set; }

        static DbTypeMap()
        {
            TypeMap = new Dictionary<Type, DbType>();
            TypeMap[typeof (byte)] = DbType.Byte;
            TypeMap[typeof (sbyte)] = DbType.SByte;
            TypeMap[typeof (short)] = DbType.Int16;
            TypeMap[typeof (ushort)] = DbType.UInt16;
            TypeMap[typeof (int)] = DbType.Int32;
            TypeMap[typeof (uint)] = DbType.UInt32;
            TypeMap[typeof (long)] = DbType.Int64;
            TypeMap[typeof (ulong)] = DbType.UInt64;
            TypeMap[typeof (float)] = DbType.Single;
            TypeMap[typeof (double)] = DbType.Double;
            TypeMap[typeof (decimal)] = DbType.Decimal;
            TypeMap[typeof (bool)] = DbType.Boolean;
            TypeMap[typeof (string)] = DbType.String;
            TypeMap[typeof (char)] = DbType.StringFixedLength;
            TypeMap[typeof (Guid)] = DbType.Guid;
            TypeMap[typeof (DateTime)] = DbType.DateTime;
            TypeMap[typeof (DateTimeOffset)] = DbType.DateTimeOffset;
            TypeMap[typeof (byte[])] = DbType.Binary;
            TypeMap[typeof (byte?)] = DbType.Byte;
            TypeMap[typeof (sbyte?)] = DbType.SByte;
            TypeMap[typeof (short?)] = DbType.Int16;
            TypeMap[typeof (ushort?)] = DbType.UInt16;
            TypeMap[typeof (int?)] = DbType.Int32;
            TypeMap[typeof (uint?)] = DbType.UInt32;
            TypeMap[typeof (long?)] = DbType.Int64;
            TypeMap[typeof (ulong?)] = DbType.UInt64;
            TypeMap[typeof (float?)] = DbType.Single;
            TypeMap[typeof (double?)] = DbType.Double;
            TypeMap[typeof (decimal?)] = DbType.Decimal;
            TypeMap[typeof (bool?)] = DbType.Boolean;
            TypeMap[typeof (char?)] = DbType.StringFixedLength;
            TypeMap[typeof (Guid?)] = DbType.Guid;
            TypeMap[typeof (DateTime?)] = DbType.DateTime;
            TypeMap[typeof (DateTimeOffset?)] = DbType.DateTimeOffset;
            //typeMap[typeof (System.Data.Linq.Binary)] = DbType.Binary;
        }

        public static DbType Resolve(Type type)
        {
            if (TypeMap.ContainsKey(type))
            {
                return TypeMap[type];
            }
            return DbType.String;
        }

        public static DbType Resolve(object value)
        {
            return Resolve(value.GetType());
        }

        public static DbType Resolve<T>()
        {
            return Resolve(typeof(T));
        }

    }
}
