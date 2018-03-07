using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.Material.Dialogs.TagHelpers;
using Util.Ui.Material.Enums;
using Util.Ui.Tests.XUnitHelpers;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Tests.Material.Dialogs {
    /// <summary>
    /// 弹出层操作测试
    /// </summary>
    public class DialogActionTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 弹出层操作
        /// </summary>
        private readonly DialogActionTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public DialogActionTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new DialogActionTagHelper();
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
            result.Append( "<mat-dialog-actions></mat-dialog-actions>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<mat-dialog-actions #a=\"\"></mat-dialog-actions>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试对齐方式
        /// </summary>
        [Fact]
        public void TestAlign() {
            var attributes = new TagHelperAttributeList { { UiConst.Align, Align.Right } };
            var result = new String();
            result.Append( "<mat-dialog-actions align=\"end\"></mat-dialog-actions>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}