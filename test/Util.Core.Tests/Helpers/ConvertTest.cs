using System;
using Util.Tests.Samples;
using Xunit;

namespace Util.Tests.Helpers {
    /// <summary>
    /// 类型转换测试
    /// </summary>
    public class ConvertTest {
        /// <summary>
        /// 转换为整型
        /// </summary>
        /// <param name="input">输入值</param>
        /// <param name="result">结果</param>
        [Theory]
        [InlineData( null, 0 )]
        [InlineData( "", 0 )]
        [InlineData( "1A", 0 )]
        [InlineData( "0", 0 )]
        [InlineData( "1", 1 )]
        [InlineData( "1778019.78", 1778020 )]
        [InlineData( "1778019.7801684", 1778020 )]
        public void TestToInt( object input, int result ) {
            Assert.Equal( result, Util.Helpers.Convert.ToInt( input ) );
        }

        /// <summary>
        /// 转换为可空整型
        /// </summary>
        /// <param name="input">输入值</param>
        /// <param name="result">结果</param>
        [Theory]
        [InlineData( null, null )]
        [InlineData( "", null )]
        [InlineData( "1A", null )]
        [InlineData( "0", 0 )]
        [InlineData( "1", 1 )]
        [InlineData( "1778019.78", 1778020 )]
        [InlineData( "1778019.7801684", 1778020 )]
        public void TestToIntOrNull( object input, int? result ) {
            Assert.Equal( result, Util.Helpers.Convert.ToIntOrNull( input ) );
        }

        /// <summary>
        /// 转换为64位整型
        /// </summary>
        /// <param name="input">输入值</param>
        /// <param name="result">结果</param>
        [Theory]
        [InlineData( null, 0 )]
        [InlineData( "", 0 )]
        [InlineData( "1A", 0 )]
        [InlineData( "0", 0 )]
        [InlineData( "1", 1 )]
        [InlineData( "1778019.7801684", 1778020 )]
        [InlineData( "177801978016841234", 177801978016841234 )]
        public void TestToLong( object input, long result ) {
            Assert.Equal( result, Util.Helpers.Convert.ToLong( input ) );
        }

        /// <summary>
        /// 转换为64位可空整型
        /// </summary>
        /// <param name="input">输入值</param>
        /// <param name="result">结果</param>
        [Theory]
        [InlineData( null, null )]
        [InlineData( "", null )]
        [InlineData( "1A", null )]
        [InlineData( "0", 0L )]
        [InlineData( "1", 1L )]
        [InlineData( "1778019.7801684", 1778020L )]
        [InlineData( "177801978016841234", 177801978016841234L )]
        public void TestToLongOrNull( object input, long? result ) {
            Assert.Equal( result, Util.Helpers.Convert.ToLongOrNull( input ) );
        }

        /// <summary>
        /// 转换为32位浮点型
        /// </summary>
        /// <param name="input">输入值</param>
        /// <param name="result">结果</param>
        /// <param name="digits">小数位数</param>
        [Theory]
        [InlineData( null, 0, null )]
        [InlineData( "", 0, null )]
        [InlineData( "1A", 0, null )]
        [InlineData( "0", 0, null )]
        [InlineData( "1", 1, null )]
        [InlineData( "1.2", 1.2, null )]
        [InlineData( "12.346", 12.35, 2 )]
        public void TestToFloat( object input, float result, int? digits ) {
            Assert.Equal( result, Util.Helpers.Convert.ToFloat( input, digits ) );
        }

        /// <summary>
        /// 转换为32位可空浮点型
        /// </summary>
        /// <param name="input">输入值</param>
        /// <param name="result">结果</param>
        /// <param name="digits">小数位数</param>
        [Theory]
        [InlineData( null, null, null )]
        [InlineData( "", null, null )]
        [InlineData( "1A", null, null )]
        [InlineData( "0", 0f, null )]
        [InlineData( "1", 1f, null )]
        [InlineData( "1.2", 1.2f, null )]
        [InlineData( "12.346", 12.35f, 2 )]
        public void TestToFloatOrNull( object input, float? result, int? digits ) {
            Assert.Equal( result, Util.Helpers.Convert.ToFloatOrNull( input, digits ) );
        }

        /// <summary>
        /// 转换为64位浮点型
        /// </summary>
        /// <param name="input">输入值</param>
        /// <param name="result">结果</param>
        /// <param name="digits">小数位数</param>
        [Theory]
        [InlineData( null, 0, null )]
        [InlineData( "", 0, null )]
        [InlineData( "1A", 0, null )]
        [InlineData( "0", 0, null )]
        [InlineData( "1", 1, null )]
        [InlineData( "1.2", 1.2, null )]
        [InlineData( "12.235", 12.24, 2 )]
        [InlineData( "12.345", 12.34, 2 )]
        [InlineData( "12.3451", 12.35, 2 )]
        [InlineData( "12.346", 12.35, 2 )]
        public void TestToDouble( object input, double result, int? digits ) {
            Assert.Equal( result, Util.Helpers.Convert.ToDouble( input, digits ) );
        }

        /// <summary>
        /// 转换为64位可空浮点型
        /// </summary>
        /// <param name="input">输入值</param>
        /// <param name="result">结果</param>
        /// <param name="digits">小数位数</param>
        [Theory]
        [InlineData( null, null, null )]
        [InlineData( "", null, null )]
        [InlineData( "1A", null, null )]
        [InlineData( "0", 0d, null )]
        [InlineData( "1", 1d, null )]
        [InlineData( "1.2", 1.2, null )]
        [InlineData( "12.355", 12.36, 2 )]
        public void TestToDoubleOrNull( object input, double? result, int? digits ) {
            Assert.Equal( result, Util.Helpers.Convert.ToDoubleOrNull( input, digits ) );
        }

        /// <summary>
        /// 转换为128位浮点型
        /// </summary>
        /// <param name="input">输入值</param>
        /// <param name="result">结果</param>
        /// <param name="digits">小数位数</param>
        [Theory]
        [InlineData( null, 0, null )]
        [InlineData( "", 0, null )]
        [InlineData( "1A", 0, null )]
        [InlineData( "0", 0, null )]
        [InlineData( "1", 1, null )]
        [InlineData( "1.2", 1.2, null )]
        [InlineData( "12.235", 12.24, 2 )]
        [InlineData( "12.345", 12.34, 2 )]
        [InlineData( "12.3451", 12.35, 2 )]
        [InlineData( "12.346", 12.35, 2 )]
        public void TestToDecimal( object input, decimal result, int? digits ) {
            Assert.Equal( result, Util.Helpers.Convert.ToDecimal( input, digits ) );
        }

        /// <summary>
        /// 转换为128位可空浮点型，验证
        /// </summary>
        /// <param name="input">输入值</param>
        /// <param name="result">结果</param>
        /// <param name="digits">小数位数</param>
        [Theory]
        [InlineData( null, null, null )]
        [InlineData( "", null, null )]
        [InlineData( "1A", null, null )]
        [InlineData( "1A", null, 2 )]
        public void TestToDecimalOrNull_Validate( object input, decimal? result, int? digits ) {
            Assert.Equal( result, Util.Helpers.Convert.ToDecimalOrNull( input, digits ) );
        }

        /// <summary>
        /// 转换为128位可空浮点型，输入值为"0"
        /// </summary>
        [Fact]
        public void TestToDecimalOrNull() {
            Assert.Equal( 0M, Util.Helpers.Convert.ToDecimalOrNull( "0" ) );
            Assert.Equal( 1.2M, Util.Helpers.Convert.ToDecimalOrNull( "1.2" ) );
            Assert.Equal( 23.46M, Util.Helpers.Convert.ToDecimalOrNull( "23.456", 2 ) );
        }

        /// <summary>
        /// 转换为布尔型
        /// </summary>
        /// <param name="input">输入值</param>
        /// <param name="result">结果</param>
        [Theory]
        [InlineData( null, false )]
        [InlineData( "", false )]
        [InlineData( "false", false )]
        [InlineData( "true", true )]
        public void TestToBool( object input, bool result ) {
            Assert.Equal( result, Util.Helpers.Convert.ToBool( input ) );
        }

        /// <summary>
        /// 转换为可空布尔型
        /// </summary>
        /// <param name="input">输入值</param>
        /// <param name="result">结果</param>
        [Theory]
        [InlineData( null, null )]
        [InlineData( "false", false )]
        [InlineData( "true", true )]
        public void TestToBoolOrNull( object input, bool? result ) {
            Assert.Equal( result, Util.Helpers.Convert.ToBoolOrNull( input ) );
        }

        /// <summary>
        /// 转换为日期，验证
        /// </summary>
        [Fact]
        public void TestToDate_Validate() {
            Assert.Equal( DateTime.MinValue, Util.Helpers.Convert.ToDate( null ) );
            Assert.Equal( DateTime.MinValue, Util.Helpers.Convert.ToDate( "" ) );
            Assert.Equal( DateTime.MinValue, Util.Helpers.Convert.ToDate( "1A" ) );
        }

        /// <summary>
        /// 转换为日期
        /// </summary>
        [Fact]
        public void TestToDate() {
            Assert.Equal( new DateTime( 2000, 1, 1 ), Util.Helpers.Convert.ToDate( "2000-1-1" ) );
        }

        /// <summary>
        /// 转换为可空日期，验证
        /// </summary>
        /// <param name="input">输入值</param>
        /// <param name="result">结果</param>
        [Theory]
        [InlineData( null, null )]
        [InlineData( "", null )]
        [InlineData( "1A", null )]
        public void TestToDateOrNull_Validate( object input, DateTime? result ) {
            Assert.Equal( result, Util.Helpers.Convert.ToDateOrNull( input ) );
        }

        /// <summary>
        /// 转换为可空日期
        /// </summary>
        [Fact]
        public void TestToDateOrNull() {
            Assert.Equal( new DateTime( 2000, 1, 1 ), Util.Helpers.Convert.ToDateOrNull( "2000-1-1" ) );
        }

        /// <summary>
        /// 转换为Guid，验证
        /// </summary>
        [Fact]
        public void TestToGuid_Validate() {
            Assert.Equal( Guid.Empty, Util.Helpers.Convert.ToGuid( null ) );
            Assert.Equal( Guid.Empty, Util.Helpers.Convert.ToGuid( "" ) );
            Assert.Equal( Guid.Empty, Util.Helpers.Convert.ToGuid( "1A" ) );
        }

        /// <summary>
        /// 转换为Guid
        /// </summary>
        [Fact]
        public void TestToGuid() {
            Assert.Equal( new Guid( "B9EB56E9-B720-40B4-9425-00483D311DDC" ), Util.Helpers.Convert.ToGuid( "B9EB56E9-B720-40B4-9425-00483D311DDC" ) );
        }

        /// <summary>
        /// 转换为可空Guid，验证
        /// </summary>
        /// <param name="input">输入值</param>
        /// <param name="result">结果</param>
        [Theory]
        [InlineData( null, null )]
        [InlineData( "", null )]
        [InlineData( "1A", null )]
        public void TestToGuidOrNull_Validate( object input, Guid? result ) {
            Assert.Equal( result, Util.Helpers.Convert.ToGuidOrNull( input ) );
        }

        /// <summary>
        /// 转换为可空Guid
        /// </summary>
        [Fact]
        public void TestToGuidOrNull() {
            Assert.Equal( new Guid( "B9EB56E9-B720-40B4-9425-00483D311DDC" ), Util.Helpers.Convert.ToGuidOrNull( "B9EB56E9-B720-40B4-9425-00483D311DDC" ) );
        }

        /// <summary>
        /// 转换为Guid集合
        /// </summary>
        [Fact]
        public void TestToGuidList() {
            Assert.Empty( Util.Helpers.Convert.ToGuidList( null ) );
            Assert.Empty( Util.Helpers.Convert.ToGuidList( "" ) );

            const string guid = "83B0233C-A24F-49FD-8083-1337209EBC9A";
            Assert.Single( Util.Helpers.Convert.ToGuidList( guid ) );
            Assert.Equal( new Guid( guid ), Util.Helpers.Convert.ToGuidList( guid )[0] );

            const string guid2 = "83B0233C-A24F-49FD-8083-1337209EBC9A,EAB523C6-2FE7-47BE-89D5-C6D440C3033A";
            Assert.Equal( 2, Util.Helpers.Convert.ToGuidList( guid2 ).Count );
            Assert.Equal( new Guid( "83B0233C-A24F-49FD-8083-1337209EBC9A" ), Util.Helpers.Convert.ToGuidList( guid2 )[0] );
            Assert.Equal( new Guid( "EAB523C6-2FE7-47BE-89D5-C6D440C3033A" ), Util.Helpers.Convert.ToGuidList( guid2 )[1] );
        }

        /// <summary>
        /// 转换为Guid集合
        /// </summary>
        [Fact]
        public void TestToGuidList_2() {
            const string guid = "83B0233C-A24F-49FD-8083-1337209EBC9A,,EAB523C6-2FE7-47BE-89D5-C6D440C3033A,";
            Assert.Equal( 2, Util.Helpers.Convert.ToGuidList( guid ).Count );
            Assert.Equal( new Guid( "83B0233C-A24F-49FD-8083-1337209EBC9A" ), Util.Helpers.Convert.ToGuidList( guid )[0] );
            Assert.Equal( new Guid( "EAB523C6-2FE7-47BE-89D5-C6D440C3033A" ), Util.Helpers.Convert.ToGuidList( guid )[1] );
        }

        /// <summary>
        /// 泛型集合转换
        /// </summary>
        [Fact]
        public void TestToList() {
            Assert.Empty( Util.Helpers.Convert.ToList<string>( null ) );
            Assert.Single( Util.Helpers.Convert.ToList<string>( "1" ) );
            Assert.Equal( 2, Util.Helpers.Convert.ToList<string>( "1,2" ).Count );
            Assert.Equal( 2, Util.Helpers.Convert.ToList<int>( "1,2" )[1] );
        }

        /// <summary>
        /// 通用泛型转换
        /// </summary>
        [Fact]
        public void TestTo() {
            Assert.Null( Util.Helpers.Convert.To<string>( "" ) );
            Assert.Equal( "1A", Util.Helpers.Convert.To<string>( "1A" ) );
            Assert.Equal( 0, Util.Helpers.Convert.To<int>( null ) );
            Assert.Equal( 0, Util.Helpers.Convert.To<int>( "" ) );
            Assert.Equal( 0, Util.Helpers.Convert.To<int>( "2A" ) );
            Assert.Equal( 1, Util.Helpers.Convert.To<int>( "1" ) );
            Assert.Null( Util.Helpers.Convert.To<int?>( null ) );
            Assert.Null( Util.Helpers.Convert.To<int?>( "" ) );
            Assert.Null( Util.Helpers.Convert.To<int?>( "3A" ) );
            Assert.Equal( Guid.Empty, Util.Helpers.Convert.To<Guid>( "" ) );
            Assert.Equal( Guid.Empty, Util.Helpers.Convert.To<Guid>( "4A" ) );
            Assert.Equal( new Guid( "B9EB56E9-B720-40B4-9425-00483D311DDC" ), Util.Helpers.Convert.To<Guid>( "B9EB56E9-B720-40B4-9425-00483D311DDC" ) );
            Assert.Equal( new Guid( "B9EB56E9-B720-40B4-9425-00483D311DDC" ), Util.Helpers.Convert.To<Guid?>( "B9EB56E9-B720-40B4-9425-00483D311DDC" ) );
            Assert.Equal( 12.5, Util.Helpers.Convert.To<double>( "12.5" ) );
            Assert.Equal( 12.5, Util.Helpers.Convert.To<double?>( "12.5" ) );
            Assert.Equal( 12.5M, Util.Helpers.Convert.To<decimal>( "12.5" ) );
            Assert.True( Util.Helpers.Convert.To<bool>( "true" ) );
            Assert.Equal( new DateTime( 2000, 1, 1 ), Util.Helpers.Convert.To<DateTime>( "2000-1-1" ) );
            Assert.Equal( new DateTime( 2000, 1, 1 ), Util.Helpers.Convert.To<DateTime?>( "2000-1-1" ) );
            var guid = Guid.NewGuid();
            Assert.Equal( guid.ToString(), Util.Helpers.Convert.To<string>( guid ) );
            Assert.Equal( EnumSample.C, Util.Helpers.Convert.To<EnumSample>( "c" ) );
        }

        /// <summary>
        /// 测试转换对象副本
        /// </summary>
        [Fact]
        public void TestTo_2() {
            Sample4 sample = new Sample4 { StringValue = "a" };
            var result = Util.Helpers.Convert.To<Sample4>( sample.GetClone() );
            Assert.Equal( "a", result?.StringValue );
        }
    }
}