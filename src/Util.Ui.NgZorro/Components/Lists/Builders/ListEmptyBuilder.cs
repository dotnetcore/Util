using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;

namespace Util.Ui.NgZorro.Components.Lists.Builders {
    /// <summary>
    /// 列表空内容标签生成器
    /// </summary>
    public class ListEmptyBuilder : AngularTagBuilder {
        /// <summary>
        /// 配置
        /// </summary>
        private readonly Config _config;

        /// <summary>
        /// 初始化列表空内容标签生成器
        /// </summary>
        /// <param name="config">配置</param>
        public ListEmptyBuilder( Config config ) : base( config,"nz-list-empty" ) {
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
            base.Config();
            NoResult();
        }
    }
}