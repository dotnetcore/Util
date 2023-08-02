using System.Text;
using Util.Ui.Configs;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Inputs {
    /// <summary>
    /// 输入框测试 - 事件测试
    /// </summary>
    public partial class InputTagHelperTest {
        /// <summary>
        /// 测试模型变更事件
        /// </summary>
        [Fact]
        public void TestOnModelChange() {
            _wrapper.SetContextAttribute( UiConst.OnModelChange, "a" );
            var result = new StringBuilder();
            result.Append( "<input (ngModelChange)=\"a\" nz-input=\"\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试输入事件
        /// </summary>
        [Fact]
        public void TestOnInput() {
            _wrapper.SetContextAttribute( UiConst.OnInput, "a" );
            var result = new StringBuilder();
            result.Append( "<input (input)=\"a\" nz-input=\"\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试回车事件
        /// </summary>
        [Fact]
        public void TestOnEnter() {
            _wrapper.SetContextAttribute( UiConst.OnEnter, "a" );
            var result = new StringBuilder();
            result.Append( "<input (keyup.enter)=\"a\" nz-input=\"\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}

