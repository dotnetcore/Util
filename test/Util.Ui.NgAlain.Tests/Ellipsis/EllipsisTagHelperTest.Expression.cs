using System.Text;
using Xunit;

namespace Util.Ui.NgAlain.Tests.Ellipsis;

/// <summary>
/// 文本省略组件测试
/// </summary>
public partial class EllipsisTagHelperTest {
    /// <summary>
    /// 测试解析表达式属性for
    /// </summary>
    [Fact]
    public void TestFor_1() {
            _wrapper.SetExpression( t => t.Code );
            var result = new StringBuilder();
            result.Append( "<ellipsis>" );
            result.Append( "{{model.code}}" );
            result.Append( "</ellipsis>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
}