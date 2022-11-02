using Util.Ui.Angular.Builders;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Layouts.Builders {
    /// <summary>
    /// 底部布局标签生成器
    /// </summary>
    public class FooterBuilder : AngularTagBuilder {
        /// <summary>
        /// 初始化底部布局标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public FooterBuilder( Config config ) : base( config,"nz-footer" ) {
        }
    }
}