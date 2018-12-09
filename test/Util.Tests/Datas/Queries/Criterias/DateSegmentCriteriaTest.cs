using System;
using System.Text;
using Util.Datas.Queries;
using Util.Datas.Queries.Criterias;
using Util.Tests.Samples;
using Xunit;
using Xunit.Abstractions;

namespace Util.Tests.Datas.Queries.Criterias {
    /// <summary>
    /// 测试日期范围过滤条件
    /// </summary>
    public class DateSegmentCriteriaTest {
        /// <summary>
        /// 输出日志
        /// </summary>
        private readonly ITestOutputHelper _output;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public DateSegmentCriteriaTest( ITestOutputHelper output) {
            _output = output;
            _min = DateTime.Parse( "2000-1-1 10:10:10" );
            _max = DateTime.Parse( "2000-1-2 10:10:10" );
        }

        /// <summary>
        /// 最小日期
        /// </summary>
        private readonly DateTime? _min;
        /// <summary>
        /// 最大日期
        /// </summary>
        private readonly DateTime? _max;

        /// <summary>
        /// 测试获取查询条件
        /// </summary>
        [Fact]
        public void TestGetPredicate() {
            var result = new StringBuilder();
            result.Append( "t => ((t.DateValue >= Convert(Parse(\"2000/1/1 0:00:00\"), DateTime))" );
            result.Append( " AndAlso (t.DateValue < Convert(Parse(\"2000/1/3 0:00:00\"), DateTime)))" );
            var criteria = new DateSegmentCriteria<AggregateRootSample, DateTime>( t => t.DateValue, _min, _max );
            _output.WriteLine( criteria.GetPredicate().ToString() );
            Assert.Equal( result.ToString(), criteria.GetPredicate().ToString() );

            result = new StringBuilder();
            result.Append( "t => ((t.NullableDateValue >= Convert(Parse(\"2000/1/1 0:00:00\"), Nullable`1))" );
            result.Append( " AndAlso (t.NullableDateValue < Convert(Parse(\"2000/1/3 0:00:00\"), Nullable`1)))" );
            var criteria2 = new DateSegmentCriteria<AggregateRootSample, DateTime?>( t => t.NullableDateValue, _min, _max );
            _output.WriteLine( criteria2.GetPredicate().ToString() );
            Assert.Equal( result.ToString(), criteria2.GetPredicate().ToString() );
        }

        /// <summary>
        /// 测试获取查询条件 - 设置边界
        /// </summary>
        [Fact]
        public void TestGetPredicate_Boundary() {
            var result = new StringBuilder();
            result.Append( "t => ((t.DateValue > Convert(Parse(\"2000/1/1 0:00:00\"), DateTime))" );
            result.Append( " AndAlso (t.DateValue < Convert(Parse(\"2000/1/3 0:00:00\"), DateTime)))" );
            var criteria = new DateSegmentCriteria<AggregateRootSample, DateTime>( t => t.DateValue, _min, _max, Boundary.Neither );
            Assert.Equal( result.ToString(), criteria.GetPredicate().ToString() );

            result = new StringBuilder();
            result.Append( "t => ((t.DateValue >= Convert(Parse(\"2000/1/1 0:00:00\"), DateTime))" );
            result.Append( " AndAlso (t.DateValue < Convert(Parse(\"2000/1/3 0:00:00\"), DateTime)))" );
            criteria = new DateSegmentCriteria<AggregateRootSample, DateTime>( t => t.DateValue, _min, _max, Boundary.Left );
            Assert.Equal( result.ToString(), criteria.GetPredicate().ToString() );

            result = new StringBuilder();
            result.Append( "t => ((t.NullableDateValue > Convert(Parse(\"2000/1/1 0:00:00\"), Nullable`1))" );
            result.Append( " AndAlso (t.NullableDateValue <= Convert(Parse(\"2000/1/3 0:00:00\"), Nullable`1)))" );
            var criteria2 = new DateSegmentCriteria<AggregateRootSample, DateTime?>( t => t.NullableDateValue, _min, _max,Boundary.Right );
            Assert.Equal( result.ToString(), criteria2.GetPredicate().ToString() );

            result = new StringBuilder();
            result.Append( "t => ((t.NullableDateValue >= Convert(Parse(\"2000/1/1 0:00:00\"), Nullable`1))" );
            result.Append( " AndAlso (t.NullableDateValue <= Convert(Parse(\"2000/1/3 0:00:00\"), Nullable`1)))" );
            criteria2 = new DateSegmentCriteria<AggregateRootSample, DateTime?>( t => t.NullableDateValue, _min, _max, Boundary.Both );
            Assert.Equal( result.ToString(), criteria2.GetPredicate().ToString() );
        }
    }
}
