using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Helpers;
using Util.Ui.Angular.AntDesign.Tests.XUnitHelpers;
using Util.Ui.Configs;
using Util.Ui.Zorro.Enums;
using Util.Ui.Zorro.Icons;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.Angular.AntDesign.Tests.Zorro {
    /// <summary>
    /// 图标测试
    /// </summary>
    public class IconTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 图标
        /// </summary>
        private readonly IconTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public IconTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new IconTagHelper();
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private string GetResult( TagHelperAttributeList contextAttributes = null, TagHelperAttributeList outputAttributes = null, TagHelperContent content = null ) {
            return Helper.GetResult( _output, _component, contextAttributes, outputAttributes, content );
        }

        /// <summary>
        /// 测试默认输出
        /// </summary>
        [Fact]
        public void TestDefault() {
            var result = new String();
            result.Append( "<i nz-icon=\"\"></i>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试图标类型
        /// </summary>
        [Fact]
        public void TestType() {
            var attributes = new TagHelperAttributeList { { UiConst.Type, AntDesignIcon.InfoCircle } };
            var result = new String();
            result.Append( "<i nz-icon=\"\" nzType=\"info-circle\"></i>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试图标类型
        /// </summary>
        [Fact]
        public void TestBindType() {
            var attributes = new TagHelperAttributeList { { AngularConst.BindType, "a" } };
            var result = new String();
            result.Append( "<i nz-icon=\"\" [nzType]=\"a\"></i>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试图标主题风格
        /// </summary>
        [Fact]
        public void TestTheme() {
            var attributes = new TagHelperAttributeList { { UiConst.Theme, AntDesignTheme.Outline } };
            var result = new String();
            result.Append( "<i nz-icon=\"\" nzTheme=\"outline\"></i>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试图标主题风格
        /// </summary>
        [Fact]
        public void TestBindThme() {
            var attributes = new TagHelperAttributeList { { AngularConst.BindTheme, "a" } };
            var result = new String();
            result.Append( "<i nz-icon=\"\" [nzTheme]=\"a\"></i>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试图标持续旋转
        /// </summary>
        [Fact]
        public void TestSpin() {
            var attributes = new TagHelperAttributeList { { UiConst.Spin, true } };
            var result = new String();
            result.Append( "<i nz-icon=\"\" [nzSpin]=\"true\"></i>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试图标旋转角度
        /// </summary>
        [Fact]
        public void TestRotate() {
            var attributes = new TagHelperAttributeList { { UiConst.Rotate, "180" } };
            var result = new String();
            result.Append( "<i nz-icon=\"\" [nzRotate]=\"180\"></i>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}
