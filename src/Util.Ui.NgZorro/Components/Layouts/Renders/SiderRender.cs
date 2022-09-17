using Util.Ui.Angular.Configs;
using Util.Ui.Angular.Renders;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Layouts.Builders;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Layouts.Renders {
    /// <summary>
    /// 侧边栏布局渲染器
    /// </summary>
    public class SiderRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化侧边栏布局渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public SiderRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new SiderBuilder();
            ConfigWidth( builder );
            ConfigTheme( builder );
            ConfigBreakpoint( builder );
            ConfigCollapsedWidth( builder );
            ConfigCollapsible( builder );
            ConfigCollapsed( builder );
            ConfigReverseArrow( builder );
            ConfigTrigger( builder );
            ConfigEvents( builder );
            ConfigContent( builder );
            return builder;
        }

        /// <summary>
        /// 配置宽度
        /// </summary>
        private void ConfigWidth( TagBuilder builder ) {
            builder.AttributeIfNotEmpty( "nzWidth", _config.GetValue( UiConst.Width ) );
            builder.AttributeIfNotEmpty( "[nzWidth]", _config.GetValue( AngularConst.BindWidth ) );
        }

        /// <summary>
        /// 配置主题
        /// </summary>
        private void ConfigTheme( TagBuilder builder ) {
            builder.AttributeIfNotEmpty( "nzTheme", _config.GetValue<SiderTheme?>( UiConst.Theme )?.Description() );
            builder.AttributeIfNotEmpty( "[nzTheme]", _config.GetValue( AngularConst.BindTheme ) );
        }

        /// <summary>
        /// 配置响应式布局断点
        /// </summary>
        private void ConfigBreakpoint( TagBuilder builder ) {
            builder.AttributeIfNotEmpty( "nzBreakpoint", _config.GetValue<GridSize?>( UiConst.Breakpoint )?.Description() );
            builder.AttributeIfNotEmpty( "[nzBreakpoint]", _config.GetValue( AngularConst.BindBreakpoint ) );
        }

        /// <summary>
        /// 配置收缩宽度
        /// </summary>
        private void ConfigCollapsedWidth( TagBuilder builder ) {
            builder.AttributeIfNotEmpty( "[nzCollapsedWidth]", _config.GetValue( UiConst.CollapsedWidth ) );
            builder.AttributeIfNotEmpty( "[nzCollapsedWidth]", _config.GetValue( AngularConst.BindCollapsedWidth ) );
        }

        /// <summary>
        /// 配置可收缩
        /// </summary>
        private void ConfigCollapsible( TagBuilder builder ) {
            builder.AttributeIfNotEmpty( "[nzCollapsible]", _config.GetBoolValue( UiConst.Collapsible ) );
            builder.AttributeIfNotEmpty( "[nzCollapsible]", _config.GetValue( AngularConst.BindCollapsible ) );
        }

        /// <summary>
        /// 配置收缩状态
        /// </summary>
        private void ConfigCollapsed( TagBuilder builder ) {
            builder.AttributeIfNotEmpty( "[nzCollapsed]", _config.GetBoolValue( UiConst.Collapsed ) );
            builder.AttributeIfNotEmpty( "[nzCollapsed]", _config.GetValue( AngularConst.BindCollapsed ) );
            builder.AttributeIfNotEmpty( "[(nzCollapsed)]", _config.GetValue( AngularConst.BindonCollapsed ) );
        }

        /// <summary>
        /// 配置翻转折叠提示箭头方向
        /// </summary>
        private void ConfigReverseArrow( TagBuilder builder ) {
            builder.AttributeIfNotEmpty( "[nzReverseArrow]", _config.GetBoolValue( UiConst.ReverseArrow ) );
            builder.AttributeIfNotEmpty( "[nzReverseArrow]", _config.GetValue( AngularConst.BindReverseArrow ) );
        }

        /// <summary>
        /// 配置自定义触发器
        /// </summary>
        private void ConfigTrigger( TagBuilder builder ) {
            builder.AttributeIfNotEmpty( "[nzTrigger]", _config.GetValue( UiConst.Trigger ) );
            builder.AttributeIfNotEmpty( "[nzZeroTrigger]", _config.GetValue( AntDesignConst.ZeroTrigger ) );
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        private void ConfigEvents( TagBuilder builder ) {
            builder.AttributeIfNotEmpty( "(nzCollapsedChange)", _config.GetValue( UiConst.OnCollapsedChange ) );
        }
    }
}