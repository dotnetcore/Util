using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Helpers;
using Util.Ui.Angular.AntDesign.Tests.XUnitHelpers;
using Util.Ui.Configs;
using Util.Ui.Zorro.Tables;
using Util.Ui.Zorro.Tables.Configs;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.Angular.AntDesign.Tests.Zorro.Tables {
    /// <summary>
    /// 表格编辑列显示内容测试
    /// </summary>
    public class DisplayTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 表格编辑列显示内容
        /// </summary>
        private readonly DisplayTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public DisplayTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new DisplayTagHelper();
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
            result.Append( "<ng-container></ng-container>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试设置内容
        /// </summary>
        [Fact]
        public void TestContent() {
            var result = new String();
            result.Append( "<ng-container *ngIf=\"id_edit.editId !== row.id;else id_edit_a\">" );
            result.Append( "content" );
            result.Append( "</ng-container>" );

            TagHelperContent content = new DefaultTagHelperContent();
            content.AppendHtml( "content" );
            var config = new ColumnShareConfig( new TableShareConfig( "id" ), "a" );
            var items = new Dictionary<object, object> { { typeof( ColumnShareConfig ), config } };

            Assert.Equal( result.ToString(), GetResult( items: items,content:content ) );
        }
    }
}
