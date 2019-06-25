using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.AntDesign.Tests.XUnitHelpers;
using Util.Ui.Configs;
using Util.Ui.Zorro.Forms;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Angular.AntDesign.Tests.Zorro.Forms {
    /// <summary>
    /// 复选框组测试
    /// </summary>
    public class CheckboxGroupTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 复选框组
        /// </summary>
        private readonly CheckboxGroupTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public CheckboxGroupTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new CheckboxGroupTagHelper();
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
            result.Append( "<x-checkbox-group></x-checkbox-group>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<x-checkbox-group #a=\"\"></x-checkbox-group>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置名称
        /// </summary>
        [Fact]
        public void TestName() {
            var attributes = new TagHelperAttributeList { { UiConst.Name, "a" } };
            var result = new String();
            result.Append( "<x-checkbox-group name=\"a\"></x-checkbox-group>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            var attributes = new TagHelperAttributeList { { UiConst.Disabled, true } };
            var result = new String();
            result.Append( "<x-checkbox-group [disabled]=\"true\"></x-checkbox-group>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置Url
        /// </summary>
        [Fact]
        public void TestUrl() {
            var attributes = new TagHelperAttributeList { { UiConst.Url, "a" } };
            var result = new String();
            result.Append( "<x-checkbox-group url=\"a\"></x-checkbox-group>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置Url
        /// </summary>
        [Fact]
        public void TestBindUrl() {
            var attributes = new TagHelperAttributeList { { AngularConst.BindUrl, "a" } };
            var result = new String();
            result.Append( "<x-checkbox-group [url]=\"a\"></x-checkbox-group>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置数据源
        /// </summary>
        [Fact]
        public void TestBindDataSource() {
            var attributes = new TagHelperAttributeList { { AngularConst.BindData, "a" } };
            var result = new String();
            result.Append( "<x-checkbox-group [dataSource]=\"a\"></x-checkbox-group>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试模型绑定
        /// </summary>
        [Fact]
        public void TestNgModel() {
            var attributes = new TagHelperAttributeList { { AngularConst.NgModel, "a" } };
            var result = new String();
            result.Append( "<x-checkbox-group [(model)]=\"a\"></x-checkbox-group>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试必填项
        /// </summary>
        [Fact]
        public void TestRequired() {
            var attributes = new TagHelperAttributeList { { UiConst.Required, true } };
            var result = new String();
            result.Append( "<x-checkbox-group [required]=\"true\"></x-checkbox-group>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试必填项消息
        /// </summary>
        [Fact]
        public void TestRequiredMessage() {
            var attributes = new TagHelperAttributeList { { UiConst.RequiredMessage, "a" } };
            var result = new String();
            result.Append( "<x-checkbox-group requiredMessage=\"a\"></x-checkbox-group>" );
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
            result.Append( "<x-checkbox-group></x-checkbox-group>" );
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
            result.Append( "<x-checkbox-group (onChange)=\"a\"></x-checkbox-group>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}