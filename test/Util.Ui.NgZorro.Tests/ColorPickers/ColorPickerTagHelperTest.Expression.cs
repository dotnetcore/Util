using System.Text;
using Xunit;

namespace Util.Ui.NgZorro.Tests.ColorPickers {
    /// <summary>
    /// 颜色选择测试 - 表达式解析测试
    /// </summary>
    public partial class ColorPickerTagHelperTest {
        /// <summary>
        /// 测试解析表达式属性for
        /// </summary>
        [Fact]
        public void TestFor_1() {
            _wrapper.SetExpression( t => t.Name );
            var result = new StringBuilder();
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>姓名</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<nz-color-picker #name=\"\" name=\"name\" " );
            result.Append( "[(ngModel)]=\"model.name\">" );
            result.Append( "</nz-color-picker>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}