using Util.Datas.Sql.Builders.Core;

namespace Util.Datas.Dapper.Oracle {
    /// <summary>
    /// Oracle方言
    /// </summary>
    public class OracleDialect : DialectBase {
        /// <summary>
        /// 起始转义标识符
        /// </summary>
        public override string OpeningIdentifier => "\"";

        /// <summary>
        /// 结束转义标识符
        /// </summary>
        public override string ClosingIdentifier => "\"";

        /// <summary>
        /// 获取安全名称
        /// </summary>
        /// <param name="name">名称</param>
        protected override string GetSafeName( string name ) {
            return $"\"{name}\"";
        }

        /// <summary>
        /// 获取参数前缀
        /// </summary>
        public override string GetPrefix() {
            return ":";
        }

        /// <summary>
        /// 创建参数名
        /// </summary>
        /// <param name="paramIndex">参数索引</param>
        public override string GenerateName( int paramIndex ) {
            return $"{GetPrefix()}p_{paramIndex}";
        }

        /// <summary>
        /// 获取参数名
        /// </summary>
        /// <param name="paramName">参数名</param>
        public override string GetParamName( string paramName ) {
            if ( paramName.StartsWith( ":" ) )
                return paramName.TrimStart( ':' );
            return paramName;
        }
    }
}