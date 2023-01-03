using Microsoft.AspNetCore.Html;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Forms.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Forms.Renders {
    /// <summary>
    /// 表单分隔符渲染器
    /// </summary>
    public class FormSplitRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化表单分隔符渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public FormSplitRender( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new FormSplitBuilder( _config );
            builder.Config();
            return builder;
        }

        /// <inheritdoc />
        public override IHtmlContent Clone() {
            return new FormSplitRender( _config.Copy() );
        }
    }
}
