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
    /// 多行文本框测试
    /// </summary>
    public class TextAreaTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 多行文本框
        /// </summary>
        private readonly TextAreaTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public TextAreaTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new TextAreaTagHelper();
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
            result.Append( "<mat-textarea-wrapper></mat-textarea-wrapper>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<mat-textarea-wrapper #a=\"\"></mat-textarea-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置名称
        /// </summary>
        [Fact]
        public void TestName() {
            var attributes = new TagHelperAttributeList { { UiConst.Name, "a" } };
            var result = new String();
            result.Append( "<mat-textarea-wrapper name=\"a\"></mat-textarea-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            var attributes = new TagHelperAttributeList { { UiConst.Disabled, true } };
            var result = new String();
            result.Append( "<mat-textarea-wrapper [disabled]=\"true\"></mat-textarea-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试只读
        /// </summary>
        [Fact]
        public void TestReadOnly() {
            var attributes = new TagHelperAttributeList { { UiConst.ReadOnly, true } };
            var result = new String();
            result.Append( "<mat-textarea-wrapper [readonly]=\"true\"></mat-textarea-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置占位提示
        /// </summary>
        [Fact]
        public void TestPlaceholder() {
            var attributes = new TagHelperAttributeList { { UiConst.Placeholder, "a" } };
            var result = new String();
            result.Append( "<mat-textarea-wrapper placeholder=\"a\"></mat-textarea-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置绑定占位提示
        /// </summary>
        [Fact]
        public void TestBindPlaceholder() {
            var attributes = new TagHelperAttributeList { { AngularConst.BindPlaceholder, "a" } };
            var result = new String();
            result.Append( "<mat-textarea-wrapper [placeholder]=\"a\"></mat-textarea-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置占位提示浮动位置
        /// </summary>
        [Fact]
        public void TestFloatPlaceholder() {
            var attributes = new TagHelperAttributeList { { MaterialConst.FloatPlaceholder, FloatType.Never } };
            var result = new String();
            result.Append( "<mat-textarea-wrapper floatPlaceholder=\"never\"></mat-textarea-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置起始提示
        /// </summary>
        [Fact]
        public void TestStartHint() {
            var attributes = new TagHelperAttributeList { { MaterialConst.StartHint, "a" } };
            var result = new String();
            result.Append( "<mat-textarea-wrapper startHint=\"a\"></mat-textarea-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置结束提示
        /// </summary>
        [Fact]
        public void TestEndHint() {
            var attributes = new TagHelperAttributeList { { MaterialConst.EndHint, "a" } };
            var result = new String();
            result.Append( "<mat-textarea-wrapper endHint=\"a\"></mat-textarea-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置前缀
        /// </summary>
        [Fact]
        public void TestPrefix() {
            var attributes = new TagHelperAttributeList { { UiConst.Prefix, "a" } };
            var result = new String();
            result.Append( "<mat-textarea-wrapper prefixText=\"a\"></mat-textarea-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置后缀文本
        /// </summary>
        [Fact]
        public void TestSuffixText() {
            var attributes = new TagHelperAttributeList { { MaterialConst.SuffixText, "a" } };
            var result = new String();
            result.Append( "<mat-textarea-wrapper suffixText=\"a\"></mat-textarea-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置后缀FontAwesome图标
        /// </summary>
        [Fact]
        public void TestSuffixFontAwesomeIcon() {
            var attributes = new TagHelperAttributeList { { MaterialConst.SuffixFontAwesomeIcon, FontAwesomeIcon.Apple } };
            var result = new String();
            result.Append( "<mat-textarea-wrapper suffixFontAwesomeIcon=\"fa-apple\"></mat-textarea-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置后缀Material图标
        /// </summary>
        [Fact]
        public void TestSuffixMaterialIcon() {
            var attributes = new TagHelperAttributeList { { MaterialConst.SuffixMaterialIcon, MaterialIcon.Android } };
            var result = new String();
            result.Append( "<mat-textarea-wrapper suffixMaterialIcon=\"android\"></mat-textarea-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置后缀图标单击事件
        /// </summary>
        [Fact]
        public void TestOnSuffixIconClick() {
            var attributes = new TagHelperAttributeList { { MaterialConst.OnSuffixIconClick, "a" } };
            var result = new String();
            result.Append( "<mat-textarea-wrapper (onSuffixIconClick)=\"a\"></mat-textarea-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试是否显示清除按钮
        /// </summary>
        [Fact]
        public void TestShowClearButton() {
            var attributes = new TagHelperAttributeList { { MaterialConst.ShowClearButton, false } };
            var result = new String();
            result.Append( "<mat-textarea-wrapper [showClearButton]=\"false\"></mat-textarea-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }


        /// <summary>
        /// 测试模型绑定
        /// </summary>
        [Fact]
        public void TestModel() {
            var attributes = new TagHelperAttributeList { { UiConst.Model, "a" } };
            var result = new String();
            result.Append( "<mat-textarea-wrapper [(model)]=\"a\"></mat-textarea-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试必填项
        /// </summary>
        [Fact]
        public void TestRequired() {
            var attributes = new TagHelperAttributeList { { UiConst.Required, true } };
            var result = new String();
            result.Append( "<mat-textarea-wrapper [required]=\"true\"></mat-textarea-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试必填项错误消息
        /// </summary>
        [Fact]
        public void TestRequiredMessage() {
            var attributes = new TagHelperAttributeList { { UiConst.RequiredMessage, "a" } };
            var result = new String();
            result.Append( "<mat-textarea-wrapper requiredMessage=\"a\"></mat-textarea-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试最小长度
        /// </summary>
        [Fact]
        public void TestMinLength() {
            var attributes = new TagHelperAttributeList { { UiConst.MinLength, 3 } };
            var result = new String();
            result.Append( "<mat-textarea-wrapper [minLength]=\"3\"></mat-textarea-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试最小长度,添加指定错误消息
        /// </summary>
        [Fact]
        public void TestMinLength_Message() {
            var attributes = new TagHelperAttributeList { { UiConst.MinLengthMessage, "a" } };
            var result = new String();
            result.Append( "<mat-textarea-wrapper minLengthMessage=\"a\"></mat-textarea-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试最大长度
        /// </summary>
        [Fact]
        public void TestMaxLength() {
            var attributes = new TagHelperAttributeList { { UiConst.MaxLength, 3 } };
            var result = new String();
            result.Append( "<mat-textarea-wrapper [maxLength]=\"3\"></mat-textarea-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试正则表达式验证
        /// </summary>
        [Fact]
        public void TestRegex() {
            var attributes = new TagHelperAttributeList { { UiConst.Regex, "a" } };
            var result = new String();
            result.Append( "<mat-textarea-wrapper pattern=\"a\"></mat-textarea-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试正则表达式验证消息
        /// </summary>
        [Fact]
        public void TestRegexMessage() {
            var attributes = new TagHelperAttributeList { { UiConst.RegexMessage, "a" } };
            var result = new String();
            result.Append( "<mat-textarea-wrapper patterMessage=\"a\"></mat-textarea-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试变更事件
        /// </summary>
        [Fact]
        public void TestOnChange() {
            var attributes = new TagHelperAttributeList { { UiConst.OnChange, "a" } };
            var result = new String();
            result.Append( "<mat-textarea-wrapper (onChange)=\"a\"></mat-textarea-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试获得焦点事件
        /// </summary>
        [Fact]
        public void TestOnFocus() {
            var attributes = new TagHelperAttributeList { { UiConst.OnFocus, "a" } };
            var result = new String();
            result.Append( "<mat-textarea-wrapper (onFocus)=\"a\"></mat-textarea-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试失去焦点事件
        /// </summary>
        [Fact]
        public void TestOnBlur() {
            var attributes = new TagHelperAttributeList { { UiConst.OnBlur, "a" } };
            var result = new String();
            result.Append( "<mat-textarea-wrapper (onBlur)=\"a\"></mat-textarea-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试键盘按下事件
        /// </summary>
        [Fact]
        public void TestOnKeydown() {
            var attributes = new TagHelperAttributeList { { UiConst.OnKeydown, "a" } };
            var result = new String();
            result.Append( "<mat-textarea-wrapper (onKeydown)=\"a\"></mat-textarea-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试最小行数
        /// </summary>
        [Fact]
        public void TestMinRows() {
            var attributes = new TagHelperAttributeList { { UiConst.MinRows, 3 } };
            var result = new String();
            result.Append( "<mat-textarea-wrapper [minRows]=\"3\"></mat-textarea-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试最大行数
        /// </summary>
        [Fact]
        public void TestMaxRows() {
            var attributes = new TagHelperAttributeList { { UiConst.MaxRows, 3 } };
            var result = new String();
            result.Append( "<mat-textarea-wrapper [maxRows]=\"3\"></mat-textarea-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}