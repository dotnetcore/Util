using Util.Ui.Angular.Builders;
using Util.Ui.Angular.Extensions;
using Util.Ui.Configs;

namespace Util.Ui.Tests.Samples {
    /// <summary>
    /// 测试标签生成器
    /// </summary>
    public class TestBuilder : AngularTagBuilder {
        /// <summary>
        /// 初始化测试标签生成器
        /// </summary>
        public TestBuilder( Config config ) : base( config,"test" ) {
        }

        /// <summary>
        /// 配置自定义标识
        /// </summary>
        protected override void ConfigId( Config config ) {
            var shareConfig = config.GetValueFromItems<TestShareConfig>();
            if ( string.IsNullOrWhiteSpace( shareConfig?.Id ) ) {
                base.ConfigId( config );
                return;
            }
            this.Id( $"test_{shareConfig.Id}" );
        }
    }
}
