using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.AntDesign.Tests.XUnitHelpers;
using Util.Ui.Configs;
using Util.Ui.Zorro.Tables;
using Util.Ui.Zorro.Tables.Configs;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Angular.AntDesign.Tests.Zorro.Tables {
    /// <summary>
    /// 表格头测试
    /// </summary>
    public class TableHeadTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 表格头
        /// </summary>
        private readonly HeadTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public TableHeadTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new HeadTagHelper();
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
            result.Append( "<thead>" );
            result.Append( "<tr>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<thead>" );
            result.Append( "<tr #a=\"\">" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试不自动创建表头行
        /// </summary>
        [Fact]
        public void TestAutoCreateHeadRow_False() {
            var config = new TableShareConfig( null ) { AutoCreateHeadRow = false };
            var items = new Dictionary<object, object> { { typeof( TableShareConfig ), config } };
            var result = new String();
            result.Append( "<thead>" );
            result.Append( "</thead>" );
            Assert.Equal( result.ToString(), GetResult( items: items ) );
        }

        /// <summary>
        /// 测试排序变更事件
        /// </summary>
        [Fact]
        public void TestOnSortChange() {
            var attributes = new TagHelperAttributeList { { UiConst.OnSortChange, "a" } };
            var result = new String();
            result.Append( "<thead (nzSortChange)=\"a\">" );
            result.Append( "<tr>" );
            result.Append( "</tr>" );
            result.Append( "</thead>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}