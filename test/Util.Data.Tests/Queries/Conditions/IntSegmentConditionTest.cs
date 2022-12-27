using Util.Data.Queries;
using Util.Data.Queries.Conditions;
using Util.Data.Tests.Samples;
using Xunit;

namespace Util.Data.Tests.Queries.Conditions {
    /// <summary>
    /// 测试整数范围过滤条件
    /// </summary>
    public class IntSegmentConditionTest  {
        /// <summary>
        /// 测试获取查询条件
        /// </summary>
        [Fact]
        public void TestGetCondition() {
            IntSegmentCondition<Sample, int> condition = new IntSegmentCondition<Sample, int>( t => t.Tel, 1, 10 );
            Assert.Equal( "t => ((t.Tel >= 1) AndAlso (t.Tel <= 10))", condition.GetCondition().ToString() );

            IntSegmentCondition<Sample, int?> condition2 = new IntSegmentCondition<Sample, int?>( t => t.Age, 1, 10 );
            Assert.Equal( "t => ((t.Age >= 1) AndAlso (t.Age <= 10))", condition2.GetCondition().ToString() );
        }

        /// <summary>
        /// 测试获取查询条件 - 设置边界
        /// </summary>
        [Fact]
        public void TestGetCondition_Boundary() {
            IntSegmentCondition<Sample, int> condition = new IntSegmentCondition<Sample, int>( t => t.Tel, 1, 10, Boundary.Neither );
            Assert.Equal( "t => ((t.Tel > 1) AndAlso (t.Tel < 10))", condition.GetCondition().ToString() );

            condition = new IntSegmentCondition<Sample, int>( t => t.Tel, 1, 10,Boundary.Left );
            Assert.Equal( "t => ((t.Tel >= 1) AndAlso (t.Tel < 10))", condition.GetCondition().ToString() );

            IntSegmentCondition<Sample, int?> condition2 = new IntSegmentCondition<Sample, int?>( t => t.Age, 1, 10, Boundary.Right );
            Assert.Equal( "t => ((t.Age > 1) AndAlso (t.Age <= 10))", condition2.GetCondition().ToString() );

            condition2 = new IntSegmentCondition<Sample, int?>( t => t.Age, 1, 10, Boundary.Both );
            Assert.Equal( "t => ((t.Age >= 1) AndAlso (t.Age <= 10))", condition2.GetCondition().ToString() );
        }

        /// <summary>
        /// 测试获取查询条件 - 最小值大于最大值，则交换大小值的位置
        /// </summary>
        [Fact]
        public void TestGetCondition_MinGreaterMax() {
            IntSegmentCondition<Sample, int> condition = new IntSegmentCondition<Sample, int>( t => t.Tel, 10, 1 );
            Assert.Equal( "t => ((t.Tel >= 1) AndAlso (t.Tel <= 10))", condition.GetCondition().ToString() );

            IntSegmentCondition<Sample, int?> condition2 = new IntSegmentCondition<Sample, int?>( t => t.Age, 10, 1 );
            Assert.Equal( "t => ((t.Age >= 1) AndAlso (t.Age <= 10))", condition2.GetCondition().ToString() );
        }

        /// <summary>
        /// 测试获取查询条件 - 最小值为空，忽略最小值条件
        /// </summary>
        [Fact]
        public void TestGetCondition_MinIsNull() {
            IntSegmentCondition<Sample, int> condition = new IntSegmentCondition<Sample, int>( t => t.Tel, null, 10 );
            Assert.Equal( "t => (t.Tel <= 10)", condition.GetCondition().ToString() );

            IntSegmentCondition<Sample, int?> condition2 = new IntSegmentCondition<Sample, int?>( t => t.Age, null, 10 );
            Assert.Equal( "t => (t.Age <= 10)", condition2.GetCondition().ToString() );
        }

        /// <summary>
        /// 测试获取查询条件 - 最大值为空，忽略最大值条件
        /// </summary>
        [Fact]
        public void TestGetCondition_MaxIsNull() {
            IntSegmentCondition<Sample, int> condition = new IntSegmentCondition<Sample, int>( t => t.Tel, 1, null );
            Assert.Equal( "t => (t.Tel >= 1)", condition.GetCondition().ToString() );

            IntSegmentCondition<Sample, int?> condition2 = new IntSegmentCondition<Sample, int?>( t => t.Age, 1, null );
            Assert.Equal( "t => (t.Age >= 1)", condition2.GetCondition().ToString() );
        }

        /// <summary>
        /// 测试获取查询条件 - 最大值和最小值均为null,忽略所有条件
        /// </summary>
        [Fact]
        public void Test_BothNull() {
            IntSegmentCondition<Sample, int> condition = new IntSegmentCondition<Sample, int>( t => t.Tel, null, null );
            Assert.Null( condition.GetCondition() );

            IntSegmentCondition<Sample, int?> condition2 = new IntSegmentCondition<Sample, int?>( t => t.Age, null, null );
            Assert.Null( condition2.GetCondition() );
        }
    }
}
