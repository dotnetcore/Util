using System.Data;

namespace Util.Generators.Contexts {
    /// <summary>
    /// 数据类型扩展操作
    /// </summary>
    public static class DbTypeExtensions {
        /// <summary>
        /// 转换为系统类型
        /// </summary>
        public static SystemType? ToSystemType( this DbType? type ) {
            if( type == null )
                return null;
            switch( type ) {
                case DbType.Guid:
                    return SystemType.Guid;
                case DbType.AnsiString:
                case DbType.String:
                case DbType.AnsiStringFixedLength:
                case DbType.StringFixedLength:
                    return SystemType.String;
                case DbType.Boolean:
                    return SystemType.Bool;
                case DbType.Byte:
                    return SystemType.Byte;
                case DbType.Int16:
                    return SystemType.Short;
                case DbType.Int32:
                    return SystemType.Int;
                case DbType.Int64:
                    return SystemType.Long;
                case DbType.Single:
                    return SystemType.Single;
                case DbType.Double:
                    return SystemType.Double;
                case DbType.Decimal:
                    return SystemType.Decimal;
                case DbType.Date:
                case DbType.Time:
                case DbType.DateTime:
                case DbType.DateTime2:
                case DbType.DateTimeOffset:
                    return SystemType.DateTime;
                case DbType.Binary:
                    return SystemType.Binary;
            }
            return null;
        }
    }
}
