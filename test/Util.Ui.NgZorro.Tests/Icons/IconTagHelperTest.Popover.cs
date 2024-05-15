using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Enums;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Icons {
    /// <summary>
    /// 图标测试 - 气泡卡片相关测试
    /// </summary>
    public partial class IconTagHelperTest {
        /// <summary>
        /// 测试气泡卡片标题
        /// </summary>
        [Fact]
        public void TestPopoverTitle() {
            _wrapper.SetContextAttribute( UiConst.PopoverTitle, "a" );
            var result = new StringBuilder();
            result.Append( "<span nz-icon=\"\" nz-popover=\"\" nzPopoverTitle=\"a\"></span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试气泡卡片标题
        /// </summary>
        [Fact]
        public void TestBindPopoverTitle() {
            _wrapper.SetContextAttribute( AngularConst.BindPopoverTitle, "a" );
            var result = new StringBuilder();
            result.Append( "<span nz-icon=\"\" nz-popover=\"\" [nzPopoverTitle]=\"a\"></span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}
