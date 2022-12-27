using System;
using System.Data;
using Util.Data.Sql.Builders;
using Util.Data.Sql.Builders.Core;

namespace Util.Data.Sql {
    /// <summary>
    /// PostgreSql Sql执行器
    /// </summary>
    public abstract class PostgreSqlExecutorBase : SqlExecutorBase {
        /// <summary>
        /// 初始化PostgreSql Sql执行器
        /// </summary>
        /// <param name="serviceProvider">服务提供器</param>
        /// <param name="options">Sql配置</param>
        /// <param name="database">数据库信息,用于接入其它数据源,比如EF DbContext</param>
        protected PostgreSqlExecutorBase( IServiceProvider serviceProvider, SqlOptions options, IDatabase database ) : base( serviceProvider, options, database ) {
        }

        /// <summary>
        /// 创建Sql生成器
        /// </summary>
        protected override ISqlBuilder CreateSqlBuilder() {
            return new PostgreSqlBuilder();
        }

        /// <summary>
        /// 创建判断是否存在Sql生成器
        /// </summary>
        protected override IExistsSqlBuilder CreatExistsSqlBuilder( ISqlBuilder sqlBuilder ) {
            return new PostgreSqlExistsSqlBuilder( sqlBuilder );
        }

        /// <summary>
        /// 创建数据库工厂
        /// </summary>
        protected override IDatabaseFactory CreateDatabaseFactory() {
            return new PostgreSqlDatabaseFactory();
        }

        /// <summary>
        /// 获取存储过程名称
        /// </summary>
        /// <param name="procedure">存储过程</param>
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

        /// <summary>
        /// 获取存储过程命令类型
        /// </summary>
        protected override CommandType GetProcedureCommandType() {
            if ( IsProcedure( GetSql() ) )
                return CommandType.Text;
            return CommandType.StoredProcedure;
        }
    }
}
