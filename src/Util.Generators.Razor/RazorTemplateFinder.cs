using System;
using System.Collections.Generic;
using System.IO;
using Util.Generators.Contexts;
using Util.Generators.Logs;
using Util.Generators.Templates;
using Util.Templates;

namespace Util.Generators.Razor {
    /// <summary>
    /// Razor模板查找器
    /// </summary>
    public class RazorTemplateFinder : ITemplateFinder {
        /// <summary>
        /// Razor模板引擎
        /// </summary>
        private readonly ITemplateEngine _templateEngine;
        /// <summary>
        /// 模板过滤器管理器
        /// </summary>
        private readonly ITemplateFilterManager _filterManager;
        /// <summary>
        /// 日志操作
        /// </summary>
        private readonly IGeneratorLogger _logger;

        /// <summary>
        /// 初始化Razor模板查找器
        /// </summary>
        /// <param name="templateEngine">Razor模板引擎</param>
        /// <param name="filterManager">模板过滤器管理器</param>
        /// <param name="logger">日志操作</param>
        public RazorTemplateFinder( ITemplateEngine templateEngine, ITemplateFilterManager filterManager, IGeneratorLogger logger = null ) {
            _templateEngine = templateEngine ?? throw new ArgumentNullException( nameof( templateEngine ) );
            _filterManager = filterManager ?? throw new ArgumentNullException( nameof( filterManager ) );
            _logger = logger ?? NullGeneratorLogger.Instance;
        }

        /// <inheritdoc />
        public IEnumerable<ITemplate> Find( string rootPath, ProjectContext projectContext ) {
            var result = new List<ITemplate>();
            var files = GetFiles( rootPath );
            foreach ( var file in files ) {
                if ( _filterManager.IsFilter( file.FullName, projectContext ) ) {
                    _logger.FilterTemplate( file.FullName );
                    continue;
                }
                result.Add( new RazorTemplate( _templateEngine, file ) );
            }
            return result;
        }

        /// <summary>
        /// 获取cshtml文件列表
        /// </summary>
        protected virtual List<FileInfo> GetFiles( string rootPath ) {
            return Util.Helpers.File.GetAllFiles( rootPath, "*.cshtml" );
        }
    }
}
