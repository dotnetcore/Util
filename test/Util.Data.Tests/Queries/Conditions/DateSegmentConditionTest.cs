using System;
using System.Globalization;
using System.Text;
using System.Threading;
using Util.Data.Queries;
using Util.Data.Queries.Conditions;
using Util.Data.Tests.Samples;
using Xunit;
using Xunit.Abstractions;

namespace Util.Data.Tests.Queries.Conditions {
    /// <summary>
    /// 测试日期范围过滤条件 - 不包含时间
    /// </summary>
    public class DateSegmentConditionTest {
        /// <summary>
        /// 输出日志
        /// </summary>
        private readonly ITestOutputHelper _output;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public DateSegmentConditionTest( ITestOutputHelper output) {
            Thread.CurrentThread.CurrentCulture = new CultureInfo( "zh-CN" ) {
                DateTimeFormat = new DateTimeFormatInfo {
                    ShortDatePattern = "yyyy/M/d"
                }
            };
            _output = output;
            _min = "2000-1-1 10:10:10".ToDateTime();
            _max = "2000-1-3 10:10:10".ToDateTime();
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
        /// 测试获取查询条件 - 不包含边界
        /// </summary>
        [Fact]
        public void TestGetCondition_Neither() {
            var result = new StringBuilder();
            result.Append( "t => ((t.DateValue >= Convert(Parse(\"2000/1/2 00:00:00\"), DateTime))" );
            result.Append( " AndAlso (t.DateValue < Convert(Parse(\"2000/1/3 00:00:00\"), DateTime)))" );
            var condition = new DateSegmentCondition<Sample, DateTime>( t => t.DateValue, _min, _max, Boundary.Neither );
            Assert.Equal( result.ToString(), condition.GetCondition().ToString() );
        }

        /// <summary>
        /// 测试获取查询条件 - 包含左边
        /// </summary>
        [Fact]
        public void TestGetCondition_Left() {
            var result = new StringBuilder();
            result.Append( "t => ((t.DateValue >= Convert(Parse(\"2000/1/1 00:00:00\"), DateTime))" );
            result.Append( " AndAlso (t.DateValue < Convert(Parse(\"2000/1/3 00:00:00\"), DateTime)))" );
            var condition = new DateSegmentCondition<Sample, DateTime>( t => t.DateValue, _min, _max, Boundary.Left );
            Assert.Equal( result.ToString(), condition.GetCondition().ToString() );
        }

        /// <summary>
        /// 测试获取查询条件 - 包含右边
        /// </summary>
        [Fact]
        public void TestGetCondition_Right() {
            var result = new StringBuilder();
            result.Append( "t => ((t.NullableDateValue >= Convert(Parse(\"2000/1/2 00:00:00\"), Nullable`1))" );
            result.Append( " AndAlso (t.NullableDateValue < Convert(Parse(\"2000/1/4 00:00:00\"), Nullable`1)))" );
            var condition = new DateSegmentCondition<Sample, DateTime?>( t => t.NullableDateValue, _min, _max, Boundary.Right );
            Assert.Equal( result.ToString(), condition.GetCondition().ToString() );
        }

        /// <summary>
        /// 测试获取查询条件 - 包含两边
        /// </summary>
        [Fact]
        public void TestGetCondition_Both() {
            var result = new StringBuilder();
            result.Append( "t => ((t.NullableDateValue >= Convert(Parse(\"2000/1/1 00:00:00\"), Nullable`1))" );
            result.Append( " AndAlso (t.NullableDateValue < Convert(Parse(\"2000/1/4 00:00:00\"), Nullable`1)))" );
            var condition = new DateSegmentCondition<Sample, DateTime?>( t => t.NullableDateValue, _min, _max, Boundary.Both );
            Assert.Equal( result.ToString(), condition.GetCondition().ToString() );
        }
    }
}
