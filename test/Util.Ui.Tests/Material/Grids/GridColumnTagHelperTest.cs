using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.Material.Grids.TagHelpers;
using Util.Ui.Tests.XUnitHelpers;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Tests.Material.Grids {
    /// <summary>
    /// 栅格列测试
    /// </summary>
    public class GridColumnTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 栅格列
        /// </summary>
        private readonly GridColumnTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public GridColumnTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new GridColumnTagHelper();
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
            result.Append( "<mat-grid-tile></mat-grid-tile>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<mat-grid-tile #a=\"\"></mat-grid-tile>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试合并列
        /// </summary>
        [Fact]
        public void TestColspan() {
            var attributes = new TagHelperAttributeList { { UiConst.Colspan, 2 } };
            var result = new String();
            result.Append( "<mat-grid-tile colspan=\"2\"></mat-grid-tile>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试用于左边占位的合并列
        /// </summary>
        [Fact]
        public void TestBeforeColspan() {
            var attributes = new TagHelperAttributeList { { UiConst.BeforeColspan, 2 } };
            var result = new String();
            result.Append( "<mat-grid-tile colspan=\"2\"></mat-grid-tile><mat-grid-tile></mat-grid-tile>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试用于右边占位的合并列
        /// </summary>
        [Fact]
        public void TestAfterColspan() {
            var attributes = new TagHelperAttributeList { { UiConst.AfterColspan, 2 } };
            var result = new String();
            result.Append( "<mat-grid-tile></mat-grid-tile><mat-grid-tile colspan=\"2\"></mat-grid-tile>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试合并行
        /// </summary>
        [Fact]
        public void TestRowspan() {
            var attributes = new TagHelperAttributeList { { UiConst.Rowspan, 2 } };
            var result = new String();
            result.Append( "<mat-grid-tile rowspan=\"2\"></mat-grid-tile>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}