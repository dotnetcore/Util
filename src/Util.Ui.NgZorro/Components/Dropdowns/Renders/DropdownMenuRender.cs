using Microsoft.AspNetCore.Html;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Dropdowns.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Dropdowns.Renders {
    /// <summary>
    /// 下拉菜单渲染器
    /// </summary>
    public class DropdownMenuRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化下拉菜单渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public DropdownMenuRender( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new DropdownMenuBuilder( _config );
            builder.Config();
            return builder;
        }

        /// <inheritdoc />
        public override IHtmlContent Clone() {
            return new DropdownMenuRender( _config.Copy() );
        }
    }
}