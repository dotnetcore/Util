using System;
using System.Data;

namespace Util.Data.Metadata {
    /// <summary>
    /// Sql Server数据类型转换器
    /// </summary>
    public class SqlServerTypeConverter : ITypeConverter {
        /// <inheritdoc />
        public DbType? ToType( string dataType, int? length = null ) {
            if ( dataType.IsEmpty() )
                return null;
            switch ( dataType.ToLower() ) {
                case "uniqueidentifier":
                    return DbType.Guid;
                case "char":
                    return DbType.AnsiStringFixedLength;
                case "nchar":
                    return DbType.StringFixedLength;
                case "varchar":
                    return DbType.AnsiString;
                case "nvarchar":
                case "text":
                case "ntext":
                    return DbType.String;
                case "bit":
                    return DbType.Boolean;
                case "tinyint":
                    return DbType.Byte;
                case "smallint":
                    return DbType.Int16;
                case "int":
                    return DbType.Int32;
                case "bigint":
                    return DbType.Int64;
                case "real":
                    return DbType.Single;
                case "float":
                    return DbType.Double;
                case "decimal":
                case "numeric":
                case "money":
                case "smallmoney":
                    return DbType.Decimal;
                case "date":
                    return DbType.Date;
                case "time":
                    return DbType.Time;
                case "datetime":
                case "smalldatetime":
                    return DbType.DateTime;
                case "datetime2":
                    return DbType.DateTime2;
                case "datetimeoffset":
                    return DbType.DateTimeOffset;
                case "binary":
                case "varbinary":
                case "varbinary(max)":
                case "image":
                case "rowversion":
                case "timestamp":
                    return DbType.Binary;
                case "xml":
                    return DbType.Xml;
                case "sql_variant":
                    return DbType.Object;
            }
            throw new NotImplementedException( dataType );
        }
    }
}
