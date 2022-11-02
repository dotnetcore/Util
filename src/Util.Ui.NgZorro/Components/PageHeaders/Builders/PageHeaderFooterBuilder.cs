using Util.Ui.Angular.Builders;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.PageHeaders.Builders {
    /// <summary>
    /// 页头底部标签生成器
    /// </summary>
    public class PageHeaderFooterBuilder : AngularTagBuilder {
        /// <summary>
        /// 初始化页头底部标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public PageHeaderFooterBuilder( Config config ) : base( config,"nz-page-header-footer" ) {
        }
    }
}