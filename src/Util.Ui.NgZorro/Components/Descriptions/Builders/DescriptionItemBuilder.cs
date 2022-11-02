using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.Extensions;

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
            AttributeIfNotEmpty( "nzTitle", _config.GetValue( UiConst.Title ) );
            AttributeIfNotEmpty( "[nzTitle]", _config.GetValue( AngularConst.BindTitle ) );
            return this;
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
            var value = _config.GetValue( UiConst.Value );
            SetContent( value );
        }
    }
}