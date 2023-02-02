using System.Text;
using Xunit;

namespace Util.Ui.NgZorro.Tests.Switches {
    /// <summary>
    /// 开关测试 - 表达式解析测试
    /// </summary>
    public partial class SwitchTagHelperTest {
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
            result.Append( "<nz-switch name=\"code\" [(ngModel)]=\"model.code\"></nz-switch>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}
