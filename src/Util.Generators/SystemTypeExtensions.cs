namespace Util.Generators {
    /// <summary>
    /// 系统类型扩展操作
    /// </summary>
    public static class SystemTypeExtensions {
        /// <summary>
        /// 获取类型字符串
        /// </summary>
        /// <param name="type">系统类型</param>
        /// <param name="isNullable">是否可空</param>
        public static string ToTypeString( this SystemType? type, bool isNullable ) {
            if ( type == null )
                return null;
            switch( type ) {
                case SystemType.Guid:
                    return isNullable? "Guid?": "Guid";
                case SystemType.String:
                    return "string";
                case SystemType.Byte:
                    return isNullable ? "byte?" : "byte";
                case SystemType.Short:
                    return isNullable ? "short?" : "short";
                case SystemType.Int:
                    return isNullable ? "int?" : "int";
                case SystemType.Long:
                    return isNullable ? "long?" : "long";
                case SystemType.Single:
                    return isNullable ? "float?" : "float";
                case SystemType.Double:
                    return isNullable ? "double?" : "double";
                case SystemType.Decimal:
                    return isNullable ? "decimal?" : "decimal";
                case SystemType.Bool:
                    return isNullable ? "bool?" : "bool";
                case SystemType.DateTime:
                    return isNullable ? "DateTime?" : "DateTime";
                case SystemType.Binary:
                    return "byte[]";
                default:
                    return null;
            }
        }
    }
}
