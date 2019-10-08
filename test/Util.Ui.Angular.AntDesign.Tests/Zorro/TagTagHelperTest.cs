using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Helpers;
using Util.Ui.Angular.AntDesign.Tests.XUnitHelpers;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Zorro.Tags;
using Xunit;
using Xunit.Abstractions;
using TagMode = Util.Ui.Enums.TagMode;

namespace Util.Ui.Angular.AntDesign.Tests.Zorro {
    /// <summary>
    /// 标签测试
    /// </summary>
    public class TagTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 标签
        /// </summary>
        private readonly TagTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public TagTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new TagTagHelper();
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
            result.Append( "<nz-tag></nz-tag>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试颜色
        /// </summary>
        [Fact]
        public void TestType() {
            var attributes = new TagHelperAttributeList { { UiConst.ColorType, AntDesignColor.GeekBlue } };
            var result = new String();
            result.Append( "<nz-tag nzColor=\"geekblue\"></nz-tag>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试颜色
        /// </summary>
        [Fact]
        public void TestColor() {
            var attributes = new TagHelperAttributeList { { UiConst.Color, "a" } };
            var result = new String();
            result.Append( "<nz-tag nzColor=\"a\"></nz-tag>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试颜色
        /// </summary>
        [Fact]
        public void TestBindColor() {
            var attributes = new TagHelperAttributeList { { AngularConst.BindColor, "a" } };
            var result = new String();
            result.Append( "<nz-tag [nzColor]=\"a\"></nz-tag>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试标签模式
        /// </summary>
        [Fact]
        public void TestMode() {
            var attributes = new TagHelperAttributeList { { UiConst.Mode, TagMode.Checkable } };
            var result = new String();
            result.Append( "<nz-tag nzMode=\"checkable\"></nz-tag>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试选中状态
        /// </summary>
        [Fact]
        public void TestChecked() {
            var attributes = new TagHelperAttributeList { { UiConst.Checked, true } };
            var result = new String();
            result.Append( "<nz-tag [nzChecked]=\"true\"></nz-tag>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试选中状态
        /// </summary>
        [Fact]
        public void TestBindOnChecked() {
            var attributes = new TagHelperAttributeList { { AngularConst.BindOnChecked, "a" } };
            var result = new String();
            result.Append( "<nz-tag [(nzChecked)]=\"a\"></nz-tag>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试关闭后事件
        /// </summary>
        [Fact]
        public void TestOnAfterClose() {
            var attributes = new TagHelperAttributeList { { UiConst.OnAfterClose, "a" } };
            var result = new String();
            result.Append( "<nz-tag (nzAfterClose)=\"a\"></nz-tag>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试关闭事件
        /// </summary>
        [Fact]
        public void TestOnClose() {
            var attributes = new TagHelperAttributeList { { UiConst.OnClose, "a" } };
            var result = new String();
            result.Append( "<nz-tag (nzOnClose)=\"a\"></nz-tag>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试关闭事件
        /// </summary>
        [Fact]
        public void TestOnCheckedChange() {
            var attributes = new TagHelperAttributeList { { UiConst.OnCheckedChange, "a" } };
            var result = new String();
            result.Append( "<nz-tag (nzCheckedChange)=\"a\"></nz-tag>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}
