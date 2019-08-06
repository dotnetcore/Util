using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.AntDesign.Tests.XUnitHelpers;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Zorro.Forms;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Angular.AntDesign.Tests.Zorro.Forms {
    /// <summary>
    /// 表单项测试
    /// </summary>
    public class FormItemTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 表单项
        /// </summary>
        private readonly FormItemTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public FormItemTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new FormItemTagHelper();
            Config.IsValidate = false;
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
            result.Append( "<nz-form-item></nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<nz-form-item #a=\"\">" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试间隔
        /// </summary>
        [Fact]
        public void TestGutter() {
            var attributes = new TagHelperAttributeList { { UiConst.Gutter, 2 } };
            var result = new String();
            result.Append( "<nz-form-item [nzGutter]=\"2\">" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试是否flex模式
        /// </summary>
        [Fact]
        public void TestIsFlex() {
            var attributes = new TagHelperAttributeList { { UiConst.IsFlex, true } };
            var result = new String();
            result.Append( "<nz-form-item [nzFlex]=\"true\">" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试垂直对齐方式
        /// </summary>
        [Fact]
        public void TestAlign() {
            var attributes = new TagHelperAttributeList { { UiConst.Align, Align.Middle } };
            var result = new String();
            result.Append( "<nz-form-item nzAlign=\"middle\" nzType=\"flex\">" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试水平排列方式
        /// </summary>
        [Fact]
        public void TestJustify() {
            var attributes = new TagHelperAttributeList { { UiConst.Justify, Justify.Center } };
            var result = new String();
            result.Append( "<nz-form-item nzJustify=\"center\" nzType=\"flex\">" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}