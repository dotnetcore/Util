using System.Text;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Checkboxes {
    /// <summary>
    /// 复选框测试 - 表达式解析测试
    /// </summary>
    public partial class CheckboxTagHelperTest {
        /// <summary>
        /// 测试解析表达式属性for
        /// </summary>
        [Fact]
        public void TestFor_1() {
            _wrapper.SetExpression( t => t.Code );
            var result = new StringBuilder();
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label>code</nz-form-label>" );
            result.Append( "<nz-form-control>" );
            result.Append( "<label name=\"code\" nz-checkbox=\"\" [(ngModel)]=\"model.code\"></label>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}
