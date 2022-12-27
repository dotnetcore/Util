using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Lists.Builders {
    /// <summary>
    /// 列表项标签生成器
    /// </summary>
    public class ListItemBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化列表项标签生成器
        /// </summary>
        public ListItemBuilder( Config config ) : base( config,"nz-list-item" ) {
            _config = config;
        }

        /// <summary>
        /// 配置是否非flex布局
        /// </summary>
        public ListItemBuilder NoFlex() {
            AttributeIfNotEmpty( "[nzNoFlex]", _config.GetBoolValue( UiConst.NoFlex ) );
            AttributeIfNotEmpty( "[nzNoFlex]", _config.GetValue( AngularConst.BindNoFlex ) );
            return this;
        }

        /// <summary>
        /// 配置虚拟滚动循环
        /// </summary>
        public ListItemBuilder VirtualFor() {
            AttributeIfNotEmpty( "*cdkVirtualFor", _config.GetValue( UiConst.VirtualFor ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            NoFlex().VirtualFor();
        }
    }
}