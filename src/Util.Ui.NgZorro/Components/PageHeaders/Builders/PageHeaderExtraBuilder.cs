using Util.Ui.Angular.Builders;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.PageHeaders.Builders {
    /// <summary>
    /// 页头标题行尾操作区标签生成器
    /// </summary>
    public class PageHeaderExtraBuilder : AngularTagBuilder {
        /// <summary>
        /// 初始化页头标题行尾操作区标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public PageHeaderExtraBuilder( Config config ) : base( config,"nz-page-header-extra" ) {
        }
    }
}