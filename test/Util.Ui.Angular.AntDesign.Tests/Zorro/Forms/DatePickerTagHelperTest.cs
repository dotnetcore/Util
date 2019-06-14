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
    /// 日期选择框测试
    /// </summary>
    public class DatePickerTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 文本框
        /// </summary>
        private readonly DatePickerTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public DatePickerTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new DatePickerTagHelper();
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
            result.Append( "<x-date-picker></x-date-picker>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<x-date-picker #a=\"\"></x-date-picker>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置名称
        /// </summary>
        [Fact]
        public void TestName() {
            var attributes = new TagHelperAttributeList { { UiConst.Name, "a" } };
            var result = new String();
            result.Append( "<x-date-picker name=\"a\"></x-date-picker>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            var attributes = new TagHelperAttributeList { { UiConst.Disabled, true } };
            var result = new String();
            result.Append( "<x-date-picker [disabled]=\"true\"></x-date-picker>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试禁用日期
        /// </summary>
        [Fact]
        public void TestDisabledDate() {
            var attributes = new TagHelperAttributeList { { UiConst.DisabledDate, "a" } };
            var result = new String();
            result.Append( "<x-date-picker [disabledDateFunc]=\"a\"></x-date-picker>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试仅能选择今天之后的日期
        /// </summary>
        [Fact]
        public void TestDisabledBeforeToday() {
            var attributes = new TagHelperAttributeList { { UiConst.DisabledBeforeToday, true } };
            var result = new String();
            result.Append( "<x-date-picker [disabledBeforeToday]=\"true\"></x-date-picker>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试仅能选择今天以及之后的日期
        /// </summary>
        [Fact]
        public void TestDisabledBeforeTomorrow() {
            var attributes = new TagHelperAttributeList { { UiConst.DisabledBeforeTomorrow, true } };
            var result = new String();
            result.Append( "<x-date-picker [disabledBeforeTomorrow]=\"true\"></x-date-picker>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试是否打开弹出面板
        /// </summary>
        [Fact]
        public void TestIsOpen() {
            var attributes = new TagHelperAttributeList { { UiConst.IsOpen, "a" } };
            var result = new String();
            result.Append( "<x-date-picker [isOpen]=\"a\"></x-date-picker>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试本地化
        /// </summary>
        [Fact]
        public void TestLocale() {
            var attributes = new TagHelperAttributeList { { UiConst.Locale, "a" } };
            var result = new String();
            result.Append( "<x-date-picker [locale]=\"a\"></x-date-picker>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置占位提示
        /// </summary>
        [Fact]
        public void TestPlaceholder() {
            var attributes = new TagHelperAttributeList { { UiConst.Placeholder, "a" } };
            var result = new String();
            result.Append( "<x-date-picker placeholder=\"a\"></x-date-picker>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置绑定占位提示
        /// </summary>
        [Fact]
        public void TestBindPlaceholder() {
            var attributes = new TagHelperAttributeList { { AngularConst.BindPlaceholder, "a" } };
            var result = new String();
            result.Append( "<x-date-picker [placeholder]=\"a\"></x-date-picker>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试模型绑定
        /// </summary>
        [Fact]
        public void TestModel() {
            var attributes = new TagHelperAttributeList { { AngularConst.NgModel, "a" } };
            var result = new String();
            result.Append( "<x-date-picker [(model)]=\"a\"></x-date-picker>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试日期选择类型
        /// </summary>
        [Fact]
        public void TestType() {
            var attributes = new TagHelperAttributeList { { UiConst.Type, DatePickerType.Month } };
            var result = new String();
            result.Append( "<x-date-picker type=\"month\"></x-date-picker>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试是否显示清除按钮
        /// </summary>
        [Fact]
        public void TestShowClear() {
            var attributes = new TagHelperAttributeList { { UiConst.ShowClear, false } };
            var result = new String();
            result.Append( "<x-date-picker [allowClear]=\"false\"></x-date-picker>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试是否自动获取焦点
        /// </summary>
        [Fact]
        public void TestAutoFocus() {
            var attributes = new TagHelperAttributeList { { UiConst.AutoFocus, false } };
            var result = new String();
            result.Append( "<x-date-picker [autoFocus]=\"false\"></x-date-picker>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试css类选择器
        /// </summary>
        [Fact]
        public void TestClassName() {
            var attributes = new TagHelperAttributeList { { UiConst.ClassName, "a" } };
            var result = new String();
            result.Append( "<x-date-picker className=\"a\"></x-date-picker>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试自定义日期单元格内容
        /// </summary>
        [Fact]
        public void TestDateRender() {
            var attributes = new TagHelperAttributeList { { UiConst.DateRender, "a" } };
            var result = new String();
            result.Append( "<x-date-picker [dateRender]=\"a\"></x-date-picker>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试格式化
        /// </summary>
        [Fact]
        public void TestFormat() {
            var attributes = new TagHelperAttributeList { { UiConst.Format,"a" } };
            var result = new String();
            result.Append( "<x-date-picker format=\"a\"></x-date-picker>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试显示时间
        /// </summary>
        [Fact]
        public void TestShowTime() {
            var attributes = new TagHelperAttributeList { { UiConst.ShowTime, true } };
            var result = new String();
            result.Append( "<x-date-picker [showTime]=\"true\"></x-date-picker>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试显示“今天”按钮
        /// </summary>
        [Fact]
        public void TestShowToday() {
            var attributes = new TagHelperAttributeList { { UiConst.ShowToday, true } };
            var result = new String();
            result.Append( "<x-date-picker [showToday]=\"true\"></x-date-picker>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试必填项
        /// </summary>
        [Fact]
        public void TestRequired() {
            var attributes = new TagHelperAttributeList { { UiConst.Required, true } };
            var result = new String();
            result.Append( "<x-date-picker [required]=\"true\"></x-date-picker>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试必填项错误消息
        /// </summary>
        [Fact]
        public void TestRequiredMessage() {
            var attributes = new TagHelperAttributeList { { UiConst.RequiredMessage, "a" } };
            var result = new String();
            result.Append( "<x-date-picker requiredMessage=\"a\"></x-date-picker>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试弹出和关闭日历事件
        /// </summary>
        [Fact]
        public void TestOnOpenChange() {
            var attributes = new TagHelperAttributeList { { UiConst.OnOpenChange, "a" } };
            var result = new String();
            result.Append( "<x-date-picker (onOpenChange)=\"a\"></x-date-picker>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试变更事件
        /// </summary>
        [Fact]
        public void TestOnChange() {
            var attributes = new TagHelperAttributeList { { UiConst.OnChange, "a" } };
            var result = new String();
            result.Append( "<x-date-picker (onChange)=\"a\"></x-date-picker>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试获得焦点事件
        /// </summary>
        [Fact]
        public void TestOnFocus() {
            var attributes = new TagHelperAttributeList { { UiConst.OnFocus, "a" } };
            var result = new String();
            result.Append( "<x-date-picker (onFocus)=\"a\"></x-date-picker>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试失去焦点事件
        /// </summary>
        [Fact]
        public void TestOnBlur() {
            var attributes = new TagHelperAttributeList { { UiConst.OnBlur, "a" } };
            var result = new String();
            result.Append( "<x-date-picker (onBlur)=\"a\"></x-date-picker>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试键盘按下事件
        /// </summary>
        [Fact]
        public void TestOnKeydown() {
            var attributes = new TagHelperAttributeList { { UiConst.OnKeydown, "a" } };
            var result = new String();
            result.Append( "<x-date-picker (onKeydown)=\"a\"></x-date-picker>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}