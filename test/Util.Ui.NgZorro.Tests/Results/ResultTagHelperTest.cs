using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Results;
using Util.Ui.NgZorro.Enums;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Results {
    /// <summary>
    /// 结果测试
    /// </summary>
    public class ResultTagHelperTest {
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
        public ResultTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new ResultTagHelper().ToWrapper();
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
            result.Append( "<nz-result></nz-result>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标题
        /// </summary>
        [Fact]
        public void TestTitle() {
            _wrapper.SetContextAttribute( UiConst.Title, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-result nzTitle=\"a\"></nz-result>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标题
        /// </summary>
        [Fact]
        public void TestBindTitle() {
            _wrapper.SetContextAttribute( AngularConst.BindTitle, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-result [nzTitle]=\"a\"></nz-result>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试副标题
        /// </summary>
        [Fact]
        public void TestSubTitle() {
            _wrapper.SetContextAttribute( UiConst.Subtitle, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-result nzSubTitle=\"a\"></nz-result>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试副标题
        /// </summary>
        [Fact]
        public void TestBindSubTitle() {
            _wrapper.SetContextAttribute( AngularConst.BindSubtitle, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-result [nzSubTitle]=\"a\"></nz-result>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试状态
        /// </summary>
        [Fact]
        public void TestStatus() {
            _wrapper.SetContextAttribute( UiConst.Status, ResultStatus.StatusCode404 );
            var result = new StringBuilder();
            result.Append( "<nz-result nzStatus=\"404\"></nz-result>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试状态
        /// </summary>
        [Fact]
        public void TestBindStatus() {
            _wrapper.SetContextAttribute( AngularConst.BindStatus, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-result [nzStatus]=\"a\"></nz-result>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试图标
        /// </summary>
        [Fact]
        public void TestIcon() {
            _wrapper.SetContextAttribute( UiConst.Icon, AntDesignIcon.AccountBook );
            var result = new StringBuilder();
            result.Append( "<nz-result nzIcon=\"account-book\"></nz-result>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试图标
        /// </summary>
        [Fact]
        public void TestBindIcon() {
            _wrapper.SetContextAttribute( AngularConst.BindIcon, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-result [nzIcon]=\"a\"></nz-result>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试操作区
        /// </summary>
        [Fact]
        public void TestExtra() {
            _wrapper.SetContextAttribute( UiConst.Extra, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-result [nzExtra]=\"a\"></nz-result>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-result>a</nz-result>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}