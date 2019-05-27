using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.AntDesign.Tests.XUnitHelpers;
using Util.Ui.Configs;
using Util.Ui.Zorro.Forms;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Angular.AntDesign.Tests.Zorro.Forms {
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
            result.Append( "<x-select></x-select>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<x-select #a=\"\"></x-select>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置名称
        /// </summary>
        [Fact]
        public void TestName() {
            var attributes = new TagHelperAttributeList { { UiConst.Name, "a" } };
            var result = new String();
            result.Append( "<x-select name=\"a\"></x-select>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置名称
        /// </summary>
        [Fact]
        public void TestBindName() {
            var attributes = new TagHelperAttributeList { { AngularConst.BindName, "a" } };
            var result = new String();
            result.Append( "<x-select [name]=\"a\"></x-select>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试显示清除按钮
        /// </summary>
        [Fact]
        public void TestShowClearButton() {
            var attributes = new TagHelperAttributeList { { UiConst.ShowClearButton, true } };
            var result = new String();
            result.Append( "<x-select [allowClear]=\"true\"></x-select>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试显示搜索框
        /// </summary>
        [Fact]
        public void TestShowSearch() {
            var attributes = new TagHelperAttributeList { { UiConst.ShowSearch, true } };
            var result = new String();
            result.Append( "<x-select [showSearch]=\"true\"></x-select>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            var attributes = new TagHelperAttributeList { { UiConst.Disabled, true } };
            var result = new String();
            result.Append( "<x-select [disabled]=\"true\"></x-select>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置Url
        /// </summary>
        [Fact]
        public void TestUrl() {
            var attributes = new TagHelperAttributeList { { UiConst.Url, "a" } };
            var result = new String();
            result.Append( "<x-select url=\"a\"></x-select>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置Url
        /// </summary>
        [Fact]
        public void TestBindUrl() {
            var attributes = new TagHelperAttributeList { { AngularConst.BindUrl, "a" } };
            var result = new String();
            result.Append( "<x-select [url]=\"a\"></x-select>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试查询参数
        /// </summary>
        [Fact]
        public void TestQueryParam() {
            var attributes = new TagHelperAttributeList { { UiConst.QueryParam, "a" } };
            var result = new String();
            result.Append( "<x-select [queryParam]=\"a\"></x-select>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置数据源
        /// </summary>
        [Fact]
        public void TestData() {
            var attributes = new TagHelperAttributeList { { UiConst.Data, "a" } };
            var result = new String();
            result.Append( "<x-select [dataSource]=\"a\"></x-select>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置占位提示
        /// </summary>
        [Fact]
        public void TestPlaceholder() {
            var attributes = new TagHelperAttributeList { { UiConst.Placeholder, "a" } };
            var result = new String();
            result.Append( "<x-select placeholder=\"a\"></x-select>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置绑定占位提示
        /// </summary>
        [Fact]
        public void TestBindPlaceholder() {
            var attributes = new TagHelperAttributeList { { AngularConst.BindPlaceholder, "a" } };
            var result = new String();
            result.Append( "<x-select [placeholder]=\"a\"></x-select>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置默认项文本
        /// </summary>
        [Fact]
        public void TestDefaultOptionText() {
            var attributes = new TagHelperAttributeList { { UiConst.DefaultOptionText, "a" } };
            var result = new String();
            result.Append( "<x-select defaultOptionText=\"a\"></x-select>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置宽度
        /// </summary>
        [Fact]
        public void TestWidth() {
            var attributes = new TagHelperAttributeList { { UiConst.Width, "a" } };
            var result = new String();
            result.Append( "<x-select width=\"a\"></x-select>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置宽度
        /// </summary>
        [Fact]
        public void TestWidth_Number() {
            var attributes = new TagHelperAttributeList { { UiConst.Width, "1" } };
            var result = new String();
            result.Append( "<x-select width=\"1px\"></x-select>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试启用多选
        /// </summary>
        [Fact]
        public void TestMultiple() {
            var attributes = new TagHelperAttributeList { { UiConst.Multiple, true } };
            var result = new String();
            result.Append( "<x-select [multiple]=\"true\"></x-select>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试模型绑定
        /// </summary>
        [Fact]
        public void TestModel() {
            var attributes = new TagHelperAttributeList { { AngularConst.NgModel, "a" } };
            var result = new String();
            result.Append( "<x-select [(model)]=\"a\"></x-select>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试必填项
        /// </summary>
        [Fact]
        public void TestRequired() {
            var attributes = new TagHelperAttributeList { { UiConst.Required, true } };
            var result = new String();
            result.Append( "<x-select [required]=\"true\"></x-select>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试必填项错误消息
        /// </summary>
        [Fact]
        public void TestRequiredMessage() {
            var attributes = new TagHelperAttributeList { { UiConst.RequiredMessage, "a" } };
            var result = new String();
            result.Append( "<x-select requiredMessage=\"a\"></x-select>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试变更事件
        /// </summary>
        [Fact]
        public void TestOnChange() {
            var attributes = new TagHelperAttributeList { { UiConst.OnChange, "a" } };
            var result = new String();
            result.Append( "<x-select (onChange)=\"a\"></x-select>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试获得焦点事件
        /// </summary>
        [Fact]
        public void TestOnFocus() {
            var attributes = new TagHelperAttributeList { { UiConst.OnFocus, "a" } };
            var result = new String();
            result.Append( "<x-select (onFocus)=\"a\"></x-select>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试失去焦点事件
        /// </summary>
        [Fact]
        public void TestOnBlur() {
            var attributes = new TagHelperAttributeList { { UiConst.OnBlur, "a" } };
            var result = new String();
            result.Append( "<x-select (onBlur)=\"a\"></x-select>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试键盘按下事件
        /// </summary>
        [Fact]
        public void TestOnKeydown() {
            var attributes = new TagHelperAttributeList { { UiConst.OnKeydown, "a" } };
            var result = new String();
            result.Append( "<x-select (onKeydown)=\"a\"></x-select>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}
