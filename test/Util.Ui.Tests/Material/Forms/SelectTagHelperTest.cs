using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.Material.Configs;
using Util.Ui.Material.Enums;
using Util.Ui.Material.Forms.TagHelpers;
using Util.Ui.Tests.XUnitHelpers;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Tests.Material.Forms {
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
        /// 测试按组显示
        /// </summary>
        [Fact]
        public void TestGroup() {
            var attributes = new TagHelperAttributeList { { UiConst.Group, true } };
            var result = new String();
            result.Append( "<mat-select-wrapper [isGroup]=\"true\"></mat-select-wrapper>" );
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
        /// 测试设置占位提示浮动位置
        /// </summary>
        [Fact]
        public void TestFloatPlaceholder() {
            var attributes = new TagHelperAttributeList { { MaterialConst.FloatPlaceholder, FloatPlaceholder.Never } };
            var result = new String();
            result.Append( "<mat-select-wrapper floatPlaceholder=\"never\"></mat-select-wrapper>" );
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
    }
}
