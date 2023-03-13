using System.Text;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Enums;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Menus {
    /// <summary>
    /// 菜单项测试 - 图标扩展
    /// </summary>
    public partial class MenuItemTagHelperTest {
        /// <summary>
        /// 测试图标
        /// </summary>
        [Fact]
        public void TestIcon_1() {
            _wrapper.SetContextAttribute( UiConst.Icon, AntDesignIcon.InfoCircle );
            var result = new StringBuilder();
            result.Append( "<li nz-menu-item=\"\">" );
            result.Append( "<i class=\"mr-sm\" nz-icon=\"\" nzType=\"info-circle\"></i>" );
            result.Append( "</li>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试图标 - 添加文本
        /// </summary>
        [Fact]
        public void TestIcon_2() {
            _wrapper.SetContextAttribute( UiConst.Text, "a" );
            _wrapper.SetContextAttribute( UiConst.Icon, AntDesignIcon.InfoCircle );
            var result = new StringBuilder();
            result.Append( "<li nz-menu-item=\"\">" );
            result.Append( "<i class=\"mr-sm\" nz-icon=\"\" nzType=\"info-circle\"></i>a" );
            result.Append( "</li>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}