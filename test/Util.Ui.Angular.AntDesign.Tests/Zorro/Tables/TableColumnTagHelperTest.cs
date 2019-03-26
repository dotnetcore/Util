using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.AntDesign.Tests.XUnitHelpers;
using Util.Ui.Angular.Enums;
using Util.Ui.Configs;
using Util.Ui.Zorro.Tables;
using Util.Ui.Zorro.Tables.Configs;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Angular.AntDesign.Tests.Zorro.Tables {
    /// <summary>
    /// 表格列测试
    /// </summary>
    public class TableColumnTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 表格列
        /// </summary>
        private readonly ColumnTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public TableColumnTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new ColumnTagHelper();
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
            result.Append( "<td></td>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<td #a=\"\"></td>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试列名称
        /// </summary>
        [Fact]
        public void TestColumn() {
            var attributes = new TagHelperAttributeList { { UiConst.Column, "a" } };
            var result = new String();
            result.Append( "<td>{{row.a}}</td>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置复选框类型
        /// </summary>
        [Fact]
        public void TestType_Checkbox() {
            var attributes = new TagHelperAttributeList { { UiConst.Type, TableColumnType.Checkbox } };
            var items = new Dictionary<object, object> { { TableConfig.TableShareKey, new TableShareConfig( "id" ) } };
            var result = new String();
            result.Append( "" );
            result.Append( "<td (click)=\"$event.stopPropagation()\" (nzCheckedChange)=\"id_wrapper.checkedSelection.toggle(row)\" nzShowCheckbox=\"\" " );
            result.Append( "[nzChecked]=\"id_wrapper.checkedSelection.isSelected(row)\">" );
            result.Append( "</td>" );
             Assert.Equal( result.ToString(), GetResult( attributes, items: items ) );
        }
    }
}