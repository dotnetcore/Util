using Util.Ui.Angular.Configs;
using Util.Ui.Builders;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Descriptions.Builders {
    /// <summary>
    /// 描述列表项标签生成器
    /// </summary>
    public class DescriptionItemBuilder : TagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化描述列表项标签生成器
        /// </summary>
        public DescriptionItemBuilder( Config config ) : base( "nz-descriptions-item" ) {
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
            Title().Span();
        }
    }
}