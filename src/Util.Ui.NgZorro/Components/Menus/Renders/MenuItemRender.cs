using Microsoft.AspNetCore.Html;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Menus.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Menus.Renders {
    /// <summary>
    /// 菜单项渲染器
    /// </summary>
    public class MenuItemRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化菜单项渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public MenuItemRender( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new MenuItemBuilder( _config );
            builder.Config();
            return builder;
        }

        /// <inheritdoc />
        public override IHtmlContent Clone() {
            return new MenuItemRender( _config.Copy() );
        }
    }
}