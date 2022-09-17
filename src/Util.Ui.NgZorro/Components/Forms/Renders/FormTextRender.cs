using Util.Ui.Angular.Renders;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Forms.Builders;

namespace Util.Ui.NgZorro.Components.Forms.Renders {
    /// <summary>
    /// 表单文本渲染器
    /// </summary>
    public class FormTextRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化表单文本渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public FormTextRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new FormTextBuilder();
            ConfigContent( builder );
            return builder;
        }
    }
}
