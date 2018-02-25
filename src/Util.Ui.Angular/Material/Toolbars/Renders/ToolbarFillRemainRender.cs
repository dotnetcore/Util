using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Material.Toolbars.Builders;
using Util.Ui.Renders;

namespace Util.Ui.Material.Toolbars.Renders {
    /// <summary>
    /// 工具栏填充项渲染器
    /// </summary>
    public class ToolbarFillRemainRender : RenderBase {
        /// <summary>
        /// 初始化工具栏填充项渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public ToolbarFillRemainRender( IConfig config ) : base( config ) {
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            return new ToolbarFillRemainBuilder();
        }
    }
}