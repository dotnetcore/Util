using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Selects;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Selects {
    /// <summary>
    /// 选项组测试
    /// </summary>
    public class OptionGroupTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// TagHelper包装器
        /// </summary>
        private readonly TagHelperWrapper _wrapper;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public OptionGroupTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new OptionGroupTagHelper().ToWrapper();
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private string GetResult() {
            var result = _wrapper.GetResult();
            _output.WriteLine( result );
            return result;
        }

        /// <summary>
        /// 测试默认输出
        /// </summary>
        [Fact]
        public void TestDefault() {
            var result = new StringBuilder();
            result.Append( "<nz-option-group></nz-option-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试组名
        /// </summary>
        [Fact]
        public void TestLabel() {
            _wrapper.SetContextAttribute( UiConst.Label, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-option-group nzLabel=\"a\"></nz-option-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试组名
        /// </summary>
        [Fact]
        public void TestBindLabel() {
            _wrapper.SetContextAttribute( AngularConst.BindLabel, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-option-group [nzLabel]=\"a\"></nz-option-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-option-group>a</nz-option-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}