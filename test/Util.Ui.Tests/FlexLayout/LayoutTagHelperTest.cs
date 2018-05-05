using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular;
using Util.Ui.Configs;
using Util.Ui.FlexLayout.Enums;
using Util.Ui.FlexLayout.TagHelpers;
using Util.Ui.Tests.XUnitHelpers;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Tests.FlexLayout {
    /// <summary>
    /// 浮动布局测试
    /// </summary>
    public class LayoutTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 浮动布局
        /// </summary>
        private readonly LayoutTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public LayoutTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new LayoutTagHelper();
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
            result.Append( "<div fxLayout=\"row\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<div #a=\"\" fxLayout=\"row\"></div>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试布局方向
        /// </summary>
        [Fact]
        public void TestDirection() {
            var attributes = new TagHelperAttributeList { { UiConst.Direction, LayoutDirection.Column } };
            var result = new String();
            result.Append( "<div fxLayout=\"column\"></div>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试布局方向
        /// </summary>
        [Fact]
        public void TestDirection_Xs() {
            var attributes = new TagHelperAttributeList { { $"{UiConst.Direction}-xs", LayoutDirection.Column } };
            var result = new String();
            result.Append( "<div fxLayout.xs=\"column\"></div>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试X轴水平对齐方式
        /// </summary>
        [Fact]
        public void TestXAlign() {
            var attributes = new TagHelperAttributeList { { UiConst.XAlign, XAlign.End } };
            var result = new String();
            result.Append( "<div fxLayout=\"row\" fxLayoutAlign=\"end start\"></div>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试Y轴水平对齐方式
        /// </summary>
        [Fact]
        public void TestYAlign() {
            var attributes = new TagHelperAttributeList { { UiConst.YAlign, YAlign.End } };
            var result = new String();
            result.Append( "<div fxLayout=\"row\" fxLayoutAlign=\"start end\"></div>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试单元格间隙
        /// </summary>
        [Fact]
        public void TestGap() {
            var attributes = new TagHelperAttributeList { { UiConst.Gap, "a" } };
            var result = new String();
            result.Append( "<div fxLayout=\"row\" fxLayoutGap=\"a\"></div>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试单元格间隙 - 添加默认单位
        /// </summary>
        [Fact]
        public void TestGap_Unit() {
            var attributes = new TagHelperAttributeList { { UiConst.Gap, "1" } };
            var result = new String();
            result.Append( "<div fxLayout=\"row\" fxLayoutGap=\"1px\"></div>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试布局策略
        /// </summary>
        [Fact]
        public void TestFlex() {
            var attributes = new TagHelperAttributeList { { UiConst.Flex, "a" } };
            var result = new String();
            result.Append( "<div fxLayout=\"row\"><div fxFlex=\"a\"></div></div>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试换行
        /// </summary>
        [Fact]
        public void TestWrap() {
            var attributes = new TagHelperAttributeList { { UiConst.Wrap, true } };
            var result = new String();
            result.Append( "<div fxLayout=\"row wrap\"></div>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试If
        /// </summary>
        [Fact]
        public void TestIf() {
            var attributes = new TagHelperAttributeList { { AngularConst.NgIf, "a" } };
            var result = new String();
            result.Append( "<div *ngIf=\"a\" fxLayout=\"row\"></div>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}