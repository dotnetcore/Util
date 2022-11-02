using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.VirtualScrolls.Builders {
    /// <summary>
    /// 虚拟滚动窗口标签生成器
    /// </summary>
    public class VirtualScrollViewportBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化虚拟滚动窗口标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public VirtualScrollViewportBuilder( Config config ) : base( config,"cdk-virtual-scroll-viewport" ) {
            _config = config;
        }

        /// <summary>
        /// 配置列高
        /// </summary>
        public VirtualScrollViewportBuilder ItemSize() {
            AttributeIfNotEmpty( "itemSize", _config.GetValue( UiConst.ItemSize ) );
            AttributeIfNotEmpty( "[itemSize]", _config.GetValue( AngularConst.BindItemSize ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            ItemSize();
        }
    }
}