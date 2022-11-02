using Util.Ui.Angular.Builders;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Layouts.Builders {
    /// <summary>
    /// 顶部布局标签生成器
    /// </summary>
    public class HeaderBuilder : AngularTagBuilder {
        /// <summary>
        /// 初始化顶部布局标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public HeaderBuilder( Config config ) : base( config,"nz-header" ) {
        }
    }
}