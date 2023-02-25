using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Util.Data.Metadata;
using Util.Generators.Configuration;
using Util.Generators.Logs;

namespace Util.Generators.Contexts {
    /// <summary>
    /// 生成器上下文构建器
    /// </summary>
    public class GeneratorContextBuilder : IGeneratorContextBuilder {
        /// <summary>
        /// 生成器日志操作
        /// </summary>
        private readonly IGeneratorLogger _logger;
        /// <summary>
        /// 生成器配置项构建器
        /// </summary>
        private readonly IGeneratorOptionsBuilder _optionsBuilder;
        /// <summary>
        /// 元数据服务工厂
        /// </summary>
        private readonly IMetadataServiceFactory _metadataServiceFactory;
        /// <summary>
        /// 数据类型转换器工厂
        /// </summary>
        private readonly ITypeConverterFactory _typeConverterFactory;

        /// <summary>
        /// 初始化生成器上下文构建器
        /// </summary>
        /// <param name="logger">日志</param>
        /// <param name="optionsBuilder">生成器配置项构建器</param>
        /// <param name="metadataServiceFactory">元数据服务工厂</param>
        /// <param name="typeConverterFactory">数据类型转换器工厂</param>
        public GeneratorContextBuilder( IGeneratorLogger logger, IGeneratorOptionsBuilder optionsBuilder, IMetadataServiceFactory metadataServiceFactory, ITypeConverterFactory typeConverterFactory ) {
            _logger = logger ?? throw new ArgumentNullException( nameof( logger ) );
            _optionsBuilder = optionsBuilder ?? throw new ArgumentNullException( nameof( optionsBuilder ) );
            _metadataServiceFactory = metadataServiceFactory ?? throw new ArgumentNullException( nameof( metadataServiceFactory ) );
            _typeConverterFactory = typeConverterFactory ?? throw new ArgumentNullException( nameof( typeConverterFactory ) );
        }

        /// <summary>
        /// 创建生成器上下文
        /// </summary>
        public async Task<GeneratorContext> BuildAsync() {
            var options = await GetGeneratorOptions();
            _logger.LogOptions( options );
            _logger.BeginBuildContext();
            var result = new GeneratorContext {
                TemplateRootPath = GetPhysicalPath( options.TemplatePath ),
                OutputRootPath = GetPhysicalPath( options.OutputPath ),
                Message = options.Messages.Clone()
            };
            _logger.LogGeneratorContextBaseInfo( result );
            await AddProjectContexts( result, options.Projects.Select( t => t.Value ) );
            result.Validate();
            return result;
        }

        /// <summary>
        /// 获取生成器配置
        /// </summary>
        protected async Task<GeneratorOptions> GetGeneratorOptions() {
            return await _optionsBuilder.BuildAsync();
        }

        /// <summary>
        /// 获取物理路径
        /// </summary>
        protected virtual string GetPhysicalPath( string path ) {
            if ( IsAbsolutePath( path ) )
                return path;
            return Util.Helpers.Common.GetPhysicalPath( path );
        }

        /// <summary>
        /// 是否绝对路径
        /// </summary>
        protected virtual  bool IsAbsolutePath( string path ) {
            if ( path.Contains( @":\" ) )
                return true;
            if ( path.Contains( ":/" ) )
                return true;
            return false;
        }

        /// <summary>
        /// 添加项目上下文集合
        /// </summary>
        protected async Task AddProjectContexts( GeneratorContext generatorContext, IEnumerable<ProjectOptions> projectOptions ) {
            foreach ( var projectOption in projectOptions ) {
                var projectContext = await CreateProjectContext( generatorContext, projectOption );
                generatorContext.Projects.Add( projectContext );
            }
        }

        /// <summary>
        /// 创建项目上下文
        /// </summary>
        protected async Task<ProjectContext> CreateProjectContext( GeneratorContext generatorContext, ProjectOptions projectOptions ) {
            _logger.BeginBuildProjectContext( projectOptions.Name );
            var result = new ProjectContext( generatorContext ) {
                Name = projectOptions.Name,
                UnitOfWorkName = projectOptions.UnitOfWorkName,
                Client = projectOptions.Client.Clone(),
                DbType = projectOptions.DbType,
                TargetDbType = projectOptions.TargetDbType ?? projectOptions.DbType,
                ConnectionString = projectOptions.ConnectionString,
                Enabled = projectOptions.Enabled,
                Utc = projectOptions.Utc,
                I18n = projectOptions.I18n,
                ProjectType = projectOptions.ProjectType,
                ApiPort = projectOptions.ApiPort,
                Extend = projectOptions.Extend
            };
            if ( projectOptions.Enabled == false )
                return result;
            _logger.BeginGetDbMetadata( projectOptions );
            var databaseInfo = await GetDatabaseInfo( projectOptions );
            _logger.EndGetDbMetadata( databaseInfo );
            var typeConverter = _typeConverterFactory.Create( projectOptions.DbType );
            foreach ( var table in databaseInfo.Tables )
                AddEntityContext( result, table, typeConverter );
            result.Schemas.AddRange( result.Entities.GroupBy( t => t.Schema ).Select( t => t.Key ) );
            _logger.EndProjectContext( result );
            return result;
        }

        /// <summary>
        /// 获取数据库元数据信息
        /// </summary>
        protected async Task<DatabaseInfo> GetDatabaseInfo( ProjectOptions projectOptions ) {
            var metadataService = _metadataServiceFactory.Create( projectOptions.DbType, projectOptions.ConnectionString );
            return await metadataService.GetDatabaseInfoAsync();
        }

        /// <summary>
        /// 添加实体上下文
        /// </summary>
        protected void AddEntityContext( ProjectContext project, TableInfo table, ITypeConverter typeConverter ) {
            var entity = new EntityContext( project, table.Name ) {
                Schema = table.Schema,
                Description = table.Comment
            };
            table.Columns.ForEach( column => {
                var length = Util.Helpers.Convert.ToInt( column.Length );
                var property = new Property( entity ) {
                    Name = column.Name,
                    Description = column.Comment,
                    IsKey = column.IsPrimaryKey,
                    IsRequired = column.IsNullable == false,
                    Type = typeConverter.ToType( column.DataType, length ),
                    NativeType = column.DataType,
                    MaxLength = length,
                    IsAutoIncrement = column.IsAutoIncrement,
                    Precision = column.Precision,
                    Scale = column.Scale
                };
                property.SystemType = property.Type.ToSystemType();
                entity.Properties.Add( property );
            } );
            project.Entities.Add( entity );
        }
    }
}
