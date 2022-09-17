using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Anchors;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Anchors {
    /// <summary>
    /// 锚点测试
    /// </summary>
    public class AnchorTagHelperTest {
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
        public AnchorTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new AnchorTagHelper().ToWrapper();
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
            result.Append( "<nz-anchor></nz-anchor>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否固定模式
        /// </summary>
        [Fact]
        public void TestAffix() {
            _wrapper.SetContextAttribute( UiConst.Affix, true );
            var result = new StringBuilder();
            result.Append( "<nz-anchor [nzAffix]=\"true\"></nz-anchor>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否固定模式
        /// </summary>
        [Fact]
        public void TestBindAffix() {
            _wrapper.SetContextAttribute( AngularConst.BindAffix, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-anchor [nzAffix]=\"a\"></nz-anchor>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试区域边界
        /// </summary>
        [Fact]
        public void TestBounds() {
            _wrapper.SetContextAttribute( UiConst.Bounds, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-anchor nzBounds=\"1\"></nz-anchor>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试区域边界
        /// </summary>
        [Fact]
        public void TestBindBounds() {
            _wrapper.SetContextAttribute( AngularConst.BindBounds, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-anchor [nzBounds]=\"a\"></nz-anchor>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试顶部偏移量
        /// </summary>
        [Fact]
        public void TestOffsetTop() {
            _wrapper.SetContextAttribute( UiConst.OffsetTop, 1 );
            var result = new StringBuilder();
            result.Append( "<nz-anchor nzOffsetTop=\"1\"></nz-anchor>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试顶部偏移量
        /// </summary>
        [Fact]
        public void TestBindOffsetTop() {
            _wrapper.SetContextAttribute( AngularConst.BindOffsetTop, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-anchor [nzOffsetTop]=\"a\"></nz-anchor>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试固定模式是否显示小圆点
        /// </summary>
        [Fact]
        public void TestShowInkInFixed() {
            _wrapper.SetContextAttribute( UiConst.ShowInkInFixed, true );
            var result = new StringBuilder();
            result.Append( "<nz-anchor [nzShowInkInFixed]=\"true\"></nz-anchor>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试固定模式是否显示小圆点
        /// </summary>
        [Fact]
        public void TestBindShowInkInFixed() {
            _wrapper.SetContextAttribute( AngularConst.BindShowInkInFixed, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-anchor [nzShowInkInFixed]=\"a\"></nz-anchor>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试容器
        /// </summary>
        [Fact]
        public void TestContainer() {
            _wrapper.SetContextAttribute( UiConst.Container, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-anchor nzContainer=\"a\"></nz-anchor>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试容器
        /// </summary>
        [Fact]
        public void TestBindContainer() {
            _wrapper.SetContextAttribute( AngularConst.BindContainer, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-anchor [nzContainer]=\"a\"></nz-anchor>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-anchor>a</nz-anchor>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试单击事件
        /// </summary>
        [Fact]
        public void TestOnClick() {
            _wrapper.SetContextAttribute( UiConst.OnClick, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-anchor (nzClick)=\"a\"></nz-anchor>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试滚动事件
        /// </summary>
        [Fact]
        public void TestOnScroll() {
            _wrapper.SetContextAttribute( UiConst.OnScroll, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-anchor (nzScroll)=\"a\"></nz-anchor>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}