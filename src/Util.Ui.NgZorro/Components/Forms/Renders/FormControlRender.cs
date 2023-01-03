using Microsoft.AspNetCore.Html;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.NgZorro.Components.Forms.Builders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Forms.Renders {
    /// <summary>
    /// 表单域渲染器
    /// </summary>
    public class FormControlRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化表单域渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public FormControlRender( Config config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new FormControlBuilder( _config );
            builder.Config();
            _config.Content.AppendTo( builder );
            return builder;
        }

        /// <inheritdoc />
        public override IHtmlContent Clone() {
            return new FormControlRender( _config.Copy() );
        }
    }
}
