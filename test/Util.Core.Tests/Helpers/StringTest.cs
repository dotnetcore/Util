using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Util.Tests.Helpers {
    /// <summary>
    /// 测试字符串操作 - 工具库
    /// </summary>
    public class StringTest {
        /// <summary>
        /// 测试将集合连接为带分隔符的字符串
        /// </summary>
        [Fact]
        public void TestJoin() {
            Assert.Equal( "1,2,3", Util.Helpers.String.Join( new List<int> { 1, 2, 3 } ) );
            Assert.Equal( "'1','2','3'", Util.Helpers.String.Join( new List<int> { 1, 2, 3 }, "'" ) );
            Assert.Equal( "123", Util.Helpers.String.Join( new List<int> { 1, 2, 3 }, "", "" ) );
            Assert.Equal( "\"1\",\"2\",\"3\"", Util.Helpers.String.Join( new List<int> { 1, 2, 3 }, "\"" ) );
            Assert.Equal( "1 2 3", Util.Helpers.String.Join( new List<int> { 1, 2, 3 }, "", " " ) );
            Assert.Equal( "1;2;3", Util.Helpers.String.Join( new List<int> { 1, 2, 3 }, "", ";" ) );
            Assert.Equal( "1,2,3", Util.Helpers.String.Join( new List<string> { "1", "2", "3" } ) );
            Assert.Equal( "'1','2','3'", Util.Helpers.String.Join( new List<string> { "1", "2", "3" }, "'" ) );

            var list = new List<Guid> {
                new( "83B0233C-A24F-49FD-8083-1337209EBC9A" ),
                new( "EAB523C6-2FE7-47BE-89D5-C6D440C3033A" )
            };
            Assert.Equal( "83B0233C-A24F-49FD-8083-1337209EBC9A,EAB523C6-2FE7-47BE-89D5-C6D440C3033A".ToLower(), Util.Helpers.String.Join( list ) );
            Assert.Equal( "'83B0233C-A24F-49FD-8083-1337209EBC9A','EAB523C6-2FE7-47BE-89D5-C6D440C3033A'".ToLower(), Util.Helpers.String.Join( list, "'" ) );
        }

        /// <summary>
        /// 首字母小写
        /// </summary>
        [Theory]
        [InlineData( null, "" )]
        [InlineData( "", "" )]
        [InlineData( " ", "" )]
        [InlineData( "a", "a" )]
        [InlineData( "A", "a" )]
        [InlineData( "Ab", "ab" )]
        [InlineData( "AB", "aB" )]
        [InlineData( "Abc", "abc" )]
        public void TestFirstLowerCase( string value, string result ) {
            Assert.Equal( result, Util.Helpers.String.FirstLowerCase( value ) );
        }

        /// <summary>
        /// 首字母大写
        /// </summary>
        [Theory]
        [InlineData( null, "" )]
        [InlineData( "", "" )]
        [InlineData( " ", "" )]
        [InlineData( "a", "A" )]
        [InlineData( "A", "A" )]
        [InlineData( "Ab", "Ab" )]
        [InlineData( "aB", "AB" )]
        [InlineData( "abc", "Abc" )]
        public void TestFirstUpperCase( string value, string result ) {
            Assert.Equal( result, Util.Helpers.String.FirstUpperCase( value ) );
        }

        /// <summary>
        /// 测试移除起始字符串
        /// </summary>
        [Theory]
        [InlineData( null, null, "" )]
        [InlineData( null, "a", "" )]
        [InlineData( "", "", "" )]
        [InlineData( "a", "b", "a" )]
        [InlineData( "ab", "b", "ab" )]
        [InlineData( "ab", "a", "b" )]
        [InlineData( "abc", "ab", "c" )]
        [InlineData( "abc", "Ab", "abc" )]
        [InlineData( "abc", "abc", "" )]
        [InlineData( "ab", "abc", "ab" )]
        [InlineData( "a.cs.cshtml", "a.cs", ".cshtml" )]
        [InlineData( "\r\na", "\r\n", "a" )]
        public void TestRemoveStart( string value, string removeValue, string result ) {
            Assert.Equal( result, Util.Helpers.String.RemoveStart( value, removeValue ) );
        }

        /// <summary>
        /// 测试移除末尾字符串
        /// </summary>
        [Theory]
        [InlineData( null, null,"" )]
        [InlineData( null, "a", "" )]
        [InlineData( "", "","" )]
        [InlineData( "a", "b", "a" )]
        [InlineData( "ab", "a", "ab" )]
        [InlineData( "ab", "b", "a" )]
        [InlineData( "abc", "abc", "" )]
        [InlineData( "bc", "abc", "bc" )]
        [InlineData( "ab", "abc", "ab" )]
        [InlineData( "a.cs.cshtml", ".cshtml", "a.cs" )]
        [InlineData( "a\r\n", "\r\n", "a" )]
        public void TestRemoveEnd( string value,string removeValue,string result ) {
            Assert.Equal( result, Util.Helpers.String.RemoveEnd( value, removeValue ) );
        }

        /// <summary>
        /// 测试移除起始字符串
        /// </summary>
        [Theory]
        [InlineData( null, null, null )]
        [InlineData( null, "a", null )]
        public void TestRemoveStart_StringBuilder( StringBuilder value, string removeValue, string result ) {
            Assert.Equal( result, Util.Helpers.String.RemoveStart( value, removeValue )?.ToString() );
        }

        /// <summary>
        /// 测试移除起始字符串
        /// </summary>
        [Theory]
        [InlineData( null, null, null )]
        [InlineData( null, "a", null )]
        [InlineData( "", "", null )]
        [InlineData( "a", "b", "a" )]
        [InlineData( "ab", "b", "ab" )]
        [InlineData( "ab", "a", "b" )]
        [InlineData( "abc", "ab", "c" )]
        [InlineData( "abc", "Ab", "abc" )]
        [InlineData( "abc", "abc", "" )]
        [InlineData( "ab", "abc", "ab" )]
        [InlineData( "a.cs.cshtml", "a.cs", ".cshtml" )]
        [InlineData( "\r\na", "\r\n", "a" )]
        public void TestRemoveStart_StringBuilder_2( string value, string removeValue, string result ) {
            var builder = new StringBuilder( value );
            Assert.Equal( result, Util.Helpers.String.RemoveStart( builder, removeValue )?.ToString() );
        }

        /// <summary>
        /// 测试移除末尾字符串
        /// </summary>
        [Theory]
        [InlineData( null, null, null )]
        [InlineData( null, "a", null )]
        public void TestRemoveEnd_StringBuilder( StringBuilder value, string removeValue, string result ) {
            Assert.Equal( result, Util.Helpers.String.RemoveEnd( value, removeValue )?.ToString() );
        }

        /// <summary>
        /// 测试移除末尾字符串
        /// </summary>
        [Theory]
        [InlineData( null, null, null )]
        [InlineData( null, "a", null )]
        [InlineData( "", "", null )]
        [InlineData( "a", "b", "a" )]
        [InlineData( "ab", "a", "ab" )]
        [InlineData( "ab", "b", "a" )]
        [InlineData( "abc", "abc", "" )]
        [InlineData( "bc", "abc", "bc" )]
        [InlineData( "ab", "abc", "ab" )]
        [InlineData( "a.cs.cshtml", ".cshtml", "a.cs" )]
        [InlineData( "a\r\n", "\r\n", "a" )]
        public void TestRemoveEnd_StringBuilder_2( string value, string removeValue, string result ) {
            var builder = new StringBuilder( value );
            Assert.Equal( result, Util.Helpers.String.RemoveEnd( builder, removeValue )?.ToString() );
        }

        /// <summary>
        /// 测试获取拼音简码
        /// </summary>
        [Theory]
        [InlineData( null, "" )]
        [InlineData( "", "" )]
        [InlineData( "中国", "zg" )]
        [InlineData( "a1宝藏b2", "a1bcb2" )]
        [InlineData( "饕餮", "tt" )]
        [InlineData( "爩", "y" )]
        public void TestPinYin( string input, string result ) {
            Assert.Equal( result, Util.Helpers.String.PinYin( input ) );
        }
    }
}
