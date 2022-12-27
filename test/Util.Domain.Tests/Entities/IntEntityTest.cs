using Util.Domain.Tests.Samples;
using Xunit;

namespace Util.Domain.Tests.Entities {
    /// <summary>
    /// int标识实体测试
    /// </summary>
    public class IntEntityTest {
        /// <summary>
        /// 测试初始化
        /// </summary>
        public IntEntityTest() {
            _sample = new IntAggregateRootSample();
            _sample2 = new IntAggregateRootSample();
        }

        /// <summary>
        /// 聚合根测试样例
        /// </summary>
        private IntAggregateRootSample _sample;
        /// <summary>
        /// 聚合根测试样例2
        /// </summary>
        private IntAggregateRootSample _sample2;

        /// <summary>
        /// 测试实体相等性 - 当两个实体的标识相同，则实体相同
        /// </summary>
        [Fact]
        public void TestEquals_IdEquals() {
            _sample = new IntAggregateRootSample( 1 );
            _sample2 = new IntAggregateRootSample( 1 );
            Assert.True( _sample.Equals( _sample2 ) );
            Assert.True( _sample == _sample2 );
            Assert.False( _sample != _sample2 );
        }

        /// <summary>
        /// 测试实体相等性 - Id为空
        /// </summary>
        [Fact]
        public void TestEquals_Id_Empty() {
            _sample = new IntAggregateRootSample( 0 );
            _sample2 = new IntAggregateRootSample( 1 );
            Assert.False( _sample.Equals( _sample2 ) );
            Assert.False( _sample == _sample2 );
            Assert.False( _sample2 == _sample );
        }
    }
}