using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Layouts.Builders {
    /// <summary>
    /// 侧边栏布局标签生成器
    /// </summary>
    public class SiderBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化侧边栏布局标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public SiderBuilder( Config config ) : base( config,"nz-sider" ) {
            _config = config;
        }

        /// <summary>
        /// 配置宽度
        /// </summary>
        public SiderBuilder Width() {
            AttributeIfNotEmpty( "nzWidth", _config.GetValue( UiConst.Width ) );
            AttributeIfNotEmpty( "[nzWidth]", _config.GetValue( AngularConst.BindWidth ) );
            return this;
        }

        /// <summary>
        /// 配置主题
        /// </summary>
        public SiderBuilder Theme() {
            AttributeIfNotEmpty( "nzTheme", _config.GetValue<SiderTheme?>( UiConst.Theme )?.Description() );
            AttributeIfNotEmpty( "[nzTheme]", _config.GetValue( AngularConst.BindTheme ) );
            return this;
        }

        /// <summary>
        /// 配置响应式布局断点
        /// </summary>
        public SiderBuilder Breakpoint() {
            AttributeIfNotEmpty( "nzBreakpoint", _config.GetValue<GridSize?>( UiConst.Breakpoint )?.Description() );
            AttributeIfNotEmpty( "[nzBreakpoint]", _config.GetValue( AngularConst.BindBreakpoint ) );
            return this;
        }

        /// <summary>
        /// 配置收缩宽度
        /// </summary>
        public SiderBuilder CollapsedWidth() {
            AttributeIfNotEmpty( "[nzCollapsedWidth]", _config.GetValue( UiConst.CollapsedWidth ) );
            AttributeIfNotEmpty( "[nzCollapsedWidth]", _config.GetValue( AngularConst.BindCollapsedWidth ) );
            return this;
        }

        /// <summary>
        /// 配置可收缩
        /// </summary>
        public SiderBuilder Collapsible() {
            AttributeIfNotEmpty( "[nzCollapsible]", _config.GetBoolValue( UiConst.Collapsible ) );
            AttributeIfNotEmpty( "[nzCollapsible]", _config.GetValue( AngularConst.BindCollapsible ) );
            return this;
        }

        /// <summary>
        /// 配置收缩状态
        /// </summary>
        public SiderBuilder Collapsed() {
            AttributeIfNotEmpty( "[nzCollapsed]", _config.GetBoolValue( UiConst.Collapsed ) );
            AttributeIfNotEmpty( "[nzCollapsed]", _config.GetValue( AngularConst.BindCollapsed ) );
            AttributeIfNotEmpty( "[(nzCollapsed)]", _config.GetValue( AngularConst.BindonCollapsed ) );
            return this;
        }

        /// <summary>
        /// 配置翻转折叠提示箭头方向
        /// </summary>
        public SiderBuilder ReverseArrow() {
            AttributeIfNotEmpty( "[nzReverseArrow]", _config.GetBoolValue( UiConst.ReverseArrow ) );
            AttributeIfNotEmpty( "[nzReverseArrow]", _config.GetValue( AngularConst.BindReverseArrow ) );
            return this;
        }

        /// <summary>
        /// 配置自定义触发器
        /// </summary>
        public SiderBuilder Trigger() {
            AttributeIfNotEmpty( "[nzTrigger]", _config.GetValue( UiConst.Trigger ) );
            AttributeIfNotEmpty( "[nzZeroTrigger]", _config.GetValue( AntDesignConst.ZeroTrigger ) );
            return this;
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        public SiderBuilder Events() {
            AttributeIfNotEmpty( "(nzCollapsedChange)", _config.GetValue( UiConst.OnCollapsedChange ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            Width().Theme().Breakpoint().CollapsedWidth().Collapsible()
                .Collapsed().ReverseArrow().Trigger()
                .Events();
        }
    }
}