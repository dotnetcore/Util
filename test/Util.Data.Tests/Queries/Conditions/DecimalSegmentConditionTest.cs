using Util.Data.Queries;
using Util.Data.Queries.Conditions;
using Util.Data.Tests.Samples;
using Xunit;

namespace Util.Data.Tests.Queries.Conditions {
    /// <summary>
    /// 测试double范围过滤条件
    /// </summary>
    public class DecimalSegmentConditionTest {
        /// <summary>
        /// 测试获取查询条件
        /// </summary>
        [Fact]
        public void TestGetCondition() {
            DecimalSegmentCondition<Sample, decimal> condition = new DecimalSegmentCondition<Sample, decimal>( t => t.DecimalValue, 1.1M, 10.1M );
            Assert.Equal( "t => ((t.DecimalValue >= 1.1) AndAlso (t.DecimalValue <= 10.1))", condition.GetCondition().ToString() );

            DecimalSegmentCondition<Sample, decimal?> condition2 = new DecimalSegmentCondition<Sample, decimal?>( t => t.NullableDecimalValue, 1.1M, 10.1M );
            Assert.Equal( "t => ((t.NullableDecimalValue >= 1.1) AndAlso (t.NullableDecimalValue <= 10.1))", condition2.GetCondition().ToString() );
        }

        /// <summary>
        /// 测试获取查询条件 - 设置边界
        /// </summary>
        [Fact]
        public void TestGetCondition_Boundary() {
            DecimalSegmentCondition<Sample, decimal> condition = new DecimalSegmentCondition<Sample, decimal>( t => t.DecimalValue, 1.1M, 10.1M, Boundary.Neither );
            Assert.Equal( "t => ((t.DecimalValue > 1.1) AndAlso (t.DecimalValue < 10.1))", condition.GetCondition().ToString() );

            condition = new DecimalSegmentCondition<Sample, decimal>( t => t.DecimalValue, 1.1M, 10.1M, Boundary.Left );
            Assert.Equal( "t => ((t.DecimalValue >= 1.1) AndAlso (t.DecimalValue < 10.1))", condition.GetCondition().ToString() );

            DecimalSegmentCondition<Sample, decimal?> condition2 = new DecimalSegmentCondition<Sample, decimal?>( t => t.NullableDecimalValue, 1.1M, 10.1M,Boundary.Right );
            Assert.Equal( "t => ((t.NullableDecimalValue > 1.1) AndAlso (t.NullableDecimalValue <= 10.1))", condition2.GetCondition().ToString() );

            condition2 = new DecimalSegmentCondition<Sample, decimal?>( t => t.NullableDecimalValue, 1.1M, 10.1M, Boundary.Both );
            Assert.Equal( "t => ((t.NullableDecimalValue >= 1.1) AndAlso (t.NullableDecimalValue <= 10.1))", condition2.GetCondition().ToString() );
        }
    }
}
