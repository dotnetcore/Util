using System.Text;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Checkboxes;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Checkboxes {
    /// <summary>
    /// 复选框包装器测试
    /// </summary>
    public class CheckboxWrapperTagHelperTest {
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
        public CheckboxWrapperTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new CheckboxWrapperTagHelper().ToWrapper();
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
            result.Append( "<nz-checkbox-wrapper></nz-checkbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            _wrapper.SetContextAttribute( UiConst.Id, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-checkbox-wrapper #a=\"\"></nz-checkbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试变更事件
        /// </summary>
        [Fact]
        public void TestOnChange() {
            _wrapper.SetContextAttribute( UiConst.OnChange, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-checkbox-wrapper (nzOnChange)=\"a\"></nz-checkbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-checkbox-wrapper>a</nz-checkbox-wrapper>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试表单容器属性
        /// </summary>
        [Fact]
        public void TestFormContainer() {
            var input = new CheckboxTagHelper().ToWrapper();
            input.SetContextAttribute( UiConst.LabelText, "b" );
            _wrapper.AppendContent( input );

            var result = new StringBuilder();
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>b</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<nz-checkbox-wrapper>" );
            result.Append( "<label nz-checkbox=\"\"></label>" );
            result.Append( "</nz-checkbox-wrapper>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}
