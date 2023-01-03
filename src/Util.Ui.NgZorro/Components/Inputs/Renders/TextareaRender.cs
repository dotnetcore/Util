using Microsoft.AspNetCore.Html;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Inputs.Builders;

namespace Util.Ui.NgZorro.Components.Inputs.Renders {
    /// <summary>
    /// 文本域渲染器
    /// </summary>
    public class TextareaRender : InputRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化文本域渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public TextareaRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取输入框标签生成器
        /// </summary>
        protected override TagBuilder GetInputBuilder() {
            var builder = new TextareaBuilder( _config );
            builder.Config();
            return builder;
        }

        /// <summary>
        /// 获取输入框组合的样式类
        /// </summary>
        protected override string GetInputGroupClass() {
            if( _config.Contains( UiConst.AllowClear ) )
                return "ant-input-affix-wrapper-textarea-with-clear-btn";
            return null;
        }

        /// <summary>
        /// 获取清除图标的样式类
        /// </summary>
        protected override string GetClearIconClass() {
            return "ant-input-textarea-clear-icon";
        }

        /// <inheritdoc />
        public override IHtmlContent Clone() {
            return new TextareaRender( _config.Copy() );
        }
    }
}