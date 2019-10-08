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
    /// 表格行测试
    /// </summary>
    public class TableRowTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 表格行
        /// </summary>
        private readonly RowTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public TableRowTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new RowTagHelper();
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
            result.Append( "<tbody>" );
            result.Append( "<tr>" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试父组件设置表格标识
        /// </summary>
        [Fact]
        public void TestSetTableId() {
            IDictionary<object, object> items = new Dictionary<object, object> {
                { TableConfig.TableShareKey, new TableShareConfig( "a" ) }
            };
            var result = new String();
            result.Append( "<tbody>" );
            result.Append( "<tr *ngFor=\"let row of a.data\">" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            Assert.Equal( result.ToString(), GetResult( items: items ) );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<tbody>" );
            result.Append( "<tr #a=\"\">" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试单击行事件
        /// </summary>
        [Fact]
        public void TestOnClick() {
            var attributes = new TagHelperAttributeList { { UiConst.OnClick, "a" } };
            var result = new String();
            result.Append( "<tbody>" );
            result.Append( "<tr (click)=\"a\">" );
            result.Append( "</tr>" );
            result.Append( "</tbody>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}