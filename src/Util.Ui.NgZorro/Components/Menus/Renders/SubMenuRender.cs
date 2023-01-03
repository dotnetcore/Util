using Microsoft.AspNetCore.Html;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Menus.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Menus.Renders {
    /// <summary>
    /// 子菜单渲染器
    /// </summary>
    public class SubMenuRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化子菜单渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public SubMenuRender( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new SubMenuBuilder( _config );
            builder.Config();
            return builder;
        }

        /// <inheritdoc />
        public override IHtmlContent Clone() {
            return new SubMenuRender( _config.Copy() );
        }
    }
}