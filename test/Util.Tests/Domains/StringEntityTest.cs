using Util.Exceptions;
using Util.Tests.Samples;
using Util.Tests.XUnitHelpers;
using Xunit;

namespace Util.Tests.Domains {
    /// <summary>
    /// string标识实体测试
    /// </summary>
    public class StringEntityTest {
        /// <summary>
        /// 测试初始化
        /// </summary>
        public StringEntityTest() {
            _sample = new StringAggregateRootSample();
            _sample2 = new StringAggregateRootSample();
        }

        /// <summary>
        /// 聚合根测试样例
        /// </summary>
        private StringAggregateRootSample _sample;
        /// <summary>
        /// 聚合根测试样例2
        /// </summary>
        private StringAggregateRootSample _sample2;

        /// <summary>
        /// 测试实体相等性 - 当两个实体的标识相同，则实体相同
        /// </summary>
        [Fact]
        public void TestEquals_IdEquals() {
            _sample = new StringAggregateRootSample( "a" );
            _sample2 = new StringAggregateRootSample( "a" );
            Assert.True( _sample.Equals( _sample2 ) );
            Assert.True( _sample == _sample2 );
            Assert.False( _sample != _sample2 );
        }

        /// <summary>
        /// 测试实体相等性 - Id为空
        /// </summary>
        [Fact]
        public void TestEquals_Id_Null() {
            _sample = new StringAggregateRootSample( null );
            _sample2 = new StringAggregateRootSample( "a" );
            Assert.False( _sample.Equals( _sample2 ) );
            Assert.False( _sample == _sample2 );
            Assert.False( _sample2 == _sample );

            _sample = new StringAggregateRootSample( "a" );
            _sample2 = new StringAggregateRootSample( null );
            Assert.False( _sample.Equals( _sample2 ) );
            Assert.False( _sample == _sample2 );
            Assert.False( _sample2 == _sample );
        }

        /// <summary>
        /// 测试状态输出
        /// </summary>
        [Fact]
        public void TestToString() {
            _sample = new StringAggregateRootSample { Name = "a" };
            Assert.Equal( string.Format( "Id:{0},姓名:a", _sample.Id ), _sample.ToString() );
        }

        /// <summary>
        /// 测试验证 - Id为空，无法通过
        /// </summary>
        [Fact]
        public void TestValidate_IdIsEmpty() {
            AssertHelper.Throws<Warning>( () => {
                _sample = new StringAggregateRootSample( null );
                _sample.Validate();
            }, "Id" );
            AssertHelper.Throws<Warning>( () => {
                _sample = new StringAggregateRootSample( "" );
                _sample.Validate();
            }, "Id" );
        }
    }
}