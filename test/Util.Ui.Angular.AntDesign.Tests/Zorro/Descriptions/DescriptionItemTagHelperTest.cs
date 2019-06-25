using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.AntDesign.Tests.XUnitHelpers;
using Util.Ui.Configs;
using Util.Ui.Zorro.Descriptions;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Angular.AntDesign.Tests.Zorro.Descriptions {
    /// <summary>
    /// 描述列表项测试
    /// </summary>
    public class DescriptionItemTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 描述列表项
        /// </summary>
        private readonly DescriptionItemTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public DescriptionItemTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new DescriptionItemTagHelper();
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
            result.Append( "<nz-descriptions-item></nz-descriptions-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<nz-descriptions-item #a=\"\"></nz-descriptions-item>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试标题
        /// </summary>
        [Fact]
        public void TestLabel() {
            var attributes = new TagHelperAttributeList { { UiConst.Label, "a" } };
            var result = new String();
            result.Append( "<nz-descriptions-item nzTitle=\"a\"></nz-descriptions-item>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试值
        /// </summary>
        [Fact]
        public void TestValue() {
            var attributes = new TagHelperAttributeList { { UiConst.Value, "a" } };
            var result = new String();
            result.Append( "<nz-descriptions-item>a</nz-descriptions-item>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试值
        /// </summary>
        [Fact]
        public void TestBindValue() {
            var attributes = new TagHelperAttributeList { { AngularConst.BindValue, "a" } };
            var result = new String();
            result.Append( "<nz-descriptions-item>{{a}}</nz-descriptions-item>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试列跨度
        /// </summary>
        [Fact]
        public void TestShowBorder() {
            var attributes = new TagHelperAttributeList { { UiConst.Span, 2 } };
            var result = new String();
            result.Append( "<nz-descriptions-item [nzSpan]=\"2\"></nz-descriptions-item>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}