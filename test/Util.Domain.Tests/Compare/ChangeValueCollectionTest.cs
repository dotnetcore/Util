using Util.Domain.Compare;
using Xunit;

namespace Util.Domain.Tests.Compare {
    /// <summary>
    /// 变更值集合测试
    /// </summary>
    public class ChangeValueCollectionTest {
        /// <summary>
        /// 测试添加1项
        /// </summary>
        [Fact]
        public void TestAdd_1() {
            var result = new ChangeValueCollection { { "a", "b", "1", "2" } }.ToString();
            Assert.Equal( "a(b),原始值:1,新值:2", result );
        }

        /// <summary>
        /// 测试添加2项
        /// </summary>
        [Fact]
        public void TestAdd_2() {
            var result = new ChangeValueCollection { { "a", "b", "1", "2" }, { "c", "d", "3", "4" } }.ToString();
            Assert.Equal( "a(b),原始值:1,新值:2,c(d),原始值:3,新值:4", result );
        }
    }
}
