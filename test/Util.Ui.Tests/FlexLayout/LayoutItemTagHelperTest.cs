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
    /// 布局项测试
    /// </summary>
    public class LayoutItemTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 布局项
        /// </summary>
        private readonly LayoutItemTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public LayoutItemTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new LayoutItemTagHelper();
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
            result.Append( "<div fxFlex=\"1 1 auto\"></div>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<div #a=\"\" fxFlex=\"1 1 auto\"></div>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试尺寸调整策略
        /// </summary>
        [Fact]
        public void TestFlex() {
            var attributes = new TagHelperAttributeList { { UiConst.Flex, "a" } };
            var result = new String();
            result.Append( "<div fxFlex=\"a\"></div>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试尺寸调整策略
        /// </summary>
        [Fact]
        public void TestFlex_Xs() {
            var attributes = new TagHelperAttributeList { { $"{UiConst.Flex}-xs", "a" } };
            var result = new String();
            result.Append( "<div fxFlex.xs=\"a\"></div>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试尺寸调整策略
        /// </summary>
        [Fact]
        public void TestFlex_Sm() {
            var attributes = new TagHelperAttributeList { { $"{UiConst.Flex}-sm", "a" } };
            var result = new String();
            result.Append( "<div fxFlex.sm=\"a\"></div>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试尺寸调整策略
        /// </summary>
        [Fact]
        public void TestFlex_Md() {
            var attributes = new TagHelperAttributeList { { $"{UiConst.Flex}-md", "a" } };
            var result = new String();
            result.Append( "<div fxFlex.md=\"a\"></div>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试尺寸调整策略
        /// </summary>
        [Fact]
        public void TestFlex_Lg() {
            var attributes = new TagHelperAttributeList { { $"{UiConst.Flex}-lg", "a" } };
            var result = new String();
            result.Append( "<div fxFlex.lg=\"a\"></div>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试尺寸调整策略
        /// </summary>
        [Fact]
        public void TestFlex_Xl() {
            var attributes = new TagHelperAttributeList { { $"{UiConst.Flex}-xl", "a" } };
            var result = new String();
            result.Append( "<div fxFlex.xl=\"a\"></div>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试排序
        /// </summary>
        [Fact]
        public void TestOrder() {
            var attributes = new TagHelperAttributeList { { UiConst.Order, 1 } };
            var result = new String();
            result.Append( "<div fxFlex=\"1 1 auto\" fxFlexOrder=\"1\"></div>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试偏移量
        /// </summary>
        [Fact]
        public void TestOffset() {
            var attributes = new TagHelperAttributeList { { UiConst.Offset, "a" } };
            var result = new String();
            result.Append( "<div fxFlex=\"1 1 auto\" fxFlexOffset=\"a\"></div>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试对齐方式
        /// </summary>
        [Fact]
        public void TestAlign() {
            var attributes = new TagHelperAttributeList { { UiConst.Align, FlexAlign.Baseline } };
            var result = new String();
            result.Append( "<div fxFlex=\"1 1 auto\" fxFlexAlign=\"baseline\"></div>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试填充
        /// </summary>
        [Fact]
        public void TestFill() {
            var attributes = new TagHelperAttributeList { { UiConst.Fill, true } };
            var result = new String();
            result.Append( "<div fxFlex=\"1 1 auto\" fxFlexFill=\"\"></div>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试ngIf
        /// </summary>
        [Fact]
        public void TestNgIf() {
            var attributes = new TagHelperAttributeList { { AngularConst.NgIf, "a" } };
            var result = new String();
            result.Append( "<div *ngIf=\"a\" fxFlex=\"1 1 auto\"></div>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试ng-for
        /// </summary>
        [Fact]
        public void TestNgFor() {
            var attributes = new TagHelperAttributeList { { AngularConst.NgFor, "a" } };
            var result = new String();
            result.Append( "<div *ngFor=\"a\" fxFlex=\"1 1 auto\"></div>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}