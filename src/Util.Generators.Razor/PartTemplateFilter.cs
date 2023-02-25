using System;
using Util.Generators.Contexts;
using Util.Generators.Templates;

namespace Util.Generators.Razor {
    /// <summary>
    /// 部分模板过滤器
    /// </summary>
    public class PartTemplateFilter : ITemplateFilter {
        /// <inheritdoc />
        public bool IsFilter( string path, ProjectContext projectContext ) {
            if ( path.IsEmpty() )
                return true;
            return path.EndsWith( ".Part.cshtml", StringComparison.OrdinalIgnoreCase );
        }
    }
}
