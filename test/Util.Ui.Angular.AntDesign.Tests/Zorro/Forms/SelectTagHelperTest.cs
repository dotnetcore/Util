using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.AntDesign.Tests.XUnitHelpers;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Zorro.Forms;
using Util.Ui.Zorro.Tables.Configs;
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
        private string GetResult( TagHelperAttributeList contextAttributes = null,TagHelperAttributeList outputAttributes = null, 
            TagHelperContent content = null, IDictionary<object, object> items = null ) {
            return Helper.GetResult( _output, _component, contextAttributes, outputAttributes, content, items );
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
        /// 测试设置排序
        /// </summary>
        [Fact]
        public void TestSort() {
            var attributes = new TagHelperAttributeList { { UiConst.Sort, "a" } };
            var result = new String();
            result.Append( "<x-select order=\"a\"></x-select>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试显示清除按钮
        /// </summary>
        [Fact]
        public void TestShowClear() {
            var attributes = new TagHelperAttributeList { { UiConst.ShowClear, true } };
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
        /// 测试显示箭头
        /// </summary>
        [Fact]
        public void TestShowArrow() {
            var attributes = new TagHelperAttributeList { { UiConst.ShowArrow, true } };
            var result = new String();
            result.Append( "<x-select [showArrow]=\"true\"></x-select>" );
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
        /// 测试服务端搜索
        /// </summary>
        [Fact]
        public void TestServerSearch() {
            var attributes = new TagHelperAttributeList { { UiConst.ServerSearch, true } };
            var result = new String();
            result.Append( "<x-select [isServerSearch]=\"true\"></x-select>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试滚动加载
        /// </summary>
        [Fact]
        public void TestScrollLoad() {
            var attributes = new TagHelperAttributeList { { UiConst.ScrollLoad, true } };
            var result = new String();
            result.Append( "<x-select [isScrollLoad]=\"true\"></x-select>" );
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
        /// 测试选择模式
        /// </summary>
        [Fact]
        public void TestMode() {
            var attributes = new TagHelperAttributeList { { UiConst.Mode, SelectMode.Multiple } };
            var result = new String();
            result.Append( "<x-select [multiple]=\"true\"></x-select>" );
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
        /// 测试启用标签
        /// </summary>
        [Fact]
        public void TestTags() {
            var attributes = new TagHelperAttributeList { { UiConst.Tags, true } };
            var result = new String();
            result.Append( "<x-select [tags]=\"true\"></x-select>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试最多选择数量
        /// </summary>
        [Fact]
        public void TestMaxMultipleCount() {
            var attributes = new TagHelperAttributeList { { UiConst.MaxMultipleCount, 10 } };
            var result = new String();
            result.Append( "<x-select [maxMultipleCount]=\"10\"></x-select>" );
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
        /// 测试自动加载
        /// </summary>
        [Fact]
        public void TestAutoLoad() {
            var attributes = new TagHelperAttributeList { { UiConst.AutoLoad, false } };
            var result = new String();
            result.Append( "<x-select [autoLoad]=\"false\"></x-select>" );
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
        /// 测试栅格跨度
        /// </summary>
        [Fact]
        public void TestSpan() {
            var attributes = new TagHelperAttributeList { { UiConst.Span, 2 } };
            var result = new String();
            result.Append( "<nz-form-control [nzSpan]=\"2\">" );
            result.Append( "<x-select></x-select>" );
            result.Append( "</nz-form-control>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试表格编辑
        /// </summary>
        [Fact]
        public void TestTableEdit() {
            var config = new ColumnShareConfig( new TableShareConfig( "id" ), "a" );
            var items = new Dictionary<object, object> { { typeof( ColumnShareConfig ), config } };

            var result = new String();
            result.Append( "<x-select [row]=\"id_row\"></x-select>" );

            Assert.Equal( result.ToString(), GetResult( items: items ) );
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

        /// <summary>
        /// 测试搜索事件
        /// </summary>
        [Fact]
        public void TestOnSearch() {
            var attributes = new TagHelperAttributeList { { UiConst.OnSearch, "a" } };
            var result = new String();
            result.Append( "<x-select (onSearch)=\"a\"></x-select>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试滚动到底部事件
        /// </summary>
        [Fact]
        public void TestOnScrollToBottom() {
            var attributes = new TagHelperAttributeList { { UiConst.OnScrollToBottom, "a" } };
            var result = new String();
            result.Append( "<x-select (onScrollToBottom)=\"a\"></x-select>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}
