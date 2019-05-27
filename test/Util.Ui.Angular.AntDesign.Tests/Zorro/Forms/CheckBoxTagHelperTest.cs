using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.AntDesign.Tests.XUnitHelpers;
using Util.Ui.Configs;
using Util.Ui.Zorro.Forms;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Angular.AntDesign.Tests.Zorro.Forms {
    /// <summary>
    /// 复选框测试
    /// </summary>
    public class CheckBoxTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 复选框
        /// </summary>
        private readonly CheckBoxTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public CheckBoxTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new CheckBoxTagHelper();
            Config.IsValidate = false;
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private string GetResult( TagHelperAttributeList contextAttributes = null,TagHelperAttributeList outputAttributes = null, TagHelperContent content = null ) {
            return Helper.GetResult( _output, _component, contextAttributes, outputAttributes, content );
        }

        /// <summary>
        /// 测试默认输出
        /// </summary>
        [Fact]
        public void TestDefault() {
            var result = new String();
            result.Append( "<label nz-checkbox=\"\"></label>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<label #a=\"\" nz-checkbox=\"\"></label>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置名称
        /// </summary>
        [Fact]
        public void TestName() {
            var attributes = new TagHelperAttributeList { { UiConst.Name, "a" } };
            var result = new String();
            result.Append( "<label name=\"a\" nz-checkbox=\"\"></label>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置名称
        /// </summary>
        [Fact]
        public void TestBindName() {
            var attributes = new TagHelperAttributeList { { AngularConst.BindName, "a" } };
            var result = new String();
            result.Append( "<label nz-checkbox=\"\" [name]=\"a\"></label>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置标签
        /// </summary>
        [Fact]
        public void TestLabel() {
            var attributes = new TagHelperAttributeList { { UiConst.Label, "a" } };
            var result = new String();
            result.Append( "<label nz-checkbox=\"\">a</label>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置标签绑定
        /// </summary>
        [Fact]
        public void TestBindLabel() {
            var attributes = new TagHelperAttributeList { { AngularConst.BindLabel, "a" } };
            var result = new String();
            result.Append( "<label nz-checkbox=\"\">{{a}}</label>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试模型绑定
        /// </summary>
        [Fact]
        public void TestNgModel() {
            var attributes = new TagHelperAttributeList { { AngularConst.NgModel, "a" } };
            var result = new String();
            result.Append( "<label nz-checkbox=\"\" [(ngModel)]=\"a\"></label>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            var attributes = new TagHelperAttributeList { { UiConst.Disabled, true } };
            var result = new String();
            result.Append( "<label nz-checkbox=\"\" nzDisabled=\"true\"></label>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestBindDisabled() {
            var attributes = new TagHelperAttributeList { { AngularConst.BindDisabled, "a" } };
            var result = new String();
            result.Append( "<label nz-checkbox=\"\" [nzDisabled]=\"a\"></label>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置中间状态
        /// </summary>
        [Fact]
        public void TestIndeterminate() {
            var attributes = new TagHelperAttributeList { { UiConst.Indeterminate, "a" } };
            var result = new String();
            result.Append( "<label nz-checkbox=\"\" [nzIndeterminate]=\"a\"></label>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试变更事件
        /// </summary>
        [Fact]
        public void TestOnChange() {
            var attributes = new TagHelperAttributeList { { UiConst.OnChange, "a" } };
            var result = new String();
            result.Append( "<label (nzOnChange)=\"a\" nz-checkbox=\"\"></label>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}
