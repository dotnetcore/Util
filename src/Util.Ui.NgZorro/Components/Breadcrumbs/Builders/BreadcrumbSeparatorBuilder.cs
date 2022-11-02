using Util.Ui.Angular.Builders;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.BreadCrumbs.Builders {
    /// <summary>
    /// 面包屑分隔符标签生成器
    /// </summary>
    public class BreadcrumbSeparatorBuilder : AngularTagBuilder {
        /// <summary>
        /// 初始化面包屑分隔符标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public BreadcrumbSeparatorBuilder( Config config ) : base( config,"nz-breadcrumb-separator" ) {
        }
    }
}