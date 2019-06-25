using Util.Ui.Angular.Base;
using Util.Ui.Angular.Builders;
using Util.Ui.Builders;
using Util.Ui.Configs;

namespace Util.Ui.Angular.Renders {
    /// <summary>
    /// ng-template模板渲染器
    /// </summary>
    public class TemplateRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly IConfig _config;

        /// <summary>
        /// 初始化模板渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public TemplateRender( IConfig config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new TemplateBuilder();
            ConfigId( builder );
            ConfigContent( builder );
            return builder;
        }
    }
}