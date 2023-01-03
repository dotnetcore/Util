using Microsoft.AspNetCore.Html;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Sliders.Builders;

namespace Util.Ui.NgZorro.Components.Sliders.Renders {
    /// <summary>
    /// 滑动输入条渲染器
    /// </summary>
    public class SliderRender : FormControlRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化滑动输入条渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public SliderRender( Config config ) : base( config ) {
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
            var builder = new SliderBuilder( _config );
            builder.Config();
            _config.Content.AppendTo( builder );
            formControlBuilder.AppendContent( builder );
        }

        /// <inheritdoc />
        public override IHtmlContent Clone() {
            return new SliderRender( _config.Copy() );
        }
    }
}