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
    /// 数字文本框测试
    /// </summary>
    public class NumberTextBoxTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 文本框
        /// </summary>
        private readonly TextBoxTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public NumberTextBoxTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new TextBoxTagHelper();
            Config.IsValidate = false;
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private string GetResult( TagHelperAttributeList contextAttributes = null, TagHelperAttributeList outputAttributes = null, TagHelperContent content = null ) {
            contextAttributes = contextAttributes ?? new TagHelperAttributeList();
            contextAttributes.Add( UiConst.Type,TextBoxType.Number );
            return Helper.GetResult( _output, _component, contextAttributes, outputAttributes, content );
        }

        /// <summary>
        /// 测试默认输出
        /// </summary>
        [Fact]
        public void TestDefault() {
            var result = new String();
            result.Append( "<x-number-textbox></x-number-textbox>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<x-number-textbox #a=\"\"></x-number-textbox>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置名称
        /// </summary>
        [Fact]
        public void TestName() {
            var attributes = new TagHelperAttributeList { { UiConst.Name, "a" } };
            var result = new String();
            result.Append( "<x-number-textbox name=\"a\"></x-number-textbox>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试添加绑定名称
        /// </summary>
        [Fact]
        public void TestBindName() {
            var attributes = new TagHelperAttributeList { { AngularConst.BindName, "a" } };
            var result = new String();
            result.Append( "<x-number-textbox [name]=\"a\"></x-number-textbox>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            var attributes = new TagHelperAttributeList { { UiConst.Disabled, true } };
            var result = new String();
            result.Append( "<x-number-textbox [disabled]=\"true\"></x-number-textbox>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试只读
        /// </summary>
        [Fact]
        public void TestReadOnly() {
            var attributes = new TagHelperAttributeList { { UiConst.ReadOnly, true } };
            var result = new String();
            result.Append( "<x-number-textbox></x-number-textbox>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置占位提示
        /// </summary>
        [Fact]
        public void TestPlaceholder() {
            var attributes = new TagHelperAttributeList { { UiConst.Placeholder, "a" } };
            var result = new String();
            result.Append( "<x-number-textbox placeholder=\"a\"></x-number-textbox>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置绑定占位提示
        /// </summary>
        [Fact]
        public void TestBindPlaceholder() {
            var attributes = new TagHelperAttributeList { { AngularConst.BindPlaceholder, "a" } };
            var result = new String();
            result.Append( "<x-number-textbox [placeholder]=\"a\"></x-number-textbox>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试模型绑定
        /// </summary>
        [Fact]
        public void TestNgModel() {
            var attributes = new TagHelperAttributeList { { AngularConst.NgModel, "a" } };
            var result = new String();
            result.Append( "<x-number-textbox [(model)]=\"a\"></x-number-textbox>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试必填项
        /// </summary>
        [Fact]
        public void TestRequired() {
            var attributes = new TagHelperAttributeList { { UiConst.Required, true } };
            var result = new String();
            result.Append( "<x-number-textbox [required]=\"true\"></x-number-textbox>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试必填项错误消息
        /// </summary>
        [Fact]
        public void TestRequiredMessage() {
            var attributes = new TagHelperAttributeList { { UiConst.RequiredMessage, "a" } };
            var result = new String();
            result.Append( "<x-number-textbox requiredMessage=\"a\"></x-number-textbox>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试最小值验证
        /// </summary>
        [Fact]
        public void TestMin() {
            var attributes = new TagHelperAttributeList { { UiConst.Min, 3 } };
            var result = new String();
            result.Append( "<x-number-textbox [min]=\"3\"></x-number-textbox>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试最大值验证
        /// </summary>
        [Fact]
        public void TestMax() {
            var attributes = new TagHelperAttributeList { { UiConst.Max, 3 } };
            var result = new String();
            result.Append( "<x-number-textbox [max]=\"3\"></x-number-textbox>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试自动获取焦点
        /// </summary>
        [Fact]
        public void TestAutoFocus() {
            var attributes = new TagHelperAttributeList { { UiConst.AutoFocus, true } };
            var result = new String();
            result.Append( "<x-number-textbox [autoFocus]=\"true\"></x-number-textbox>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试精度
        /// </summary>
        [Fact]
        public void TestPrecision() {
            var attributes = new TagHelperAttributeList { { UiConst.Precision, 1 } };
            var result = new String();
            result.Append( "<x-number-textbox [precision]=\"1\"></x-number-textbox>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试步进
        /// </summary>
        [Fact]
        public void TestStep() {
            var attributes = new TagHelperAttributeList { { UiConst.Step, 1 } };
            var result = new String();
            result.Append( "<x-number-textbox [step]=\"1\"></x-number-textbox>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试栅格跨度
        /// </summary>
        [Fact]
        public void TestSpan() {
            var attributes = new TagHelperAttributeList { { UiConst.Span, 2 } };
            var result = new String();
            result.Append( "<nz-form-control [nzSpan]=\"2\">" );
            result.Append( "<x-number-textbox></x-number-textbox>" );
            result.Append( "</nz-form-control>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试变更事件
        /// </summary>
        [Fact]
        public void TestOnChange() {
            var attributes = new TagHelperAttributeList { { UiConst.OnChange, "a" } };
            var result = new String();
            result.Append( "<x-number-textbox (onChange)=\"a\"></x-number-textbox>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试获得焦点事件
        /// </summary>
        [Fact]
        public void TestOnFocus() {
            var attributes = new TagHelperAttributeList { { UiConst.OnFocus, "a" } };
            var result = new String();
            result.Append( "<x-number-textbox (onFocus)=\"a\"></x-number-textbox>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试失去焦点事件
        /// </summary>
        [Fact]
        public void TestOnBlur() {
            var attributes = new TagHelperAttributeList { { UiConst.OnBlur, "a" } };
            var result = new String();
            result.Append( "<x-number-textbox (onBlur)=\"a\"></x-number-textbox>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试键盘按下事件
        /// </summary>
        [Fact]
        public void TestOnKeydown() {
            var attributes = new TagHelperAttributeList { { UiConst.OnKeydown, "a" } };
            var result = new String();
            result.Append( "<x-number-textbox (onKeydown)=\"a\"></x-number-textbox>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}
