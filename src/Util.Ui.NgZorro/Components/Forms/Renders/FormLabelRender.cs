using Util.Ui.Angular.Renders;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Forms.Builders;

namespace Util.Ui.NgZorro.Components.Forms.Renders {
    /// <summary>
    /// 表单标签渲染器
    /// </summary>
    public class FormLabelRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化表单标签渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public FormLabelRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new FormLabelBuilder( _config );
            builder.Config();
            ConfigContent( builder );
            return builder;
        }
    }
}
