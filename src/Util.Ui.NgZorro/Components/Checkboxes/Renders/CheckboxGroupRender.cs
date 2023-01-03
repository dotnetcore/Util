using Microsoft.AspNetCore.Html;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Checkboxes.Builders;

namespace Util.Ui.NgZorro.Components.Checkboxes.Renders {
    /// <summary>
    /// 复选框组合渲染器
    /// </summary>
    public class CheckboxGroupRender : FormControlRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化复选框组合渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public CheckboxGroupRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 添加表单控件
        /// </summary>
        protected override void AppendControl( TagBuilder formControlBuilder ) {
            var builder = new CheckboxGroupBuilder( _config );
            builder.Config();
            _config.Content.AppendTo( builder );
            formControlBuilder.AppendContent( builder );
        }

        /// <inheritdoc />
        public override IHtmlContent Clone() {
            return new CheckboxGroupRender( _config.Copy() );
        }
    }
}