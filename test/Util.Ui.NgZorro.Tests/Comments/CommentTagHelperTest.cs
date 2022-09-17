using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Comments;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Comments {
    /// <summary>
    /// 评论测试
    /// </summary>
    public class CommentTagHelperTest {
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
        public CommentTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new CommentTagHelper().ToWrapper();
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
            result.Append( "<nz-comment></nz-comment>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试作者
        /// </summary>
        [Fact]
        public void TestAuthor() {
            _wrapper.SetContextAttribute( UiConst.Author, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-comment nzAuthor=\"a\"></nz-comment>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试作者
        /// </summary>
        [Fact]
        public void TestBindAuthor() {
            _wrapper.SetContextAttribute( AngularConst.BindAuthor, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-comment [nzAuthor]=\"a\"></nz-comment>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试时间描述
        /// </summary>
        [Fact]
        public void TestDatetime() {
            _wrapper.SetContextAttribute( UiConst.Datetime, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-comment nzDatetime=\"a\"></nz-comment>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试时间描述
        /// </summary>
        [Fact]
        public void TestBindDatetime() {
            _wrapper.SetContextAttribute( AngularConst.BindDatetime, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-comment [nzDatetime]=\"a\"></nz-comment>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-comment>a</nz-comment>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}