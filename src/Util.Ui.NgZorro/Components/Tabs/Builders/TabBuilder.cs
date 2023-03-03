using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.NgZorro.Components.Templates.Builders;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Enums;
using Util.Ui.NgZorro.Extensions;

namespace Util.Ui.NgZorro.Components.Tabs.Builders {
    /// <summary>
    /// 标签标签生成器
    /// </summary>
    public class TabBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化标签标签生成器
        /// </summary>
        public TabBuilder( Config config ) : base( config, "nz-tab" ) {
            _config = config;
        }

        /// <summary>
        /// 配置标题
        /// </summary>
        public TabBuilder Title() {
            SetTitle( _config.GetValue( UiConst.Title ) );
            AttributeIfNotEmpty( "[nzTitle]", _config.GetValue( AngularConst.BindTitle ) );
            return this;
        }

        /// <summary>
        /// 设置标题
        /// </summary>
        private void SetTitle( string value ) {
            var options = NgZorroOptionsService.GetOptions();
            if ( options.EnableI18n ) {
                this.AttributeByI18n( "[nzTitle]", value );
                return;
            }
            AttributeIfNotEmpty( "nzTitle", value );
        }

        /// <summary>
        /// 配置是否强制渲染
        /// </summary>
        public TabBuilder ForceRender() {
            AttributeIfNotEmpty( "[nzForceRender]", _config.GetBoolValue( UiConst.ForceRender ) );
            AttributeIfNotEmpty( "[nzForceRender]", _config.GetValue( AngularConst.BindForceRender ) );
            return this;
        }

        /// <summary>
        /// 配置是否禁用
        /// </summary>
        public TabBuilder Disabled() {
            AttributeIfNotEmpty( "[nzDisabled]", _config.GetBoolValue( UiConst.Disabled ) );
            AttributeIfNotEmpty( "[nzDisabled]", _config.GetValue( AngularConst.BindDisabled ) );
            return this;
        }

        /// <summary>
        /// 配置是否显示关闭按钮
        /// </summary>
        public TabBuilder Closable() {
            AttributeIfNotEmpty( "[nzClosable]", _config.GetBoolValue( UiConst.Closable ) );
            AttributeIfNotEmpty( "[nzClosable]", _config.GetValue( AngularConst.BindClosable ) );
            return this;
        }

        /// <summary>
        /// 配置关闭按钮图标
        /// </summary>
        public TabBuilder CloseIcon() {
            AttributeIfNotEmpty( "nzCloseIcon", _config.GetValue<AntDesignIcon?>( UiConst.CloseIcon )?.Description() );
            AttributeIfNotEmpty( "[nzCloseIcon]", _config.GetValue( AngularConst.BindCloseIcon ) );
            return this;
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        public TabBuilder Events() {
            AttributeIfNotEmpty( "(nzClick)", _config.GetValue( UiConst.OnClick ) );
            AttributeIfNotEmpty( "(nzContextmenu)", _config.GetValue( UiConst.OnContextmenu ) );
            AttributeIfNotEmpty( "(nzSelect)", _config.GetValue( UiConst.OnSelect ) );
            AttributeIfNotEmpty( "(nzDeselect)", _config.GetValue( UiConst.OnDeselect ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            Title().ForceRender().Disabled().Closable().CloseIcon()
                .Events();
        }

        /// <summary>
        /// 配置内容
        /// </summary>
        protected override void ConfigContent( Config config ) {
            var isLazy = _config.GetValue<bool?>( UiConst.Lazy );
            if ( isLazy != true ) {
                base.ConfigContent( config );
                return;
            }
            var templateBuilder = new TemplateBuilder( _config );
            templateBuilder.Tab( true );
            config.Content.AppendTo( templateBuilder );
            SetContent( templateBuilder );
        }
    }
}