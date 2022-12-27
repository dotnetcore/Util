using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Selects;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Selects {
    /// <summary>
    /// 选项测试
    /// </summary>
    public class OptionTagHelperTest {
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
        public OptionTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new OptionTagHelper().ToWrapper();
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
            result.Append( "<nz-option></nz-option>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签
        /// </summary>
        [Fact]
        public void TestLabel() {
            _wrapper.SetContextAttribute( UiConst.Label, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-option nzLabel=\"a\"></nz-option>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标签
        /// </summary>
        [Fact]
        public void TestBindLabel() {
            _wrapper.SetContextAttribute( AngularConst.BindLabel, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-option [nzLabel]=\"a\"></nz-option>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            _wrapper.SetContextAttribute( UiConst.Disabled, true );
            var result = new StringBuilder();
            result.Append( "<nz-option [nzDisabled]=\"true\"></nz-option>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestBindDisabled() {
            _wrapper.SetContextAttribute( AngularConst.BindDisabled, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-option [nzDisabled]=\"a\"></nz-option>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试值
        /// </summary>
        [Fact]
        public void TestValue() {
            _wrapper.SetContextAttribute( UiConst.Value, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-option nzValue=\"a\"></nz-option>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试值
        /// </summary>
        [Fact]
        public void TestBindValue() {
            _wrapper.SetContextAttribute( AngularConst.BindValue, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-option [nzValue]=\"a\"></nz-option>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试隐藏
        /// </summary>
        [Fact]
        public void TestHide() {
            _wrapper.SetContextAttribute( UiConst.Hide, true );
            var result = new StringBuilder();
            result.Append( "<nz-option [nzHide]=\"true\"></nz-option>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试隐藏
        /// </summary>
        [Fact]
        public void TestBindHide() {
            _wrapper.SetContextAttribute( AngularConst.BindHide, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-option [nzHide]=\"a\"></nz-option>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否自定义内容
        /// </summary>
        [Fact]
        public void TestCustomContent() {
            _wrapper.SetContextAttribute( UiConst.CustomContent, true );
            var result = new StringBuilder();
            result.Append( "<nz-option [nzCustomContent]=\"true\"></nz-option>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否自定义内容
        /// </summary>
        [Fact]
        public void TestBindCustomContent() {
            _wrapper.SetContextAttribute( AngularConst.BindCustomContent, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-option [nzCustomContent]=\"a\"></nz-option>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-option>a</nz-option>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}