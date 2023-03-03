using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Util.Helpers;

namespace Util.Data.EntityFrameworkCore.Migrations {
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
        /// 数据上下文项目根目录绝对路径
        /// </summary>
        private string _dbContextRootPath;
        /// <summary>
        /// 数据上下文
        /// </summary>
        private IUnitOfWork _dbcontext;
        /// <summary>
        /// 迁移名称
        /// </summary>
        private string _migrationName;
        /// <summary>
        /// 是否移除所有外键
        /// </summary>
        private bool _isRemoveForeignKeys;

        /// <summary>
        /// 初始化迁移服务
        /// </summary>
        /// <param name="logger">日志</param>
        /// <param name="migrationFileService">迁移文件服务</param>
        public MigrationService( ILogger<MigrationService> logger, IMigrationFileService migrationFileService ) {
            _logger = logger ?? NullLogger<MigrationService>.Instance;
            _migrationFileService = migrationFileService ?? throw new ArgumentNullException( nameof(migrationFileService) );
        }

        /// <inheritdoc />
        public IMigrationService DbContextRootPath( string path ) {
            _dbContextRootPath = path;
            return this;
        }

        /// <inheritdoc />
        public IMigrationService DbContext( IUnitOfWork dbcontext ) {
            _dbcontext = dbcontext;
            return this;
        }

        /// <inheritdoc />
        public IMigrationService MigrationName( string name ) {
            _migrationName = name;
            return this;
        }

        /// <inheritdoc />
        public IMigrationService RemoveForeignKeys() {
            _isRemoveForeignKeys = true;
            return this;
        }

        /// <inheritdoc />
        public async Task MigrateAsync( CancellationToken cancellationToken = default ) {
            if ( Validate() == false )
                return;
            AddMigration();
            if( _isRemoveForeignKeys )
                await RemoveMigrationFileForeignKeys();
            await UpdateDatabase( cancellationToken );
        }

        /// <summary>
        /// 验证
        /// </summary>
        private bool Validate() {
            if ( _migrationName.IsEmpty() )
                throw new ArgumentException( "必须设置迁移名称" );
            var migrations = _dbcontext?.GetMigrations();
            if ( migrations == null )
                return true;
            if ( migrations.Any( t => t.EndsWith( $"_{_migrationName}" ) ) )
                return false;
            return true;
        }

        /// <summary>
        /// 添加迁移
        /// </summary>
        private void AddMigration() {
            var result = CommandLine.Create( "dotnet", $"ef migrations add {_migrationName}" )
                .WorkingDirectory( _dbContextRootPath )
                .ExecuteResult();
            _logger.LogTrace( $"添加迁移: {result}" );
        }

        /// <summary>
        /// 删除迁移文件中的外键设置
        /// </summary>
        private async Task RemoveMigrationFileForeignKeys() {
            _logger.LogTrace( "准备移除迁移文件中的外键设置." );
            var migrationsPath = Common.JoinPath( _dbContextRootPath, "Migrations" );
            await _migrationFileService
                .MigrationsPath( migrationsPath )
                .MigrationName( _migrationName )
                .RemoveForeignKeys()
                .SaveAsync();
        }

        /// <summary>
        /// 更新数据库
        /// </summary>
        private async Task UpdateDatabase( CancellationToken cancellationToken ) {
            for ( int i = 0; i < 3; i++ ) {
                var result = CommandLine.Create( "dotnet", "ef database update" )
                    .WorkingDirectory( _dbContextRootPath )
                    .ExecuteResult();
                _logger.LogTrace( $"迁移更新数据库: {result}" );
                if ( result.Contains( "Exception" ) )
                    throw new Exception( $"迁移更新数据库失败: {result}" );
                if ( result.Contains( "Applying migration" ) )
                    return;
                await Task.Delay( 1000, cancellationToken );
            }
        }
    }
}
