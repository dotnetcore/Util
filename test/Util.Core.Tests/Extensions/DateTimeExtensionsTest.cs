using System;
using Xunit;

namespace Util.Tests.Extensions {
    /// <summary>
    /// 日期扩展测试
    /// </summary>
    public class DateTimeExtensionsTest {
        /// <summary>
        /// 测试获取格式化日期时间字符串
        /// </summary>
        [Fact]
        public void TestToDateTimeString() {
            string date = "2012-01-02 11:11:11";
            Assert.Equal( date, Util.Helpers.Convert.ToDateTime( date ).ToDateTimeString() );
            Assert.Equal( "2012-01-02 11:11", Util.Helpers.Convert.ToDateTime( date ).ToDateTimeString( true ) );
            Assert.Equal( "", Util.Helpers.Convert.ToDateTimeOrNull( "" ).ToDateTimeString() );
            Assert.Equal( date, Util.Helpers.Convert.ToDateTimeOrNull( date ).ToDateTimeString() );
        }

        /// <summary>
        /// 获取格式化日期字符串
        /// </summary>
        [Fact]
        public void TestToDateString() {
            string date = "2012-01-02";
            Assert.Equal( date, Util.Helpers.Convert.ToDateTime( date ).ToDateString() );
            Assert.Equal( "", Util.Helpers.Convert.ToDateTimeOrNull( "" ).ToDateString() );
            Assert.Equal( date, Util.Helpers.Convert.ToDateTimeOrNull( date ).ToDateString() );
        }

        /// <summary>
        /// 获取格式化时间字符串
        /// </summary>
        [Fact]
        public void TestToTimeString() {
            string date = "2012-01-02 11:11:11";
            Assert.Equal( "11:11:11", Util.Helpers.Convert.ToDateTime( date ).ToTimeString() );
            Assert.Equal( "", Util.Helpers.Convert.ToDateTimeOrNull( "" ).ToTimeString() );
            Assert.Equal( "11:11:11", Util.Helpers.Convert.ToDateTimeOrNull( date ).ToTimeString() );
        }

        /// <summary>
        /// 获取格式化毫秒字符串
        /// </summary>
        [Fact]
        public void TestToMillisecondString() {
            string date = "2012-01-02 11:11:11.123";
            Assert.Equal( date, Util.Helpers.Convert.ToDateTime( date ).ToMillisecondString() );
            Assert.Equal( "", Util.Helpers.Convert.ToDateTimeOrNull( "" ).ToMillisecondString() );
            Assert.Equal( date, Util.Helpers.Convert.ToDateTimeOrNull( date ).ToMillisecondString() );
        }

        /// <summary>
        /// 获取格式化中文日期字符串
        /// </summary>
        [Fact]
        public void TestToChineseDateString() {
            string date = "2012-01-02";
            Assert.Equal( "2012年1月2日", Util.Helpers.Convert.ToDateTime( date ).ToChineseDateString() );
            Assert.Equal( "2012年12月12日", Util.Helpers.Convert.ToDateTime( "2012-12-12" ).ToChineseDateString() );
            Assert.Equal( "", Util.Helpers.Convert.ToDateTimeOrNull( "" ).ToChineseDateString() );
            Assert.Equal( "2012年1月2日", Util.Helpers.Convert.ToDateTimeOrNull( date ).ToChineseDateString() );
        }

        /// <summary>
        /// 获取格式化中文日期时间字符串
        /// </summary>
        [Fact]
        public void TestToChineseDateTimeString() {
            string date = "2012-01-02 11:11:11";
            Assert.Equal( "2012年1月2日 11时11分11秒", Util.Helpers.Convert.ToDateTime( date ).ToChineseDateTimeString() );
            Assert.Equal( "2012年12月12日 11时11分11秒", Util.Helpers.Convert.ToDateTime( "2012-12-12 11:11:11" ).ToChineseDateTimeString() );
            Assert.Equal( "2012年1月2日 11时11分", Util.Helpers.Convert.ToDateTime( date ).ToChineseDateTimeString( true ) );
            Assert.Equal( "", Util.Helpers.Convert.ToDateTimeOrNull( "" ).ToChineseDateTimeString() );
            Assert.Equal( "2012年1月2日 11时11分11秒", Util.Helpers.Convert.ToDateTimeOrNull( date ).ToChineseDateTimeString() );
            Assert.Equal( "2012年1月2日 11时11分", Util.Helpers.Convert.ToDateTimeOrNull( date ).ToChineseDateTimeString( true ) );
        }

        /// <summary>
        /// 测试获取时间间隔描述
        /// </summary>
        [Fact]
        public void TestDescription_TimeSpan() {
            TimeSpan timeSpan = new DateTime( 2000, 1, 1, 1, 0, 1 ) - new DateTime( 2000, 1, 1, 1, 0, 0 );
            Assert.Equal( "1秒", timeSpan.Description() );
            timeSpan = new DateTime( 2000, 1, 1, 1, 1, 0 ) - new DateTime( 2000, 1, 1, 1, 0, 0 );
            Assert.Equal( "1分", timeSpan.Description() );
            timeSpan = new DateTime( 2000, 1, 1, 1, 0, 0 ) - new DateTime( 2000, 1, 1, 0, 0, 0 );
            Assert.Equal( "1小时", timeSpan.Description() );
            timeSpan = new DateTime( 2000, 1, 2, 0, 0, 0 ) - new DateTime( 2000, 1, 1, 0, 0, 0 );
            Assert.Equal( "1天", timeSpan.Description() );
            timeSpan = new DateTime( 2000, 1, 2, 0, 2, 0 ) - new DateTime( 2000, 1, 1, 0, 0, 0 );
            Assert.Equal( "1天2分", timeSpan.Description() );
            timeSpan = "2000-1-1 06:10:10.123".ToDateTime() - "2000-1-1 06:10:10.122".ToDateTime();
            Assert.Equal( "1毫秒", timeSpan.Description() );
            timeSpan = "2000-1-1 06:10:10.1000001".ToDateTime() - "2000-1-1 06:10:10.1000000".ToDateTime();
            Assert.Equal( "0.0001毫秒", timeSpan.Description() );
        }
    }
}
