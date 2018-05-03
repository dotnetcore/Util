using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Material;
using Util.Ui.Material.Enums;
using Util.Ui.Material.Forms.TagHelpers;
using Util.Ui.Tests.XUnitHelpers;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Tests.Material.Forms.TagHelpers {
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
            result.Append( "<mat-datepicker-wrapper></mat-datepicker-wrapper>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<mat-datepicker-wrapper #a=\"\"></mat-datepicker-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置名称
        /// </summary>
        [Fact]
        public void TestName() {
            var attributes = new TagHelperAttributeList { { UiConst.Name, "a" } };
            var result = new String();
            result.Append( "<mat-datepicker-wrapper name=\"a\"></mat-datepicker-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            var attributes = new TagHelperAttributeList { { UiConst.Disabled, true } };
            var result = new String();
            result.Append( "<mat-datepicker-wrapper [disabled]=\"true\"></mat-datepicker-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试只读
        /// </summary>
        [Fact]
        public void TestReadOnly() {
            var attributes = new TagHelperAttributeList { { UiConst.ReadOnly, true } };
            var result = new String();
            result.Append( "<mat-datepicker-wrapper [readonly]=\"true\"></mat-datepicker-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置占位提示
        /// </summary>
        [Fact]
        public void TestPlaceholder() {
            var attributes = new TagHelperAttributeList { { UiConst.Placeholder, "a" } };
            var result = new String();
            result.Append( "<mat-datepicker-wrapper placeholder=\"a\"></mat-datepicker-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置绑定占位提示
        /// </summary>
        [Fact]
        public void TestBindPlaceholder() {
            var attributes = new TagHelperAttributeList { { AngularConst.BindPlaceholder, "a" } };
            var result = new String();
            result.Append( "<mat-datepicker-wrapper [placeholder]=\"a\"></mat-datepicker-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置占位提示浮动位置
        /// </summary>
        [Fact]
        public void TestFloatPlaceholder() {
            var attributes = new TagHelperAttributeList { { MaterialConst.FloatPlaceholder, FloatType.Never } };
            var result = new String();
            result.Append( "<mat-datepicker-wrapper floatPlaceholder=\"never\"></mat-datepicker-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置起始提示
        /// </summary>
        [Fact]
        public void TestStartHint() {
            var attributes = new TagHelperAttributeList { { MaterialConst.StartHint, "a" } };
            var result = new String();
            result.Append( "<mat-datepicker-wrapper startHint=\"a\"></mat-datepicker-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置结束提示
        /// </summary>
        [Fact]
        public void TestEndHint() {
            var attributes = new TagHelperAttributeList { { MaterialConst.EndHint, "a" } };
            var result = new String();
            result.Append( "<mat-datepicker-wrapper endHint=\"a\"></mat-datepicker-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置前缀
        /// </summary>
        [Fact]
        public void TestPrefix() {
            var attributes = new TagHelperAttributeList { { UiConst.Prefix, "a" } };
            var result = new String();
            result.Append( "<mat-datepicker-wrapper prefixText=\"a\"></mat-datepicker-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置后缀文本
        /// </summary>
        [Fact]
        public void TestSuffixText() {
            var attributes = new TagHelperAttributeList { { MaterialConst.SuffixText, "a" } };
            var result = new String();
            result.Append( "<mat-datepicker-wrapper suffixText=\"a\"></mat-datepicker-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置后缀FontAwesome图标
        /// </summary>
        [Fact]
        public void TestSuffixFontAwesomeIcon() {
            var attributes = new TagHelperAttributeList { { MaterialConst.SuffixFontAwesomeIcon, FontAwesomeIcon.Apple } };
            var result = new String();
            result.Append( "<mat-datepicker-wrapper suffixFontAwesomeIcon=\"fa-apple\"></mat-datepicker-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置后缀Material图标
        /// </summary>
        [Fact]
        public void TestSuffixMaterialIcon() {
            var attributes = new TagHelperAttributeList { { MaterialConst.SuffixMaterialIcon, MaterialIcon.Android } };
            var result = new String();
            result.Append( "<mat-datepicker-wrapper suffixMaterialIcon=\"android\"></mat-datepicker-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置后缀图标单击事件
        /// </summary>
        [Fact]
        public void TestOnSuffixIconClick() {
            var attributes = new TagHelperAttributeList { { MaterialConst.OnSuffixIconClick, "a" } };
            var result = new String();
            result.Append( "<mat-datepicker-wrapper (onSuffixIconClick)=\"a\"></mat-datepicker-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试是否显示清除按钮
        /// </summary>
        [Fact]
        public void TestShowClearButton() {
            var attributes = new TagHelperAttributeList { { MaterialConst.ShowClearButton, false } };
            var result = new String();
            result.Append( "<mat-datepicker-wrapper [showClearButton]=\"false\"></mat-datepicker-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }


        /// <summary>
        /// 测试模型绑定
        /// </summary>
        [Fact]
        public void TestModel() {
            var attributes = new TagHelperAttributeList { { UiConst.Model, "a" } };
            var result = new String();
            result.Append( "<mat-datepicker-wrapper [(model)]=\"a\"></mat-datepicker-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试必填项
        /// </summary>
        [Fact]
        public void TestRequired() {
            var attributes = new TagHelperAttributeList { { UiConst.Required, true } };
            var result = new String();
            result.Append( "<mat-datepicker-wrapper [required]=\"true\"></mat-datepicker-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试必填项错误消息
        /// </summary>
        [Fact]
        public void TestRequiredMessage() {
            var attributes = new TagHelperAttributeList { { UiConst.RequiredMessage, "a" } };
            var result = new String();
            result.Append( "<mat-datepicker-wrapper requiredMessage=\"a\"></mat-datepicker-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试变更事件
        /// </summary>
        [Fact]
        public void TestOnChange() {
            var attributes = new TagHelperAttributeList { { UiConst.OnChange, "a" } };
            var result = new String();
            result.Append( "<mat-datepicker-wrapper (onChange)=\"a\"></mat-datepicker-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试获得焦点事件
        /// </summary>
        [Fact]
        public void TestOnFocus() {
            var attributes = new TagHelperAttributeList { { UiConst.OnFocus, "a" } };
            var result = new String();
            result.Append( "<mat-datepicker-wrapper (onFocus)=\"a\"></mat-datepicker-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试失去焦点事件
        /// </summary>
        [Fact]
        public void TestOnBlur() {
            var attributes = new TagHelperAttributeList { { UiConst.OnBlur, "a" } };
            var result = new String();
            result.Append( "<mat-datepicker-wrapper (onBlur)=\"a\"></mat-datepicker-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试键盘按下事件
        /// </summary>
        [Fact]
        public void TestOnKeydown() {
            var attributes = new TagHelperAttributeList { { UiConst.OnKeydown, "a" } };
            var result = new String();
            result.Append( "<mat-datepicker-wrapper (onKeydown)=\"a\"></mat-datepicker-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试宽度
        /// </summary>
        [Fact]
        public void TestWidth() {
            var attributes = new TagHelperAttributeList { { UiConst.Width, 1 } };
            var result = new String();
            result.Append( "<mat-datepicker-wrapper [width]=\"1\"></mat-datepicker-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试起始视图
        /// </summary>
        [Fact]
        public void TestStartView() {
            var attributes = new TagHelperAttributeList { { MaterialConst.StartView, DateView.Year } };
            var result = new String();
            result.Append( "<mat-datepicker-wrapper startView=\"year\"></mat-datepicker-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试触摸模式
        /// </summary>
        [Fact]
        public void TestTouchUi() {
            var attributes = new TagHelperAttributeList { { MaterialConst.TouchUi, true } };
            var result = new String();
            result.Append( "<mat-datepicker-wrapper [touchUi]=\"true\"></mat-datepicker-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试最小日期
        /// </summary>
        [Fact]
        public void TestMinDate() {
            var attributes = new TagHelperAttributeList { { MaterialConst.MinDate, "a" } };
            var result = new String();
            result.Append( "<mat-datepicker-wrapper minDate=\"a\"></mat-datepicker-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试最大日期
        /// </summary>
        [Fact]
        public void TestMaxDate() {
            var attributes = new TagHelperAttributeList { { MaterialConst.MaxDate, "a" } };
            var result = new String();
            result.Append( "<mat-datepicker-wrapper maxDate=\"a\"></mat-datepicker-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}