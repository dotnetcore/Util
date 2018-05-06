using NSubstitute;
using Util.Domains.Trees;
using Xunit;

namespace Util.Tests {
    /// <summary>
    /// 扩展测试 - 树型扩展
    /// </summary>
    public partial class ExtensionTest {
        /// <summary>
        /// 检查空值，不为空则正常执行
        /// </summary>
        [Fact]
        public void TestSwapSort() {
            var entity = Substitute.For<ISortId>();
            var swapEntity = Substitute.For<ISortId>();
            entity.SortId = 1;
            swapEntity.SortId = 2;
            entity.SwapSort( swapEntity );
            Assert.Equal( 2,entity.SortId );
            Assert.Equal( 1, swapEntity.SortId );
        }
    }
}
