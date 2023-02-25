using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Util.Generators.Contexts;
using Util.Generators.Logs;
using Util.Generators.Templates;

namespace Util.Generators.Resources {
    /// <summary>
    /// 静态资源管理器
    /// </summary>
    public class ResourceManager : IResourceManager {
        /// <summary>
        /// 静态资源列表
        /// </summary>
        private static readonly List<Resource> _resources = new();
        /// <summary>
        /// 模板过滤器管理器
        /// </summary>
        private readonly ITemplateFilterManager _filterManager;
        /// <summary>
        /// 生成器日志
        /// </summary>
        private readonly IGeneratorLogger _logger;

        /// <summary>
        /// 初始化静态资源管理器
        /// </summary>
        /// <param name="filterManager">模板过滤器管理器</param>
        /// <param name="logger">生成器日志</param>
        public ResourceManager( ITemplateFilterManager filterManager, IGeneratorLogger logger = null ) {
            _filterManager = filterManager ?? throw new ArgumentNullException( nameof( filterManager ) );
            _logger = logger ?? NullGeneratorLogger.Instance;
        }

        /// <summary>
        /// 添加静态资源
        /// </summary>
        /// <param name="from">静态资源文件路径,即模板项目中要复制目录或文件的相对模板根路径,范例:src/Presentation/ClientApp/src/assets</param>
        /// <param name="to">复制到输出目录的目标路径,可使用项目占位符{Project},范例:src/{Project}.Ui/ClientApp/src/assets</param>
        public static void AddResource( string from,string to ) {
            if ( from.IsEmpty() )
                return;
            if ( to.IsEmpty() )
                return;
            _resources.Add( new Resource( from,to ) );
        }

        /// <inheritdoc />
        public virtual Task ImportsAsync( string templateRootPath, string outputRootPath, ProjectContext project ) {
            foreach ( var resource in _resources ) {
                _logger.ImportResource( templateRootPath, outputRootPath, project.Name, resource );
                var path = GetResourcePath( templateRootPath, resource.From );
                if ( _filterManager.IsFilter( path, project ) ) {
                    _logger.FilterResource( path );
                    continue;
                }
                if ( Directory.Exists( path ) ) {
                    ImportDirectory( templateRootPath, outputRootPath, project.Name, resource.From, resource.To );
                    continue;
                }
                if ( File.Exists( path ) ) {
                    ImportFile( templateRootPath, outputRootPath, project.Name, resource.From, resource.To, path );
                    continue;
                }
            }
            return Task.CompletedTask;
        }

        /// <summary>
        /// 获取资源绝对路径
        /// </summary>
        private string GetResourcePath( string templateRootPath, string from ) {
            return Path.Combine( templateRootPath, from );
        }

        /// <summary>
        /// 导入目录
        /// </summary>
        protected virtual void ImportDirectory( string templateRootPath, string outputRootPath, string project, string from,string to ) {
            _logger.ImportDirectory( templateRootPath, outputRootPath, project, from, to );
            var path = GetResourcePath( templateRootPath, from );
            var files = Directory.GetFiles( path, "*.*",SearchOption.AllDirectories );
            foreach ( var file in files ) {
                ImportFile( templateRootPath, outputRootPath, project, from,to, file );
            }
        }

        /// <summary>
        /// 导入文件
        /// </summary>
        protected virtual void ImportFile( string templateRootPath, string outputRootPath, string project, string from, string to, string file ) {
            var destPath = GetTargetPath( templateRootPath, outputRootPath, project, from, to, file );
            _logger.BeginImportFile( file, destPath );
            var fileInfo = new FileInfo( destPath );
            Directory.CreateDirectory( fileInfo.DirectoryName );
            File.Copy( file, destPath,true );
            _logger.EndImportFile( file, destPath );
        }

        /// <summary>
        /// 获取目标文件绝对路径
        /// </summary>
        private string GetTargetPath( string templateRootPath, string outputRootPath, string project, string from, string to, string file ) {
            var subPath = file.RemoveStart( GetResourcePath( templateRootPath, from ) ).RemoveStart( "\\" );
            to = to.Replace( "{Project}", project, StringComparison.OrdinalIgnoreCase );
            return Path.Combine( outputRootPath, project, to, subPath );
        }
    }
}
