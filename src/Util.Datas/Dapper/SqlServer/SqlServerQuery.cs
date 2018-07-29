using Util.Datas.Dapper.SqlServer.Builders;
using Util.Datas.Sql;
using Util.Datas.Sql.Queries.Builders;

namespace Util.Datas.Dapper.SqlServer {
    /// <summary>
    /// Sql Server查询对象
    /// </summary>
    public class SqlServerQuery : Util.Datas.Dapper.Core.SqlQueryBase {
        /// <summary>
        /// 初始化Dapper Sql查询对象
        /// </summary>
        /// <param name="database">数据库</param>
        public SqlServerQuery( IDatabase database = null ) : base( database ) {
        }

        /// <summary>
        /// 创建Sql生成器
        /// </summary>
        protected override ISqlBuilder CreateBuilder() {
            return new SqlServerBuilder();
        }
    }
}
