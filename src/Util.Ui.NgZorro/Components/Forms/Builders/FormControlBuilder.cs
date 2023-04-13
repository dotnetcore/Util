using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Base;
using Util.Ui.NgZorro.Components.Forms.Configs;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Extensions;

namespace Util.Ui.NgZorro.Components.Forms.Builders {
    /// <summary>
    /// 表单域标签生成器
    /// </summary>
    public class FormControlBuilder : ColumnBuilderBase<FormControlBuilder> {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化表单域标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public FormControlBuilder( Config config ) : base( config, "nz-form-control" ) {
            _config = config;
        }

        /// <summary>
        /// 获取表单项共享配置
        /// </summary>
        private FormItemShareConfig GetFormItemShareConfig() {
            return _config.GetValueFromItems<FormItemShareConfig>() ?? new FormItemShareConfig();
        }

        /// <summary>
        /// 配置校验状态
        /// </summary>
        public FormControlBuilder ValidateStatus() {
            AttributeIfNotEmpty( "[nzValidateStatus]", _config.GetValue( UiConst.ValidateStatus ) );
            return this;
        }

        /// <summary>
        /// 配置展示校验状态图标
        /// </summary>
        public FormControlBuilder HasFeedback() {
            AttributeIfNotEmpty( "[nzHasFeedback]", _config.GetValue( UiConst.HasFeedback ) );
            return this;
        }

        /// <summary>
        /// 配置额外提示
        /// </summary>
        public FormControlBuilder Extra() {
            Extra( _config.GetValue( UiConst.Extra ) );
            BindExtra( _config.GetValue( AngularConst.BindExtra ) );
            return this;
        }

        /// <summary>
        /// 配置额外提示
        /// </summary>
        private void Extra( string value ) {
            var options = NgZorroOptionsService.GetOptions();
            if ( options.EnableI18n ) {
                this.AttributeByI18n( "[nzExtra]", value );
                return;
            }
            AttributeIfNotEmpty( "nzExtra", value );
        }

        /// <summary>
        /// 配置额外提示
        /// </summary>
        private void BindExtra( string value ) {
            AttributeIfNotEmpty( "[nzExtra]", value );
        }

        /// <summary>
        /// 配置校验成功状态提示
        /// </summary>
        public FormControlBuilder SuccessTip() {
            AttributeIfNotEmpty( "nzSuccessTip", _config.GetValue( UiConst.SuccessTip ) );
            AttributeIfNotEmpty( "[nzSuccessTip]", _config.GetValue( AngularConst.BindSuccessTip ) );
            return this;
        }

        /// <summary>
        /// 配置校验警告状态提示
        /// </summary>
        public FormControlBuilder WarningTip() {
            AttributeIfNotEmpty( "nzWarningTip", _config.GetValue( UiConst.WarningTip ) );
            AttributeIfNotEmpty( "[nzWarningTip]", _config.GetValue( AngularConst.BindWarningTip ) );
            return this;
        }

        /// <summary>
        /// 配置校验错误状态提示
        /// </summary>
        public FormControlBuilder ErrorTip() {
            AttributeIfNotEmpty( "nzErrorTip", _config.GetValue( UiConst.ErrorTip ) );
            AttributeIfNotEmpty( "[nzErrorTip]", _config.GetValue( AngularConst.BindErrorTip ) );
            return this;
        }

        /// <summary>
        /// 配置校验中状态提示
        /// </summary>
        public FormControlBuilder ValidatingTip() {
            AttributeIfNotEmpty( "nzValidatingTip", _config.GetValue( UiConst.ValidatingTip ) );
            AttributeIfNotEmpty( "[nzValidatingTip]", _config.GetValue( AngularConst.BindValidatingTip ) );
            return this;
        }

        /// <summary>
        /// 配置自动提示
        /// </summary>
        public FormControlBuilder AutoTips() {
            AttributeIfNotEmpty( "[nzAutoTips]", _config.GetValue( UiConst.AutoTips ) );
            return this;
        }

        /// <summary>
        /// 配置禁用自动提示
        /// </summary>
        public FormControlBuilder DisableAutoTips() {
            AttributeIfNotEmpty( "[nzDisableAutoTips]", _config.GetValue( UiConst.DisableAutoTips ) );
            return this;
        }

        /// <summary>
        /// 配置跨度
        /// </summary>
        public override FormControlBuilder Span() {
            if( _config.Contains( UiConst.Span ) || _config.Contains( AngularConst.BindSpan ) )
                return base.Span();
            var shareConfig = GetFormItemShareConfig();
            AttributeIfNotEmpty( "[nzSpan]", shareConfig.ControlSpan );
            return this;
        }

        /// <summary>
        /// 配置偏移量
        /// </summary>
        public override FormControlBuilder Offset() {
            if( _config.Contains( UiConst.Offset ) || _config.Contains( AngularConst.BindOffset ) )
                return base.Offset();
            var shareConfig = GetFormItemShareConfig();
            AttributeIfNotEmpty( "[nzOffset]", shareConfig.ControlOffset );
            return this;
        }

        /// <summary>
        /// 配置栅格顺序
        /// </summary>
        public override FormControlBuilder Order() {
            if( _config.Contains( UiConst.Order ) || _config.Contains( AngularConst.BindOrder ) )
                return base.Order();
            var shareConfig = GetFormItemShareConfig();
            AttributeIfNotEmpty( "[nzOrder]", shareConfig.ControlOrder );
            return this;
        }

        /// <summary>
        /// 配置栅格左移
        /// </summary>
        public override FormControlBuilder Pull() {
            if( _config.Contains( UiConst.Pull ) || _config.Contains( AngularConst.BindPull ) )
                return base.Pull();
            var shareConfig = GetFormItemShareConfig();
            AttributeIfNotEmpty( "[nzPull]", shareConfig.ControlPull );
            return this;
        }

        /// <summary>
        /// 配置栅格右移
        /// </summary>
        public override FormControlBuilder Push() {
            if( _config.Contains( UiConst.Push ) || _config.Contains( AngularConst.BindPush ) )
                return base.Push();
            var shareConfig = GetFormItemShareConfig();
            AttributeIfNotEmpty( "[nzPush]", shareConfig.ControlPush );
            return this;
        }

        /// <summary>
        /// 配置Flex布局
        /// </summary>
        public override FormControlBuilder Flex() {
            if( _config.Contains( UiConst.Flex ) || _config.Contains( AngularConst.BindFlex ) )
                return base.Flex();
            var shareConfig = GetFormItemShareConfig();
            AttributeIfNotEmpty( "[nzFlex]", shareConfig.ControlFlex );
            return this;
        }

        /// <summary>
        /// 获取Xs超窄尺寸响应式栅格
        /// </summary>
        protected override string GetXs() {
            if( _config.Contains( UiConst.Xs ) )
                return base.GetXs();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.ControlXs;
        }

        /// <summary>
        /// 获取Xs超窄尺寸跨度
        /// </summary>
        protected override int? GetXsSpan() {
            if( _config.Contains( UiConst.XsSpan ) )
                return base.GetXsSpan();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.ControlXsSpan;
        }

        /// <summary>
        /// 获取Xs超窄尺寸偏移量
        /// </summary>
        protected override int? GetXsOffset() {
            if( _config.Contains( UiConst.XsOffset ) )
                return base.GetXsOffset();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.ControlXsOffset;
        }

        /// <summary>
        /// 获取Xs超窄尺寸顺序
        /// </summary>
        protected override int? GetXsOrder() {
            if( _config.Contains( UiConst.XsOrder ) )
                return base.GetXsOrder();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.ControlXsOrder;
        }

        /// <summary>
        /// 获取Xs超窄尺寸左移
        /// </summary>
        protected override int? GetXsPull() {
            if( _config.Contains( UiConst.XsPull ) )
                return base.GetXsPull();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.ControlXsPull;
        }

        /// <summary>
        /// 获取Xs超窄尺寸右移
        /// </summary>
        protected override int? GetXsPush() {
            if( _config.Contains( UiConst.XsPush ) )
                return base.GetXsPush();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.ControlXsPush;
        }

        /// <summary>
        /// 获取Sm窄尺寸响应式栅格
        /// </summary>
        protected override string GetSm() {
            if( _config.Contains( UiConst.Sm ) )
                return base.GetSm();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.ControlSm;
        }

        /// <summary>
        /// 获取Sm窄尺寸跨度
        /// </summary>
        protected override int? GetSmSpan() {
            if( _config.Contains( UiConst.SmSpan ) )
                return base.GetSmSpan();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.ControlSmSpan;
        }

        /// <summary>
        /// 获取Sm窄尺寸偏移量
        /// </summary>
        protected override int? GetSmOffset() {
            if( _config.Contains( UiConst.SmOffset ) )
                return base.GetSmOffset();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.ControlSmOffset;
        }

        /// <summary>
        /// 获取Sm窄尺寸顺序
        /// </summary>
        protected override int? GetSmOrder() {
            if( _config.Contains( UiConst.SmOrder ) )
                return base.GetSmOrder();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.ControlSmOrder;
        }

        /// <summary>
        /// 获取Sm窄尺寸左移
        /// </summary>
        protected override int? GetSmPull() {
            if( _config.Contains( UiConst.SmPull ) )
                return base.GetSmPull();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.ControlSmPull;
        }

        /// <summary>
        /// 获取Sm窄尺寸右移
        /// </summary>
        protected override int? GetSmPush() {
            if( _config.Contains( UiConst.SmPush ) )
                return base.GetSmPush();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.ControlSmPush;
        }

        /// <summary>
        /// 获取Md中尺寸响应式栅格
        /// </summary>
        protected override string GetMd() {
            if( _config.Contains( UiConst.Md ) )
                return base.GetMd();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.ControlMd;
        }

        /// <summary>
        /// 获取Md中尺寸跨度
        /// </summary>
        protected override int? GetMdSpan() {
            if( _config.Contains( UiConst.MdSpan ) )
                return base.GetMdSpan();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.ControlMdSpan;
        }

        /// <summary>
        /// 获取Md中尺寸偏移量
        /// </summary>
        protected override int? GetMdOffset() {
            if( _config.Contains( UiConst.MdOffset ) )
                return base.GetMdOffset();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.ControlMdOffset;
        }

        /// <summary>
        /// 获取Md中尺寸顺序
        /// </summary>
        protected override int? GetMdOrder() {
            if( _config.Contains( UiConst.MdOrder ) )
                return base.GetMdOrder();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.ControlMdOrder;
        }

        /// <summary>
        /// 获取Md中尺寸左移
        /// </summary>
        protected override int? GetMdPull() {
            if( _config.Contains( UiConst.MdPull ) )
                return base.GetMdPull();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.ControlMdPull;
        }

        /// <summary>
        /// 获取Md中尺寸右移
        /// </summary>
        protected override int? GetMdPush() {
            if( _config.Contains( UiConst.MdPush ) )
                return base.GetMdPush();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.ControlMdPush;
        }

        /// <summary>
        /// 获取Lg宽尺寸响应式栅格
        /// </summary>
        protected override string GetLg() {
            if( _config.Contains( UiConst.Lg ) )
                return base.GetLg();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.ControlLg;
        }

        /// <summary>
        /// 获取Lg宽尺寸跨度
        /// </summary>
        protected override int? GetLgSpan() {
            if( _config.Contains( UiConst.LgSpan ) )
                return base.GetLgSpan();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.ControlLgSpan;
        }

        /// <summary>
        /// 获取Lg宽尺寸偏移量
        /// </summary>
        protected override int? GetLgOffset() {
            if( _config.Contains( UiConst.LgOffset ) )
                return base.GetLgOffset();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.ControlLgOffset;
        }

        /// <summary>
        /// 获取Lg宽尺寸顺序
        /// </summary>
        protected override int? GetLgOrder() {
            if( _config.Contains( UiConst.LgOrder ) )
                return base.GetLgOrder();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.ControlLgOrder;
        }

        /// <summary>
        /// 获取Lg宽尺寸左移
        /// </summary>
        protected override int? GetLgPull() {
            if( _config.Contains( UiConst.LgPull ) )
                return base.GetLgPull();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.ControlLgPull;
        }

        /// <summary>
        /// 获取Lg宽尺寸右移
        /// </summary>
        protected override int? GetLgPush() {
            if( _config.Contains( UiConst.LgPush ) )
                return base.GetLgPush();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.ControlLgPush;
        }

        /// <summary>
        /// 获取Xl超宽尺寸响应式栅格
        /// </summary>
        protected override string GetXl() {
            if( _config.Contains( UiConst.Xl ) )
                return base.GetXl();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.ControlXl;
        }

        /// <summary>
        /// 获取Xl超宽尺寸跨度
        /// </summary>
        protected override int? GetXlSpan() {
            if( _config.Contains( UiConst.XlSpan ) )
                return base.GetXlSpan();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.ControlXlSpan;
        }

        /// <summary>
        /// 获取Xl超宽尺寸偏移量
        /// </summary>
        protected override int? GetXlOffset() {
            if( _config.Contains( UiConst.XlOffset ) )
                return base.GetXlOffset();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.ControlXlOffset;
        }

        /// <summary>
        /// 获取Xl超宽尺寸顺序
        /// </summary>
        protected override int? GetXlOrder() {
            if( _config.Contains( UiConst.XlOrder ) )
                return base.GetXlOrder();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.ControlXlOrder;
        }

        /// <summary>
        /// 获取Xl超宽尺寸左移
        /// </summary>
        protected override int? GetXlPull() {
            if( _config.Contains( UiConst.XlPull ) )
                return base.GetXlPull();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.ControlXlPull;
        }

        /// <summary>
        /// 获取Xl超宽尺寸右移
        /// </summary>
        protected override int? GetXlPush() {
            if( _config.Contains( UiConst.XlPush ) )
                return base.GetXlPush();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.ControlXlPush;
        }

        /// <summary>
        /// 获取Xxl极宽尺寸响应式栅格
        /// </summary>
        protected override string GetXxl() {
            if( _config.Contains( UiConst.Xxl ) )
                return base.GetXxl();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.ControlXxl;
        }

        /// <summary>
        /// 获取Xxl极宽尺寸跨度
        /// </summary>
        protected override int? GetXxlSpan() {
            if( _config.Contains( UiConst.XxlSpan ) )
                return base.GetXxlSpan();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.ControlXxlSpan;
        }

        /// <summary>
        /// 获取Xxl极宽尺寸偏移量
        /// </summary>
        protected override int? GetXxlOffset() {
            if( _config.Contains( UiConst.XxlOffset ) )
                return base.GetXxlOffset();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.ControlXxlOffset;
        }

        /// <summary>
        /// 获取Xxl极宽尺寸顺序
        /// </summary>
        protected override int? GetXxlOrder() {
            if( _config.Contains( UiConst.XxlOrder ) )
                return base.GetXxlOrder();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.ControlXxlOrder;
        }

        /// <summary>
        /// 获取Xxl极宽尺寸左移
        /// </summary>
        protected override int? GetXxlPull() {
            if( _config.Contains( UiConst.XxlPull ) )
                return base.GetXxlPull();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.ControlXxlPull;
        }

        /// <summary>
        /// 获取Xxl极宽尺寸右移
        /// </summary>
        protected override int? GetXxlPush() {
            if( _config.Contains( UiConst.XxlPush ) )
                return base.GetXxlPush();
            var shareConfig = GetFormItemShareConfig();
            return shareConfig.ControlXxlPush;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.ConfigBase(_config);
            ConfigColumn().ValidateStatus().HasFeedback().Extra()
                .SuccessTip().WarningTip().ErrorTip().ValidatingTip()
                .AutoTips().DisableAutoTips();
        }
    }
}
