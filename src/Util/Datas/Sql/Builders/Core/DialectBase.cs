namespace Util.Datas.Sql.Builders.Core {
    /// <summary>
    /// 方言
    /// </summary>
    public class DialectBase : IDialect {
        /// <summary>
        /// 起始转义标识符
        /// </summary>
        public virtual string OpeningIdentifier { get; } = "[";

        /// <summary>
        /// 结束转义标识符
        /// </summary>
        public virtual string ClosingIdentifier { get; } = "]";

        /// <summary>
        /// 获取安全名称
        /// </summary>
        public virtual string SafeName( string name ) {
            if( string.IsNullOrWhiteSpace( name ) )
                return string.Empty;
            if( name == "*" )
                return name;
            return GetSafeName( FilterName( name ) );
        }

        /// <summary>
        /// 过滤名称
        /// </summary>
        /// <param name="name">名称</param>
        protected string FilterName( string name ) {
            return name.Trim().TrimStart( '[' ).TrimEnd( ']' ).TrimStart( '`' ).TrimEnd( '`' ).TrimStart( '"' ).TrimEnd( '"' );
        }

        /// <summary>
        /// 获取安全名称
        /// </summary>
        /// <param name="name">名称</param>
        protected virtual string GetSafeName( string name ) {
            return $"[{name}]";
        }

        /// <summary>
        /// 获取参数前缀
        /// </summary>
        public virtual string GetPrefix() {
            return "@";
        }

        /// <summary>
        /// Select子句是否支持As关键字
        /// </summary>
        public virtual bool SupportSelectAs() {
            return true;
        }

        /// <summary>
        /// 创建参数名
        /// </summary>
        /// <param name="paramIndex">参数索引</param>
        public virtual string GenerateName( int paramIndex ) {
            return $"{GetPrefix()}_p_{paramIndex}";
        }

        /// <summary>
        /// 获取参数名
        /// </summary>
        /// <param name="paramName">参数名</param>
        public virtual string GetParamName( string paramName ) {
            return paramName;
        }

        /// <summary>
        /// 获取参数值
        /// </summary>
        /// <param name="paramValue">参数值</param>
        public virtual object GetParamValue( object paramValue ) {
            return paramValue;
        }
    }
}
