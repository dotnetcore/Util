using Util.Ui.Angular.Builders;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.PageHeaders.Builders {
    /// <summary>
    /// 页头内容标签生成器
    /// </summary>
    public class PageHeaderContentBuilder : AngularTagBuilder {
        /// <summary>
        /// 初始化页头内容标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public PageHeaderContentBuilder( Config config ) : base( config,"nz-page-header-content" ) {
        }
    }
}