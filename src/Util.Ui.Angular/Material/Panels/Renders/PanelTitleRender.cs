using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Material.Panels.Builders;
using Util.Ui.Renders;

namespace Util.Ui.Material.Panels.Renders {
    /// <summary>
    /// 面板标题渲染器
    /// </summary>
    public class PanelTitleRender : RenderBase {
        /// <summary>
        /// 初始化面板标题渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public PanelTitleRender( IConfig config ) : base( config ) {
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new PanelTitleBuilder();
            Config( builder );
            return builder;
        }

        /// <summary>
        /// 配置
        /// </summary>
        protected void Config( TagBuilder builder ) {
            ConfigId( builder );
            ConfigContent( builder );
        }
    }
}