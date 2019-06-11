using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.AntDesign.Tests.XUnitHelpers;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Zorro.Buttons;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Angular.AntDesign.Tests.Zorro {
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
            result.Append( "<x-button></x-button>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<x-button #a=\"\"></x-button>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试文本
        /// </summary>
        [Fact]
        public void TestText() {
            var attributes = new TagHelperAttributeList { { UiConst.Text, "a" } };
            var result = new String();
            result.Append( "<x-button text=\"a\"></x-button>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试文本 - 空值允许覆盖
        /// </summary>
        [Fact]
        public void TestText_Empty() {
            var attributes = new TagHelperAttributeList { { UiConst.Text, "" } };
            var result = new String();
            result.Append( "<x-button text=\"\"></x-button>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试绑定文本
        /// </summary>
        [Fact]
        public void TestBindText() {
            var attributes = new TagHelperAttributeList { { AngularConst.BindText, "a" } };
            var result = new String();
            result.Append( "<x-button [text]=\"a\"></x-button>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试是否验证表单
        /// </summary>
        [Fact]
        public void TestValidateForm() {
            var attributes = new TagHelperAttributeList { { UiConst.ValidateForm, true } };
            var result = new String();
            result.Append( "<x-button [validateForm]=\"true\"></x-button>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试ngClass
        /// </summary>
        [Fact]
        public void TestNgClass() {
            var attributes = new TagHelperAttributeList { { AngularConst.NgClass, "a" } };
            var result = new String();
            result.Append( "<x-button [ngClass]=\"a\"></x-button>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试判断
        /// </summary>
        [Fact]
        public void TestNgIf() {
            var attributes = new TagHelperAttributeList { { AngularConst.NgIf, "a" } };
            var result = new String();
            result.Append( "<x-button *ngIf=\"a\"></x-button>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试颜色
        /// </summary>
        [Fact]
        public void TestColor() {
            var attributes = new TagHelperAttributeList { { UiConst.Color, Color.Primary } };
            var result = new String();
            result.Append( "<x-button color=\"primary\"></x-button>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试禁用
        /// </summary>
        [Fact]
        public void TestDisabled() {
            var attributes = new TagHelperAttributeList { { UiConst.Disabled, "a" } };
            var result = new String();
            result.Append( "<x-button [disabled]=\"a\"></x-button>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试提示
        /// </summary>
        [Fact]
        public void TestTooltip() {
            var attributes = new TagHelperAttributeList { { UiConst.Tooltip, "a" } };
            var result = new String();
            result.Append( "<x-button tooltip=\"a\"></x-button>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试单击事件
        /// </summary>
        [Fact]
        public void TestOnClick() {
            var attributes = new TagHelperAttributeList { { UiConst.OnClick, "a" } };
            var result = new String();
            result.Append( "<x-button (onClick)=\"a\"></x-button>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试按钮尺寸
        /// </summary>
        [Fact]
        public void TestSize() {
            var attributes = new TagHelperAttributeList { { UiConst.Size, ButtonSize.Small } };
            var result = new String();
            result.Append( "<x-button size=\"small\"></x-button>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试按钮形状
        /// </summary>
        [Fact]
        public void TestShape() {
            var attributes = new TagHelperAttributeList { { UiConst.Shape, ButtonShape.Circle } };
            var result = new String();
            result.Append( "<x-button shape=\"circle\"></x-button>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试加载状态
        /// </summary>
        [Fact]
        public void TestLoading() {
            var attributes = new TagHelperAttributeList { { UiConst.Loading,"true" } };
            var result = new String();
            result.Append( "<x-button [loading]=\"true\"></x-button>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试调整为父宽度
        /// </summary>
        [Fact]
        public void TestBlock() {
            var attributes = new TagHelperAttributeList { { UiConst.Block, true } };
            var result = new String();
            result.Append( "<x-button [block]=\"true\"></x-button>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置为透明背景
        /// </summary>
        [Fact]
        public void TestGhost() {
            var attributes = new TagHelperAttributeList { { UiConst.Ghost, true } };
            var result = new String();
            result.Append( "<x-button [ghost]=\"true\"></x-button>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置图标
        /// </summary>
        [Fact]
        public void TestIcon() {
            var attributes = new TagHelperAttributeList { { UiConst.Icon, AntDesignIcon.Check } };
            var result = new String();
            result.Append( "<x-button>" );
            result.Append( "<ng-template>" );
            result.Append( "<i nz-icon=\"\" nzType=\"check\"></i>" );
            result.Append( "</ng-template>" );
            result.Append( "</x-button>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}
