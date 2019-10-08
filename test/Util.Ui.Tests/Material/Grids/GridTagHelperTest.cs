using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Configs;
using Util.Ui.Material;
using Util.Ui.Material.Grids.TagHelpers;
using Util.Ui.Tests.XUnitHelpers;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Tests.Material.Grids {
    /// <summary>
    /// 网格测试
    /// </summary>
    public class GridTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 网格
        /// </summary>
        private readonly GridTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public GridTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new GridTagHelper();
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
            result.Append( "<mat-grid-list></mat-grid-list>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<mat-grid-list #a=\"\"></mat-grid-list>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试列数
        /// </summary>
        [Fact]
        public void TestColumns() {
            var attributes = new TagHelperAttributeList { { UiConst.Columns, 2 } };
            var result = new String();
            result.Append( "<mat-grid-list cols=\"2\"></mat-grid-list>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试行高
        /// </summary>
        [Fact]
        public void TestRowHeight() {
            var attributes = new TagHelperAttributeList { { UiConst.RowHeight, "2" } };
            var result = new String();
            result.Append( "<mat-grid-list rowHeight=\"2px\"></mat-grid-list>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试行高
        /// </summary>
        [Fact]
        public void TestRowHeight_2() {
            var attributes = new TagHelperAttributeList { { UiConst.RowHeight, "2em" } };
            var result = new String();
            result.Append( "<mat-grid-list rowHeight=\"2em\"></mat-grid-list>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试单元格间距
        /// </summary>
        [Fact]
        public void TestGutterSize() {
            var attributes = new TagHelperAttributeList { { MaterialConst.GutterSize, "2" } };
            var result = new String();
            result.Append( "<mat-grid-list gutterSize=\"2px\"></mat-grid-list>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试单元格间距
        /// </summary>
        [Fact]
        public void TestGutterSize_2() {
            var attributes = new TagHelperAttributeList { { MaterialConst.GutterSize, "2em" } };
            var result = new String();
            result.Append( "<mat-grid-list gutterSize=\"2em\"></mat-grid-list>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}