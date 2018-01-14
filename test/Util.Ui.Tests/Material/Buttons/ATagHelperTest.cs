using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.Material.Buttons.TagHelpers;
using Util.Ui.Material.Enums;
using Util.Ui.Tests.XUnitHelpers;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Tests.Material.Buttons {
    /// <summary>
    /// 链接测试
    /// </summary>
    public class ATagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 按钮
        /// </summary>
        private readonly ATagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public ATagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new ATagHelper();
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
            result.Append( "<mat-a-wrapper></mat-a-wrapper>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<mat-a-wrapper #a=\"\"></mat-a-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试文本
        /// </summary>
        [Fact]
        public void TestText() {
            var attributes = new TagHelperAttributeList { { UiConst.Text, "a" } };
            var result = new String();
            result.Append( "<mat-a-wrapper text=\"a\"></mat-a-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试样式
        /// </summary>
        [Fact]
        public void TestStyle() {
            var attributes = new TagHelperAttributeList { { UiConst.Styles, ButtonStyle.Fab } };
            var result = new String();
            result.Append( "<mat-a-wrapper style=\"mat-fab\"></mat-a-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试颜色
        /// </summary>
        [Fact]
        public void TestColor() {
            var attributes = new TagHelperAttributeList { { UiConst.Color, Color.Primary } };
            var result = new String();
            result.Append( "<mat-a-wrapper color=\"primary\"></mat-a-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            var attributes = new TagHelperAttributeList { { UiConst.Disabled, "a" } };
            var result = new String();
            result.Append( "<mat-a-wrapper [disabled]=\"a\"></mat-a-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试提示
        /// </summary>
        [Fact]
        public void TestTooltip() {
            var attributes = new TagHelperAttributeList { { UiConst.Tooltip, "a" } };
            var result = new String();
            result.Append( "<mat-a-wrapper tooltip=\"a\"></mat-a-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试路由链接地址
        /// </summary>
        [Fact]
        public void TestLink() {
            var attributes = new TagHelperAttributeList { { UiConst.Link, "a" } };
            var result = new String();
            result.Append( "<mat-a-wrapper link=\"a\"></mat-a-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试单击事件
        /// </summary>
        [Fact]
        public void TestOnClick() {
            var attributes = new TagHelperAttributeList { { UiConst.OnClick, "a" } };
            var result = new String();
            result.Append( "<mat-a-wrapper (onClick)=\"a\"></mat-a-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}
