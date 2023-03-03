using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Util.Helpers;

namespace Util.Data.EntityFrameworkCore.Migrations {
    /// <summary>
    /// 迁移文件服务
    /// </summary>
    public class MigrationFileService : IMigrationFileService {
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILogger<MigrationFileService> _logger;
        /// <summary>
        /// 迁移目录绝对路径
        /// </summary>
        private string _migrationsPath;
        /// <summary>
        /// 迁移名称
        /// </summary>
        private string _migrationName;
        /// <summary>
        /// 是否移除所有外键
        /// </summary>
        private bool _isRemoveForeignKeys;

        /// <summary>
        /// 初始化迁移文件服务
        /// </summary>
        /// <param name="logger">日志</param>
        public MigrationFileService( ILogger<MigrationFileService> logger ) {
            _logger = logger ?? NullLogger<MigrationFileService>.Instance;
        }

        /// <inheritdoc />
        public IMigrationFileService MigrationsPath( string path ) {
            _migrationsPath = path;
            return this;
        }

        /// <inheritdoc />
        public IMigrationFileService MigrationName( string name ) {
            _migrationName = name;
            return this;
        }

        /// <inheritdoc />
        public IMigrationFileService RemoveForeignKeys() {
            _isRemoveForeignKeys = true;
            return this;
        }

        /// <inheritdoc />
        public string GetFilePath() {
            if ( _migrationsPath.IsEmpty() )
                return null;
            if ( _migrationName.IsEmpty() )
                return null;
            var files = File.GetAllFiles( _migrationsPath, "*.cs" );
            var file = files.FirstOrDefault( t => t.Name.EndsWith( $"{_migrationName}.cs" ) );
            if ( file == null )
                return null;
            return file.FullName;
        }

        /// <inheritdoc />
        public async Task<string> GetContentAsync() {
            var filePath = GetFilePath();
            if ( filePath.IsEmpty() )
                return null;
            return await File.ReadToStringAsync( filePath );
        }

        /// <inheritdoc />
        public async Task SaveAsync( string filePath = null ) {
            if ( _isRemoveForeignKeys == false )
                return;
            if ( filePath.IsEmpty() )
                filePath = GetFilePath();
            var content = await GetContentAsync();
            var pattern = @"table.ForeignKey\([\s\S]+?\);";
            var result = Util.Helpers.Regex.Replace( content, pattern, "" );
            pattern = @$"\s+{Common.Line}\s+{Common.Line}";
            result = Util.Helpers.Regex.Replace( result, pattern, Common.Line );
            await Util.Helpers.File.WriteAsync( filePath, result );
            _logger.LogTrace( $"修改迁移文件并保存成功,路径:{filePath}" );
        }
    }
}