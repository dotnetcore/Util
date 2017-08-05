using System;
using System.Text;
using Util.Datas.Queries.Criterias;
using Util.Tests.Samples;
using Xunit;

namespace Util.Tests.Datas.Queries.Criterias {
    /// <summary>
    /// 测试日期范围过滤条件
    /// </summary>
    public class DateSegmentCriteriaTest {
        /// <summary>
        /// 测试初始化
        /// </summary>
        public DateSegmentCriteriaTest() {
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
            result.AppendFormat( "t => ((t.DateValue >= {0})",DateTime.Parse( "2000/1/1 0:00:00" ) );
            result.AppendFormat( " AndAlso (t.DateValue < {0}))", DateTime.Parse( "2000/1/3 0:00:00" ) );
            var criteria = new DateSegmentCriteria<AggregateRootSample, DateTime>( t => t.DateValue, _min, _max );
            Assert.Equal( result.ToString(), criteria.GetPredicate().ToString() );

            result = new StringBuilder();
            result.AppendFormat( "t => ((t.NullableDateValue >= {0})", DateTime.Parse( "2000/1/1 0:00:00" ) );
            result.AppendFormat( " AndAlso (t.NullableDateValue < {0}))", DateTime.Parse( "2000/1/3 0:00:00" ) );
            var criteria2 = new DateSegmentCriteria<AggregateRootSample, DateTime?>( t => t.NullableDateValue, _min, _max );
            Assert.Equal( result.ToString(), criteria2.GetPredicate().ToString() );
        }
    }
}
