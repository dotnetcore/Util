using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Autocompletes;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Autocompletes {
    /// <summary>
    /// 自动完成项测试
    /// </summary>
    public class AutoOptionTagHelperTest {
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
        public AutoOptionTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new AutoOptionTagHelper().ToWrapper();
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
            result.Append( "<nz-auto-option></nz-auto-option>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试值
        /// </summary>
        [Fact]
        public void TestValue() {
            _wrapper.SetContextAttribute( UiConst.Value, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-auto-option nzValue=\"a\"></nz-auto-option>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试值
        /// </summary>
        [Fact]
        public void TestBindValue() {
            _wrapper.SetContextAttribute( AngularConst.BindValue, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-auto-option [nzValue]=\"a\"></nz-auto-option>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签 - 内容为空时,将标签写入内容
        /// </summary>
        [Fact]
        public void TestLabel() {
            _wrapper.SetContextAttribute( UiConst.Label, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-auto-option nzLabel=\"a\">a</nz-auto-option>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签 - 内容不为空时,保留内容
        /// </summary>
        [Fact]
        public void TestLabel_2() {
            _wrapper.SetContextAttribute( UiConst.Label, "a" );
            _wrapper.AppendContent( "b" );
            var result = new StringBuilder();
            result.Append( "<nz-auto-option nzLabel=\"a\">b</nz-auto-option>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签 - 内容为空时,将标签写入内容
        /// </summary>
        [Fact]
        public void TestBindLabel() {
            _wrapper.SetContextAttribute( AngularConst.BindLabel, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-auto-option [nzLabel]=\"a\">{{a}}</nz-auto-option>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签 - 内容不为空时,保留内容
        /// </summary>
        [Fact]
        public void TestBindLabel_2() {
            _wrapper.SetContextAttribute( AngularConst.BindLabel, "a" );
            _wrapper.AppendContent( "b" );
            var result = new StringBuilder();
            result.Append( "<nz-auto-option [nzLabel]=\"a\">b</nz-auto-option>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            _wrapper.SetContextAttribute( UiConst.Disabled, true );
            var result = new StringBuilder();
            result.Append( "<nz-auto-option [nzDisabled]=\"true\"></nz-auto-option>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestBindDisabled() {
            _wrapper.SetContextAttribute( AngularConst.BindDisabled, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-auto-option [nzDisabled]=\"a\"></nz-auto-option>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-auto-option>a</nz-auto-option>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}