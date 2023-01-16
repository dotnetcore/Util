using System;
using Util.Helpers;
using Xunit;
using Convert = Util.Helpers.Convert;

namespace Util.Tests.Extensions {
    /// <summary>
    /// 日期扩展测试
    /// </summary>
    public class DateTimeExtensionsTest : IDisposable {

        #region 测试初始化

        /// <summary>
        /// 日期字符串1,值为 2012-12-12 12:12:12
        /// </summary>
        private string _dateString1 = "2012-12-12 12:12:12";
        /// <summary>
        /// 日期字符串2,值为 2012-12-12 20:12:12
        /// </summary>
        private string _dateString2 = "2012-12-12 20:12:12";
        /// <summary>
        /// 日期字符串3,值为 2012-12-12 12:12
        /// </summary>
        private string _dateString3 = "2012-12-12 12:12";
        /// <summary>
        /// 日期字符串4,值为 2012-12-12 20:12
        /// </summary>
        private string _dateString4 = "2012-12-12 20:12";
        /// <summary>
        /// 日期1,值为 2012-12-12 12:12:12
        /// </summary>
        private DateTime _date = new DateTime( 2012, 12, 12, 12, 12, 12 );
        /// <summary>
        /// Utc日期,值为 2012-12-12 12:12:12
        /// </summary>
        private DateTime _utcDate = new DateTime( 2012, 12, 12, 12, 12, 12,DateTimeKind.Utc );
        /// <summary>
        /// 可空日期1,值为 2012-12-12 12:12:12
        /// </summary>
        private DateTime? _nullabledate = new DateTime( 2012, 12, 12, 12, 12, 12 );
        /// <summary>
        /// 可空Utc日期,值为 2012-12-12 12:12:12
        /// </summary>
        private DateTime? _nullableUtcDate = new DateTime( 2012, 12, 12, 12, 12, 12, DateTimeKind.Utc );

        #endregion

        #region 测试清理

        /// <summary>
        /// 测试清理
        /// </summary>
        public void Dispose() {
            Time.Reset();
        }

        #endregion

        #region ToDateTimeString

        /// <summary>
        /// 测试获取格式化日期时间字符串
        /// </summary>
        [Fact]
        public void TestToDateTimeString() {
            Assert.Equal( _dateString1, _date.ToDateTimeString() );
            Assert.Equal( _dateString3, _date.ToDateTimeString( true ) );
            Assert.Equal( "", Convert.ToDateTimeOrNull( "" ).ToDateTimeString() );
            Assert.Equal( _dateString1, _nullabledate.ToDateTimeString() );
            Assert.Equal( _dateString3, _nullabledate.ToDateTimeString( true ) );
            Assert.Equal( _dateString2, _utcDate.ToDateTimeString() );
            Assert.Equal( _dateString4, _utcDate.ToDateTimeString( true ) );
            Assert.Equal( _dateString2, _nullableUtcDate.ToDateTimeString() );
            Assert.Equal( _dateString4, _nullableUtcDate.ToDateTimeString( true ) );
        }

        /// <summary>
        /// 测试获取格式化日期时间字符串 - 使用Utc
        /// </summary>
        [Fact]
        public void TestToDateTimeString_Utc() {
            Time.UseUtc();
            Assert.Equal( _dateString1, _date.ToDateTimeString() );
            Assert.Equal( _dateString3, _date.ToDateTimeString( true ) );
            Assert.Equal( "", Convert.ToDateTimeOrNull( "" ).ToDateTimeString() );
            Assert.Equal( _dateString1, _nullabledate.ToDateTimeString() );
            Assert.Equal( _dateString3, _nullabledate.ToDateTimeString( true ) );
            Assert.Equal( _dateString2, _utcDate.ToDateTimeString() );
            Assert.Equal( _dateString4, _utcDate.ToDateTimeString( true ) );
            Assert.Equal( _dateString2, _nullableUtcDate.ToDateTimeString() );
            Assert.Equal( _dateString4, _nullableUtcDate.ToDateTimeString( true ) );
        }

        #endregion

        #region ToDateString

        /// <summary>
        /// 获取格式化日期字符串
        /// </summary>
        [Fact]
        public void TestToDateString() {
            string date = "2012-01-02";
            Assert.Equal( date, Convert.ToDateTime( date ).ToDateString() );
            Assert.Equal( "", Convert.ToDateTimeOrNull( "" ).ToDateString() );
            Assert.Equal( date, Convert.ToDateTimeOrNull( date ).ToDateString() );
        }

        #endregion

        #region ToTimeString

        /// <summary>
        /// 获取格式化时间字符串
        /// </summary>
        [Fact]
        public void TestToTimeString() {
            string date = "2012-01-02 11:11:11";
            Assert.Equal( "11:11:11", Convert.ToDateTime( date ).ToTimeString() );
            Assert.Equal( "", Convert.ToDateTimeOrNull( "" ).ToTimeString() );
            Assert.Equal( "11:11:11", Convert.ToDateTimeOrNull( date ).ToTimeString() );
        }

        #endregion

        #region ToMillisecondString

        /// <summary>
        /// 获取格式化毫秒字符串
        /// </summary>
        [Fact]
        public void TestToMillisecondString() {
            string date = "2012-01-02 11:11:11.123";
            Assert.Equal( date, Convert.ToDateTime( date ).ToMillisecondString() );
            Assert.Equal( "", Convert.ToDateTimeOrNull( "" ).ToMillisecondString() );
            Assert.Equal( date, Convert.ToDateTimeOrNull( date ).ToMillisecondString() );
        }

        #endregion

        #region ToChineseDateString

        /// <summary>
        /// 获取格式化中文日期字符串
        /// </summary>
        [Fact]
        public void TestToChineseDateString() {
            string date = "2012-01-02";
            Assert.Equal( "2012年1月2日", Convert.ToDateTime( date ).ToChineseDateString() );
            Assert.Equal( "2012年12月12日", Convert.ToDateTime( "2012-12-12" ).ToChineseDateString() );
            Assert.Equal( "", Convert.ToDateTimeOrNull( "" ).ToChineseDateString() );
            Assert.Equal( "2012年1月2日", Convert.ToDateTimeOrNull( date ).ToChineseDateString() );
        }

        #endregion

        #region ToChineseDateTimeString

        /// <summary>
        /// 获取格式化中文日期时间字符串
        /// </summary>
        [Fact]
        public void TestToChineseDateTimeString() {
            string date = "2012-01-02 11:11:11";
            Assert.Equal( "2012年1月2日 11时11分11秒", Convert.ToDateTime( date ).ToChineseDateTimeString() );
            Assert.Equal( "2012年12月12日 11时11分11秒", Convert.ToDateTime( "2012-12-12 11:11:11" ).ToChineseDateTimeString() );
            Assert.Equal( "2012年1月2日 11时11分", Convert.ToDateTime( date ).ToChineseDateTimeString( true ) );
            Assert.Equal( "", Convert.ToDateTimeOrNull( "" ).ToChineseDateTimeString() );
            Assert.Equal( "2012年1月2日 11时11分11秒", Convert.ToDateTimeOrNull( date ).ToChineseDateTimeString() );
            Assert.Equal( "2012年1月2日 11时11分", Convert.ToDateTimeOrNull( date ).ToChineseDateTimeString( true ) );
        }

        #endregion

        #region TimeSpan_Description

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

        #endregion
    }
}
