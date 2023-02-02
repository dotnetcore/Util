using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Enums;
using Util.Ui.NgZorro.Extensions;

namespace Util.Ui.NgZorro.Components.Tags.Builders {
    /// <summary>
    /// 标签标签生成器
    /// </summary>
    public class TagTagBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化标签标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public TagTagBuilder( Config config ) : base( config,"nz-tag" ) {
            _config = config;
        }

        /// <summary>
        /// 配置模式
        /// </summary>
        public TagTagBuilder Mode() {
            AttributeIfNotEmpty( "nzMode", _config.GetValue<TagMode?>( UiConst.Mode )?.Description() );
            AttributeIfNotEmpty( "[nzMode]", _config.GetValue( AngularConst.BindMode ) );
            return this;
        }

        /// <summary>
        /// 配置是否选中
        /// </summary>
        public TagTagBuilder Checked() {
            AttributeIfNotEmpty( "[nzChecked]", _config.GetBoolValue( UiConst.Checked ) );
            AttributeIfNotEmpty( "[nzChecked]", _config.GetValue( AngularConst.BindChecked ) );
            AttributeIfNotEmpty( "[(nzChecked)]", _config.GetValue( AngularConst.BindonChecked ) );
            return this;
        }

        /// <summary>
        /// 配置颜色
        /// </summary>
        public TagTagBuilder Color() {
            AttributeIfNotEmpty( "nzColor", _config.GetValue<AntDesignColor?>( UiConst.ColorType )?.Description() );
            AttributeIfNotEmpty( "nzColor", _config.GetValue( UiConst.Color ) );
            AttributeIfNotEmpty( "[nzColor]", _config.GetValue( AngularConst.BindColor ) );
            return this;
        }

        /// <summary>
        /// 配置事件
        /// </summary>
        public TagTagBuilder Events() {
            AttributeIfNotEmpty( "(nzOnClose)", _config.GetValue( UiConst.OnClose ) );
            AttributeIfNotEmpty( "(nzCheckedChange)", _config.GetValue( UiConst.OnCheckedChange ) );
            return this;
        }

        /// <summary>
        /// 配置Enabled文本
        /// </summary>
        public TagTagBuilder TextEnabled() {
            var value = _config.GetValue<bool?>( UiConst.TextEnabled );
            if ( value != true )
                return this;
            var options = NgZorroOptionsService.GetOptions();
            if ( options.EnableI18n ) {
                _config.SetAttribute( UiConst.Text, "util.enabled" );
                return this;
            }
            _config.SetAttribute( UiConst.Text, "Enabled" );
            return this;
        }

        /// <summary>
        /// 配置Not Enabled文本
        /// </summary>
        public TagTagBuilder TextNotEnabled() {
            var value = _config.GetValue<bool?>( UiConst.TextNotEnabled );
            if ( value != true )
                return this;
            var options = NgZorroOptionsService.GetOptions();
            if ( options.EnableI18n ) {
                _config.SetAttribute( UiConst.Text, "util.notEnabled" );
                return this;
            }
            _config.SetAttribute( UiConst.Text, "Not Enabled" );
            return this;
        }

        /// <summary>
        /// 配置文本
        /// </summary>
        public TagTagBuilder Text() {
            var options = NgZorroOptionsService.GetOptions();
            var text = _config.GetValue( UiConst.Text );
            if ( text.IsEmpty() )
                return this;
            if ( options.EnableI18n ) {
                this.AppendContentByI18n( text );
                return this;
            }
            AppendContent( text );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            Mode().Checked().Color().Events();
            TextEnabled().TextNotEnabled().Text();
        }
    }
}