using Util.Ui.Angular.Extensions;
using Util.Ui.Angular.Renders;
using Util.Ui.Builders;
using Util.Ui.Configs;

namespace Util.Ui.Tests.Samples {
    /// <summary>
    /// 测试渲染器
    /// </summary>
    public class TestRender : AngularRenderBase {
        /// <summary>
        /// 配置
        /// </summary>
        private Config _config;

        /// <summary>
        /// 初始化测试渲染器
        /// </summary>
        /// <param name="config">配置</param>
        public TestRender( Config config ) : base( config ) {
            _config = config;
        }

        /// <summary>
        /// 获取标签生成器
        /// </summary>
        protected override TagBuilder GetTagBuilder() {
            var builder = new TestBuilder();
            builder.AttributeIfNotEmpty( UiConst.Name, _config.GetValue( UiConst.Name ) );
            builder.AttributeIfNotEmpty( UiConst.Title, _config.GetValue( UiConst.Title ) );
            ConfigContent( builder );
            return builder;
        }

        /// <summary>
        /// 配置自定义标识
        /// </summary>
        protected override void ConfigId( TagBuilder builder ) {
            var shareConfig = _config.GetValueFromItems<TestShareConfig>();
            if ( string.IsNullOrWhiteSpace( shareConfig?.Id ) ) {
                base.ConfigId( builder );
                return;
            }
            builder.Id( $"test_{shareConfig.Id}" );
        }
    }
}