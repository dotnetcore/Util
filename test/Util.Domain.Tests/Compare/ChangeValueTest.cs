using Util.Domain.Compare;
using Xunit;

namespace Util.Domain.Tests.Compare {
    /// <summary>
    /// 变更值测试
    /// </summary>
    public class ChangeValueTest {
        /// <summary>
        /// 测试变更值输出结果
        /// </summary>
        [Fact]
        public void TestToString() {
            var result = new ChangeValue( "a", "b", "1", "2" ).ToString();
            Assert.Equal( "a(b),原始值:1,新值:2", result );
        }
    }
}
