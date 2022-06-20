using System;

namespace Util.Data.Sql.Builders.Core {
    /// <summary>
    /// Sql方言
    /// </summary>
    public abstract class DialectBase : IDialect {
        /// <summary>
        /// 获取起始转义标识符
        /// </summary>
        public abstract string GetOpeningIdentifier();

        /// <summary>
        /// 获取结束转义标识符
        /// </summary>
        public abstract string GetClosingIdentifier();

        /// <summary>
        /// 获取安全名称
        /// </summary>
        public virtual string GetSafeName( string name ) {
            if( string.IsNullOrWhiteSpace( name ) )
                return string.Empty;
            if( name == "*" )
                return name;
            return $"{GetOpeningIdentifier()}{FilterName( name )}{GetClosingIdentifier()}";
        }

        /// <summary>
        /// 过滤名称
        /// </summary>
        private string FilterName( string name ) {
            return name.Trim().RemoveStart( GetOpeningIdentifier() ).RemoveEnd( GetClosingIdentifier() );
        }

        /// <summary>
        /// 获取参数前缀
        /// </summary>
        public abstract string GetPrefix();

        /// <summary>
        /// Select子句是否支持As关键字
        /// </summary>
        public virtual bool SupportSelectAs() {
            return true;
        }

        /// <summary>
        /// 替换Sql,将[]替换为特定Sql转义符
        /// </summary>
        /// <param name="sql">原始Sql</param>
        public virtual string ReplaceSql( string sql ) {
            return sql?
                .Replace( "[[", "|&<&|", StringComparison.Ordinal )
                .Replace( "]]", "|&>&|", StringComparison.Ordinal )
                .Replace( "[", GetOpeningIdentifier(), StringComparison.Ordinal )
                .Replace( "]", GetClosingIdentifier(), StringComparison.Ordinal )
                .Replace( "|&<&|", "[", StringComparison.Ordinal )
                .Replace( "|&>&|", "]", StringComparison.Ordinal );
        }
    }
}
