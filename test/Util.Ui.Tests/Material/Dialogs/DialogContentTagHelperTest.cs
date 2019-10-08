using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.Material.Dialogs.TagHelpers;
using Util.Ui.Tests.XUnitHelpers;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Tests.Material.Dialogs {
    /// <summary>
    /// 弹出层内容测试
    /// </summary>
    public class DialogContentTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 弹出层内容
        /// </summary>
        private readonly DialogContentTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public DialogContentTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new DialogContentTagHelper();
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
            result.Append( "<mat-dialog-content></mat-dialog-content>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<mat-dialog-content #a=\"\"></mat-dialog-content>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}