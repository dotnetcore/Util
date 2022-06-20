using System;
using Util.Data.Sql.Builders;

namespace Util.Data.Sql {
    /// <summary>
    /// Sql Server Sql查询对象
    /// </summary>
    public abstract class SqlServerSqlQueryBase : SqlQueryBase {
        /// <summary>
        /// 初始化Sql Server Sql查询对象
        /// </summary>
        /// <param name="serviceProvider">服务提供器</param>
        /// <param name="options">Sql配置</param>
        /// <param name="database">数据库信息,用于接入其它数据源,比如EF DbContext</param>
        protected SqlServerSqlQueryBase( IServiceProvider serviceProvider, SqlOptions options, IDatabase database ) : base( serviceProvider, options, database ) {
        }

        /// <inheritdoc />
        protected override ISqlBuilder CreateSqlBuilder() {
            return new SqlServerBuilder();
        }

        /// <inheritdoc />
        protected override IExistsSqlBuilder CreatExistsSqlBuilder( ISqlBuilder sqlBuilder ) {
            return new SqlServerExistsSqlBuilder( sqlBuilder );
        }

        /// <inheritdoc />
        protected override IDatabaseFactory CreateDatabaseFactory() {
            return new SqlServerDatabaseFactory();
        }
    }
}
