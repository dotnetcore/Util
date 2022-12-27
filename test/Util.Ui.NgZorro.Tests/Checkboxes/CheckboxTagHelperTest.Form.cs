using System.Text;
using Util.Ui.Configs;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Checkboxes {
    /// <summary>
    /// 复选框测试 - 表单结构相关
    /// </summary>
    public partial class CheckboxTagHelperTest {
        /// <summary>
        /// 测试标签文本
        /// </summary>
        [Fact]
        public void TestLabelText() {
            _wrapper.SetContextAttribute( UiConst.LabelText, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>a</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<label nz-checkbox=\"\"></label>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}
