using System;
using Util.Data.Queries;
using Util.Data.Queries.Conditions;
using Util.Data.Tests.Samples;
using Xunit;

namespace Util.Data.Tests.Queries.Conditions {
    /// <summary>
    /// 测试double范围过滤条件
    /// </summary>
    public class DoubleSegmentConditionTest  {
        /// <summary>
        /// 测试获取查询条件
        /// </summary>
        [Fact]
        public void TestGetCondition() {
            DoubleSegmentCondition<Sample, double> condition = new DoubleSegmentCondition<Sample, double>( t => t.DoubleValue, 1.1, 10.1 );
            Assert.Equal( "t => ((t.DoubleValue >= 1.1) AndAlso (t.DoubleValue <= 10.1))", condition.GetCondition().ToString() );

            DoubleSegmentCondition<Sample, double?> condition2 = new DoubleSegmentCondition<Sample, double?>( t => t.NullableDoubleValue, 1.1, 10.1 );
            Assert.Equal( "t => ((t.NullableDoubleValue >= 1.1) AndAlso (t.NullableDoubleValue <= 10.1))", condition2.GetCondition().ToString() );
        }

        /// <summary>
        /// 测试获取查询条件 - 设置边界
        /// </summary>
        [Fact]
        public void TestGetCondition_Boundary() {
            DoubleSegmentCondition<Sample, double> condition = new DoubleSegmentCondition<Sample, double>( t => t.DoubleValue, 1.1, 10.1, Boundary.Neither );
            Assert.Equal( "t => ((t.DoubleValue > 1.1) AndAlso (t.DoubleValue < 10.1))", condition.GetCondition().ToString() );

            condition = new DoubleSegmentCondition<Sample, double>( t => t.DoubleValue, 1.1, 10.1, Boundary.Left );
            Assert.Equal( "t => ((t.DoubleValue >= 1.1) AndAlso (t.DoubleValue < 10.1))", condition.GetCondition().ToString() );

            DoubleSegmentCondition<Sample, double?> condition2 = new DoubleSegmentCondition<Sample, double?>( t => t.NullableDoubleValue, 1.1, 10.1,Boundary.Right );
            Assert.Equal( "t => ((t.NullableDoubleValue > 1.1) AndAlso (t.NullableDoubleValue <= 10.1))", condition2.GetCondition().ToString() );

            condition2 = new DoubleSegmentCondition<Sample, double?>( t => t.NullableDoubleValue, 1.1, 10.1, Boundary.Both );
            Assert.Equal( "t => ((t.NullableDoubleValue >= 1.1) AndAlso (t.NullableDoubleValue <= 10.1))", condition2.GetCondition().ToString() );
        }

        /// <summary>
        /// 测试获取查询条件 - 属性为int类型，则发生类型不匹配异常
        /// </summary>
        [Fact]
        public void TestGetCondition_ValidateType() {
            Assert.Throws<ArgumentException>( () => {
                var condition = new DoubleSegmentCondition<Sample, int?>( t => t.Age, 1.1, 10.1 );
                var result = condition.GetCondition();
            } );
        }

        /// <summary>
        /// 测试获取查询条件 - 最小值大于最大值，则交换大小值的位置
        /// </summary>
        [Fact]
        public void TestGetCondition_MinGreaterMax() {
            DoubleSegmentCondition<Sample, double> condition = new DoubleSegmentCondition<Sample, double>( t => t.DoubleValue, 10.1, 1.1 );
            Assert.Equal( "t => ((t.DoubleValue >= 1.1) AndAlso (t.DoubleValue <= 10.1))", condition.GetCondition().ToString() );

            DoubleSegmentCondition<Sample, double?> condition2 = new DoubleSegmentCondition<Sample, double?>( t => t.NullableDoubleValue, 10.1, 1.1 );
            Assert.Equal( "t => ((t.NullableDoubleValue >= 1.1) AndAlso (t.NullableDoubleValue <= 10.1))", condition2.GetCondition().ToString() );
        }

        /// <summary>
        /// 测试获取查询条件 - 最小值为空，忽略最小值条件
        /// </summary>
        [Fact]
        public void TestGetCondition_MinIsNull() {
            DoubleSegmentCondition<Sample, double> condition = new DoubleSegmentCondition<Sample, double>( t => t.DoubleValue, null, 10.1 );
            Assert.Equal( "t => (t.DoubleValue <= 10.1)", condition.GetCondition().ToString() );

            DoubleSegmentCondition<Sample, double?> condition2 = new DoubleSegmentCondition<Sample, double?>( t => t.NullableDoubleValue, null, 10.1 );
            Assert.Equal( "t => (t.NullableDoubleValue <= 10.1)", condition2.GetCondition().ToString() );
        }

        /// <summary>
        /// 测试获取查询条件 - 最大值为空，忽略最大值条件
        /// </summary>
        [Fact]
        public void TestGetCondition_MaxIsNull() {
            DoubleSegmentCondition<Sample, double> condition = new DoubleSegmentCondition<Sample, double>( t => t.DoubleValue, 1.1, null );
            Assert.Equal( "t => (t.DoubleValue >= 1.1)", condition.GetCondition().ToString() );

            DoubleSegmentCondition<Sample, double?> condition2 = new DoubleSegmentCondition<Sample, double?>( t => t.NullableDoubleValue, 1.1, null );
            Assert.Equal( "t => (t.NullableDoubleValue >= 1.1)", condition2.GetCondition().ToString() );
        }

        /// <summary>
        /// 测试获取查询条件 - 最大值和最小值均为null,忽略所有条件
        /// </summary>
        [Fact]
        public void TestGetCondition_BothNull() {
            DoubleSegmentCondition<Sample, double> condition = new DoubleSegmentCondition<Sample, double>( t => t.DoubleValue, null, null );
            Assert.Null( condition.GetCondition() );

            DoubleSegmentCondition<Sample, double?> condition2 = new DoubleSegmentCondition<Sample, double?>( t => t.NullableDoubleValue, null, null );
            Assert.Null( condition2.GetCondition() );
        }
    }
}
