using System.Text;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Forms.Configs;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Buttons {
    /// <summary>
    /// 按钮测试 - 表单相关
    /// </summary>
    public partial class ButtonTagHelperTest {
        /// <summary>
        /// 测试提交按钮类型
        /// </summary>
        [Fact]
        public void TestIsSubmit() {
            _wrapper.SetContextAttribute( UiConst.IsSubmit, true );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" type=\"submit\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试提交按钮类型 - 当按钮放进表单中
        /// </summary>
        [Fact]
        public void TestIsSubmit_2() {
            _wrapper.SetItem( new FormShareConfig() );
            _wrapper.SetContextAttribute( UiConst.IsSubmit, true );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" type=\"submit\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试按钮类型 - 当按钮放进表单中自动设置按钮类型
        /// </summary>
        [Fact]
        public void TestButtonType_1() {
            _wrapper.SetItem( new FormShareConfig() );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" type=\"button\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}
