namespace Util.Data.EntityFrameworkCore; 

/// <summary>
/// Sqlite工作单元基类
/// </summary>
public abstract class SqliteUnitOfWorkBase : UnitOfWorkBase {
    /// <summary>
    /// 初始化Sqlite工作单元
    /// </summary>
    /// <param name="serviceProvider">服务提供器</param>
    /// <param name="options">配置</param>
    protected SqliteUnitOfWorkBase( IServiceProvider serviceProvider, DbContextOptions options )
        : base( serviceProvider, options ) {
    }

    /// <inheritdoc />
    protected override void ConfigTenantConnectionString( DbContextOptionsBuilder optionsBuilder, string connectionString ) {
        optionsBuilder.UseSqlite( connectionString );
    }
}