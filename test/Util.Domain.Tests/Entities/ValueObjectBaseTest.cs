using Util.Domain.Tests.Samples;
using Xunit;

namespace Util.Domain.Tests.Entities {
    /// <summary>
    /// 测试值对象
    /// </summary>
    public class ValueObjectBaseTest {
        /// <summary>
        /// 测试初始化
        /// </summary>
        public ValueObjectBaseTest() {
            _sample = new ValueObjectSample( "a", "b" );
            _sample2 = new ValueObjectSample( "a", "b" );
            _sample3 = new ValueObjectSample( "1", "" );
            _aggregateRootSample = new AggregateRootSample();
            _sample4 = new ValueObjectSample( "a", "b", _aggregateRootSample );
            _sample5 = new ValueObjectSample( "a", "b", _aggregateRootSample );
            _sample6 = new ValueObjectSample( "a", "b", _aggregateRootSample, new ValueObjectSample( "a", "b" ) );
            _sample7 = new ValueObjectSample( "a", "b", _aggregateRootSample, new ValueObjectSample( "a", "b" ) );
        }

        /// <summary>
        /// 值对象测试样例1
        /// </summary>
        private ValueObjectSample _sample;
        /// <summary>
        /// 值对象测试样例2
        /// </summary>
        private ValueObjectSample _sample2;
        /// <summary>
        /// 值对象测试样例3
        /// </summary>
        private ValueObjectSample _sample3;
        /// <summary>
        /// 值对象测试样例4
        /// </summary>
        private ValueObjectSample _sample4;
        /// <summary>
        /// 值对象测试样例5
        /// </summary>
        private ValueObjectSample _sample5;
        /// <summary>
        /// 值对象测试样例6
        /// </summary>
        private ValueObjectSample _sample6;
        /// <summary>
        /// 值对象测试样例7
        /// </summary>
        private ValueObjectSample _sample7;
        /// <summary>
        /// 聚合根测试样例
        /// </summary>
        private AggregateRootSample _aggregateRootSample;

        /// <summary>
        /// 测试对象相等性
        /// </summary>
        [Fact]
        public void TestEquals() {            
            Assert.False( _sample.Equals( new AggregateRootSample() ) );
            Assert.True( _sample.Equals( _sample2 ), "1" );
            Assert.True( _sample == _sample2, "2" );
            Assert.False( _sample != _sample2, "3" );
            Assert.False( _sample == _sample3, "4" );
            Assert.True( _sample4 == _sample5, "5" );
            Assert.True( _sample4.Equals( _sample5 ), "6" );
            Assert.False( _sample6 == _sample7, "7" );
            Assert.False( _sample6.Equals( _sample7 ), "8" );
        }

        /// <summary>
        /// 测试对象相等性 - 判空
        /// </summary>
        [Fact]
        public void TestEquals_Null() {
            Assert.False( _sample.Equals( null ) );
            Assert.False( _sample == null );
            Assert.False( null == _sample );
            Assert.True( _sample != null );

            _sample2 = null;
            Assert.False( _sample.Equals( _sample2 ) );

            _sample = null;
            Assert.False( _sample == _sample2 );
            Assert.False( _sample2 == _sample );
        }

        /// <summary>
        /// 测试哈希
        /// </summary>
        [Fact]
        public void TestGetHashCode() {
            Assert.True( _sample.GetHashCode() == _sample2.GetHashCode() );
        }

        /// <summary>
        /// 测试克隆
        /// </summary>
        [Fact]
        public void TestClone() {
            _sample3 = _sample.Clone();
            Assert.NotSame( _sample, _sample3 );
            Assert.True( _sample == _sample3 );
            Assert.Equal( "a", _sample3.City );

            _sample = _sample6.Clone();
            Assert.True( _sample == _sample6 );
            Assert.Equal( "a", _sample.Child.City );
            Assert.Same( _sample.Child, _sample6.Child );
        }
    }
}
