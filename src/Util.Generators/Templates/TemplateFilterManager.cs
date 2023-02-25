using System;
using System.Collections.Generic;
using Util.Generators.Contexts;

namespace Util.Generators.Templates {
    /// <summary>
    /// 模板过滤器管理器
    /// </summary>
    public class TemplateFilterManager : ITemplateFilterManager {
        /// <summary>
        /// 模板过滤器列表
        /// </summary>
        private static readonly List<ITemplateFilter> _filters = new();

        /// <summary>
        /// 添加模板过滤器
        /// </summary>
        /// <param name="filter">模板过滤器</param>
        public static void AddFilter( ITemplateFilter filter ) {
            if ( filter == null )
                return;
            _filters.Add( filter );
        }

        /// <summary>
        /// 添加模板过滤器
        /// </summary>
        /// <param name="type">模板过滤器类型</param>
        public static void AddFilter( Type type ) {
            var filter = Util.Helpers.Reflection.CreateInstance<ITemplateFilter>( type );
            AddFilter( filter );
        }

        /// <summary>
        /// 清空模板过滤器
        /// </summary>
        public static void Clear() {
            _filters.Clear();
        }

        /// <inheritdoc />
        public List<ITemplateFilter> GetFilters() {
            return _filters;
        }

        /// <inheritdoc />
        public bool IsFilter( string rootPath, ProjectContext projectContext ) {
            foreach ( var filter in _filters ) {
                if ( filter.IsFilter( rootPath, projectContext ) )
                    return true;
            }
            return false;
        }
    }
}
