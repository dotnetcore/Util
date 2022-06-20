using System;
using Util.Data.Sql.Builders;

namespace Util.Data.Sql {
    /// <summary>
    /// Sql Server Sql执行器
    /// </summary>
    public abstract class SqlServerSqlExecutorBase : SqlExecutorBase {
        /// <summary>
        /// 初始化Sql Server Sql执行器
        /// </summary>
        /// <param name="serviceProvider">服务提供器</param>
        /// <param name="options">Sql配置</param>
        /// <param name="database">数据库信息,用于接入其它数据源,比如EF DbContext</param>
        protected SqlServerSqlExecutorBase( IServiceProvider serviceProvider, SqlOptions options, IDatabase database ) : base( serviceProvider, options, database ) {
        }

        /// <summary>
        /// 创建Sql生成器
        /// </summary>
        protected override ISqlBuilder CreateSqlBuilder() {
            return new SqlServerBuilder();
        }

        /// <summary>
        /// 创建判断是否存在Sql生成器
        /// </summary>
        protected override IExistsSqlBuilder CreatExistsSqlBuilder( ISqlBuilder sqlBuilder ) {
            return new SqlServerExistsSqlBuilder( sqlBuilder );
        }

        /// <summary>
        /// 创建数据库工厂
        /// </summary>
        protected override IDatabaseFactory CreateDatabaseFactory() {
            return new SqlServerDatabaseFactory();
        }
    }
}
