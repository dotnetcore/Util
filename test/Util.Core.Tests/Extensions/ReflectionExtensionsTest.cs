using System.Linq;
using Util.Tests.Samples;
using Xunit;

namespace Util.Tests.Extensions {
    /// <summary>
    /// 反射扩展测试
    /// </summary>
    public class ReflectionExtensionsTest {
        /// <summary>
        /// 测试安全获取值
        /// </summary>
        [Fact]
        public void TestSafeValue() {
            Sample sample = new Sample { StringValue = "A" };
            var member = sample.GetType().GetMember( "StringValue" ).First();
            Assert.Equal( "A", member.GetPropertyValue( sample ) );
        }
    }
}
