using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Anchors.Builders {
    /// <summary>
    /// 锚点标签生成器
    /// </summary>
    public class AnchorBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化锚点标签生成器
        /// </summary>
        public AnchorBuilder( Config config ) : base( config,"nz-anchor" ) {
            _config = config;
        }

        /// <summary>
        /// 配置是否固定模式
        /// </summary>
        public AnchorBuilder Affix() {
            AttributeIfNotEmpty( "[nzAffix]", _config.GetBoolValue( UiConst.Affix ) );
            AttributeIfNotEmpty( "[nzAffix]", _config.GetValue( AngularConst.BindAffix ) );
            return this;
        }

        /// <summary>
        /// 配置区域边界
        /// </summary>
        public AnchorBuilder Bounds() {
            AttributeIfNotEmpty( "nzBounds", _config.GetValue( UiConst.Bounds ) );
            AttributeIfNotEmpty( "[nzBounds]", _config.GetValue( AngularConst.BindBounds ) );
            return this;
        }

        /// <summary>
        /// 配置顶部偏移量
        /// </summary>
        public AnchorBuilder OffsetTop() {
            AttributeIfNotEmpty( "nzOffsetTop", _config.GetValue( UiConst.OffsetTop ) );
            AttributeIfNotEmpty( "[nzOffsetTop]", _config.GetValue( AngularConst.BindOffsetTop ) );
            return this;
        }

        /// <summary>
        /// 配置固定模式是否显示小圆点
        /// </summary>
        public AnchorBuilder ShowInkInFixed() {
            AttributeIfNotEmpty( "[nzShowInkInFixed]", _config.GetBoolValue( UiConst.ShowInkInFixed ) );
            AttributeIfNotEmpty( "[nzShowInkInFixed]", _config.GetValue( AngularConst.BindShowInkInFixed ) );
            return this;
        }

        /// <summary>
        /// 配置容器
        /// </summary>
        public AnchorBuilder Container() {
            AttributeIfNotEmpty( "nzContainer", _config.GetValue( UiConst.Container ) );
            AttributeIfNotEmpty( "[nzContainer]", _config.GetValue( AngularConst.BindContainer ) );
            return this;
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        public AnchorBuilder Events() {
            AttributeIfNotEmpty( "(nzClick)", _config.GetValue( UiConst.OnClick ) );
            AttributeIfNotEmpty( "(nzScroll)", _config.GetValue( UiConst.OnScroll ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            Affix().Bounds().OffsetTop().ShowInkInFixed().Container().Events();
        }
    }
}