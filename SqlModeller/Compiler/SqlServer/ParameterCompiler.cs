using System;
using System.Data;
using SqlModeller.Compiler.Model;
using SqlModeller.Model;

namespace SqlModeller.Compiler.SqlServer
{
    public class ParameterCompiler
    {
        public CompiledQueryParameter Compile(QueryParameter parameter)
        {
            var typeString = GetTypeString(parameter.DataType);

            var sql = string.Format("DECLARE {0} {1}; SET {0} = {2}",
                parameter.ParameterName,
                typeString,
                parameter.StringValue);

            var result = new CompiledQueryParameter()
                         {
                             Sql = sql,

                             StringValue = parameter.StringValue,
                             Value =  parameter.Value,
                             Alias =  parameter.Alias,
                             DataType = parameter.DataType,
                             ID = parameter.ID,
                             ParameterName = parameter.ParameterName
                         };

            return result;
        }

        private string GetTypeString(DbType dataType)
        {
            switch (dataType)
            {
                case DbType.String:
                case DbType.StringFixedLength:
                case DbType.AnsiString:
                case DbType.AnsiStringFixedLength:
                    return "NVARCHAR(max)";

                case DbType.Int16:
                    return "SMALLINT";
                case DbType.Int32:
                    return "INT";
                case DbType.Int64:
                    return "BIGINT";
                case DbType.Decimal:
                    return "DECIMAL";
                case DbType.Double:
                    return "DOUBLE";

                case DbType.DateTime:
                    return "DATETIME";
                case DbType.DateTime2:
                    return "DATETIME2";
            }
            throw new NotImplementedException();
        }
    }
}