using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.AntDesign.Tests.XUnitHelpers;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Zorro.Descriptions;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Angular.AntDesign.Tests.Zorro.Descriptions {
    /// <summary>
    /// 描述列表测试
    /// </summary>
    public class DescriptionTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 描述列表
        /// </summary>
        private readonly DescriptionTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public DescriptionTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new DescriptionTagHelper();
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
            result.Append( "<nz-descriptions></nz-descriptions>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<nz-descriptions #a=\"\"></nz-descriptions>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试标题
        /// </summary>
        [Fact]
        public void TestTitle() {
            var attributes = new TagHelperAttributeList { { UiConst.Title, "a" } };
            var result = new String();
            result.Append( "<nz-descriptions nzTitle=\"a\"></nz-descriptions>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试显示边框
        /// </summary>
        [Fact]
        public void TestShowBorder() {
            var attributes = new TagHelperAttributeList { { UiConst.ShowBorder, true } };
            var result = new String();
            result.Append( "<nz-descriptions [nzBordered]=\"true\"></nz-descriptions>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试列的数量
        /// </summary>
        [Fact]
        public void TestColumn() {
            var attributes = new TagHelperAttributeList { { UiConst.Column, "2" } };
            var result = new String();
            result.Append( "<nz-descriptions [nzColumn]=\"2\"></nz-descriptions>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试大小
        /// </summary>
        [Fact]
        public void TestSize() {
            var attributes = new TagHelperAttributeList { { UiConst.Size, DescriptionSize.Middle } };
            var result = new String();
            result.Append( "<nz-descriptions nzSize=\"middle\"></nz-descriptions>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}