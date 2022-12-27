using System.Text;
using Util.Ui.Configs;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Inputs {
    /// <summary>
    /// 输入框测试 - 自动完成相关
    /// </summary>
    public partial class InputTagHelperTest {
        /// <summary>
        /// 测试自动完成
        /// </summary>
        [Fact]
        public void TestAutocomplete() {
            _wrapper.SetContextAttribute( UiConst.Autocomplete, "a" );
            var result = new StringBuilder();
            result.Append( "<input nz-input=\"\" [nzAutocomplete]=\"a\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}

