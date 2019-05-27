using Util.Ui.Angular.Base;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Material.Toolbars.Builders;

namespace Util.Ui.Material.Toolbars.Renders {
    /// <summary>
    /// 工具栏填充项渲染器
    /// </summary>
    public class ToolbarFillRemainRender : AngularRenderBase {
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