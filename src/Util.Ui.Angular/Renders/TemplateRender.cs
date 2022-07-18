using Util.Ui.Angular.Builders;
using Util.Ui.Builders;
using Util.Ui.Configs;

namespace Util.Ui.Angular.Renders {
    /// <summary>
    /// ng-template模板渲染器
    /// </summary>
    public class TemplateRender : AngularRenderBase {
        /// <summary>
        /// 初始化模板渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public TemplateRender( Config config ) : base( config ) {
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new TemplateBuilder();
            ConfigContent( builder );
            return builder;
        }
    }
}