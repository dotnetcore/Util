using Microsoft.AspNetCore.Html;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Upload.Builders;

namespace Util.Ui.NgZorro.Components.Upload.Renders {
    /// <summary>
    /// 上传渲染器
    /// </summary>
    public class UploadRender : FormControlRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化上传渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public UploadRender( Config config ) : base( config ) {
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
            var builder = new UploadBuilder( _config );
            builder.Config();
            _config.Content.AppendTo( builder );
            formControlBuilder.AppendContent( builder );
        }

        /// <inheritdoc />
        public override IHtmlContent Clone() {
            return new UploadRender( _config.Copy() );
        }
    }
}