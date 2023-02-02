using Microsoft.AspNetCore.Html;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.NgAlain.Components.Tinymce.Builders;
using Util.Ui.NgZorro.Components.Base;

namespace Util.Ui.NgAlain.Components.Tinymce.Renders {
    /// <summary>
    /// Tinymce富文本渲染器
    /// </summary>
    public class TinymceRender : FormControlRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化Tinymce富文本渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public TinymceRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        protected override void Init() {
            SetControlId();
        }

        /// <summary>
        /// 添加表单控件
        /// </summary>
        protected override void AppendControl( TagBuilder formControlBuilder ) {
            var builder = new TinymceBuilder( _config );
            builder.Config();
            _config.Content.AppendTo( builder );
            formControlBuilder.AppendContent( builder );
        }

        /// <inheritdoc />
        public override IHtmlContent Clone() {
            return new TinymceRender( _config.Copy() );
        }
    }
}