using Util.Datas.Queries.Criterias;
using Util.Tests.Samples;
using Xunit;

namespace Util.Tests.Datas.Queries.Criterias {
    /// <summary>
    /// 测试整数范围过滤条件
    /// </summary>
    public class IntSegmentCriteriaTest {
        /// <summary>
        /// 测试获取查询条件
        /// </summary>
        [Fact]
        public void TestGetPredicate() {
            IntSegmentCriteria<AggregateRootSample, int> criteria = new IntSegmentCriteria<AggregateRootSample, int>( t => t.Tel, 1, 10 );
            Assert.Equal( "t => ((t.Tel >= 1) AndAlso (t.Tel <= 10))", criteria.GetPredicate().ToString() );

            IntSegmentCriteria<AggregateRootSample, int?> criteria2 = new IntSegmentCriteria<AggregateRootSample, int?>( t => t.Age, 1, 10 );
            Assert.Equal( "t => ((t.Age >= 1) AndAlso (t.Age <= 10))", criteria2.GetPredicate().ToString() );
        }

        /// <summary>
        /// 测试获取查询条件 - 最小值大于最大值，则交换大小值的位置
        /// </summary>
        [Fact]
        public void TestGetPredicate_MinGreaterMax() {
            IntSegmentCriteria<AggregateRootSample, int> criteria = new IntSegmentCriteria<AggregateRootSample, int>( t => t.Tel, 10, 1 );
            Assert.Equal( "t => ((t.Tel >= 1) AndAlso (t.Tel <= 10))", criteria.GetPredicate().ToString() );

            IntSegmentCriteria<AggregateRootSample, int?> criteria2 = new IntSegmentCriteria<AggregateRootSample, int?>( t => t.Age, 10, 1 );
            Assert.Equal( "t => ((t.Age >= 1) AndAlso (t.Age <= 10))", criteria2.GetPredicate().ToString() );
        }

        /// <summary>
        /// 测试获取查询条件 - 最小值为空，忽略最小值条件
        /// </summary>
        [Fact]
        public void TestGetPredicate_MinIsNull() {
            IntSegmentCriteria<AggregateRootSample, int> criteria = new IntSegmentCriteria<AggregateRootSample, int>( t => t.Tel, null, 10 );
            Assert.Equal( "t => (t.Tel <= 10)", criteria.GetPredicate().ToString() );

            IntSegmentCriteria<AggregateRootSample, int?> criteria2 = new IntSegmentCriteria<AggregateRootSample, int?>( t => t.Age, null, 10 );
            Assert.Equal( "t => (t.Age <= 10)", criteria2.GetPredicate().ToString() );
        }

        /// <summary>
        /// 测试获取查询条件 - 最大值为空，忽略最大值条件
        /// </summary>
        [Fact]
        public void TestGetPredicate_MaxIsNull() {
            IntSegmentCriteria<AggregateRootSample, int> criteria = new IntSegmentCriteria<AggregateRootSample, int>( t => t.Tel, 1, null );
            Assert.Equal( "t => (t.Tel >= 1)", criteria.GetPredicate().ToString() );

            IntSegmentCriteria<AggregateRootSample, int?> criteria2 = new IntSegmentCriteria<AggregateRootSample, int?>( t => t.Age, 1, null );
            Assert.Equal( "t => (t.Age >= 1)", criteria2.GetPredicate().ToString() );
        }

        /// <summary>
        /// 测试获取查询条件 - 最大值和最小值均为null,忽略所有条件
        /// </summary>
        [Fact]
        public void Test_BothNull() {
            IntSegmentCriteria<AggregateRootSample, int> criteria = new IntSegmentCriteria<AggregateRootSample, int>( t => t.Tel, null, null );
            Assert.Null( criteria.GetPredicate() );

            IntSegmentCriteria<AggregateRootSample, int?> criteria2 = new IntSegmentCriteria<AggregateRootSample, int?>( t => t.Age, null, null );
            Assert.Null( criteria2.GetPredicate() );
        }
    }
}
