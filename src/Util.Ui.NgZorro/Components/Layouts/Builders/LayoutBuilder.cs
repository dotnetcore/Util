using Util.Ui.Angular.Builders;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Layouts.Builders {
    /// <summary>
    /// 布局标签生成器
    /// </summary>
    public class LayoutBuilder : AngularTagBuilder {
        /// <summary>
        /// 初始化布局标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public LayoutBuilder( Config config ) : base( config,"nz-layout" ) {
        }
    }
}