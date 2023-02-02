using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Forms.Configs;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Enums;
using Util.Ui.NgZorro.Extensions;

namespace Util.Ui.NgZorro.Components.Forms.Builders {
    /// <summary>
    /// 表单标签标签生成器
    /// </summary>
    public class FormLabelBuilder : ColumnBuilderBase<FormLabelBuilder> {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化表单标签标签生成器
        /// </summary>
        public FormLabelBuilder( Config config ) : base( config, "nz-form-label" ) {
            _config = config;
        }

        /// <summary>
        /// 获取表单项共享配置
        /// </summary>
        private FormItemShareConfig GetFormItemShareConfig() {
            return _config.GetValueFromItems<FormItemShareConfig>() ?? new FormItemShareConfig();
        }

        /// <summary>
        /// 配置必填样式
        /// </summary>
        public FormLabelBuilder Required() {
            AttributeIfNotEmpty( "[nzRequired]", _config.GetBoolValue( UiConst.Required ) );
            AttributeIfNotEmpty( "[nzRequired]", _config.GetValue( AngularConst.BindRequired ) );
            return this;
        }

        /// <summary>
        /// 配置不显示冒号
        /// </summary>
        public FormLabelBuilder NoColon() {
            AttributeIfNotEmpty( "[nzNoColon]", _config.GetBoolValue( UiConst.NoColon ) );
            AttributeIfNotEmpty( "[nzNoColon]", _config.GetValue( AngularConst.BindNoColon ) );
            return this;
        }

        /// <summary>
        /// 配置For
        /// </summary>
        public FormLabelBuilder For() {
            if ( _config.Contains( UiConst.LabelFor ) || _config.Contains( AngularConst.BindLabelFor ) ) {
                AttributeIfNotEmpty( "nzFor", _config.GetValue( UiConst.LabelFor ) );
                AttributeIfNotEmpty( "[nzFor]", _config.GetValue( AngularConst.BindLabelFor ) );
                return this;
            }
            var shareConfig = GetFormItemShareConfig();
            if ( shareConfig.AutoLabelFor != true )
                return this;
            AttributeIfNotEmpty( "nzFor", shareConfig.ControlId );
            return this;
        }

        /// <summary>
        /// 配置提示信息
        /// </summary>
        public FormLabelBuilder TooltipTitle() {
            AttributeIfNotEmpty( "nzTooltipTitle", _config.GetValue( UiConst.TooltipTitle ) );
            AttributeIfNotEmpty( "[nzTooltipTitle]", _config.GetValue( AngularConst.BindTooltipTitle ) );
            return this;
        }

        /// <summary>
        /// 配置提示图标
        /// </summary>
        public FormLabelBuilder TooltipIcon() {
            AttributeIfNotEmpty( "nzTooltipIcon", _config.GetValue<AntDesignIcon?>( UiConst.TooltipIcon )?.Description() );
            AttributeIfNotEmpty( "[nzTooltipIcon]", _config.GetValue( AngularConst.BindTooltipIcon ) );
            return this;
        }

        /// <summary>
        /// 配置跨度
        /// </summary>
        public override FormLabelBuilder Span() {
            if ( _config.Contains( UiConst.Span ) || _config.Contains( AngularConst.BindSpan ) )
                return base.Span();
            var shareConfig = GetFormItemShareConfig();
            AttributeIfNotEmpty( "[nzSpan]", shareConfig.LabelSpan );
            return this;
        }

        /// <summary>
        /// 配置偏移量
        /// </summary>
        public override FormLabelBuilder Offset() {
            if( _config.Contains( UiConst.Offset ) || _config.Contains( AngularConst.BindOffset ) )
                return base.Offset();
            var shareConfig = GetFormItemShareConfig();
            AttributeIfNotEmpty( "[nzOffset]", shareConfig.LabelOffset );
            return this;
        }

        /// <summary>
        /// 配置栅格顺序
        /// </summary>
        public override FormLabelBuilder Order() {
            if( _config.Contains( UiConst.Order ) || _config.Contains( AngularConst.BindOrder ) )
                return base.Order();
            var shareConfig = GetFormItemShareConfig();
            AttributeIfNotEmpty( "[nzOrder]", shareConfig.LabelOrder );
            return this;
        }

        /// <summary>
        /// 配置栅格左移
        /// </summary>
        public override FormLabelBuilder Pull() {
            if( _config.Contains( UiConst.Pull ) || _config.Contains( AngularConst.BindPull ) )
                return base.Pull();
            var shareConfig = GetFormItemShareConfig();
            AttributeIfNotEmpty( "[nzPull]", shareConfig.LabelPull );
            return this;
        }

        /// <summary>
        /// 配置栅格右移
        /// </summary>
        public override FormLabelBuilder Push() {
            if( _config.Contains( UiConst.Push ) || _config.Contains( AngularConst.BindPush ) )
                return base.Push();
            var shareConfig = GetFormItemShareConfig();
            AttributeIfNotEmpty( "[nzPush]", shareConfig.LabelPush );
            return this;
        }

        /// <summary>
        /// 配置Flex布局
        /// </summary>
        public override FormLabelBuilder Flex() {
            if( _config.Contains( UiConst.Flex ) || _config.Contains( AngularConst.BindFlex ) )
                return base.Flex();
            var shareConfig = GetFormItemShareConfig();
            AttributeIfNotEmpty( "[nzFlex]", shareConfig.LabelFlex );
            return this;
        }

        /// <summary>
        /// 获取Xs超窄尺寸响应式栅格
        /// </summary>
        protected override string GetXs() {
            if( _config.Contains( UiConst.Xs ) )
                return base.GetXs();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.LabelXs;
        }

        /// <summary>
        /// 获取Xs超窄尺寸跨度
        /// </summary>
        protected override int? GetXsSpan() {
            if( _config.Contains( UiConst.XsSpan ) )
                return base.GetXsSpan();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.LabelXsSpan;
        }

        /// <summary>
        /// 获取Xs超窄尺寸偏移量
        /// </summary>
        protected override int? GetXsOffset() {
            if( _config.Contains( UiConst.XsOffset ) )
                return base.GetXsOffset();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.LabelXsOffset;
        }

        /// <summary>
        /// 获取Xs超窄尺寸顺序
        /// </summary>
        protected override int? GetXsOrder() {
            if( _config.Contains( UiConst.XsOrder ) )
                return base.GetXsOrder();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.LabelXsOrder;
        }

        /// <summary>
        /// 获取Xs超窄尺寸左移
        /// </summary>
        protected override int? GetXsPull() {
            if( _config.Contains( UiConst.XsPull ) )
                return base.GetXsPull();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.LabelXsPull;
        }

        /// <summary>
        /// 获取Xs超窄尺寸右移
        /// </summary>
        protected override int? GetXsPush() {
            if( _config.Contains( UiConst.XsPush ) )
                return base.GetXsPush();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.LabelXsPush;
        }

        /// <summary>
        /// 获取Sm窄尺寸响应式栅格
        /// </summary>
        protected override string GetSm() {
            if( _config.Contains( UiConst.Sm ) )
                return base.GetSm();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.LabelSm;
        }

        /// <summary>
        /// 获取Sm窄尺寸跨度
        /// </summary>
        protected override int? GetSmSpan() {
            if( _config.Contains( UiConst.SmSpan ) )
                return base.GetSmSpan();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.LabelSmSpan;
        }

        /// <summary>
        /// 获取Sm窄尺寸偏移量
        /// </summary>
        protected override int? GetSmOffset() {
            if( _config.Contains( UiConst.SmOffset ) )
                return base.GetSmOffset();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.LabelSmOffset;
        }

        /// <summary>
        /// 获取Sm窄尺寸顺序
        /// </summary>
        protected override int? GetSmOrder() {
            if( _config.Contains( UiConst.SmOrder ) )
                return base.GetSmOrder();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.LabelSmOrder;
        }

        /// <summary>
        /// 获取Sm窄尺寸左移
        /// </summary>
        protected override int? GetSmPull() {
            if( _config.Contains( UiConst.SmPull ) )
                return base.GetSmPull();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.LabelSmPull;
        }

        /// <summary>
        /// 获取Sm窄尺寸右移
        /// </summary>
        protected override int? GetSmPush() {
            if( _config.Contains( UiConst.SmPush ) )
                return base.GetSmPush();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.LabelSmPush;
        }

        /// <summary>
        /// 获取Md中尺寸响应式栅格
        /// </summary>
        protected override string GetMd() {
            if( _config.Contains( UiConst.Md ) )
                return base.GetMd();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.LabelMd;
        }

        /// <summary>
        /// 获取Md中尺寸跨度
        /// </summary>
        protected override int? GetMdSpan() {
            if( _config.Contains( UiConst.MdSpan ) )
                return base.GetMdSpan();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.LabelMdSpan;
        }

        /// <summary>
        /// 获取Md中尺寸偏移量
        /// </summary>
        protected override int? GetMdOffset() {
            if( _config.Contains( UiConst.MdOffset ) )
                return base.GetMdOffset();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.LabelMdOffset;
        }

        /// <summary>
        /// 获取Md中尺寸顺序
        /// </summary>
        protected override int? GetMdOrder() {
            if( _config.Contains( UiConst.MdOrder ) )
                return base.GetMdOrder();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.LabelMdOrder;
        }

        /// <summary>
        /// 获取Md中尺寸左移
        /// </summary>
        protected override int? GetMdPull() {
            if( _config.Contains( UiConst.MdPull ) )
                return base.GetMdPull();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.LabelMdPull;
        }

        /// <summary>
        /// 获取Md中尺寸右移
        /// </summary>
        protected override int? GetMdPush() {
            if( _config.Contains( UiConst.MdPush ) )
                return base.GetMdPush();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.LabelMdPush;
        }

        /// <summary>
        /// 获取Lg宽尺寸响应式栅格
        /// </summary>
        protected override string GetLg() {
            if( _config.Contains( UiConst.Lg ) )
                return base.GetLg();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.LabelLg;
        }

        /// <summary>
        /// 获取Lg宽尺寸跨度
        /// </summary>
        protected override int? GetLgSpan() {
            if( _config.Contains( UiConst.LgSpan ) )
                return base.GetLgSpan();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.LabelLgSpan;
        }

        /// <summary>
        /// 获取Lg宽尺寸偏移量
        /// </summary>
        protected override int? GetLgOffset() {
            if( _config.Contains( UiConst.LgOffset ) )
                return base.GetLgOffset();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.LabelLgOffset;
        }

        /// <summary>
        /// 获取Lg宽尺寸顺序
        /// </summary>
        protected override int? GetLgOrder() {
            if( _config.Contains( UiConst.LgOrder ) )
                return base.GetLgOrder();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.LabelLgOrder;
        }

        /// <summary>
        /// 获取Lg宽尺寸左移
        /// </summary>
        protected override int? GetLgPull() {
            if( _config.Contains( UiConst.LgPull ) )
                return base.GetLgPull();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.LabelLgPull;
        }

        /// <summary>
        /// 获取Lg宽尺寸右移
        /// </summary>
        protected override int? GetLgPush() {
            if( _config.Contains( UiConst.LgPush ) )
                return base.GetLgPush();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.LabelLgPush;
        }

        /// <summary>
        /// 获取Xl超宽尺寸响应式栅格
        /// </summary>
        protected override string GetXl() {
            if( _config.Contains( UiConst.Xl ) )
                return base.GetXl();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.LabelXl;
        }

        /// <summary>
        /// 获取Xl超宽尺寸跨度
        /// </summary>
        protected override int? GetXlSpan() {
            if( _config.Contains( UiConst.XlSpan ) )
                return base.GetXlSpan();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.LabelXlSpan;
        }

        /// <summary>
        /// 获取Xl超宽尺寸偏移量
        /// </summary>
        protected override int? GetXlOffset() {
            if( _config.Contains( UiConst.XlOffset ) )
                return base.GetXlOffset();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.LabelXlOffset;
        }

        /// <summary>
        /// 获取Xl超宽尺寸顺序
        /// </summary>
        protected override int? GetXlOrder() {
            if( _config.Contains( UiConst.XlOrder ) )
                return base.GetXlOrder();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.LabelXlOrder;
        }

        /// <summary>
        /// 获取Xl超宽尺寸左移
        /// </summary>
        protected override int? GetXlPull() {
            if( _config.Contains( UiConst.XlPull ) )
                return base.GetXlPull();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.LabelXlPull;
        }

        /// <summary>
        /// 获取Xl超宽尺寸右移
        /// </summary>
        protected override int? GetXlPush() {
            if( _config.Contains( UiConst.XlPush ) )
                return base.GetXlPush();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.LabelXlPush;
        }

        /// <summary>
        /// 获取Xxl极宽尺寸响应式栅格
        /// </summary>
        protected override string GetXxl() {
            if( _config.Contains( UiConst.Xxl ) )
                return base.GetXxl();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.LabelXxl;
        }

        /// <summary>
        /// 获取Xxl极宽尺寸跨度
        /// </summary>
        protected override int? GetXxlSpan() {
            if( _config.Contains( UiConst.XxlSpan ) )
                return base.GetXxlSpan();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.LabelXxlSpan;
        }

        /// <summary>
        /// 获取Xxl极宽尺寸偏移量
        /// </summary>
        protected override int? GetXxlOffset() {
            if( _config.Contains( UiConst.XxlOffset ) )
                return base.GetXxlOffset();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.LabelXxlOffset;
        }

        /// <summary>
        /// 获取Xxl极宽尺寸顺序
        /// </summary>
        protected override int? GetXxlOrder() {
            if( _config.Contains( UiConst.XxlOrder ) )
                return base.GetXxlOrder();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.LabelXxlOrder;
        }

        /// <summary>
        /// 获取Xxl极宽尺寸左移
        /// </summary>
        protected override int? GetXxlPull() {
            if( _config.Contains( UiConst.XxlPull ) )
                return base.GetXxlPull();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.LabelXxlPull;
        }

        /// <summary>
        /// 获取Xxl极宽尺寸右移
        /// </summary>
        protected override int? GetXxlPush() {
            if( _config.Contains( UiConst.XxlPush ) )
                return base.GetXxlPush();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.LabelXxlPush;
        }

        /// <summary>
        /// 配置文本
        /// </summary>
        public FormLabelBuilder Text() {
            return SetText( _config.GetValue( UiConst.Text ) );
        }

        /// <summary>
        /// 配置内容
        /// </summary>
        private FormLabelBuilder SetText( string value ) {
            var options = NgZorroOptionsService.GetOptions();
            if ( value.IsEmpty() )
                return this;
            if ( options.EnableI18n ) {
                this.AppendContentByI18n( value );
                return this;
            }
            AppendContent( value );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            ConfigColumn().Required().NoColon().For().TooltipTitle().TooltipIcon();
            Text();
        }

        /// <summary>
        /// 配置内容
        /// </summary>
        protected override void ConfigContent( Config config ) {
            if ( config.Content.IsEmpty() ) {
                SetText( config.GetValue( UiConst.Title ) );
                return;
            }
            base.ConfigContent( config );
        }
    }
}
