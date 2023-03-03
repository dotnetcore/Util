using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Images;
using Util.Ui.NgZorro.Enums;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Images {
    /// <summary>
    /// 图片测试
    /// </summary>
    public class ImageTagHelperTest {
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
        public ImageTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new ImageTagHelper().ToWrapper();
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
            result.Append( "<img nz-image=\"\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试图片地址
        /// </summary>
        [Fact]
        public void TestSrc() {
            _wrapper.SetContextAttribute( UiConst.Src, "a" );
            var result = new StringBuilder();
            result.Append( "<img nz-image=\"\" nzSrc=\"a\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试图片地址
        /// </summary>
        [Fact]
        public void TestBindSrc() {
            _wrapper.SetContextAttribute( AngularConst.BindSrc, "a" );
            var result = new StringBuilder();
            result.Append( "<img nz-image=\"\" [nzSrc]=\"a\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试加载失败容错地址
        /// </summary>
        [Fact]
        public void TestFallback() {
            _wrapper.SetContextAttribute( UiConst.Fallback, "a" );
            var result = new StringBuilder();
            result.Append( "<img nz-image=\"\" nzFallback=\"a\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试加载失败容错地址
        /// </summary>
        [Fact]
        public void TestBindFallback() {
            _wrapper.SetContextAttribute( AngularConst.BindFallback, "a" );
            var result = new StringBuilder();
            result.Append( "<img nz-image=\"\" [nzFallback]=\"a\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试加载占位地址
        /// </summary>
        [Fact]
        public void TestPlaceholder() {
            _wrapper.SetContextAttribute( UiConst.Placeholder, "a" );
            var result = new StringBuilder();
            result.Append( "<img nz-image=\"\" nzPlaceholder=\"a\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试加载占位地址
        /// </summary>
        [Fact]
        public void TestBindPlaceholder() {
            _wrapper.SetContextAttribute( AngularConst.BindPlaceholder, "a" );
            var result = new StringBuilder();
            result.Append( "<img nz-image=\"\" [nzPlaceholder]=\"a\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否禁止预览
        /// </summary>
        [Fact]
        public void TestDisablePreview() {
            _wrapper.SetContextAttribute( UiConst.DisablePreview, true );
            var result = new StringBuilder();
            result.Append( "<img nz-image=\"\" [nzDisablePreview]=\"true\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试是否禁止预览
        /// </summary>
        [Fact]
        public void TestBindDisablePreview() {
            _wrapper.SetContextAttribute( AngularConst.BindDisablePreview, "a" );
            var result = new StringBuilder();
            result.Append( "<img nz-image=\"\" [nzDisablePreview]=\"a\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试导航时是否关闭预览
        /// </summary>
        [Fact]
        public void TestCloseOnNavigation() {
            _wrapper.SetContextAttribute( UiConst.CloseOnNavigation, true );
            var result = new StringBuilder();
            result.Append( "<img nz-image=\"\" [nzCloseOnNavigation]=\"true\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试导航时是否关闭预览
        /// </summary>
        [Fact]
        public void TestBindCloseOnNavigation() {
            _wrapper.SetContextAttribute( AngularConst.BindCloseOnNavigation, "a" );
            var result = new StringBuilder();
            result.Append( "<img nz-image=\"\" [nzCloseOnNavigation]=\"a\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试文字方向
        /// </summary>
        [Fact]
        public void TestDirection() {
            _wrapper.SetContextAttribute( UiConst.Direction, Direction.Rtl );
            var result = new StringBuilder();
            result.Append( "<img nz-image=\"\" nzDirection=\"rtl\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试文字方向
        /// </summary>
        [Fact]
        public void TestBindDirection() {
            _wrapper.SetContextAttribute( AngularConst.BindDirection, "a" );
            var result = new StringBuilder();
            result.Append( "<img nz-image=\"\" [nzDirection]=\"a\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试宽度 - 像素
        /// </summary>
        [Fact]
        public void TestWidth_1() {
            _wrapper.SetContextAttribute( UiConst.Width, 1 );
            var result = new StringBuilder();
            result.Append( "<img nz-image=\"\" width=\"1px\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试宽度 - 像素
        /// </summary>
        [Fact]
        public void TestWidth_2() {
            _wrapper.SetContextAttribute( UiConst.Width, "10px" );
            var result = new StringBuilder();
            result.Append( "<img nz-image=\"\" width=\"10px\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试宽度 - 百分比
        /// </summary>
        [Fact]
        public void TestWidth_3() {
            _wrapper.SetContextAttribute( UiConst.Width, "10%" );
            var result = new StringBuilder();
            result.Append( "<img nz-image=\"\" width=\"10%\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试宽度
        /// </summary>
        [Fact]
        public void TestBindWidth() {
            _wrapper.SetContextAttribute( AngularConst.BindWidth, "a" );
            var result = new StringBuilder();
            result.Append( "<img nz-image=\"\" [width]=\"a\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试高度
        /// </summary>
        [Fact]
        public void TestHeight() {
            _wrapper.SetContextAttribute( UiConst.Height, 1 );
            var result = new StringBuilder();
            result.Append( "<img height=\"1px\" nz-image=\"\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试高度
        /// </summary>
        [Fact]
        public void TestBindHeight() {
            _wrapper.SetContextAttribute( AngularConst.BindHeight, 'a' );
            var result = new StringBuilder();
            result.Append( "<img nz-image=\"\" [height]=\"a\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试文本描述
        /// </summary>
        [Fact]
        public void TestAlt() {
            _wrapper.SetContextAttribute( UiConst.Alt, "a" );
            var result = new StringBuilder();
            result.Append( "<img alt=\"a\" nz-image=\"\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试文本描述
        /// </summary>
        [Fact]
        public void TestBindAlt() {
            _wrapper.SetContextAttribute( AngularConst.BindAlt, "a" );
            var result = new StringBuilder();
            result.Append( "<img nz-image=\"\" [alt]=\"a\" />" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}