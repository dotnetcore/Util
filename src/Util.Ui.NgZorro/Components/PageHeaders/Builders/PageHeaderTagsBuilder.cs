using Util.Ui.Angular.Builders;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.PageHeaders.Builders {
    /// <summary>
    /// 页头标签列表标签生成器
    /// </summary>
    public class PageHeaderTagsBuilder : AngularTagBuilder {
        /// <summary>
        /// 初始化页头标签列表标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public PageHeaderTagsBuilder( Config config ) : base( config,"nz-page-header-tags" ) {
        }
    }
}