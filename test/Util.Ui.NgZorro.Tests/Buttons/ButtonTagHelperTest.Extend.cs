using System.Text;
using Util.Ui.Configs;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Buttons {
    /// <summary>
    /// 按钮测试 - 指令扩展
    /// </summary>
    public partial class ButtonTagHelperTest {
        /// <summary>
        /// 测试是否验证表单
        /// </summary>
        [Fact]
        public void TestValidateForm() {
            _wrapper.SetContextAttribute( UiConst.ValidateForm, true );
            var result = new StringBuilder();
            result.Append( "<button nz-button=\"\" x-button-extend=\"\"></button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}
