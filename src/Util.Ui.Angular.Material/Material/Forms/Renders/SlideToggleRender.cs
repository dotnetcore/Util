using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Material.Forms.Builders;

namespace Util.Ui.Material.Forms.Renders {
    /// <summary>
    /// 滑动开关渲染器
    /// </summary>
    public class SlideToggleRender : CheckBoxRender {
        /// <summary>
        /// 初始化滑动开关渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public SlideToggleRender( Config config ) : base( config ) {
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            ResolveExpression();
            var builder = new SlideToggleBuilder();
            Config( builder );
            return builder;
        }
    }
}
