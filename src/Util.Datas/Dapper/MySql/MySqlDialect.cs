using Util.Datas.Sql.Builders.Core;

namespace Util.Datas.Dapper.MySql {
    /// <summary>
    /// MySql方言
    /// </summary>
    public class MySqlDialect : DialectBase {
        /// <summary>
        /// 获取安全名称
        /// </summary>
        /// <param name="name">名称</param>
        protected override string GetSafeName( string name ) {
            return $"`{name}`";
        }
    }
}