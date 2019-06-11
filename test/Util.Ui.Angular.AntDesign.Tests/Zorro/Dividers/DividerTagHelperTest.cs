using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.AntDesign.Tests.XUnitHelpers;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.Zorro.Dividers;
using Xunit;
using Xunit.Abstractions;
using String = Util.Helpers.String;

namespace Util.Ui.Angular.AntDesign.Tests.Zorro.Dividers {
    /// <summary>
    /// 分隔线测试
    /// </summary>
    public class DividerTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 分隔线
        /// </summary>
        private readonly DividerTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public DividerTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new DividerTagHelper();
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
            result.Append( "<nz-divider></nz-divider>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试添加标识
        /// </summary>
        [Fact]
        public void TestId() {
            var attributes = new TagHelperAttributeList { { UiConst.Id, "a" } };
            var result = new String();
            result.Append( "<nz-divider #a=\"\"></nz-divider>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试虚线
        /// </summary>
        [Fact]
        public void TestDashed() {
            var attributes = new TagHelperAttributeList { { UiConst.Dashed, true } };
            var result = new String();
            result.Append( "<nz-divider [nzDashed]=\"true\"></nz-divider>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置垂直方向
        /// </summary>
        [Fact]
        public void TestVertical() {
            var attributes = new TagHelperAttributeList { { UiConst.Vertical, true } };
            var result = new String();
            result.Append( "<nz-divider nzType=\"vertical\"></nz-divider>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置文字
        /// </summary>
        [Fact]
        public void TestText() {
            var attributes = new TagHelperAttributeList { { UiConst.Text, "a" } };
            var result = new String();
            result.Append( "<nz-divider nzText=\"a\"></nz-divider>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }

        /// <summary>
        /// 测试设置文字方向
        /// </summary>
        [Fact]
        public void TestOrientation() {
            var attributes = new TagHelperAttributeList { { UiConst.Orientation, Orientation.Right } };
            var result = new String();
            result.Append( "<nz-divider nzOrientation=\"right\"></nz-divider>" );
            Assert.Equal( result.ToString(), GetResult( attributes ) );
        }
    }
}