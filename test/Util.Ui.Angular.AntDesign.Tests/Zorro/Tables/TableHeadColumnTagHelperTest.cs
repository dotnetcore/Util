using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Properties;
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

        /// <summary>
        /// 测试设置复选框类型
        /// </summary>
        [Fact]
        public void TestType_Checkbox() {
            var attributes = new TagHelperAttributeList { { UiConst.Type, TableColumnType.Checkbox } };
            var items = new Dictionary<object, object> { { TableConfig.TableShareKey, new TableShareConfig( "id" ) } };
            var result = new String();
            result.Append( "<th (nzCheckedChange)=\"id_wrapper.masterToggle()\" nzShowCheckbox=\"\" nzWidth=\"30px\" " );
            result.Append( "[nzChecked]=\"id_wrapper.isMasterChecked()\" " );
            result.Append( "[nzDisabled]=\"!id_wrapper.dataSource.length\" [nzIndeterminate]=\"id_wrapper.isMasterIndeterminate()\">" );
            result.Append( "</th>" );
            Assert.Equal( result.ToString(), GetResult( attributes, items: items ) );
        }

        /// <summary>
        /// 测试设置序号类型
        /// </summary>
        [Fact]
        public void TestType_LineNumber() {
            var attributes = new TagHelperAttributeList { { UiConst.Type, TableColumnType.LineNumber } };
            var result = new String();
            result.Append( $"<th nzWidth=\"70px\">{R.LineNumber}</th>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试排序
        /// </summary>
        [Fact]
        public void TestSort() {
            var attributes = new TagHelperAttributeList { { UiConst.Sort, "a" } };
            var result = new String();
            result.Append( "<th nzSortKey=\"a\" [nzShowSort]=\"true\"></th>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试宽度
        /// </summary>
        [Fact]
        public void TestWidth() {
            var attributes = new TagHelperAttributeList { { UiConst.Width, "a" } };
            var result = new String();
            result.Append( "<th nzWidth=\"a\"></th>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试宽度,如果是数值，添加px
        /// </summary>
        [Fact]
        public void TestWidth_Number() {
            var attributes = new TagHelperAttributeList { { UiConst.Width, "100" } };
            var result = new String();
            result.Append( "<th nzWidth=\"100px\"></th>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}