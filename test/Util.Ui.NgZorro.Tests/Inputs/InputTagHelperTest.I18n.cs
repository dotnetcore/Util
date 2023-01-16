using System.Text;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Configs;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Inputs {
    /// <summary>
    /// 输入框测试 - 国际化
    /// </summary>
    public partial class InputTagHelperTest {
        /// <summary>
        /// 测试标签文本 - 启用I18n
        /// </summary>
        [Fact]
        public void TestLabelText_I18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetContextAttribute( UiConst.LabelText, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>{{'a'|i18n}}</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<input nz-input=\"\" />" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}

