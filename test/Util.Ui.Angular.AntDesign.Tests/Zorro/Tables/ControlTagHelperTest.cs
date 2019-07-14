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
    /// 表格列编辑控件测试
    /// </summary>
    public class ControlTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 表格列编辑控件
        /// </summary>
        private readonly ControlTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public ControlTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new ControlTagHelper();
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
            result.Append( "<ng-template></ng-template>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<ng-template #a=\"\"></ng-template>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置模板标识
        /// </summary>
        [Fact]
        public void TestTemplateId() {
            var config = new ColumnShareConfig( new TableShareConfig( "id" ), "a" );
            var items = new Dictionary<object, object> { { typeof( ColumnShareConfig ), config } };
            var result = new String();
            result.Append( "<ng-template #id_edit_a=\"\"></ng-template>" );
            Assert.Equal( result.ToString(), GetResult( items: items ) );
        }
    }
}
