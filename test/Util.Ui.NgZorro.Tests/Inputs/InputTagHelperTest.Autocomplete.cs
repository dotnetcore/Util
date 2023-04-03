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

        /// <summary>
        /// 测试自动完成搜索关键字
        /// </summary>
        [Fact]
        public void TestAutocompleteSearchKeyword() {
            _wrapper.SetContextAttribute( UiConst.Autocomplete, "a" );
            _wrapper.SetContextAttribute( UiConst.AutocompleteSearchKeyword, true );
            var result = new StringBuilder();
            result.Append( "<input (input)=\"x_a.search($event.target.value)\" nz-input=\"\" [nzAutocomplete]=\"a\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}

