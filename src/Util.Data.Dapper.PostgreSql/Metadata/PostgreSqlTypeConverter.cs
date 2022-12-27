using System;
using System.Data;

namespace Util.Data.Metadata {
    /// <summary>
    /// PostgreSql数据类型转换器
    /// </summary>
    public class PostgreSqlTypeConverter : ITypeConverter {
        /// <inheritdoc />
        public DbType? ToType( string dataType, int? length = null ) {
            if ( dataType.IsEmpty() )
                return null;
            switch ( dataType.ToLower() ) {
                case "uuid":
                    return DbType.Guid;
                case "varchar":
                case "text":
                case "json":
                case "jsonb":
                case "xml":
                    return DbType.String;
                case "bool":
                    return DbType.Boolean;
                case "char":
                    return DbType.Byte;
                case "int2":
                    return DbType.Int16;
                case "int4":
                    return DbType.Int32;
                case "int8":
                    return DbType.Int64;
                case "float4":
                    return DbType.Single;
                case "float8":
                    return DbType.Double;
                case "numeric":
                case "decimal":
                    return DbType.Decimal;
                case "date":
                    return DbType.Date;
                case "time":
                case "timetz":
                    return DbType.Time;
                case "timestamp":
                case "timestamptz":
                    return DbType.DateTime;
                case "bytea":
                    return DbType.Binary;
            }
            throw new NotImplementedException( dataType );
        }
    }
}
