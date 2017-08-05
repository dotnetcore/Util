using System;
using Util.Datas.Queries.Criterias;
using Util.Tests.Samples;
using Xunit;

namespace Util.Tests.Datas.Queries.Criterias {
    /// <summary>
    /// 测试double范围过滤条件
    /// </summary>
    public class DoubleSegmentCriteriaTest {
        /// <summary>
        /// 测试获取查询条件
        /// </summary>
        [Fact]
        public void TestGetPredicate() {
            DoubleSegmentCriteria<AggregateRootSample, double> criteria = new DoubleSegmentCriteria<AggregateRootSample, double>( t => t.DoubleValue, 1.1, 10.1 );
            Assert.Equal( "t => ((t.DoubleValue >= 1.1) AndAlso (t.DoubleValue <= 10.1))", criteria.GetPredicate().ToString() );

            DoubleSegmentCriteria<AggregateRootSample, double?> criteria2 = new DoubleSegmentCriteria<AggregateRootSample, double?>( t => t.NullableDoubleValue, 1.1, 10.1 );
            Assert.Equal( "t => ((t.NullableDoubleValue >= 1.1) AndAlso (t.NullableDoubleValue <= 10.1))", criteria2.GetPredicate().ToString() );
        }

        /// <summary>
        /// 测试获取查询条件 - 属性为int类型，则发生类型不匹配异常
        /// </summary>
        [Fact]
        public void TestGetPredicate_ValidateType() {
            Assert.Throws<ArgumentException>( () => {
                var criteria = new DoubleSegmentCriteria<AggregateRootSample, int?>( t => t.Age, 1.1, 10.1 );
                var result = criteria.GetPredicate();
            } );
        }

        /// <summary>
        /// 测试获取查询条件 - 最小值大于最大值，则交换大小值的位置
        /// </summary>
        [Fact]
        public void TestGetPredicate_MinGreaterMax() {
            DoubleSegmentCriteria<AggregateRootSample, double> criteria = new DoubleSegmentCriteria<AggregateRootSample, double>( t => t.DoubleValue, 10.1, 1.1 );
            Assert.Equal( "t => ((t.DoubleValue >= 1.1) AndAlso (t.DoubleValue <= 10.1))", criteria.GetPredicate().ToString() );

            DoubleSegmentCriteria<AggregateRootSample, double?> criteria2 = new DoubleSegmentCriteria<AggregateRootSample, double?>( t => t.NullableDoubleValue, 10.1, 1.1 );
            Assert.Equal( "t => ((t.NullableDoubleValue >= 1.1) AndAlso (t.NullableDoubleValue <= 10.1))", criteria2.GetPredicate().ToString() );
        }

        /// <summary>
        /// 测试获取查询条件 - 最小值为空，忽略最小值条件
        /// </summary>
        [Fact]
        public void TestGetPredicate_MinIsNull() {
            DoubleSegmentCriteria<AggregateRootSample, double> criteria = new DoubleSegmentCriteria<AggregateRootSample, double>( t => t.DoubleValue, null, 10.1 );
            Assert.Equal( "t => (t.DoubleValue <= 10.1)", criteria.GetPredicate().ToString() );

            DoubleSegmentCriteria<AggregateRootSample, double?> criteria2 = new DoubleSegmentCriteria<AggregateRootSample, double?>( t => t.NullableDoubleValue, null, 10.1 );
            Assert.Equal( "t => (t.NullableDoubleValue <= 10.1)", criteria2.GetPredicate().ToString() );
        }

        /// <summary>
        /// 测试获取查询条件 - 最大值为空，忽略最大值条件
        /// </summary>
        [Fact]
        public void TestGetPredicate_MaxIsNull() {
            DoubleSegmentCriteria<AggregateRootSample, double> criteria = new DoubleSegmentCriteria<AggregateRootSample, double>( t => t.DoubleValue, 1.1, null );
            Assert.Equal( "t => (t.DoubleValue >= 1.1)", criteria.GetPredicate().ToString() );

            DoubleSegmentCriteria<AggregateRootSample, double?> criteria2 = new DoubleSegmentCriteria<AggregateRootSample, double?>( t => t.NullableDoubleValue, 1.1, null );
            Assert.Equal( "t => (t.NullableDoubleValue >= 1.1)", criteria2.GetPredicate().ToString() );
        }

        /// <summary>
        /// 测试获取查询条件 - 最大值和最小值均为null,忽略所有条件
        /// </summary>
        [Fact]
        public void TestGetPredicate_BothNull() {
            DoubleSegmentCriteria<AggregateRootSample, double> criteria = new DoubleSegmentCriteria<AggregateRootSample, double>( t => t.DoubleValue, null, null );
            Assert.Null( criteria.GetPredicate() );

            DoubleSegmentCriteria<AggregateRootSample, double?> criteria2 = new DoubleSegmentCriteria<AggregateRootSample, double?>( t => t.NullableDoubleValue, null, null );
            Assert.Null( criteria2.GetPredicate() );
        }
    }
}
