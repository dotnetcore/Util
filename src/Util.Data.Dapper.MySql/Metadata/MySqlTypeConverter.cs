using System;
using System.Data;

namespace Util.Data.Metadata {
    /// <summary>
    /// MySql数据类型转换器
    /// </summary>
    public class MySqlTypeConverter : ITypeConverter {
        /// <inheritdoc />
        public DbType? ToType( string dataType, int? length = null ) {
            if ( dataType.IsEmpty() )
                return null;
            switch ( dataType.ToLower() ) {
                case "char":
                    return length == 36 ? DbType.Guid : DbType.String;
                case "varchar":
                case "tinytext":
                case "mediumtext":
                case "longtext":
                case "text":
                    return DbType.String;
                case "tinyint":
                    return length == 1 ? DbType.Boolean : DbType.Byte;
                case "bit":
                    return DbType.Boolean;
                case "smallint":
                    return DbType.Int16;
                case "integer":
                case "int":
                case "mediumint":
                    return DbType.Int32;
                case "bigint":
                    return DbType.Int64;
                case "float":
                    return DbType.Single;
                case "double":
                    return DbType.Double;
                case "decimal":
                case "numeric":
                    return DbType.Decimal;
                case "date":
                    return DbType.Date;
                case "time":
                    return DbType.Time;
                case "datetime":
                case "timestamp":
                    return DbType.DateTime;
                case "tinyblob":
                case "mediumblob":
                case "longblob":
                case "blob":
                    return DbType.Binary;
            }
            throw new NotImplementedException( dataType );
        }
    }
}
