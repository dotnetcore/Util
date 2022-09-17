using Util.Ui.Angular.Configs;
using Util.Ui.Angular.Renders;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.NgZorro.Components.Menus.Builders;
using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Menus.Renders {
    /// <summary>
    /// 子菜单渲染器
    /// </summary>
    public class SubMenuRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化子菜单渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public SubMenuRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new SubMenuBuilder();
            ConfigTitle( builder );
            ConfigDisabled( builder );
            ConfigIcon( builder );
            ConfigOpen( builder );
            ConfigMenuClassName( builder );
            ConfigEvents( builder );
            ConfigContent( builder );
            return builder;
        }

        /// <summary>
        /// 配置标题
        /// </summary>
        private void ConfigTitle( TagBuilder builder ) {
            builder.AttributeIfNotEmpty( "nzTitle", _config.GetValue( UiConst.Title ) );
            builder.AttributeIfNotEmpty( "[nzTitle]", _config.GetValue( AngularConst.BindTitle ) );
        }

        /// <summary>
        /// 配置禁用
        /// </summary>
        private void ConfigDisabled( TagBuilder builder ) {
            builder.AttributeIfNotEmpty( "[nzDisabled]", _config.GetBoolValue( UiConst.Disabled ) );
            builder.AttributeIfNotEmpty( "[nzDisabled]", _config.GetValue( AngularConst.BindDisabled ) );
        }

        /// <summary>
        /// 配置图标
        /// </summary>
        private void ConfigIcon( TagBuilder builder ) {
            builder.AttributeIfNotEmpty( "nzIcon", _config.GetValue<AntDesignIcon?>( UiConst.Icon )?.Description() );
            builder.AttributeIfNotEmpty( "[nzIcon]", _config.GetValue( AngularConst.BindIcon ) );
        }

        /// <summary>
        /// 配置展开
        /// </summary>
        private void ConfigOpen( TagBuilder builder ) {
            builder.AttributeIfNotEmpty( "[nzOpen]", _config.GetBoolValue( UiConst.Open ) );
            builder.AttributeIfNotEmpty( "[nzOpen]", _config.GetValue( AngularConst.BindOpen ) );
            builder.AttributeIfNotEmpty( "[(nzOpen)]", _config.GetValue( AngularConst.BindonOpen ) );
        }

        /// <summary>
        /// 配置自定义子菜单容器类名
        /// </summary>
        private void ConfigMenuClassName( TagBuilder builder ) {
            builder.AttributeIfNotEmpty( "nzMenuClassName", _config.GetValue( UiConst.MenuClassName ) );
            builder.AttributeIfNotEmpty( "[nzMenuClassName]", _config.GetValue( AngularConst.BindMenuClassName ) );
        }

        /// <summary>
        /// 配置内容元素
        /// </summary>
        protected override void ConfigContent( TagBuilder builder ) {
            var ulBuilder = new UlBuilder();
            builder.SetContent( ulBuilder );
            _config.Content.AppendTo( ulBuilder );
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        private void ConfigEvents( TagBuilder builder ) {
            builder.AttributeIfNotEmpty( "(nzOpenChange)", _config.GetValue( UiConst.OnOpenChange ) );
        }
    }
}