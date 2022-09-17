using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Empties;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Empties {
    /// <summary>
    /// 空状态测试
    /// </summary>
    public class EmptyTagHelperTest {
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
        public EmptyTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new EmptyTagHelper().ToWrapper();
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
            result.Append( "<nz-empty></nz-empty>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试图片
        /// </summary>
        [Fact]
        public void TestNotFoundImage() {
            _wrapper.SetContextAttribute( UiConst.NotFoundImage, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-empty nzNotFoundImage=\"a\"></nz-empty>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试图片
        /// </summary>
        [Fact]
        public void TestBindNotFoundImage() {
            _wrapper.SetContextAttribute( AngularConst.BindNotFoundImage, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-empty [nzNotFoundImage]=\"a\"></nz-empty>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestNotFoundContent() {
            _wrapper.SetContextAttribute( UiConst.NotFoundContent, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-empty nzNotFoundContent=\"a\"></nz-empty>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestBindNotFoundContent() {
            _wrapper.SetContextAttribute( AngularConst.BindNotFoundContent, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-empty [nzNotFoundContent]=\"a\"></nz-empty>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试底部内容
        /// </summary>
        [Fact]
        public void TestNotFoundFooter() {
            _wrapper.SetContextAttribute( UiConst.NotFoundFooter, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-empty nzNotFoundFooter=\"a\"></nz-empty>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试底部内容
        /// </summary>
        [Fact]
        public void TestBindNotFoundFooter() {
            _wrapper.SetContextAttribute( AngularConst.BindNotFoundFooter, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-empty [nzNotFoundFooter]=\"a\"></nz-empty>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-empty>a</nz-empty>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}