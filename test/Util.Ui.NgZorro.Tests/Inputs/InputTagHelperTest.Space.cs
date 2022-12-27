using System.Text;
using Util.Ui.Configs;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Inputs {
    /// <summary>
    /// 输入框测试 - 间距相关
    /// </summary>
    public partial class InputTagHelperTest {
        /// <summary>
        /// 测试间距项
        /// </summary>
        [Fact]
        public void TestSpaceItem() {
            _wrapper.SetContextAttribute( UiConst.SpaceItem, true );
            var result = new StringBuilder();
            result.Append( "<input *nzSpaceItem=\"\" nz-input=\"\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}

