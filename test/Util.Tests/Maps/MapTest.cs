using Util.Maps;
using Util.Tests.Samples;
using Xunit;

namespace Util.Tests.Maps {
    /// <summary>
    /// 对象映射测试
    /// </summary>
    public class MapTest {
        /// <summary>
        /// 测试映射
        /// </summary>
        [Fact]
        public void TestMapTo() {
            Sample sample = new Sample();
            Sample2 sample2 = new Sample2 { StringValue = "a" };
            sample2.MapTo( sample );
            Assert.Equal( "a", sample.StringValue );
        }

        /// <summary>
        /// 测试映射
        /// </summary>
        [Fact]
        public void TestMapTo_2() {
            Sample sample = new Sample { StringValue = "a" };
            Sample2 sample2 = sample.MapTo<Sample2>();
            Assert.Equal( "a", sample2.StringValue );
        }
    }
}
