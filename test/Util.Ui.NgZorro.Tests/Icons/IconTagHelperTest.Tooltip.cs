using System.Text;
using Util.Ui.Configs;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Icons {
    /// <summary>
    /// 图标测试 - 工具提示相关测试
    /// </summary>
    public partial class IconTagHelperTest {
        /// <summary>
        /// 测试提示文字
        /// </summary>
        [Fact]
        public void TestTooltipTitle() {
            _wrapper.SetContextAttribute( UiConst.TooltipTitle, "a" );
            var result = new StringBuilder();
            result.Append( "<i nz-icon=\"\" nz-tooltip=\"\" nzTooltipTitle=\"a\"></i>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}
