using Microsoft.AspNetCore.Html;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Inputs.Builders;

namespace Util.Ui.NgZorro.Components.Inputs.Renders {
    /// <summary>
    /// 输入框渲染器
    /// </summary>
    public class InputRender : InputRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化输入框渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public InputRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取输入框标签生成器
        /// </summary>
        protected override TagBuilder GetInputBuilder() {
            var builder = new InputBuilder( _config );
            builder.Config();
            return builder;
        }

        /// <inheritdoc />
        public override IHtmlContent Clone() {
            return new InputRender( _config.Copy() );
        }
    }
}