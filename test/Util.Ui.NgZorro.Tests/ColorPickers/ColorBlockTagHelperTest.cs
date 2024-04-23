using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.ColorPickers;
using Util.Ui.NgZorro.Enums;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.ColorPickers {
    /// <summary>
    /// 颜色块测试
    /// </summary>
    public class ColorBlockTagHelperTest {
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
        public ColorBlockTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new ColorBlockTagHelper().ToWrapper();
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
            result.Append( "<nz-color-block></nz-color-block>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试颜色值
        /// </summary>
        [Fact]
        public void TestColor() {
            _wrapper.SetContextAttribute( UiConst.Color, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-color-block nzColor=\"a\"></nz-color-block>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试颜色值
        /// </summary>
        [Fact]
        public void TestBindColor() {
            _wrapper.SetContextAttribute( AngularConst.BindColor, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-color-block [nzColor]=\"a\"></nz-color-block>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试控件尺寸
        /// </summary>
        [Fact]
        public void TestSize() {
            _wrapper.SetContextAttribute( UiConst.Size, InputSize.Large );
            var result = new StringBuilder();
            result.Append( "<nz-color-block nzSize=\"large\"></nz-color-block>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试控件尺寸
        /// </summary>
        [Fact]
        public void TestBindSize() {
            _wrapper.SetContextAttribute( AngularConst.BindSize, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-color-block [nzSize]=\"a\"></nz-color-block>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<nz-color-block>a</nz-color-block>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试点击事件
        /// </summary>
        [Fact]
        public void TestOnChange() {
            _wrapper.SetContextAttribute( UiConst.OnClick, "a" );
            var result = new StringBuilder();
            result.Append( "<nz-color-block (nzOnClick)=\"a\"></nz-color-block>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}