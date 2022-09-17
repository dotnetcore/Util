using Util.Ui.Angular.Configs;
using Util.Ui.Angular.Renders;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.NgZorro.Components.Menus.Builders;

namespace Util.Ui.NgZorro.Components.Menus.Renders {
    /// <summary>
    /// 菜单组渲染器
    /// </summary>
    public class MenuGroupRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化菜单组渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public MenuGroupRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new MenuGroupBuilder();
            ConfigTitle( builder );
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
        /// 配置内容元素
        /// </summary>
        protected override void ConfigContent( TagBuilder builder ) {
            var ulBuilder = new UlBuilder();
            builder.SetContent( ulBuilder );
            _config.Content.AppendTo( ulBuilder );
        }
    }
}