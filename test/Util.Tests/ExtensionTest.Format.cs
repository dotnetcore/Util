using Xunit;

namespace Util.Tests {
    /// <summary>
    /// 扩展测试 - 格式化
    /// </summary>
    public partial class ExtensionTest {
        /// <summary>
        /// 测试获取布尔值描述
        /// </summary>
        [Fact]
        public void TestDescription_Bool() {
            bool? value = null;
            Assert.Equal( "", value.Description() );
            Assert.Equal( "是", true.Description() );
            Assert.Equal( "否", false.Description() );
        }
    }
}
