using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Collapses;
using Util.Ui.NgZorro.Enums;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Collapses {
    /// <summary>
    /// 折叠测试
    /// </summary>
    public class CollapseTagHelperTest {
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
        public CollapseTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new CollapseTagHelper().ToWrapper();
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
            result.Append( "<nz-collapse></nz-collapse>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否手风琴
        /// </summary>
        [Fact]
        public void TestAccordion() {
            _wrapper.SetContextAttribute( UiConst.Accordion, true );
            var result = new StringBuilder();
            result.Append( "<nz-collapse [nzAccordion]=\"true\"></nz-collapse>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否手风琴
        /// </summary>
        [Fact]
        public void TestBindAccordion() {
            _wrapper.SetContextAttribute( AngularConst.BindAccordion, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-collapse [nzAccordion]=\"a\"></nz-collapse>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否有边框
        /// </summary>
        [Fact]
        public void TestBordered() {
            _wrapper.SetContextAttribute( UiConst.Bordered, true );
            var result = new StringBuilder();
            result.Append( "<nz-collapse [nzBordered]=\"true\"></nz-collapse>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否有边框
        /// </summary>
        [Fact]
        public void TestBindBordered() {
            _wrapper.SetContextAttribute( AngularConst.BindBordered, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-collapse [nzBordered]=\"a\"></nz-collapse>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否幽灵面板
        /// </summary>
        [Fact]
        public void TestGhost() {
            _wrapper.SetContextAttribute( UiConst.Ghost, true );
            var result = new StringBuilder();
            result.Append( "<nz-collapse [nzGhost]=\"true\"></nz-collapse>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否幽灵面板
        /// </summary>
        [Fact]
        public void TestBindGhost() {
            _wrapper.SetContextAttribute( AngularConst.BindGhost, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-collapse [nzGhost]=\"a\"></nz-collapse>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试图标位置
        /// </summary>
        [Fact]
        public void TestExpandIconPosition() {
            _wrapper.SetContextAttribute( UiConst.ExpandIconPosition, CollapseIconPosition.Left );
            var result = new StringBuilder();
            result.Append( "<nz-collapse nzExpandIconPosition=\"left\"></nz-collapse>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试图标位置
        /// </summary>
        [Fact]
        public void TestBindExpandIconPosition() {
            _wrapper.SetContextAttribute( AngularConst.BindExpandIconPosition, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-collapse [nzExpandIconPosition]=\"a\"></nz-collapse>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-collapse>a</nz-collapse>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}