using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Material;
using Util.Ui.Material.Buttons.TagHelpers;
using Util.Ui.Material.Enums;
using Util.Ui.Tests.XUnitHelpers;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Tests.Material.Buttons {
    /// <summary>
    /// 按钮测试
    /// </summary>
    public class ButtonTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 按钮
        /// </summary>
        private readonly ButtonTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public ButtonTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new ButtonTagHelper();
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
            result.Append( "<mat-button-wrapper></mat-button-wrapper>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<mat-button-wrapper #a=\"\"></mat-button-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试文本
        /// </summary>
        [Fact]
        public void TestText() {
            var attributes = new TagHelperAttributeList { { UiConst.Text, "a" } };
            var result = new String();
            result.Append( "<mat-button-wrapper text=\"a\"></mat-button-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试绑定文本
        /// </summary>
        [Fact]
        public void TestBindText() {
            var attributes = new TagHelperAttributeList { { AngularConst.BindText, "a" } };
            var result = new String();
            result.Append( "<mat-button-wrapper [text]=\"a\"></mat-button-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试ngClass
        /// </summary>
        [Fact]
        public void TestNgClass() {
            var attributes = new TagHelperAttributeList { { AngularConst.NgClass, "a" } };
            var result = new String();
            result.Append( "<mat-button-wrapper [ngClass]=\"a\"></mat-button-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试类型
        /// </summary>
        [Fact]
        public void TestType() {
            var attributes = new TagHelperAttributeList { { UiConst.Type, ButtonType.Reset } };
            var result = new String();
            result.Append( "<mat-button-wrapper type=\"reset\"></mat-button-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试样式
        /// </summary>
        [Fact]
        public void TestStyle() {
            var attributes = new TagHelperAttributeList { { UiConst.Styles, ButtonStyle.Fab } };
            var result = new String();
            result.Append( "<mat-button-wrapper style=\"mat-fab\"></mat-button-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试颜色
        /// </summary>
        [Fact]
        public void TestColor() {
            var attributes = new TagHelperAttributeList { { UiConst.Color, Color.Primary } };
            var result = new String();
            result.Append( "<mat-button-wrapper color=\"primary\"></mat-button-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            var attributes = new TagHelperAttributeList { { UiConst.Disabled, "a" } };
            var result = new String();
            result.Append( "<mat-button-wrapper [disabled]=\"a\"></mat-button-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试提示
        /// </summary>
        [Fact]
        public void TestTooltip() {
            var attributes = new TagHelperAttributeList { { UiConst.Tooltip, "a" } };
            var result = new String();
            result.Append( "<mat-button-wrapper tooltip=\"a\"></mat-button-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试单击事件
        /// </summary>
        [Fact]
        public void TestOnClick() {
            var attributes = new TagHelperAttributeList { { UiConst.OnClick, "a" } };
            var result = new String();
            result.Append( "<mat-button-wrapper (onClick)=\"a\"></mat-button-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试等待时显示的文本
        /// </summary>
        [Fact]
        public void TestWaitingText() {
            var attributes = new TagHelperAttributeList { { UiConst.WaitingText, "a" } };
            var result = new String();
            result.Append( "<mat-button-wrapper waitingText=\"a\"></mat-button-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试判断
        /// </summary>
        [Fact]
        public void TestIf() {
            var attributes = new TagHelperAttributeList { { AngularConst.NgIf, "a" } };
            var result = new String();
            result.Append( "<mat-button-wrapper *ngIf=\"a\"></mat-button-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试等待时显示的图标
        /// </summary>
        [Fact]
        public void TestWaitingIcon() {
            var attributes = new TagHelperAttributeList { { UiConst.WaitingIcon, MaterialIcon.Access_Alarm } };
            var result = new String();
            result.Append( "<mat-button-wrapper waitingMatIcon=\"access_alarm\"></mat-button-wrapper>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置菜单标识
        /// </summary>
        [Fact]
        public void TestMenuId() {
            var attributes = new TagHelperAttributeList { { MaterialConst.MenuId, "a" } };
            var result = new String();
            result.Append( "<button mat-raised-button=\"\" type=\"button\" [matMenuTriggerFor]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试关闭弹出层
        /// </summary>
        [Fact]
        public void TestCloseDialog() {
            var attributes = new TagHelperAttributeList { { MaterialConst.CloseDialog, "a" } };
            var result = new String();
            result.Append( "<button mat-dialog-close=\"a\" mat-raised-button=\"\" type=\"button\"></button>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试关闭弹出层,设置文本绑定属性
        /// </summary>
        [Fact]
        public void TestCloseDialog_BindText() {
            var attributes = new TagHelperAttributeList { { MaterialConst.CloseDialog, "a" },{ AngularConst.BindText ,"b"} };
            var result = new String();
            result.Append( "<button mat-dialog-close=\"a\" mat-raised-button=\"\" type=\"button\">{{b}}</button>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试ngClass
        /// </summary>
        [Fact]
        public void TestNgClass_CloseDialog() {
            var attributes = new TagHelperAttributeList { { MaterialConst.CloseDialog, "a" }, { AngularConst.NgClass, "a" } };
            var result = new String();
            result.Append( "<button mat-dialog-close=\"a\" mat-raised-button=\"\" type=\"button\" [ngClass]=\"a\"></button>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试单击事件
        /// </summary>
        [Fact]
        public void TestNgClass_CloseDialog_Click() {
            var attributes = new TagHelperAttributeList { { MaterialConst.CloseDialog, "a" }, { UiConst.OnClick, "a" } };
            var result = new String();
            result.Append( "<button (click)=\"a\" mat-dialog-close=\"a\" mat-raised-button=\"\" type=\"button\"></button>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}
