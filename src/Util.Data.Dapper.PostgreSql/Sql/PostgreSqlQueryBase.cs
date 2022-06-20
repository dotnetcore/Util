using System;
using System.Data;
using Util.Data.Sql.Builders;
using Util.Data.Sql.Builders.Core;

namespace Util.Data.Sql {
    /// <summary>
    /// PostgreSql Sql查询对象
    /// </summary>
    public abstract class PostgreSqlQueryBase : SqlQueryBase {
        /// <summary>
        /// 初始化PostgreSql Sql查询对象
        /// </summary>
        /// <param name="serviceProvider">服务提供器</param>
        /// <param name="options">Sql配置</param>
        /// <param name="database">数据库信息,用于接入其它数据源,比如EF DbContext</param>
        protected PostgreSqlQueryBase( IServiceProvider serviceProvider, SqlOptions options, IDatabase database ) : base( serviceProvider, options, database ) {
        }

        /// <inheritdoc />
        protected override ISqlBuilder CreateSqlBuilder() {
            return new PostgreSqlBuilder();
        }

        /// <inheritdoc />
        protected override IExistsSqlBuilder CreatExistsSqlBuilder( ISqlBuilder sqlBuilder ) {
            return new PostgreSqlExistsSqlBuilder( sqlBuilder );
        }

        /// <inheritdoc />
        protected override IDatabaseFactory CreateDatabaseFactory() {
            return new PostgreSqlDatabaseFactory();
        }

        /// <inheritdoc />
        protected override string GetProcedure( string procedure ) {
            if ( IsProcedure( procedure ) )
                return Dialect.ReplaceSql( procedure );
            return new TableItem( Dialect, procedure ).ToResult();
        }

        /// <summary>
        /// 是否存储过程
        /// </summary>
        protected virtual bool IsProcedure( string procedure ) {
            return procedure.Trim().StartsWith( "call ", StringComparison.OrdinalIgnoreCase );
        }

        /// <inheritdoc />
        protected override CommandType GetProcedureCommandType() {
            if ( IsProcedure( GetSql() ) )
                return CommandType.Text;
            return CommandType.StoredProcedure;
        }
    }
}
