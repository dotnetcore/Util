using Util.Ui.Angular.Configs;
using Util.Ui.Builders;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Lists.Builders {
    /// <summary>
    /// 列表空内容标签生成器
    /// </summary>
    public class ListEmptyBuilder : TagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化列表空内容标签生成器
        /// </summary>
        public ListEmptyBuilder( Config config ) : base( "nz-list-empty" ) {
            _config = config;
        }

        /// <summary>
        /// 配置空内容显示文本
        /// </summary>
        public ListEmptyBuilder NoResult() {
            AttributeIfNotEmpty( "nzNoResult", _config.GetValue( UiConst.NoResult ) );
            AttributeIfNotEmpty( "[nzNoResult]", _config.GetValue( AngularConst.BindNoResult ) );
            return this;
        }

        /// <summary>
        /// 配置
        /// </summary>
        public override void Config() {
            NoResult();
        }
    }
}