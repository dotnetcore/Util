using System.Text;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Icons;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Enums;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Icons {
    /// <summary>
    /// 图标测试
    /// </summary>
    public partial class IconTagHelperTest {
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
        public IconTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new IconTagHelper().ToWrapper();
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
            result.Append( "<span nz-icon=\"\"></span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试标识
        /// </summary>
        [Fact]
        public void TestId() {
            _wrapper.SetContextAttribute( UiConst.Id, "a" );
            var result = new StringBuilder();
            result.Append( "<span #a=\"\" nz-icon=\"\"></span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试图标类型
        /// </summary>
        [Fact]
        public void TestType() {
            _wrapper.SetContextAttribute( UiConst.Type, AntDesignIcon.InfoCircle );
            var result = new StringBuilder();
            result.Append( "<span nz-icon=\"\" nzType=\"info-circle\"></span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试图标类型
        /// </summary>
        [Fact]
        public void TestBindType() {
            _wrapper.SetContextAttribute( AngularConst.BindType, "a" );
            var result = new StringBuilder();
            result.Append( "<span nz-icon=\"\" [nzType]=\"a\"></span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试图标主题
        /// </summary>
        [Fact]
        public void TestTheme() {
            _wrapper.SetContextAttribute( UiConst.Theme, IconTheme.Outline );
            var result = new StringBuilder();
            result.Append( "<span nz-icon=\"\" nzTheme=\"outline\"></span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试图标主题
        /// </summary>
        [Fact]
        public void TestBindThme() {
            _wrapper.SetContextAttribute( AngularConst.BindTheme, "a" );
            var result = new StringBuilder();
            result.Append( "<span nz-icon=\"\" [nzTheme]=\"a\"></span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试图标持续旋转
        /// </summary>
        [Fact]
        public void TestSpin() {
            _wrapper.SetContextAttribute( UiConst.Spin, "true" );
            var result = new StringBuilder();
            result.Append( "<span nz-icon=\"\" [nzSpin]=\"true\"></span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试图标旋转角度
        /// </summary>
        [Fact]
        public void TestRotate() {
            _wrapper.SetContextAttribute( UiConst.Rotate, "180" );
            var result = new StringBuilder();
            result.Append( "<span nz-icon=\"\" [nzRotate]=\"180\"></span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试双色图标主题色
        /// </summary>
        [Fact]
        public void TestTwotoneColorType() {
            _wrapper.SetContextAttribute( UiConst.TwotoneColorType, AntDesignColor.Red );
            var result = new StringBuilder();
            result.Append( "<span nz-icon=\"\" nzTheme=\"twotone\" nzTwotoneColor=\"red\"></span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试双色图标主题色
        /// </summary>
        [Fact]
        public void TestTwotoneColor() {
            _wrapper.SetContextAttribute( UiConst.TwotoneColor, "#eb2f96" );
            var result = new StringBuilder();
            result.Append( "<span nz-icon=\"\" nzTheme=\"twotone\" nzTwotoneColor=\"#eb2f96\"></span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试双色图标主题色
        /// </summary>
        [Fact]
        public void TestTwotoneColor_2() {
            _wrapper.SetContextAttribute( UiConst.Theme, IconTheme.Twotone ).SetContextAttribute( UiConst.TwotoneColor, "#eb2f96" );
            var result = new StringBuilder();
            result.Append( "<span nz-icon=\"\" nzTheme=\"twotone\" nzTwotoneColor=\"#eb2f96\"></span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试双色图标主题色
        /// </summary>
        [Fact]
        public void TestBindTwotoneColor() {
            _wrapper.SetContextAttribute( AngularConst.BindTwotoneColor, "a" );
            var result = new StringBuilder();
            result.Append( "<span nz-icon=\"\" nzTheme=\"twotone\" [nzTwotoneColor]=\"a\"></span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试Iconfont图标
        /// </summary>
        [Fact]
        public void TestIconfont() {
            _wrapper.SetContextAttribute( UiConst.IconFont, "a" );
            var result = new StringBuilder();
            result.Append( "<span nz-icon=\"\" nzIconfont=\"a\"></span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试Iconfont图标
        /// </summary>
        [Fact]
        public void TestBindIconfont() {
            _wrapper.SetContextAttribute( AngularConst.BindIconFont, "a" );
            var result = new StringBuilder();
            result.Append( "<span nz-icon=\"\" [nzIconfont]=\"a\"></span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<span nz-icon=\"\">a</span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试单击事件
        /// </summary>
        [Fact]
        public void TestOnClick() {
            _wrapper.SetContextAttribute( UiConst.OnClick, "a" );
            var result = new StringBuilder();
            result.Append( "<span (click)=\"a\" nz-icon=\"\"></span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}
