using Util.Datas.Sql.Queries.Builders.Abstractions;

namespace Util.Datas.Dapper.PgSql {
    /// <summary>
    /// PgSql方言
    /// </summary>
    public class PgSqlDialect : IDialect {
        /// <summary>
        /// 获取安全名称
        /// </summary>
        public string SafeName( string name ) {
            if( string.IsNullOrWhiteSpace( name ) )
                return string.Empty;
            if( name == "*" )
                return name;
            name = name.Trim().TrimStart( '"' ).TrimEnd( '"' );
            return $"\"{name}\"";
        }

        /// <summary>
        /// 获取参数前缀
        /// </summary>
        public string GetPrefix() {
            return "@";
        }
    }
}