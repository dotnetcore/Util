using Microsoft.AspNetCore.Html;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Switches.Builders;

namespace Util.Ui.NgZorro.Components.Switches.Renders {
    /// <summary>
    /// 开关渲染器
    /// </summary>
    public class SwitchRender : FormControlRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化开关渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public SwitchRender( Config config ) : base( config ) {
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
            var builder = new SwitchBuilder( _config );
            builder.Config();
            if( _config.Content.IsEmpty() == false )
                builder.SetContent( _config.Content );
            formControlBuilder.AppendContent( builder );
        }

        /// <inheritdoc />
        public override IHtmlContent Clone() {
            return new SwitchRender( _config.Copy() );
        }
    }
}
