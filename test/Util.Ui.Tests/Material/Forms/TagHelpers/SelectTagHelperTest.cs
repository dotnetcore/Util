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
    /// 下拉列表测试
    /// </summary>
    public class SelectTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 下拉列表
        /// </summary>
        private readonly SelectTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public SelectTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new SelectTagHelper();
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
            result.Append( "<mat-select-wrapper></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<mat-select-wrapper #a=\"\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置名称
        /// </summary>
        [Fact]
        public void TestName() {
            var attributes = new TagHelperAttributeList { { UiConst.Name, "a" } };
            var result = new String();
            result.Append( "<mat-select-wrapper name=\"a\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            var attributes = new TagHelperAttributeList { { UiConst.Disabled, true } };
            var result = new String();
            result.Append( "<mat-select-wrapper [disabled]=\"true\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置Url
        /// </summary>
        [Fact]
        public void TestUrl() {
            var attributes = new TagHelperAttributeList { { UiConst.Url, "a" } };
            var result = new String();
            result.Append( "<mat-select-wrapper url=\"a\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置数据源
        /// </summary>
        [Fact]
        public void TestDataSource() {
            var attributes = new TagHelperAttributeList { { UiConst.DataSource, "a" } };
            var result = new String();
            result.Append( "<mat-select-wrapper [dataSource]=\"a\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置占位提示
        /// </summary>
        [Fact]
        public void TestPlaceholder() {
            var attributes = new TagHelperAttributeList { { UiConst.Placeholder, "a" } };
            var result = new String();
            result.Append( "<mat-select-wrapper placeholder=\"a\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置绑定占位提示
        /// </summary>
        [Fact]
        public void TestBindPlaceholder() {
            var attributes = new TagHelperAttributeList { { AngularConst.BindPlaceholder, "a" } };
            var result = new String();
            result.Append( "<mat-select-wrapper [placeholder]=\"a\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置占位提示浮动位置
        /// </summary>
        [Fact]
        public void TestFloatPlaceholder() {
            var attributes = new TagHelperAttributeList { { MaterialConst.FloatPlaceholder, FloatType.Never } };
            var result = new String();
            result.Append( "<mat-select-wrapper floatPlaceholder=\"never\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置起始提示
        /// </summary>
        [Fact]
        public void TestStartHint() {
            var attributes = new TagHelperAttributeList { { MaterialConst.StartHint, "a" } };
            var result = new String();
            result.Append( "<mat-select-wrapper startHint=\"a\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置结束提示
        /// </summary>
        [Fact]
        public void TestEndHint() {
            var attributes = new TagHelperAttributeList { { MaterialConst.EndHint, "a" } };
            var result = new String();
            result.Append( "<mat-select-wrapper endHint=\"a\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置前缀
        /// </summary>
        [Fact]
        public void TestPrefix() {
            var attributes = new TagHelperAttributeList { { UiConst.Prefix, "a" } };
            var result = new String();
            result.Append( "<mat-select-wrapper prefixText=\"a\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置后缀文本
        /// </summary>
        [Fact]
        public void TestSuffixText() {
            var attributes = new TagHelperAttributeList { { MaterialConst.SuffixText, "a" } };
            var result = new String();
            result.Append( "<mat-select-wrapper suffixText=\"a\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置后缀FontAwesome图标
        /// </summary>
        [Fact]
        public void TestSuffixFontAwesomeIcon() {
            var attributes = new TagHelperAttributeList { { MaterialConst.SuffixFontAwesomeIcon, FontAwesomeIcon.Apple } };
            var result = new String();
            result.Append( "<mat-select-wrapper suffixFontAwesomeIcon=\"fa-apple\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置后缀Material图标
        /// </summary>
        [Fact]
        public void TestSuffixMaterialIcon() {
            var attributes = new TagHelperAttributeList { { MaterialConst.SuffixMaterialIcon, MaterialIcon.Android } };
            var result = new String();
            result.Append( "<mat-select-wrapper suffixMaterialIcon=\"android\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置后缀图标单击事件
        /// </summary>
        [Fact]
        public void TestOnSuffixIconClick() {
            var attributes = new TagHelperAttributeList { { MaterialConst.OnSuffixIconClick, "a" } };
            var result = new String();
            result.Append( "<mat-select-wrapper (onSuffixIconClick)=\"a\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试启用重置项
        /// </summary>
        [Fact]
        public void TestEnableResetOption() {
            var attributes = new TagHelperAttributeList { { MaterialConst.EnableResetOption, true } };
            var result = new String();
            result.Append( "<mat-select-wrapper [enableResetOption]=\"true\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置重置项文本
        /// </summary>
        [Fact]
        public void TestResetOptionText() {
            var attributes = new TagHelperAttributeList { { MaterialConst.ResetOptionText, "a" } };
            var result = new String();
            result.Append( "<mat-select-wrapper resetOptionText=\"a\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试启用多选
        /// </summary>
        [Fact]
        public void TestMultiple() {
            var attributes = new TagHelperAttributeList { { UiConst.Multiple, true } };
            var result = new String();
            result.Append( "<mat-select-wrapper [multiple]=\"true\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试模型绑定
        /// </summary>
        [Fact]
        public void TestModel() {
            var attributes = new TagHelperAttributeList { { UiConst.Model, "a" } };
            var result = new String();
            result.Append( "<mat-select-wrapper [(model)]=\"a\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试必填项
        /// </summary>
        [Fact]
        public void TestRequired() {
            var attributes = new TagHelperAttributeList { { UiConst.Required, true } };
            var result = new String();
            result.Append( "<mat-select-wrapper [required]=\"true\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试必填项错误消息
        /// </summary>
        [Fact]
        public void TestRequiredMessage() {
            var attributes = new TagHelperAttributeList { { UiConst.RequiredMessage, "a" } };
            var result = new String();
            result.Append( "<mat-select-wrapper requiredMessage=\"a\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试显示模板
        /// </summary>
        [Fact]
        public void TestTemplate() {
            var attributes = new TagHelperAttributeList { { UiConst.Template, "a" } };
            var result = new String();
            result.Append( "<mat-select-wrapper template=\"a\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试变更事件
        /// </summary>
        [Fact]
        public void TestOnChange() {
            var attributes = new TagHelperAttributeList { { UiConst.OnChange, "a" } };
            var result = new String();
            result.Append( "<mat-select-wrapper (onChange)=\"a\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试获得焦点事件
        /// </summary>
        [Fact]
        public void TestOnFocus() {
            var attributes = new TagHelperAttributeList { { UiConst.OnFocus, "a" } };
            var result = new String();
            result.Append( "<mat-select-wrapper (onFocus)=\"a\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试失去焦点事件
        /// </summary>
        [Fact]
        public void TestOnBlur() {
            var attributes = new TagHelperAttributeList { { UiConst.OnBlur, "a" } };
            var result = new String();
            result.Append( "<mat-select-wrapper (onBlur)=\"a\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试键盘按下事件
        /// </summary>
        [Fact]
        public void TestOnKeydown() {
            var attributes = new TagHelperAttributeList { { UiConst.OnKeydown, "a" } };
            var result = new String();
            result.Append( "<mat-select-wrapper (onKeydown)=\"a\"></mat-select-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}
