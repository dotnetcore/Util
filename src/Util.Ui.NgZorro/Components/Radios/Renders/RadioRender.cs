using Microsoft.AspNetCore.Html;
using Util.Ui.Builders;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Forms.Renders;
using Util.Ui.NgZorro.Components.Radios.Builders;
using Util.Ui.NgZorro.Components.Radios.Configs;

namespace Util.Ui.NgZorro.Components.Radios.Renders {
    /// <summary>
    /// 单选框渲染器
    /// </summary>
    public class RadioRender : FormControlRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;
        /// <summary>
        /// 单选框组合共享配置
        /// </summary>
        private readonly RadioGroupShareConfig _shareConfig;

        /// <summary>
        /// 初始化单选框渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public RadioRender( Config config ) : base( config ) {
            _config = config;
            _shareConfig = GetShareConfig();
        }

        /// <summary>
        /// 获取单选框组合共享配置
        /// </summary>
        private RadioGroupShareConfig GetShareConfig() {
            return _config.GetValueFromItems<RadioGroupShareConfig>() ?? new RadioGroupShareConfig();
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
            var groupBuilder = GetRadioGroupBuilder();
            groupBuilder.AppendContent( GetRadioBuilder() );
            formControlBuilder.AppendContent( groupBuilder );
        }

        /// <summary>
        /// 获取单选框组合标签生成器
        /// </summary>
        private TagBuilder GetRadioGroupBuilder() {
            if ( _shareConfig.IsAutoCreateRadioGroup != true )
                return new EmptyContainerTagBuilder();
            var groupBuilder = new RadioGroupBuilder( _config );
            groupBuilder.SelectExtend();
            groupBuilder.Data();
            groupBuilder.Url();
            groupBuilder.NgModel();
            groupBuilder.Name();
            groupBuilder.OnModelChange();
            return groupBuilder;
        }

        /// <summary>
        /// 获取单选框标签生成器
        /// </summary>
        private TagBuilder GetRadioBuilder() {
            var builder = new RadioBuilder( _config );
            builder.Config();
            if ( _config.Content.IsEmpty() == false )
                builder.SetContent( _config.Content );
            if ( _shareConfig.IsRadioExtend )
                builder.Extend();
            return builder;
        }

        /// <inheritdoc />
        public override IHtmlContent Clone() {
            return new RadioRender( _config.Copy() );
        }
    }
}
