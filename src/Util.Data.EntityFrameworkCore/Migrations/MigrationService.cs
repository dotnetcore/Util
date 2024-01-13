using Util.Helpers;

namespace Util.Data.EntityFrameworkCore.Migrations;

/// <summary>
/// 迁移服务
/// </summary>
public class MigrationService : IMigrationService {
    /// <summary>
    /// 日志
    /// </summary>
    private readonly ILogger<MigrationService> _logger;
    /// <summary>
    /// 迁移文件服务
    /// </summary>
    private readonly IMigrationFileService _migrationFileService;

    /// <summary>
    /// 初始化迁移服务
    /// </summary>
    /// <param name="logger">日志</param>
    /// <param name="migrationFileService">迁移文件服务</param>
    public MigrationService( ILogger<MigrationService> logger, IMigrationFileService migrationFileService ) {
        _logger = logger ?? NullLogger<MigrationService>.Instance;
        _migrationFileService = migrationFileService ?? throw new ArgumentNullException( nameof( migrationFileService ) );
    }

    /// <inheritdoc />
    public IMigrationService InstallEfTool( string version = null ) {
        _logger.LogTrace( "准备安装 dotnet-ef 全局工具." );
        var versionArgs = version.IsEmpty() ? null : $" --version {version}";
        CommandLine.Create( "dotnet", $"tool install -g dotnet-ef{versionArgs}" )
            .OutputToMatch( "dotnet-ef" )
            .Log( _logger )
            .Execute();
        return this;
    }

    /// <inheritdoc />
    public IMigrationService UninstallEfTool() {
        _logger.LogTrace( "准备卸载 dotnet-ef 全局工具." );
        CommandLine.Create( "dotnet", "tool uninstall -g dotnet-ef" )
            .OutputToMatch( "dotnet-ef" )
            .Log( _logger )
            .Execute();
        return this;
    }

    /// <inheritdoc />
    public IMigrationService UpdateEfTool( string version = null ) {
        _logger.LogTrace( "准备更新 dotnet-ef 全局工具." );
        var versionArgs = version.IsEmpty() ? null : $" --version {version}";
        CommandLine.Create( "dotnet", $"tool update -g dotnet-ef{versionArgs}" )
            .OutputToMatch( "dotnet-ef" )
            .Log( _logger )
            .Execute();
        return this;
    }

    /// <inheritdoc />
    public IMigrationService AddMigration( string migrationName, string dbContextRootPath, bool isRemoveForeignKeys = false ) {
        if ( migrationName.IsEmpty() )
            throw new ArgumentException( "必须设置迁移名称" );
        if ( dbContextRootPath.IsEmpty() )
            throw new ArgumentException( "必须设置数据上下文项目根目录绝对路径" );
        _logger.LogTrace( "准备添加 ef 迁移." );
        CommandLine.Create( "dotnet", $"ef migrations add {migrationName}" )
            .WorkingDirectory( dbContextRootPath )
            .OutputToMatch( "Done" )
            .OutputToMatch( "used by an existing migration" )
            .Log( _logger )
            .Execute();
        if ( isRemoveForeignKeys )
            RemoveMigrationFileForeignKeys( migrationName, dbContextRootPath );
        return this;
    }

    /// <summary>
    /// 删除迁移文件中的外键设置
    /// </summary>
    private void RemoveMigrationFileForeignKeys( string migrationName, string dbContextRootPath ) {
        _logger.LogTrace( "准备移除迁移文件中的外键设置." );
        var migrationsPath = Common.JoinPath( dbContextRootPath, "Migrations" );
        _migrationFileService
            .MigrationsPath( migrationsPath )
            .MigrationName( migrationName )
            .RemoveForeignKeys()
            .Save();
    }

    /// <inheritdoc />
    public void Migrate( string dbContextRootPath ) {
        _logger.LogTrace( "准备执行 ef 迁移更新数据库." );
        CommandLine.Create( "dotnet", "ef database update" )
            .WorkingDirectory( dbContextRootPath )
            .OutputToMatch( "The ConnectionString property has not been initialized" )
            .OutputToMatch( "The server was not found or was not accessible" )
            .OutputToMatch( "There is already an object named" )
            .OutputToMatch( "Applying migration" )
            .OutputToMatch( "Done" )
            .Log( _logger )
            .Execute();
    }
}