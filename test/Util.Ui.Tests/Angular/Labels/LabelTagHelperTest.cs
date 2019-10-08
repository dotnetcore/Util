using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular;
using Util.Ui.Angular.Enums;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.Tests.XUnitHelpers;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Tests.Angular.Labels {
    /// <summary>
    /// 标签测试
    /// </summary>
    public class LabelTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 标签
        /// </summary>
        private readonly LabelTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public LabelTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new LabelTagHelper();
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
            result.Append( "<span></span>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<span #a=\"\"></span>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试文本
        /// </summary>
        [Fact]
        public void TestText() {
            var attributes = new TagHelperAttributeList { { UiConst.Text, "a" } };
            var result = new String();
            result.Append( "<span>a</span>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试绑定文本
        /// </summary>
        [Fact]
        public void TestBindText() {
            var attributes = new TagHelperAttributeList { { AngularConst.BindText, "a" } };
            var result = new String();
            result.Append( "<span>{{a}}</span>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置布尔类型
        /// </summary>
        [Fact]
        public void TestType_Bool() {
            var attributes = new TagHelperAttributeList { { AngularConst.BindText, "a" },{ UiConst.Type, LabelType.Bool } };
            var result = new String();
            result.Append( "<span>" );
            result.Append( "<mat-icon *ngIf=\"a\">check</mat-icon>" );
            result.Append( "<mat-icon *ngIf=\"!(a)\">clear</mat-icon>" );
            result.Append( "</span>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置日期类型
        /// </summary>
        [Fact]
        public void TestType_Date() {
            var attributes = new TagHelperAttributeList { { AngularConst.BindText, "a" },{ UiConst.Type, LabelType.Date } };
            var result = new String();
            result.Append( "<span>" );
            result.Append( "{{ a | date:\"yyyy-MM-dd\" }}" );
            result.Append( "</span>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置日期类型 - 指定格式化字符串
        /// </summary>
        [Fact]
        public void TestType_Date_Format() {
            var attributes = new TagHelperAttributeList { { AngularConst.BindText, "a" }, { UiConst.Type, LabelType.Date }, { UiConst.DateFormat, "a" } };
            var result = new String();
            result.Append( "<span>" );
            result.Append( "{{ a | date:\"a\" }}" );
            result.Append( "</span>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}