using System;
using Util.Data.Sql.Builders;

namespace Util.Data.Sql {
    /// <summary>
    /// MySql Sql查询对象
    /// </summary>
    public abstract class MySqlQueryBase : SqlQueryBase {
        /// <summary>
        /// 初始化MySql Sql查询对象
        /// </summary>
        /// <param name="serviceProvider">服务提供器</param>
        /// <param name="options">Sql配置</param>
        /// <param name="database">数据库信息,用于接入其它数据源,比如EF DbContext</param>
        protected MySqlQueryBase( IServiceProvider serviceProvider, SqlOptions options, IDatabase database ) : base( serviceProvider, options, database ) {
        }

        /// <inheritdoc />
        protected override ISqlBuilder CreateSqlBuilder() {
            return new MySqlBuilder();
        }

        /// <inheritdoc />
        protected override IExistsSqlBuilder CreatExistsSqlBuilder( ISqlBuilder sqlBuilder ) {
            return new MySqlExistsSqlBuilder( sqlBuilder );
        }

        /// <inheritdoc />
        protected override IDatabaseFactory CreateDatabaseFactory() {
            return new MySqlDatabaseFactory();
        }
    }
}
