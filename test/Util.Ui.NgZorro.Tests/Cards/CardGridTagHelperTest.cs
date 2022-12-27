using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Cards;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Cards {
    /// <summary>
    /// 网格内嵌卡片测试
    /// </summary>
    public class CardGridTagHelperTest {
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
        public CardGridTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new CardGridTagHelper().ToWrapper();
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
            result.Append( "<div nz-card-grid=\"\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试鼠标滑过时是否可浮起
        /// </summary>
        [Fact]
        public void TestHoverable() {
            _wrapper.SetContextAttribute( UiConst.Hoverable, true );
            var result = new StringBuilder();
            result.Append( "<div nz-card-grid=\"\" [nzHoverable]=\"true\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试鼠标滑过时是否可浮起
        /// </summary>
        [Fact]
        public void TestBindHoverable() {
            _wrapper.SetContextAttribute( AngularConst.BindHoverable, "a" );
            var result = new StringBuilder();
            result.Append( "<div nz-card-grid=\"\" [nzHoverable]=\"a\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<div nz-card-grid=\"\">a</div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}