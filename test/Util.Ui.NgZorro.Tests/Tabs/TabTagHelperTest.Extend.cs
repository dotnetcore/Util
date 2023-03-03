using System.Text;
using Util.Ui.Configs;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Tabs {
    /// <summary>
    /// 标签测试 - 扩展测试
    /// </summary>
    public partial class TabTagHelperTest {
        /// <summary>
        /// 测试延迟加载
        /// </summary>
        [Fact]
        public void TestLazy() {
            _wrapper.SetContextAttribute( UiConst.Lazy, true );
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-tab>" );
            result.Append( "<ng-template nz-tab=\"\">a</ng-template>" );
            result.Append( "</nz-tab>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}