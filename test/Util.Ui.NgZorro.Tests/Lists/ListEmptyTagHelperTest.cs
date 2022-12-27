using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Lists;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Lists {
    /// <summary>
    /// 列表空内容测试
    /// </summary>
    public class ListEmptyTagHelperTest {
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
        public ListEmptyTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new ListEmptyTagHelper().ToWrapper();
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
            result.Append( "<nz-list-empty></nz-list-empty>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试空内容显示文本
        /// </summary>
        [Fact]
        public void TestNoResult() {
            _wrapper.SetContextAttribute( UiConst.NoResult, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-list-empty nzNoResult=\"a\"></nz-list-empty>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试空内容显示文本
        /// </summary>
        [Fact]
        public void TestBindNoResult() {
            _wrapper.SetContextAttribute( AngularConst.BindNoResult, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-list-empty [nzNoResult]=\"a\"></nz-list-empty>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-list-empty>a</nz-list-empty>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}