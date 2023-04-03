using Microsoft.AspNetCore.Html;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Selects.Builders;

namespace Util.Ui.NgZorro.Components.Selects.Renders {
    /// <summary>
    /// 选择器渲染器
    /// </summary>
    public class SelectRender : FormControlRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化选择器渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public SelectRender( Config config ) : base( config ) {
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
            var builder = new SelectBuilder( _config );
            builder.Config();
            formControlBuilder.AppendContent( builder );
        }

        /// <inheritdoc />
        public override IHtmlContent Clone() {
            return new SelectRender( _config.Copy() );
        }
    }
}