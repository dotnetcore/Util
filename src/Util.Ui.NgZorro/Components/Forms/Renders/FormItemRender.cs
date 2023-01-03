using Microsoft.AspNetCore.Html;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.NgZorro.Components.Forms.Builders;
using Util.Ui.NgZorro.Components.Forms.Configs;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.Forms.Renders {
    /// <summary>
    /// 表单项渲染器
    /// </summary>
    public class FormItemRender : RenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;
        /// <summary>
        /// 表单项共享配置
        /// </summary>
        private readonly FormItemShareConfig _shareConfig;

        /// <summary>
        /// 初始化表单项渲染器
        /// </summary>
        /// <param name="config">配置</param>
        /// <param name="shareConfig">共享配置</param>
        public FormItemRender( Config config, FormItemShareConfig shareConfig = null ) {
            _config = config;
            _shareConfig = shareConfig ?? GetFormItemShareConfig();
        }

        /// <summary>
        /// 获取表单项共享配置
        /// </summary>
        private FormItemShareConfig GetFormItemShareConfig() {
            return _config.GetValueFromItems<FormItemShareConfig>() ?? new FormItemShareConfig();
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new FormItemBuilder( _config );
            builder.Config();
            var formLabel = GetFormLabel();
            builder.AppendContent( formLabel );
            _config.Content.AppendTo( builder );
            return builder;
        }

        /// <summary>
        /// 获取表单标签
        /// </summary>
        private TagBuilder GetFormLabel() {
            if ( _shareConfig.AutoCreateFormLabel == true ) {
                _shareConfig.AutoCreateFormLabel = false;
                var builder = new FormLabelBuilder( _config );
                builder.Config();
                builder.SetContent( _shareConfig.LabelText );
                return builder;
            }
            return new EmptyContainerTagBuilder();
        }

        /// <inheritdoc />
        public override IHtmlContent Clone() {
            return new FormItemRender( _config.Copy(), _shareConfig.MapTo<FormItemShareConfig>() );
        }
    }
}
