using Util.Ui.Angular.Renders;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Menus.Builders;

namespace Util.Ui.NgZorro.Components.Menus.Renders {
    /// <summary>
    /// 菜单分隔线渲染器
    /// </summary>
    public class MenuDividerRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化菜单分隔线渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public MenuDividerRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new MenuDividerBuilder();
            ConfigContent( builder );
            return builder;
        }
    }
}