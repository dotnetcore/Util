using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Material.Toolbars.Builders;

namespace Util.Ui.Material.Toolbars.Renders {
    /// <summary>
    /// 工具栏项渲染器
    /// </summary>
    public class ToolbarRowRender : AngularRenderBase {
        /// <summary>
        /// 初始化工具栏项渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public ToolbarRowRender( IConfig config ) : base( config ) {
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new ToolbarRowBuilder();
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