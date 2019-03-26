using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Helpers;
using Util.Ui.Angular.AntDesign.Tests.XUnitHelpers;
using Util.Ui.Zorro.Icons;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.Angular.AntDesign.Tests.Zorro.Icons {
    /// <summary>
    /// 图标测试
    /// </summary>
    public class IconTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// 图标
        /// </summary>
        private readonly IconTagHelper _component;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public IconTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _component = new IconTagHelper();
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
            result.Append( "<i nz-icon=\"\"></i>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}
