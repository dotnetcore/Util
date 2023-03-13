using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.Extensions;
using Util.Ui.NgZorro.Components.Icons.Builders;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Enums;
using Util.Ui.NgZorro.Extensions;

namespace Util.Ui.NgZorro.Components.Descriptions.Builders {
    /// <summary>
    /// 描述列表项标签生成器
    /// </summary>
    public class DescriptionItemBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化描述列表项标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public DescriptionItemBuilder( Config config ) : base( config,"nz-descriptions-item" ) {
            _config = config;
        }

        /// <summary>
        /// 配置标题
        /// </summary>
        public DescriptionItemBuilder Title() {
            SetTitle( _config.GetValue( UiConst.Title ) );
            AttributeIfNotEmpty( "[nzTitle]", _config.GetValue( AngularConst.BindTitle ) );
            return this;
        }

        /// <summary>
        /// 设置表单标签文本
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
        /// 配置列跨度
        /// </summary>
        public DescriptionItemBuilder Span() {
            AttributeIfNotEmpty( "nzSpan", _config.GetValue( UiConst.Span ) );
            AttributeIfNotEmpty( "[nzSpan]", _config.GetValue( AngularConst.BindSpan ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            base.Config();
            Title().Span();
        }

        /// <summary>
        /// 配置内容
        /// </summary>
        protected override void ConfigContent( Config config ) {
            if ( config.Content.IsEmpty() == false ) {
                config.Content.AppendTo( this );
                return;
            }
            ConfigValue();
        }

        /// <summary>
        /// 配置值
        /// </summary>
        private void ConfigValue() {
            var dataType = _config.GetValue<DataType?>( UiConst.DataType );
            var value = _config.GetValue( UiConst.Value );
            if ( value.IsEmpty() )
                return;
            if ( dataType == DataType.Bool ) {
                LoadBool(value);
                return;
            }
            if ( dataType == DataType.Date ) {
                LoadDate( value );
                return;
            }
            SetContent( "{{" + value + "}}");
        }

        /// <summary>
        /// 加载布尔值
        /// </summary>
        protected void LoadBool( string value ) {
            AppendContent( new IconBuilder( _config ).Type( AntDesignIcon.Check.Description() ).Attribute( "*ngIf", $"{value}" ) );
            AppendContent( new IconBuilder( _config ).Type( AntDesignIcon.Close.Description() ).Attribute( "*ngIf", $"!({value})" ) );
        }

        /// <summary>
        /// 加载日期值
        /// </summary>
        protected void LoadDate( string value ) {
            var format = _config.GetValue( UiConst.DateFormat );
            if ( format.IsEmpty() )
                format = "yyyy-MM-dd HH:mm";
            SetContent( $"{{{{{value}|date:\"{format}\"}}}}" );
        }
    }
}