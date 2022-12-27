using System.Text;
using Util.Ui.Configs;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Buttons {
    /// <summary>
    /// 按钮测试 - 间距相关
    /// </summary>
    public partial class ButtonTagHelperTest {
        /// <summary>
        /// 测试间距项
        /// </summary>
        [Fact]
        public void TestSpaceItem() {
            _wrapper.SetContextAttribute( UiConst.SpaceItem, true );
            var result = new StringBuilder();
            result.Append( "<button *nzSpaceItem=\"\" nz-button=\"\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试间距项 - 设置为false不设置*nzSpaceItem
        /// </summary>
        [Fact]
        public void TestSpaceItem_False() {
            _wrapper.SetContextAttribute( UiConst.SpaceItem, false );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}
