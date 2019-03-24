using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.AntDesign.Tests.XUnitHelpers;
using Util.Ui.Configs;
using Util.Ui.Zorro.Tables;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Angular.AntDesign.Tests.Zorro.Tables {
    /// <summary>
    /// 表格标题列测试
    /// </summary>
    public class TableHeadColumnTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 表格标题列
        /// </summary>
        private readonly HeadColumnTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public TableHeadColumnTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new HeadColumnTagHelper();
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private string GetResult( TagHelperAttributeList contextAttributes = null, TagHelperAttributeList outputAttributes = null,
            TagHelperContent content = null, IDictionary<object, object> items = null ) {
            return Helper.GetResult( _output, _component, contextAttributes, outputAttributes, content, items );
        }

        /// <summary>
        /// 测试默认输出
        /// </summary>
        [Fact]
        public void TestDefault() {
            var result = new String();
            result.Append( "<th></th>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<th #a=\"\"></th>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试添加标题
        /// </summary>
        [Fact]
        public void TestTitle() {
            var attributes = new TagHelperAttributeList { { UiConst.Title, "a" } };
            var result = new String();
            result.Append( "<th>a</th>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}