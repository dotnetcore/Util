using System;
using Xunit;
using String = Util.Helpers.String;

namespace Util.Tests.Helpers {
    /// <summary>
    /// 测试字符串生成器
    /// </summary>
    public partial class StringTest {
        /// <summary>
        /// 测试初始化
        /// </summary>
        public StringTest() {
            Builder = new String();
        }

        /// <summary>
        /// 字符串
        /// </summary>
        private String Builder { get; }

        /// <summary>
        /// 测试默认输出
        /// </summary>
        [Fact]
        public void TestDefault() {
            Assert.Equal( string.Empty, Builder.ToString() );
        }

        /// <summary>
        /// 测试添加
        /// </summary>
        [Theory]
        [InlineData( "a", "a" )]
        [InlineData( 1, "1" )]
        public void TestAppend( object value, string result ) {
            Builder.Append( value );
            Assert.Equal( result, Builder.ToString() );
        }

        /// <summary>
        /// 测试添加 - 2个值
        /// </summary>
        [Theory]
        [InlineData( "a", 1, "a1" )]
        [InlineData( "{", "}", "{}" )]
        public void TestAppend_2Value(object value,object value2,string result) {
            Builder.Append( value );
            Builder.Append( value2 );
            Assert.Equal( result, Builder.ToString() );
        }

        /// <summary>
        /// 测试添加 - 带一个参数
        /// </summary>
        [Theory]
        [InlineData( "a{0}b", 1, "a1b" )]
        [InlineData( "a{0}b", null, "ab" )]
        public void TestAppend_1Arg( string value,object arg,string result ) {
            Builder.Append( value, arg );
            Assert.Equal( result, Builder.ToString() );
        }

        /// <summary>
        /// 测试添加 - 带2个参数
        /// </summary>
        [Theory]
        [InlineData( "a{0}b{1}", 1, 5.5, "a1b5.5" )]
        [InlineData( "a{0}b{1}", null, null, "ab" )]
        public void TestAdd_2Arg( string value, object arg, object arg2, string result ) {
            Builder.Append( value, arg, arg2 );
            Assert.Equal( result, Builder.ToString() );
        }

        /// <summary>
        /// 测试换行
        /// </summary>
        [Fact]
        public void TestAddLine() {
            Builder.AppendLine();
            Assert.Equal(Environment.NewLine , Builder.ToString() );
        }

        /// <summary>
        /// 测试换行,添加内容
        /// </summary>
        [Fact]
        public void TestAddLine_Value() {
            Builder.AppendLine( 1 );
            Builder.Append( "b" );
            Assert.Equal( string.Format( "1{0}b", Environment.NewLine ) , Builder.ToString() );
        }

        /// <summary>
        /// 测试换行,带参数
        /// </summary>
        [Fact]
        public void TestAddLine_Params() {
            Builder.AppendLine( "a{0}", 1 );
            Builder.Append( "b" );
            Assert.Equal( string.Format( "a1{0}b", Environment.NewLine ), Builder.ToString() );
        }

        /// <summary>
        /// 测试清空字符串
        /// </summary>
        [Fact]
        public void TestClear() {
            Builder.Append( "a" );
            Builder.Clear();
            Assert.Equal( "", Builder.ToString() );
        }

        /// <summary>
        /// 测试移除末尾的字符串
        /// </summary>
        [Theory]
        [InlineData( "a,",",","a")]
        [InlineData( "ab", "a", "ab" )]
        [InlineData( "abc", "bc", "a" )]
        public void TestRemoveEnd( string append,string remove,string result ) {
            Builder.Append( append );
            Builder.RemoveEnd( remove );
            Assert.Equal( result, Builder.ToString() );
        }
    }
}
